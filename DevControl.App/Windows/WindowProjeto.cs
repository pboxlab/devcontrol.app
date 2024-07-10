﻿using DevControl.App.Common;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Repositories;

namespace DevControl.App.Windows
{
    public partial class WindowProjeto : Form
    {
        private          WindowProjetoFormulario _projetoFormulario = new();
        private          List<ProjectEntity>     _projetos          = new();
        private readonly ProjectRepository       _projetoRepository = new();      

        public WindowProjeto()
        {
            _projetoFormulario.ReloadProjetos += ReloadProjetos;

            InitializeComponent();
            LoadProjetos();
        }

        private async void LoadProjetos()
        {
            _projetos = await _projetoRepository.LoadRecordsAsync();
            panelProjects.Controls.Clear();

            int y = 10;
            int isScroll = _projetos.Count > 10 ? 20 : 0;
            foreach (var projeto in _projetos)
            {
                var panel = CreatePanel(projeto, y, isScroll);
                panelProjects.Controls.Add(panel);
                y += 45;
            }
        }

        private Panel CreatePanel(ProjectEntity projeto, int y, int isScroll = 0)
        {
            int widthTotal = 1040 - isScroll;

            var panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(0, y),
                Size = new Size(widthTotal, 40),
                BackColor = Color.White,
            };

            var labelList = new List<(string Text, string Name, int Width)>()
            {
                new (projeto.Name!, $"labelProjetoName_{projeto.Id}", 150),
            };
            var p = 0;
            foreach (var label in labelList)
            {
                panel.Controls.Add(PanelComponents.LabelPanel(label.Text, label.Name, label.Width, p));
                p = p + label.Width;
            }

            var buttonList = new List<(object Text, int Width, string Tag, string Function)>
            {
                new(Properties.Resources.btnDelete, 25, $"btnApagar_{projeto.Id}", "btnApagarProjeto_Click"),
                new(Properties.Resources.btnEdit, 25, $"btnEditar_{projeto.Id}", "btnEditarProjeto_Click"),
                new(Properties.Resources.btnOpenFolder, 25, $"btnExplorar_{projeto.Id}", "btnOpenDirectory_Click")
            };

            var b = widthTotal;
            foreach (var button in buttonList)
            {
                b = (b - button.Width) - 5;
                panel.Controls.Add(ButtonPanel(projeto, button.Text, button.Tag, button.Width, b, button.Function));
            }

            var wL = 50;
            panel.Controls.Add(PanelComponents.LabelPanel("", $"labelProjetoProcessId_{projeto.Id}", wL, (b - wL - 5)));

            return panel;
        }       

        private Button ButtonPanel(ProjectEntity projeto, object text, string tag, int width, int px, string? funcao = null)
        {
            var button = new Button();

            if (text is Image image)
            {
                button.Image = image;
            }
            else
            {
                button.Text = text.ToString();
            }

            button.Location = new Point(px, 6);
            button.Size = new Size(width, 25);
            button.Tag = tag;

            if (!string.IsNullOrEmpty(funcao))
            {
                switch (funcao)
                {
                    case "btnEditarProjeto_Click":
                        button.Click += (s, e) => btnEditarProjeto_Click(projeto);
                        break;
                    case "btnApagarProjeto_Click":
                        button.Click += (s, e) => btnApagarProjeto_Click(projeto);
                        break;
                    case "btnOpenDirectory_Click":
                        button.Click += (s, e) => DialogCommon.OpenDirectoryClick(projeto.Path);
                        break;
                }
            }
            return button;
        }

        private void ReloadProjetos(object sender, EventArgs e)
        {
            LoadProjetos();
        }

        private void btnNovoProjeto_Click(object sender, EventArgs e)
        {
            _projetoFormulario.LoadDetails();
            _projetoFormulario.ShowDialog();
        }

        private void btnEditarProjeto_Click(ProjectEntity projeto)
        {
            _projetoFormulario.LoadDetails(projeto);
            _projetoFormulario.ShowDialog();
        }

        private void btnApagarProjeto_Click(ProjectEntity projeto)
        {
            var result = MessageBox.Show($"Tem certeza que deseja remover o projeto {projeto.Name}?", "Remover Projeto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                _projetoRepository.ExecuteQueryAsync(new ProjectDto { Id = projeto.Id }, TypeQueryExecuteEnum.Delete);
                LoadProjetos();
            }
        }
    }
}