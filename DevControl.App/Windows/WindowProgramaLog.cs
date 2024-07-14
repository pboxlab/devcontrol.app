using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Models;
using DevControl.App.Data.Repositories;
using Microsoft.VisualBasic.Logging;
using System.Diagnostics;

namespace DevControl.App.Windows
{
    public partial class WindowProgramaLog : Form
    {

        private Process _process = new();
        private readonly LogsProcessRepository _logsProcessRepository = new();
        private readonly ProgramEntity _programa;
        private bool _autoScroll = true;
        private LogsProcessModel _logsProcessModel = new();

        public WindowProgramaLog(ProgramEntity programa)
        {
            InitializeComponent();

            _programa = programa;
            Text = $"Logs: {_programa.Name}";

            //LoadLogs();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            checkProcessoAtual.Enabled = _programa.Process == null ? false : true;

            LoadLogs();
        }

        private async void LoadLogs()
        {
            _logsProcessModel.SoftwareId = _programa.Id;

            List<LogsProcessEntity> logs = new();

            try
            {
                logs = await _logsProcessRepository.LoadRecordsAsync(_logsProcessModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar carregar os logs do programa.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxLog.Items.Clear();

            foreach (var log in logs)
            {
                AddLog(ParseTextLog(log));
            }

            if (listBoxLog.Items.Count > 0)
            {
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
        }

        private string ParseTextLog(LogsProcessEntity log)
        {
            var text = $"{log.CreatedAt}  |  ";
            text += $"{log.PID.ToString().PadLeft(6, '0')}  |  ";
            text += $"{log.LogValue}";
            return text;
        }

        public void AddLog(string logText)
        {
            listBoxLog.Items.Add(logText);

            if (_autoScroll)
            {
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
        }

        private void listBoxLog_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBoxLog.SelectedItems.Count > 0)
                {
                    var selectedItems = string.Join(Environment.NewLine, listBoxLog.SelectedItems.Cast<string>());
                    Clipboard.SetText(selectedItems);
                    ShowCopyAlert("Log copiado");
                }
            }
        }

        private async void ShowCopyAlert(string text)
        {
            labelCopyAlert.Text = text;
            labelCopyAlert.Visible = true;
            await Task.Delay(1000);
            labelCopyAlert.Visible = false;
        }

        private void BtnReloadLogs_Click(object sender, EventArgs e)
        {
            LoadLogs();
            ShowCopyAlert("Log carregado");
        }

        private async void BtnLimparLog_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Tem certeza que deseja limpar os logs do programa {_programa.Name}?", "Limpar Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _logsProcessRepository.ExecuteQueryAsync(new() { SoftwareId = _programa.Id }, TypeQueryExecuteEnum.Delete);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao tentar apagar logs.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadLogs();
                ShowCopyAlert("Log carregado");
            }
        }

        private void CheckProcessoAtual_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _logsProcessModel.PID = checkProcessoAtual.Checked ? _programa.Process!.Id : null ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar o log.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadLogs();
        }
    }
}
