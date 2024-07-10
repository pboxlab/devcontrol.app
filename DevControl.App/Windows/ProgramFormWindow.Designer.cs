using DevControl.App.Common;

namespace DevControl.App.Windows
{
    partial class ProgramFormWindow
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
            labelProgramName = new Label();
            textProgramName = new TextBox();
            btnSaveProgram = new Button();
            btnCancelProgram = new Button();
            textProgramPath = new TextBox();
            textProgramPort = new TextBox();
            labelProgramPath = new Label();
            labelProgramPort = new Label();
            btnBrowseProgramPath = new Button();
            comboBoxProgramType = new ComboBox();
            labelProgramType = new Label();
            labelProgramProcessName = new Label();
            labelProject = new Label();
            comboBoxProject = new ComboBox();
            labelProgramRepositoryUrl = new Label();
            textProgramRepositoryUrl = new TextBox();
            labelProgramCommand = new Label();
            textProgramCommand = new TextBox();
            comboBoxProgramStart = new ComboBox();
            SuspendLayout();
            // 
            // labelProgramName
            // 
            labelProgramName.AutoSize = true;
            labelProgramName.Location = new Point(12, 67);
            labelProgramName.Name = "labelProgramName";
            labelProgramName.Size = new Size(40, 15);
            labelProgramName.TabIndex = 10;
            labelProgramName.Text = "Nome";
            // 
            // textProgramName
            // 
            textProgramName.BorderStyle = BorderStyle.FixedSingle;
            textProgramName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramName.Location = new Point(16, 87);
            textProgramName.Name = "textProgramName";
            textProgramName.Size = new Size(284, 29);
            textProgramName.TabIndex = 1;
            // 
            // btnSaveProgram
            // 
            btnSaveProgram.Location = new Point(382, 312);
            btnSaveProgram.Name = "btnSaveProgram";
            btnSaveProgram.Size = new Size(90, 30);
            btnSaveProgram.TabIndex = 9;
            btnSaveProgram.Text = "Salvar";
            btnSaveProgram.UseVisualStyleBackColor = true;
            btnSaveProgram.Click += btnSave_Click;
            // 
            // btnCancelProgram
            // 
            btnCancelProgram.Location = new Point(478, 312);
            btnCancelProgram.Name = "btnCancelProgram";
            btnCancelProgram.Size = new Size(90, 30);
            btnCancelProgram.TabIndex = 10;
            btnCancelProgram.Text = "Cancelar";
            btnCancelProgram.UseVisualStyleBackColor = true;
            btnCancelProgram.Click += btnCancel_Click;
            // 
            // textProgramPath
            // 
            textProgramPath.BorderStyle = BorderStyle.FixedSingle;
            textProgramPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramPath.Location = new Point(16, 30);
            textProgramPath.Name = "textProgramPath";
            textProgramPath.Size = new Size(426, 29);
            textProgramPath.TabIndex = 0;
            // 
            // textProgramPort
            // 
            textProgramPort.BorderStyle = BorderStyle.FixedSingle;
            textProgramPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramPort.Location = new Point(448, 144);
            textProgramPort.Name = "textProgramPort";
            textProgramPort.Size = new Size(120, 29);
            textProgramPort.TabIndex = 5;
            textProgramPort.TextAlign = HorizontalAlignment.Right;
            // 
            // labelProgramPath
            // 
            labelProgramPath.AutoSize = true;
            labelProgramPath.Location = new Point(12, 10);
            labelProgramPath.Name = "labelProgramPath";
            labelProgramPath.Size = new Size(141, 15);
            labelProgramPath.TabIndex = 12;
            labelProgramPath.Text = "Diretório do código fonte";
            // 
            // labelProgramPort
            // 
            labelProgramPort.AutoSize = true;
            labelProgramPort.Location = new Point(448, 124);
            labelProgramPort.Name = "labelProgramPort";
            labelProgramPort.Size = new Size(35, 15);
            labelProgramPort.TabIndex = 11;
            labelProgramPort.Text = "Porta";
            // 
            // btnBrowseProgramPath
            // 
            btnBrowseProgramPath.Location = new Point(448, 28);
            btnBrowseProgramPath.Name = "btnBrowseProgramPath";
            btnBrowseProgramPath.Size = new Size(120, 31);
            btnBrowseProgramPath.TabIndex = 0;
            btnBrowseProgramPath.Text = "Procurar...";
            btnBrowseProgramPath.UseVisualStyleBackColor = true;
            btnBrowseProgramPath.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // comboBoxProgramType
            // 
            comboBoxProgramType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProgramType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxProgramType.FormattingEnabled = true;
            comboBoxProgramType.Location = new Point(322, 87);
            comboBoxProgramType.Name = "comboBoxProgramType";
            comboBoxProgramType.Size = new Size(120, 29);
            comboBoxProgramType.TabIndex = 2;
            // 
            // labelProgramType
            // 
            labelProgramType.AutoSize = true;
            labelProgramType.Location = new Point(322, 67);
            labelProgramType.Name = "labelProgramType";
            labelProgramType.Size = new Size(30, 15);
            labelProgramType.TabIndex = 15;
            labelProgramType.Text = "Tipo";
            // 
            // labelProgramProcessName
            // 
            labelProgramProcessName.AutoSize = true;
            labelProgramProcessName.Location = new Point(12, 124);
            labelProgramProcessName.Name = "labelProgramProcessName";
            labelProgramProcessName.Size = new Size(107, 15);
            labelProgramProcessName.TabIndex = 13;
            labelProgramProcessName.Text = "Nome do Processo";
            // 
            // labelProject
            // 
            labelProject.AutoSize = true;
            labelProject.Location = new Point(448, 67);
            labelProject.Name = "labelProject";
            labelProject.Size = new Size(45, 15);
            labelProject.TabIndex = 16;
            labelProject.Text = "Projeto";
            // 
            // comboBoxProject
            // 
            comboBoxProject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxProject.FormattingEnabled = true;
            comboBoxProject.Location = new Point(448, 87);
            comboBoxProject.Name = "comboBoxProject";
            comboBoxProject.Size = new Size(120, 29);
            comboBoxProject.TabIndex = 3;
            // 
            // labelProgramRepositoryUrl
            // 
            labelProgramRepositoryUrl.AutoSize = true;
            labelProgramRepositoryUrl.Location = new Point(12, 238);
            labelProgramRepositoryUrl.Name = "labelProgramRepositoryUrl";
            labelProgramRepositoryUrl.Size = new Size(99, 15);
            labelProgramRepositoryUrl.TabIndex = 14;
            labelProgramRepositoryUrl.Text = "Repositório (URL)";
            // 
            // textProgramRepositoryUrl
            // 
            textProgramRepositoryUrl.BorderStyle = BorderStyle.FixedSingle;
            textProgramRepositoryUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramRepositoryUrl.Location = new Point(16, 258);
            textProgramRepositoryUrl.Name = "textProgramRepositoryUrl";
            textProgramRepositoryUrl.Size = new Size(552, 29);
            textProgramRepositoryUrl.TabIndex = 7;
            // 
            // labelProgramCommand
            // 
            labelProgramCommand.AutoSize = true;
            labelProgramCommand.Location = new Point(12, 181);
            labelProgramCommand.Name = "labelProgramCommand";
            labelProgramCommand.Size = new Size(244, 15);
            labelProgramCommand.TabIndex = 18;
            labelProgramCommand.Text = "Entrada no terminal (comandos e instruções)";
            // 
            // textProgramCommand
            // 
            textProgramCommand.BorderStyle = BorderStyle.FixedSingle;
            textProgramCommand.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProgramCommand.Location = new Point(16, 201);
            textProgramCommand.Name = "textProgramCommand";
            textProgramCommand.Size = new Size(552, 29);
            textProgramCommand.TabIndex = 6;
            // 
            // comboBoxProgramStart
            // 
            comboBoxProgramStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxProgramStart.FormattingEnabled = true;
            comboBoxProgramStart.Location = new Point(16, 144);
            comboBoxProgramStart.Name = "comboBoxProgramStart";
            comboBoxProgramStart.Size = new Size(426, 29);
            comboBoxProgramStart.TabIndex = 4;
            comboBoxProgramStart.SelectedIndexChanged += comboBoxProgramStart_SelectedIndexChanged;
            // 
            // ProgramFormWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(584, 356);
            Controls.Add(comboBoxProgramStart);
            Controls.Add(textProgramCommand);
            Controls.Add(labelProgramCommand);
            Controls.Add(textProgramRepositoryUrl);
            Controls.Add(labelProgramRepositoryUrl);
            Controls.Add(comboBoxProject);
            Controls.Add(labelProject);
            Controls.Add(labelProgramProcessName);
            Controls.Add(labelProgramType);
            Controls.Add(comboBoxProgramType);
            Controls.Add(btnSaveProgram);
            Controls.Add(btnCancelProgram);
            Controls.Add(btnBrowseProgramPath);
            Controls.Add(labelProgramPort);
            Controls.Add(labelProgramPath);
            Controls.Add(textProgramPort);
            Controls.Add(textProgramPath);
            Controls.Add(textProgramName);
            Controls.Add(labelProgramName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ProgramFormWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Programa";
            FormClosed += btnCancel_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textProgramName;
        private TextBox textProgramPort;
        private TextBox textProgramPath;
        private TextBox textProgramRepositoryUrl;
        private TextBox textProgramCommand;
        private ComboBox comboBoxProgramStart;
        private ComboBox comboBoxProgramType;
        private ComboBox comboBoxProject;

        private Label labelProgramPath;
        private Label labelProgramPort;
        private Label labelProgramType;
        private Label labelProgramName;
        private Label labelProgramProcessName;
        private Label labelProject;
        private Label labelProgramRepositoryUrl;
        private Label labelProgramCommand;

        private Button btnSaveProgram;
        private Button btnCancelProgram;
        private Button btnBrowseProgramPath;
    }
}
