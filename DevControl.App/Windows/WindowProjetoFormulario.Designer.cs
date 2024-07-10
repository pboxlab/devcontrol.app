namespace DevControl.App.Windows
{
    partial class WindowProjetoFormulario
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
            btnProjetoPath = new Button();
            labelProjetoPath = new Label();
            textProjetoPath = new TextBox();
            textProjetoName = new TextBox();
            labelProjetoName = new Label();
            btnProjetoSalvar = new Button();
            btnProjetoCancelar = new Button();
            SuspendLayout();
            // 
            // btnProjetoPath
            // 
            btnProjetoPath.Location = new Point(282, 80);
            btnProjetoPath.Name = "btnProjetoPath";
            btnProjetoPath.Size = new Size(90, 31);
            btnProjetoPath.TabIndex = 13;
            btnProjetoPath.Text = "Procurar...";
            btnProjetoPath.UseVisualStyleBackColor = true;
            btnProjetoPath.Click += btnProjetoPath_Click;
            // 
            // labelProjetoPath
            // 
            labelProjetoPath.AutoSize = true;
            labelProjetoPath.Location = new Point(12, 63);
            labelProjetoPath.Name = "labelProjetoPath";
            labelProjetoPath.Size = new Size(102, 15);
            labelProjetoPath.TabIndex = 15;
            labelProjetoPath.Text = "Diretório principal";
            // 
            // textProjetoPath
            // 
            textProjetoPath.BorderStyle = BorderStyle.FixedSingle;
            textProjetoPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProjetoPath.Location = new Point(16, 81);
            textProjetoPath.Name = "textProjetoPath";
            textProjetoPath.Size = new Size(260, 29);
            textProjetoPath.TabIndex = 14;
            // 
            // textProjetoName
            // 
            textProjetoName.BorderStyle = BorderStyle.FixedSingle;
            textProjetoName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textProjetoName.Location = new Point(16, 27);
            textProjetoName.Name = "textProjetoName";
            textProjetoName.Size = new Size(260, 29);
            textProjetoName.TabIndex = 16;
            // 
            // labelProjetoName
            // 
            labelProjetoName.AutoSize = true;
            labelProjetoName.Location = new Point(12, 9);
            labelProjetoName.Name = "labelProjetoName";
            labelProjetoName.Size = new Size(40, 15);
            labelProjetoName.TabIndex = 17;
            labelProjetoName.Text = "Nome";
            // 
            // btnProjetoSalvar
            // 
            btnProjetoSalvar.Location = new Point(186, 135);
            btnProjetoSalvar.Name = "btnProjetoSalvar";
            btnProjetoSalvar.Size = new Size(90, 30);
            btnProjetoSalvar.TabIndex = 18;
            btnProjetoSalvar.Text = "Salvar";
            btnProjetoSalvar.UseVisualStyleBackColor = true;
            btnProjetoSalvar.Click += btnProjetoSalvar_Click;
            // 
            // btnProjetoCancelar
            // 
            btnProjetoCancelar.Location = new Point(282, 135);
            btnProjetoCancelar.Name = "btnProjetoCancelar";
            btnProjetoCancelar.Size = new Size(90, 30);
            btnProjetoCancelar.TabIndex = 19;
            btnProjetoCancelar.Text = "Cancelar";
            btnProjetoCancelar.UseVisualStyleBackColor = true;
            btnProjetoCancelar.Click += btnProjetoCancelar_Click;
            // 
            // WindowProjetoFormulario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(384, 175);
            Controls.Add(btnProjetoSalvar);
            Controls.Add(btnProjetoCancelar);
            Controls.Add(textProjetoName);
            Controls.Add(labelProjetoName);
            Controls.Add(btnProjetoPath);
            Controls.Add(labelProjetoPath);
            Controls.Add(textProjetoPath);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "WindowProjetoFormulario";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Novo Projeto";
            FormClosed += btnProjetoCancelar_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProjetoPath;
        private Label labelProjetoPath;
        private TextBox textProjetoPath;
        private TextBox textProjetoName;
        private Label labelProjetoName;
        private Button btnProjetoSalvar;
        private Button btnProjetoCancelar;
    }
}