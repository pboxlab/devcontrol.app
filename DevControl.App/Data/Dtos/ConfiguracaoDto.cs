namespace DevControl.App.Data.Dtos
{
    public class ConfiguracaoDto
    {
        public int             Id    { get; set; }
        public required string Name  { get; set; }
        public required string Value { get; set; }
    }
}
