
namespace DevControl.App.Windows
{
    partial class WindowConfiguracao
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
            btnBancoExistente = new Button();
            labelBancoPath = new Label();
            groupBanco = new GroupBox();
            btnNovoBanco = new Button();

            groupFecharPrograma = new GroupBox();
            checkFecharPrograma = new CheckBox();
            labelFecharPrograma = new Label();
            labelIniciaWindows = new Label();
            checkIniciaWindows = new CheckBox();
            groupIniciaWindows = new GroupBox();


            groupBanco.SuspendLayout();
            groupFecharPrograma.SuspendLayout();
            groupIniciaWindows.SuspendLayout();
            SuspendLayout();
            // 
            // btnBancoExistente
            // 
            btnBancoExistente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBancoExistente.Location = new Point(164, 53);
            btnBancoExistente.Name = "btnBancoExistente";
            btnBancoExistente.Size = new Size(150, 31);
            btnBancoExistente.TabIndex = 16;
            btnBancoExistente.Text = "Arquivo Existente";
            btnBancoExistente.UseVisualStyleBackColor = true;
            btnBancoExistente.Click += btnBancoExistente_Click;
            // 
            // labelBancoPath
            // 
            labelBancoPath.AutoSize = true;
            labelBancoPath.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelBancoPath.Location = new Point(8, 29);
            labelBancoPath.Name = "labelBancoPath";
            labelBancoPath.Size = new Size(102, 15);
            labelBancoPath.TabIndex = 18;
            labelBancoPath.Text = "Diretório principal";
            // 
            // groupBanco
            // 
            groupBanco.Controls.Add(btnNovoBanco);
            groupBanco.Controls.Add(labelBancoPath);
            groupBanco.Controls.Add(btnBancoExistente);
            groupBanco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBanco.Location = new Point(12, 12);
            groupBanco.Name = "groupBanco";
            groupBanco.Size = new Size(460, 92);
            groupBanco.TabIndex = 19;
            groupBanco.TabStop = false;
            groupBanco.Text = "Banco de dados";
            // 
            // btnNovoBanco
            // 
            btnNovoBanco.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnNovoBanco.Location = new Point(8, 53);
            btnNovoBanco.Name = "btnNovoBanco";
            btnNovoBanco.Size = new Size(150, 31);
            btnNovoBanco.TabIndex = 19;
            btnNovoBanco.Text = "Criar Novo Banco";
            btnNovoBanco.UseVisualStyleBackColor = true;
            btnNovoBanco.Click += btnNovoBanco_Click;
            // 
            // groupFecharPrograma
            // 
            groupFecharPrograma.Controls.Add(checkFecharPrograma);
            groupFecharPrograma.Controls.Add(labelFecharPrograma);
            groupFecharPrograma.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupFecharPrograma.Location = new Point(12, 179);
            groupFecharPrograma.Name = "groupFecharPrograma";
            groupFecharPrograma.Size = new Size(460, 73);
            groupFecharPrograma.TabIndex = 21;
            groupFecharPrograma.TabStop = false;
            groupFecharPrograma.Text = "Ao fechar o programa";
            // 
            // checkFecharPrograma
            // 
            checkFecharPrograma.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkFecharPrograma.Location = new Point(429, 14);
            checkFecharPrograma.Name = "checkFecharPrograma";
            checkFecharPrograma.Size = new Size(30, 57);
            checkFecharPrograma.TabIndex = 2;
            checkFecharPrograma.UseVisualStyleBackColor = true;
            checkFecharPrograma.CheckedChanged += checkFecharPrograma_CheckedChanged;
            // 
            // labelFecharPrograma
            // 
            labelFecharPrograma.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelFecharPrograma.Location = new Point(8, 29);
            labelFecharPrograma.Name = "labelFecharPrograma";
            labelFecharPrograma.Size = new Size(345, 34);
            labelFecharPrograma.TabIndex = 0;
            labelFecharPrograma.Text = "Ao clicar no botão de fechar, o programa será minimizado para a bandeja do sistema.";
            // 
            // labelIniciaWindows
            // 
            labelIniciaWindows.AutoSize = true;
            labelIniciaWindows.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelIniciaWindows.Location = new Point(8, 29);
            labelIniciaWindows.Name = "labelIniciaWindows";
            labelIniciaWindows.Size = new Size(384, 15);
            labelIniciaWindows.TabIndex = 0;
            labelIniciaWindows.Text = "O programa será executado automaticamente ao iniciar seu dispositivo.";
            // 
            // checkIniciaWindows
            // 
            checkIniciaWindows.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkIniciaWindows.Location = new Point(429, 14);
            checkIniciaWindows.Name = "checkIniciaWindows";
            checkIniciaWindows.Size = new Size(30, 47);
            checkIniciaWindows.TabIndex = 1;
            checkIniciaWindows.UseVisualStyleBackColor = true;
            checkIniciaWindows.CheckedChanged += checkIniciaWindows_CheckedChanged;
            // 
            // groupIniciaWindows
            // 
            groupIniciaWindows.Controls.Add(checkIniciaWindows);
            groupIniciaWindows.Controls.Add(labelIniciaWindows);
            groupIniciaWindows.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupIniciaWindows.Location = new Point(12, 110);
            groupIniciaWindows.Name = "groupIniciaWindows";
            groupIniciaWindows.Size = new Size(460, 63);
            groupIniciaWindows.TabIndex = 20;
            groupIniciaWindows.TabStop = false;
            groupIniciaWindows.Text = "Iniciar com o Windows";
            // 
            // WindowConfiguracao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(484, 263);
            Controls.Add(groupFecharPrograma);
            Controls.Add(groupIniciaWindows);
            Controls.Add(groupBanco);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "WindowConfiguracao";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações";
            FormClosing += WindowConfiguracoes_FormClosed;
            groupBanco.ResumeLayout(false);
            groupBanco.PerformLayout();
            groupFecharPrograma.ResumeLayout(false);
            groupIniciaWindows.ResumeLayout(false);
            groupIniciaWindows.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelBancoPath;
        private Button btnBancoExistente;
        private Button btnNovoBanco;
        private GroupBox groupBanco;

        private Label labelFecharPrograma;
        private GroupBox groupFecharPrograma;
        private CheckBox checkFecharPrograma;

        private Label labelIniciaWindows;
        private GroupBox groupIniciaWindows;
        private CheckBox checkIniciaWindows;
    }
}