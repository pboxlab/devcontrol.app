namespace DevControl.App.Windows
{
    partial class WindowAjudaSobre
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
            pictureBox1 = new PictureBox();
            labelNameProgram = new Label();
            label2 = new Label();
            labelProgramVersion = new Label();
            labelProgramLink = new Label();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.qrcode_contribuicao;
            pictureBox1.Location = new Point(125, 223);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelNameProgram
            // 
            labelNameProgram.AutoSize = true;
            labelNameProgram.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelNameProgram.ImageAlign = ContentAlignment.TopLeft;
            labelNameProgram.Location = new Point(208, 79);
            labelNameProgram.Name = "labelNameProgram";
            labelNameProgram.Size = new Size(107, 25);
            labelNameProgram.TabIndex = 1;
            labelNameProgram.Text = "DevControl";
            labelNameProgram.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(110, 199);
            label2.Name = "label2";
            label2.Size = new Size(180, 21);
            label2.TabIndex = 2;
            label2.Text = "Contribua com o projeto";
            // 
            // labelProgramVersion
            // 
            labelProgramVersion.AutoSize = true;
            labelProgramVersion.Location = new Point(211, 109);
            labelProgramVersion.Name = "labelProgramVersion";
            labelProgramVersion.Size = new Size(44, 15);
            labelProgramVersion.TabIndex = 3;
            labelProgramVersion.Text = "Versão:";
            // 
            // labelProgramLink
            // 
            labelProgramLink.AutoSize = true;
            labelProgramLink.Cursor = Cursors.Hand;
            labelProgramLink.ForeColor = SystemColors.Highlight;
            labelProgramLink.Location = new Point(211, 128);
            labelProgramLink.Name = "labelProgramLink";
            labelProgramLink.Size = new Size(127, 15);
            labelProgramLink.TabIndex = 4;
            labelProgramLink.Text = "https://devcontrol.app";
            labelProgramLink.Click += labelLinkProjeto_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_150px;
            pictureBox2.Location = new Point(95, 79);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 376);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 6;
            label1.Text = "QRCode PIX";
            // 
            // WindowAjudaSobre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(400, 400);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(labelProgramLink);
            Controls.Add(labelProgramVersion);
            Controls.Add(label2);
            Controls.Add(labelNameProgram);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "WindowAjudaSobre";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sobre DevControl";
            TopMost = true;
            Click += WindowAjudaSobre_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelNameProgram;
        private Label label2;
        private Label labelProgramVersion;
        private Label labelProgramLink;
        private PictureBox pictureBox2;
        private Label label1;
    }
}