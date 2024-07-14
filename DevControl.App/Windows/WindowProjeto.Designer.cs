namespace DevControl.App.Windows
{
    partial class WindowProjeto
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
            panelProjects = new Panel();
            btnNovoProjeto = new Button();
            SuspendLayout();
            // 
            // panelProjects
            // 
            panelProjects.AutoScroll = true;
            panelProjects.BackColor = SystemColors.ControlLightLight;
            panelProjects.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelProjects.ForeColor = SystemColors.ControlDarkDark;
            panelProjects.Location = new Point(12, 49);
            panelProjects.Name = "panelProjects";
            panelProjects.Size = new Size(1040, 781);
            panelProjects.TabIndex = 0;
            // 
            // btnNovoProjeto
            // 
            btnNovoProjeto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnNovoProjeto.Location = new Point(12, 12);
            btnNovoProjeto.Name = "btnNovoProjeto";
            btnNovoProjeto.Size = new Size(120, 31);
            btnNovoProjeto.TabIndex = 1;
            btnNovoProjeto.Text = "Novo Projeto";
            btnNovoProjeto.UseVisualStyleBackColor = true;
            btnNovoProjeto.Click += (s, e) => BtnFormularioProjeto_Click();
            // 
            // WindowProjeto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1064, 842);
            ControlBox = false;
            Controls.Add(panelProjects);
            Controls.Add(btnNovoProjeto);
            Name = "WindowProjeto";
            Text = "Projetos";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelProjects;
        private Button btnNovoProjeto;
    }
}