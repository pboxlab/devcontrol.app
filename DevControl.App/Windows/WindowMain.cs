using DevControl.App.Services;
using System.Diagnostics;
using System.Windows.Forms;

namespace DevControl.App.Windows
{
    public partial class WindowMain : Form
    {
        private NotifyIcon _notifyIcon = new();
        private ComputerResourcesService _recurcesService = new();

        public WindowMain()
        {
            InitializeComponent();
            InitializeWindowDefault();
            SetNotifyIcon();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetStatus();
        }

        private async void InitializeWindowDefault()
        {
            WindowAjudaAtualizacao _formUpdate = new(true);
            var update = await _formUpdate.HaveNewerVersion();

            if (update)
            {
                var result = MessageBox.Show($"Há uma atualização disponível para o {AppConfig.AppName}.\nDeseja atualizar agora?", "Atualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    var formAjudaAtualizacao = new WindowAjudaAtualizacao();
                    formAjudaAtualizacao.ShowDialog();
                }
            }

            if (!AppConfig.ProgramConfigured && string.IsNullOrEmpty(AppConfig.PathDatabase))
            {
                WindowConfiguracao windowConfiguracao = new();
                windowConfiguracao.ShowDialog();
            }

            if (!string.IsNullOrEmpty(AppConfig.PathDatabase) && !File.Exists(AppConfig.PathDatabase))
            {
                var result = MessageBox.Show($"Não encontramos uma configuração válida para o banco de dados.", "Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    WindowConfiguracao windowConfiguracao = new();
                    windowConfiguracao.ShowDialog();
                }
            }

            OpenForm(new WindowMonitor());
        }

        private void SetStatus()
        {
            _recurcesService.GetComputerResources();
            labelUseMemory.Text = $"Memória: {_recurcesService.Memory}";
        }

        private void SetNotifyIcon()
        {
            ContextMenuStrip menuStrip = new();

            ToolStripMenuItem menuFerramentas = new("Ferramentas");
            ToolStripMenuItem menuoConfiguracoes = new("Configurações");
            ToolStripMenuItem menuAtualizacao = new("Verificar Atualização");
            ToolStripMenuItem menuAjuda = new("Ajuda");
            ToolStripMenuItem menuSair = new("Sair");

            menuFerramentas.Tag = "WindowFerramenta";

            menuSair.Click += menuItemArquivoSair_Click;
            menuAjuda.Click += menuItemAjudaOpen_Click;
            menuFerramentas.Click += menuItem_Click;
            menuAtualizacao.Click += menuItemAjudaAtualizacao_Click;
            menuoConfiguracoes.Click += menuItemArquivoConfiguracoes_Click;

            menuStrip.Items.Add(menuFerramentas);
            menuStrip.Items.Add(menuoConfiguracoes);
            menuStrip.Items.Add(menuAtualizacao);
            menuStrip.Items.Add(menuAjuda);
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(menuSair);

            _notifyIcon.Text = AppConfig.AppName;
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenuStrip = menuStrip;
            _notifyIcon.Icon = Properties.Resources.favicon2;
            _notifyIcon.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
            };
        }

        private void ServicePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppConfig.HideProgramClosing)
            {
                e.Cancel = true;
                Hide();
                _notifyIcon.Visible = true;
            }
        }

        private void OpenForm(Form form)
        {
            if (form.MdiParent == null)
            {
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                form.BringToFront();
            }

            Show();
            WindowState = FormWindowState.Normal;
        }

        private void OpenFormParent(object sender)
        {
            ToolStripMenuItem button = (sender as ToolStripMenuItem)!;

            var className = (button.Tag ?? "").ToString();

            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show($"Tag para o objeto {button.Name} não foi especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Type formType = Type.GetType("DevControl.App.Windows." + className)!;

            if (formType == null)
            {
                MessageBox.Show($"O menu {className} não foi implementado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form form = this.MdiChildren.FirstOrDefault(f => f.GetType() == formType)!;

            if (form == null)
            {
                form = (Form)Activator.CreateInstance(formType)!;
            }

            OpenForm(form);
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            OpenFormParent(sender);
        }

        private void menuItemArquivoSair_Click(object sender, EventArgs e)
        {
            AppConfig.HideProgramClosing = false;
            Application.Exit();
        }

        private void menuItemArquivoConfiguracoes_Click(object sender, EventArgs e)
        {
            WindowConfiguracao windowConfiguracao = new();
            windowConfiguracao.ShowDialog();
        }

        private void menuItemAjudaOpen_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/pboxlab/devcontrol.app/wiki";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemAjudaSobre_Click(object sender, EventArgs e)
        {
            WindowAjudaSobre windowAjudaSobre = new();
            windowAjudaSobre.ShowDialog();
        }

        private void menuItemAjudaAtualizacao_Click(object sender, EventArgs e)
        {
            WindowAjudaAtualizacao windowAjudaAtualizacao = new();
            windowAjudaAtualizacao.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetStatus();
        }

    }
}
