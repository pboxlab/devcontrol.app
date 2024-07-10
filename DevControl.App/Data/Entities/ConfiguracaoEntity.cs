namespace DevControl.App.Data.Entities
{
    public class ConfiguracaoEntity
    {
        public int             Id    { get; set; }
        public required string Name  { get; set; }
        public required string Value { get; set; }
    }
}
