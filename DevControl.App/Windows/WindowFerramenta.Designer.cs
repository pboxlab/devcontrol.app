namespace DevControl.App.Windows
{
    partial class WindowFerramenta
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
            btnGerarGuid = new Button();
            grupoGuid = new GroupBox();
            listGuidGerados = new ListBox();
            label1 = new Label();
            numericQuantidadeGuid = new NumericUpDown();
            labelCopyAlert = new Label();
            groupBox1 = new GroupBox();
            textJson = new TextBox();
            btnFormatarJson = new Button();
            grupoGuid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantidadeGuid).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGerarGuid
            // 
            btnGerarGuid.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGerarGuid.Location = new Point(6, 18);
            btnGerarGuid.Name = "btnGerarGuid";
            btnGerarGuid.Size = new Size(100, 30);
            btnGerarGuid.TabIndex = 2;
            btnGerarGuid.Text = "Gerar GUID";
            btnGerarGuid.UseVisualStyleBackColor = true;
            btnGerarGuid.Click += btnGerarGuid_Click;
            // 
            // grupoGuid
            // 
            grupoGuid.Controls.Add(listGuidGerados);
            grupoGuid.Controls.Add(label1);
            grupoGuid.Controls.Add(numericQuantidadeGuid);
            grupoGuid.Controls.Add(btnGerarGuid);
            grupoGuid.Location = new Point(12, 41);
            grupoGuid.Name = "grupoGuid";
            grupoGuid.Size = new Size(1040, 142);
            grupoGuid.TabIndex = 3;
            grupoGuid.TabStop = false;
            grupoGuid.Text = "Gerar GUID";
            // 
            // listGuidGerados
            // 
            listGuidGerados.FormattingEnabled = true;
            listGuidGerados.ItemHeight = 15;
            listGuidGerados.Location = new Point(112, 18);
            listGuidGerados.Name = "listGuidGerados";
            listGuidGerados.SelectionMode = SelectionMode.MultiExtended;
            listGuidGerados.Size = new Size(920, 109);
            listGuidGerados.TabIndex = 5;
            listGuidGerados.MouseUp += listGuidGerados_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 82);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 4;
            label1.Text = "Quantidade";
            // 
            // numericQuantidadeGuid
            // 
            numericQuantidadeGuid.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            numericQuantidadeGuid.Location = new Point(8, 100);
            numericQuantidadeGuid.Name = "numericQuantidadeGuid";
            numericQuantidadeGuid.Size = new Size(98, 27);
            numericQuantidadeGuid.TabIndex = 3;
            numericQuantidadeGuid.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelCopyAlert
            // 
            labelCopyAlert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCopyAlert.BackColor = Color.PaleGreen;
            labelCopyAlert.BorderStyle = BorderStyle.FixedSingle;
            labelCopyAlert.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCopyAlert.ForeColor = SystemColors.ControlDarkDark;
            labelCopyAlert.Location = new Point(952, 9);
            labelCopyAlert.Name = "labelCopyAlert";
            labelCopyAlert.Size = new Size(100, 17);
            labelCopyAlert.TabIndex = 4;
            labelCopyAlert.Text = "Log copiado";
            labelCopyAlert.TextAlign = ContentAlignment.MiddleCenter;
            labelCopyAlert.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textJson);
            groupBox1.Controls.Add(btnFormatarJson);
            groupBox1.Location = new Point(12, 205);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1040, 625);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formatador de JSON";
            // 
            // textJson
            // 
            textJson.BorderStyle = BorderStyle.FixedSingle;
            textJson.Location = new Point(8, 58);
            textJson.Multiline = true;
            textJson.Name = "textJson";
            textJson.ScrollBars = ScrollBars.Vertical;
            textJson.Size = new Size(1024, 561);
            textJson.TabIndex = 1;
            // 
            // btnFormatarJson
            // 
            btnFormatarJson.Location = new Point(8, 22);
            btnFormatarJson.Name = "btnFormatarJson";
            btnFormatarJson.Size = new Size(100, 30);
            btnFormatarJson.TabIndex = 0;
            btnFormatarJson.Text = "Formatar";
            btnFormatarJson.UseVisualStyleBackColor = true;
            btnFormatarJson.Click += btnFormatarJson_Click;
            // 
            // WindowFerramenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 842);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(labelCopyAlert);
            Controls.Add(grupoGuid);
            Name = "WindowFerramenta";
            Text = "Ferramentas";
            WindowState = FormWindowState.Maximized;
            grupoGuid.ResumeLayout(false);
            grupoGuid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantidadeGuid).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGerarGuid;
        private GroupBox grupoGuid;
        private NumericUpDown numericQuantidadeGuid;
        private Label label1;
        private ListBox listGuidGerados;
        private Label labelCopyAlert;
        private GroupBox groupBox1;
        private Button btnFormatarJson;
        private TextBox textJson;
    }
}