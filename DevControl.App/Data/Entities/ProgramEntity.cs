using DevControl.App.Data.Enum;
using System.Diagnostics;

namespace DevControl.App.Data.Entities
{
    public class ProgramEntity
    {
        public int             Id             { get; set; }
        public int             ProjectId      { get; set; }
        public string?         ProjectName    { get; set; }
        public string?         RepositoryUrl  { get; set; }
        public ProgramTypeEnum Type           { get; set; }
        public string?         Name           { get; set; }
        public string?         Path           { get; set; }
        public int?            Port           { get; set; }
        public string          ProcessName    { get; set; }
        public string?         Command        { get; set; }
        public string?         Workspace      { get; set; }
        public int?            PID            { get; set; }
        public Process?        Process        { get; set; }
        public Button?         Button         { get; set; }
    }
}
