namespace DevControl.App.Windows
{
    partial class ProgramCloneWindow
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
            btnBrowseProgramPath = new Button();
            labelProgramPath = new Label();
            textProgramPath = new TextBox();
            comboBoxProject = new ComboBox();
            labelProject = new Label();
            textProgramRepositoryUrl = new TextBox();
            labelProgramRepositoryUrl = new Label();
            btnSaveProgram = new Button();
            btnCancelProgram = new Button();
            SuspendLayout();
            // 
            // btnBrowseProgramPath
            // 
            btnBrowseProgramPath.Location = new Point(448, 28);
            btnBrowseProgramPath.Name = "btnBrowseProgramPath";
            btnBrowseProgramPath.Size = new Size(120, 31);
            btnBrowseProgramPath.TabIndex = 13;
            btnBrowseProgramPath.Text = "Procurar...";
            btnBrowseProgramPath.UseVisualStyleBackColor = true;
            btnBrowseProgramPath.Click += btnBrowseProgramPath_Click;
            // 
            // labelProgramPath
            // 
            labelProgramPath.AutoSize = true;
            labelProgramPath.Location = new Point(12, 10);
            labelProgramPath.Name = "labelProgramPath";
            labelProgramPath.Size = new Size(141, 15);
            labelProgramPath.TabIndex = 15;
            labelProgramPath.Text = "Diretório do código fonte";
            // 
            // textProgramPath
            // 
            textProgramPath.BorderStyle = BorderStyle.FixedSingle;
            textProgramPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramPath.Location = new Point(16, 30);
            textProgramPath.Name = "textProgramPath";
            textProgramPath.Size = new Size(426, 29);
            textProgramPath.TabIndex = 14;
            // 
            // comboBoxProject
            // 
            comboBoxProject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxProject.FormattingEnabled = true;
            comboBoxProject.Location = new Point(448, 87);
            comboBoxProject.Name = "comboBoxProject";
            comboBoxProject.Size = new Size(120, 29);
            comboBoxProject.TabIndex = 17;
            // 
            // labelProject
            // 
            labelProject.AutoSize = true;
            labelProject.Location = new Point(448, 67);
            labelProject.Name = "labelProject";
            labelProject.Size = new Size(45, 15);
            labelProject.TabIndex = 18;
            labelProject.Text = "Projeto";
            // 
            // textProgramRepositoryUrl
            // 
            textProgramRepositoryUrl.BorderStyle = BorderStyle.FixedSingle;
            textProgramRepositoryUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramRepositoryUrl.Location = new Point(16, 87);
            textProgramRepositoryUrl.Name = "textProgramRepositoryUrl";
            textProgramRepositoryUrl.Size = new Size(426, 29);
            textProgramRepositoryUrl.TabIndex = 19;
            // 
            // labelProgramRepositoryUrl
            // 
            labelProgramRepositoryUrl.AutoSize = true;
            labelProgramRepositoryUrl.Location = new Point(12, 67);
            labelProgramRepositoryUrl.Name = "labelProgramRepositoryUrl";
            labelProgramRepositoryUrl.Size = new Size(99, 15);
            labelProgramRepositoryUrl.TabIndex = 22;
            labelProgramRepositoryUrl.Text = "Repositório (URL)";
            // 
            // btnSaveProgram
            // 
            btnSaveProgram.Location = new Point(382, 138);
            btnSaveProgram.Name = "btnSaveProgram";
            btnSaveProgram.Size = new Size(90, 30);
            btnSaveProgram.TabIndex = 20;
            btnSaveProgram.Text = "Salvar";
            btnSaveProgram.UseVisualStyleBackColor = true;
            btnSaveProgram.Click += btnSaveProgram_Click;
            // 
            // btnCancelProgram
            // 
            btnCancelProgram.Location = new Point(478, 138);
            btnCancelProgram.Name = "btnCancelProgram";
            btnCancelProgram.Size = new Size(90, 30);
            btnCancelProgram.TabIndex = 21;
            btnCancelProgram.Text = "Cancelar";
            btnCancelProgram.UseVisualStyleBackColor = true;
            btnCancelProgram.Click += btnCancelProgram_Click;
            // 
            // ProgramCloneWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(584, 182);
            Controls.Add(textProgramRepositoryUrl);
            Controls.Add(labelProgramRepositoryUrl);
            Controls.Add(btnSaveProgram);
            Controls.Add(btnCancelProgram);
            Controls.Add(comboBoxProject);
            Controls.Add(labelProject);
            Controls.Add(btnBrowseProgramPath);
            Controls.Add(labelProgramPath);
            Controls.Add(textProgramPath);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ProgramCloneWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clone Programa";
            FormClosed += btnCancel_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBrowseProgramPath;
        private Label labelProgramPath;
        private TextBox textProgramPath;
        private ComboBox comboBoxProject;
        private Label labelProject;
        private TextBox textProgramRepositoryUrl;
        private Label labelProgramRepositoryUrl;
        private Button btnSaveProgram;
        private Button btnCancelProgram;
    }
}