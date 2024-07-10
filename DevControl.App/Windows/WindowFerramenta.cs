using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Xml;

namespace DevControl.App.Windows
{
    public partial class WindowFerramenta : Form
    {
        public WindowFerramenta()
        {
            InitializeComponent();
        }

        private void btnGerarGuid_Click(object sender, EventArgs e)
        {
            var quantidade = numericQuantidadeGuid.Value;
            listGuidGerados.Items.Clear();

            for (int i = 0; i < quantidade; i++)
            {
                listGuidGerados.Items.Add(Guid.NewGuid().ToString());
            }
        }

        private async void ShowCopyAlert(string text)
        {
            labelCopyAlert.Text = text;
            labelCopyAlert.Visible = true;
            await Task.Delay(1000);
            labelCopyAlert.Visible = false;
        }

        private void listGuidGerados_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listGuidGerados.SelectedItems.Count > 0)
                {
                    var selectedItems = string.Join(Environment.NewLine, listGuidGerados.SelectedItems.Cast<string>());
                    Clipboard.SetText(selectedItems);
                    ShowCopyAlert("Guid copiado");
                }
            }
        }

        private void btnFormatarJson_Click(object sender, EventArgs e)
        {
            string input = textJson.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("O campo de texto está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var parsedJson = JToken.Parse(input);
                var formattedJson = parsedJson.ToString(Newtonsoft.Json.Formatting.Indented);
                textJson.Text = formattedJson;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Erro de formatação JSON: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
