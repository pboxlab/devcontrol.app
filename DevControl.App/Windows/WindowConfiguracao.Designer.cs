
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
            groupBox1 = new GroupBox();
            btnNovoBanco = new Button();
            groupBox2 = new GroupBox();
            checkIniciaWindows = new CheckBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            checkFecharPrograma = new CheckBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(btnNovoBanco);
            groupBox1.Controls.Add(labelBancoPath);
            groupBox1.Controls.Add(btnBancoExistente);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 92);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Banco de dados";
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
            // groupBox2
            // 
            groupBox2.Controls.Add(checkIniciaWindows);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 110);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(460, 63);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Iniciar com o Windows";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 29);
            label1.Name = "label1";
            label1.Size = new Size(385, 15);
            label1.TabIndex = 0;
            label1.Text = "O programa será executado automaticamente ao iniciar seu dispositivo.";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkFecharPrograma);
            groupBox3.Controls.Add(label2);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(12, 179);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(460, 73);
            groupBox3.TabIndex = 21;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ao fechar o programa";
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
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(8, 29);
            label2.Name = "label2";
            label2.Size = new Size(345, 34);
            label2.TabIndex = 0;
            label2.Text = "Ao clicar no botão de fechar, o programa será minimizado para a bandeja do sistema.";
            // 
            // WindowConfiguracao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(484, 263);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnBancoExistente;
        private Label labelBancoPath;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private CheckBox checkIniciaWindows;
        private GroupBox groupBox3;
        private Label label2;
        private CheckBox checkFecharPrograma;
        private Button btnNovoBanco;
    }
}