namespace DevControl.App.Windows
{
    partial class WindowMonitor
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
            panelMotiporProgramas = new Panel();
            labelFiltroTipos = new Label();
            boxFiltroProjeto = new ComboBox();
            labelFiltroProjetos = new Label();
            boxFiltroTipo = new ComboBox();
            btnNovoPrograma = new Button();
            grupoFiltro = new GroupBox();
            btnReloadProgramas = new Button();
            grupoFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // panelMotiporProgramas
            // 
            panelMotiporProgramas.AutoScroll = true;
            panelMotiporProgramas.BackColor = SystemColors.ControlLightLight;
            panelMotiporProgramas.ForeColor = SystemColors.ControlDarkDark;
            panelMotiporProgramas.Location = new Point(12, 78);
            panelMotiporProgramas.Name = "panelMotiporProgramas";
            panelMotiporProgramas.Size = new Size(1040, 752);
            panelMotiporProgramas.TabIndex = 0;
            // 
            // labelFiltroTipos
            // 
            labelFiltroTipos.AutoSize = true;
            labelFiltroTipos.Location = new Point(838, 26);
            labelFiltroTipos.Name = "labelFiltroTipos";
            labelFiltroTipos.Size = new Size(30, 15);
            labelFiltroTipos.TabIndex = 9;
            labelFiltroTipos.Text = "Tipo";
            // 
            // boxFiltroProjeto
            // 
            boxFiltroProjeto.DisplayMember = "Name";
            boxFiltroProjeto.DropDownStyle = ComboBoxStyle.DropDownList;
            boxFiltroProjeto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            boxFiltroProjeto.FormattingEnabled = true;
            boxFiltroProjeto.Location = new Point(627, 20);
            boxFiltroProjeto.Name = "boxFiltroProjeto";
            boxFiltroProjeto.Size = new Size(160, 29);
            boxFiltroProjeto.TabIndex = 8;
            boxFiltroProjeto.ValueMember = "Id";
            boxFiltroProjeto.SelectedIndexChanged += BoxFilterProjetos_SelectedIndexChanged;
            // 
            // labelFiltroProjetos
            // 
            labelFiltroProjetos.AutoSize = true;
            labelFiltroProjetos.Location = new Point(576, 28);
            labelFiltroProjetos.Name = "labelFiltroProjetos";
            labelFiltroProjetos.Size = new Size(45, 15);
            labelFiltroProjetos.TabIndex = 6;
            labelFiltroProjetos.Text = "Projeto";
            // 
            // boxFiltroTipo
            // 
            boxFiltroTipo.DisplayMember = "Name";
            boxFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxFiltroTipo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            boxFiltroTipo.FormattingEnabled = true;
            boxFiltroTipo.Location = new Point(874, 18);
            boxFiltroTipo.Name = "boxFiltroTipo";
            boxFiltroTipo.Size = new Size(160, 29);
            boxFiltroTipo.TabIndex = 7;
            boxFiltroTipo.ValueMember = "Id";
            boxFiltroTipo.SelectedIndexChanged += BoxFilterProjetos_SelectedIndexChanged;
            // 
            // btnNovoPrograma
            // 
            btnNovoPrograma.Location = new Point(6, 19);
            btnNovoPrograma.Name = "btnNovoPrograma";
            btnNovoPrograma.Size = new Size(120, 30);
            btnNovoPrograma.TabIndex = 5;
            btnNovoPrograma.Text = "Novo Programa";
            btnNovoPrograma.UseVisualStyleBackColor = true;            
            // 
            // grupoFiltro
            // 
            grupoFiltro.Controls.Add(btnReloadProgramas);
            grupoFiltro.Controls.Add(labelFiltroTipos);
            grupoFiltro.Controls.Add(labelFiltroProjetos);
            grupoFiltro.Controls.Add(boxFiltroTipo);
            grupoFiltro.Controls.Add(btnNovoPrograma);
            grupoFiltro.Controls.Add(boxFiltroProjeto);
            grupoFiltro.Location = new Point(12, 12);
            grupoFiltro.Name = "grupoFiltro";
            grupoFiltro.Size = new Size(1040, 60);
            grupoFiltro.TabIndex = 11;
            grupoFiltro.TabStop = false;
            // 
            // btnReloadProgramas
            // 
            btnReloadProgramas.Location = new Point(132, 19);
            btnReloadProgramas.Name = "btnReloadProgramas";
            btnReloadProgramas.Size = new Size(100, 30);
            btnReloadProgramas.TabIndex = 10;
            btnReloadProgramas.Text = "Recarregar (F5)";
            btnReloadProgramas.UseVisualStyleBackColor = true;            
            // 
            // WindowMonitor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1064, 842);
            ControlBox = false;
            Controls.Add(grupoFiltro);
            Controls.Add(panelMotiporProgramas);
            KeyPreview = true;
            Name = "WindowMonitor";
            Text = "Monitor de Serviços";
            WindowState = FormWindowState.Maximized;           
            grupoFiltro.ResumeLayout(false);
            grupoFiltro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label    labelFiltroProjetos;
        private Label    labelFiltroTipos;
        private Panel    panelMotiporProgramas;
        private Button   btnNovoPrograma;
        private ComboBox boxFiltroProjeto;
        private ComboBox boxFiltroTipo;
        private GroupBox grupoFiltro;
        private Button btnReloadProgramas;
    }
}