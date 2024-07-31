namespace DevControl.App.Windows
{
    partial class WindowAjudaAtualizacao
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
            labelMessage = new Label();
            labelVersion = new Label();
            pictureBox1 = new PictureBox();
            btnUpdate = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(199, 30);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(155, 15);
            labelMessage.TabIndex = 1;
            labelMessage.Text = "Você possui a última versão.";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(199, 12);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(47, 15);
            labelVersion.TabIndex = 3;
            labelVersion.Text = "Versão: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_150px;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(199, 76);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 30);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Atualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(199, 109);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 6;
            label1.Text = "Link para nova versão";
            label1.Click += label1_Click;
            // 
            // WindowAjudaAtualizacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(495, 135);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(pictureBox1);
            Controls.Add(labelVersion);
            Controls.Add(labelMessage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "WindowAjudaAtualizacao";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atualização";
            FormClosing += WindowAjudaAtualizacao_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelMessage;
        private Label labelVersion;
        private PictureBox pictureBox1;
        private Button btnUpdate;
        private Label label1;
    }
}