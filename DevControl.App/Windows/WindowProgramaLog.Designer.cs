namespace DevControl.App.Windows
{
    partial class WindowProgramaLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxLog = new ListBox();
            labelCopyAlert = new Label();
            groupBox1 = new GroupBox();
            checkProcessoAtual = new CheckBox();
            btnLimparLog = new Button();
            btnReloadLogs = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxLog
            // 
            listBoxLog.Dock = DockStyle.Fill;
            listBoxLog.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxLog.FormattingEnabled = true;
            listBoxLog.ItemHeight = 17;
            listBoxLog.Location = new Point(3, 32);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(843, 426);
            listBoxLog.TabIndex = 0;
            listBoxLog.SelectionMode = SelectionMode.MultiExtended;
            listBoxLog.MouseUp += listBoxLog_MouseUp;
            // 
            // labelCopyAlert
            // 
            labelCopyAlert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCopyAlert.BackColor = Color.PaleGreen;
            labelCopyAlert.BorderStyle = BorderStyle.FixedSingle;
            labelCopyAlert.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCopyAlert.ForeColor = SystemColors.ControlDarkDark;
            labelCopyAlert.Location = new Point(743, 6);
            labelCopyAlert.Name = "labelCopyAlert";
            labelCopyAlert.Size = new Size(100, 17);
            labelCopyAlert.TabIndex = 1;
            labelCopyAlert.Text = "Log copiado";
            labelCopyAlert.TextAlign = ContentAlignment.MiddleCenter;
            labelCopyAlert.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(checkProcessoAtual);
            groupBox1.Controls.Add(btnLimparLog);
            groupBox1.Controls.Add(btnReloadLogs);
            groupBox1.Controls.Add(labelCopyAlert);
            groupBox1.Controls.Add(listBoxLog);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(849, 461);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // checkProcessoAtual
            // 
            checkProcessoAtual.AutoSize = true;
            checkProcessoAtual.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkProcessoAtual.Location = new Point(218, 6);
            checkProcessoAtual.Name = "checkProcessoAtual";
            checkProcessoAtual.Size = new Size(169, 19);
            checkProcessoAtual.TabIndex = 5;
            checkProcessoAtual.Text = "Somente do processo atual";
            checkProcessoAtual.UseVisualStyleBackColor = true;
            checkProcessoAtual.CheckedChanged += CheckProcessoAtual_CheckedChanged;
            // 
            // btnLimparLog
            // 
            btnLimparLog.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLimparLog.Location = new Point(112, 3);
            btnLimparLog.Name = "btnLimparLog";
            btnLimparLog.Size = new Size(100, 23);
            btnLimparLog.TabIndex = 4;
            btnLimparLog.Text = "Apagar Logs";
            btnLimparLog.UseVisualStyleBackColor = true;
            btnLimparLog.Click += BtnLimparLog_Click;
            // 
            // btnReloadLogs
            // 
            btnReloadLogs.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnReloadLogs.Location = new Point(6, 3);
            btnReloadLogs.Name = "btnReloadLogs";
            btnReloadLogs.Size = new Size(100, 23);
            btnReloadLogs.TabIndex = 3;
            btnReloadLogs.Text = "Recarregar";
            btnReloadLogs.UseVisualStyleBackColor = true;
            btnReloadLogs.Click += BtnReloadLogs_Click;
            // 
            // WindowProgramaLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 461);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "WindowProgramaLog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logs";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxLog;
        private Label labelCopyAlert;
        private GroupBox groupBox1;
        private Button btnReloadLogs;
        private Button btnLimparLog;
        private CheckBox checkProcessoAtual;
    }
}