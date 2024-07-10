namespace DevControl.App.Data.Entities
{
    public class ProgramTypeEntity
    {
        public int    Id       { get; set; }
        public string Name     { get; set; }
        public string Executor { get; set; }


        public List<ProgramTypeEntity> ListType()
        {
            return new List<ProgramTypeEntity>
            {
                new() { Id = 1,  Name = ".Net",    Executor = "cmd.exe" },
                new() { Id = 2,  Name = "Angular", Executor = "node.exe" },
                new() { Id = 3,  Name = "NodeJs",  Executor = "node.exe" },
                new() { Id = 4,  Name = "PHP",     Executor = "php.exe" },
                new() { Id = 99, Name = "Outro",   Executor = "cmd.exe" },
            };
        }

    }
}
