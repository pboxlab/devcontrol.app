namespace DevControl.App.Common
{
    public static class PanelComponents
    {
        public static Label LabelPanel(string text, string name, int width, int px) 
        {
            return new Label
            {
                Name = name,
                Text = text,
                Location = new Point(px + 10, 11),
                Size = new Size(width, 20)
            };
        }
    }
}
