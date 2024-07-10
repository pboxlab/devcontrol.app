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
            labelTitle = new Label();
            labelMessage = new Label();
            btnFechar = new Button();
            labelVersion = new Label();
            pictureBox1 = new PictureBox();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.ForestGreen;
            labelTitle.Location = new Point(131, 24);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(97, 21);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "DevControl";
            // 
            // labelMessage
            // 
            labelMessage.Location = new Point(134, 69);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(288, 34);
            labelMessage.TabIndex = 1;
            labelMessage.Text = "Você possui a última versão.";
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(332, 106);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(90, 30);
            btnFechar.TabIndex = 2;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnSobreAtualizacaoFechar_Click;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(133, 49);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(47, 15);
            labelVersion.TabIndex = 3;
            labelVersion.Text = "Versão: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_150px;
            pictureBox1.Location = new Point(25, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(134, 106);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 30);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Atualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // WindowAjudaAtualizacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(434, 148);
            Controls.Add(btnUpdate);
            Controls.Add(pictureBox1);
            Controls.Add(labelVersion);
            Controls.Add(btnFechar);
            Controls.Add(labelMessage);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "WindowAjudaAtualizacao";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Programa Atualizado";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            FormClosing += WindowAjudaAtualizacao_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelMessage;
        private Button btnFechar;
        private Label labelVersion;
        private PictureBox pictureBox1;
        private Button btnUpdate;
    }
}