namespace DevControl.App.Windows
{
    partial class WindowMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMain));
            menuGlobal = new MenuStrip();
            menuItemArquivos = new ToolStripMenuItem();
            menuItemArquivoConfiguracoes = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuItemArquivoSair = new ToolStripMenuItem();
            menuItemMonitor = new ToolStripMenuItem();
            menuItemProjetos = new ToolStripMenuItem();
            menuItemFerramentas = new ToolStripMenuItem();
            menuItemAjuda = new ToolStripMenuItem();
            menuItemAjudaOpen = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuItemAjudaAtualizacao = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            menuItemAjudaSobre = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            labelUseMemory = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuGlobal.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuGlobal
            // 
            menuGlobal.Items.AddRange(new ToolStripItem[] { menuItemArquivos, menuItemMonitor, menuItemProjetos, menuItemFerramentas, menuItemAjuda });
            menuGlobal.Location = new Point(0, 0);
            menuGlobal.Name = "menuGlobal";
            menuGlobal.RenderMode = ToolStripRenderMode.System;
            menuGlobal.Size = new Size(1064, 24);
            menuGlobal.TabIndex = 18;
            // 
            // menuItemArquivos
            // 
            menuItemArquivos.DropDownItems.AddRange(new ToolStripItem[] { menuItemArquivoConfiguracoes, toolStripSeparator1, menuItemArquivoSair });
            menuItemArquivos.Name = "menuItemArquivos";
            menuItemArquivos.ShortcutKeys = Keys.Control | Keys.Q;
            menuItemArquivos.Size = new Size(61, 20);
            menuItemArquivos.Text = "A&rquivo";
            // 
            // menuItemArquivoConfiguracoes
            // 
            menuItemArquivoConfiguracoes.Name = "menuItemArquivoConfiguracoes";
            menuItemArquivoConfiguracoes.Size = new Size(151, 22);
            menuItemArquivoConfiguracoes.Text = "Configurações";
            menuItemArquivoConfiguracoes.Click += menuItemArquivoConfiguracoes_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(148, 6);
            // 
            // menuItemArquivoSair
            // 
            menuItemArquivoSair.Name = "menuItemArquivoSair";
            menuItemArquivoSair.ShortcutKeys = Keys.Control | Keys.Q;
            menuItemArquivoSair.Size = new Size(151, 22);
            menuItemArquivoSair.Text = "Sair";
            menuItemArquivoSair.Click += menuItemArquivoSair_Click;
            // 
            // menuItemMonitor
            // 
            menuItemMonitor.Name = "menuItemMonitor";
            menuItemMonitor.Size = new Size(62, 20);
            menuItemMonitor.Tag = "WindowMonitor";
            menuItemMonitor.Text = "&Monitor";
            menuItemMonitor.Click += menuItem_Click;
            // 
            // menuItemProjetos
            // 
            menuItemProjetos.Name = "menuItemProjetos";
            menuItemProjetos.Size = new Size(62, 20);
            menuItemProjetos.Tag = "WindowProjeto";
            menuItemProjetos.Text = "&Projetos";
            menuItemProjetos.Click += menuItem_Click;
            // 
            // menuItemFerramentas
            // 
            menuItemFerramentas.Name = "menuItemFerramentas";
            menuItemFerramentas.Size = new Size(84, 20);
            menuItemFerramentas.Tag = "WindowFerramenta";
            menuItemFerramentas.Text = "&Ferramentas";
            menuItemFerramentas.Click += menuItem_Click;
            // 
            // menuItemAjuda
            // 
            menuItemAjuda.DropDownItems.AddRange(new ToolStripItem[] { menuItemAjudaOpen, toolStripSeparator2, menuItemAjudaAtualizacao, toolStripSeparator3, menuItemAjudaSobre });
            menuItemAjuda.Name = "menuItemAjuda";
            menuItemAjuda.ShortcutKeys = Keys.F1;
            menuItemAjuda.Size = new Size(50, 20);
            menuItemAjuda.Text = "&Ajuda";
            // 
            // menuItemAjudaOpen
            // 
            menuItemAjudaOpen.Name = "menuItemAjudaOpen";
            menuItemAjudaOpen.ShortcutKeys = Keys.F1;
            menuItemAjudaOpen.Size = new Size(186, 22);
            menuItemAjudaOpen.Text = "Ajuda";
            menuItemAjudaOpen.Click += menuItemAjudaOpen_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(183, 6);
            // 
            // menuItemAjudaAtualizacao
            // 
            menuItemAjudaAtualizacao.Name = "menuItemAjudaAtualizacao";
            menuItemAjudaAtualizacao.Size = new Size(186, 22);
            menuItemAjudaAtualizacao.Text = "Verificar atualização";
            menuItemAjudaAtualizacao.Click += menuItemAjudaAtualizacao_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(183, 6);
            // 
            // menuItemAjudaSobre
            // 
            menuItemAjudaSobre.Name = "menuItemAjudaSobre";
            menuItemAjudaSobre.Size = new Size(186, 22);
            menuItemAjudaSobre.Text = "Sobre o DevControl...";
            menuItemAjudaSobre.Click += menuItemAjudaSobre_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.GripMargin = new Padding(4);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelUseMemory });
            statusStrip1.Location = new Point(0, 859);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1064, 22);
            statusStrip1.TabIndex = 20;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelUseMemory
            // 
            labelUseMemory.Name = "labelUseMemory";
            labelUseMemory.Size = new Size(55, 17);
            labelUseMemory.Text = "Memória";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // WindowMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 881);
            Controls.Add(statusStrip1);
            Controls.Add(menuGlobal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuGlobal;
            MaximizeBox = false;
            Name = "WindowMain";
            Text = AppConfig.AppName;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ServicePanel_FormClosing;
            menuGlobal.ResumeLayout(false);
            menuGlobal.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuGlobal;

        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;

        private ToolStripMenuItem menuItemArquivos;
        private ToolStripMenuItem menuItemArquivoSair;
        private ToolStripMenuItem menuItemArquivoConfiguracoes;

        private ToolStripMenuItem menuItemMonitor;

        private ToolStripMenuItem menuItemAjuda;
        private ToolStripMenuItem menuItemAjudaSobre;
        private ToolStripMenuItem menuItemAjudaOpen;
        private ToolStripMenuItem menuItemAjudaAtualizacao;
        private ToolStripMenuItem menuItemFerramentas;
        private ToolStripMenuItem menuItemProjetos;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelUseMemory;
        private System.Windows.Forms.Timer timer1;
    }
}
