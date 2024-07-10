namespace DevControl.App.Data.Entities
{
    public class LogsProcessEntity
    {
        public int      Id         { get; set; }
        public int      SoftwareId { get; set; }
        public int      PID        { get; set; }
        public string   Type       { get; set; }
        public string   LogValue   { get; set; }
        public DateTime CreatedAt  { get; set; }
    }
}
