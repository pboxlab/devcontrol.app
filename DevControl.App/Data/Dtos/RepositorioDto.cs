namespace DevControl.App.Data.Dtos
{
    public class RepositorioDto
    {
        public int             Id           { get; set; }
        public required string Name         { get; set; }
        public required string Url          { get; set; }
    }
}
