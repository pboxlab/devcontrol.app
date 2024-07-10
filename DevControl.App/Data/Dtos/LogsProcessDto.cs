namespace DevControl.App.Data.Dtos
{
    public class LogsProcessDto
    {
        public int      SoftwareId { get; set; }
        public int?     PID        { get; set; }
        public string   Type       { get; set; }
        public string   LogValue   { get; set; }
    }
}
