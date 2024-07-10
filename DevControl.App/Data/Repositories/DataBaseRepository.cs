using Dapper;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Enum;
using System.Data.SQLite;

namespace DevControl.App.Data.Repositories
{
    public class DataBaseRepository
    {
        private readonly string _pathDataBase;

        public DataBaseRepository(string pathDatabase)
        {
            _pathDataBase = pathDatabase;
        }

        public string CreateDataBase()
        {
            try
            {
                SQLiteConnection.CreateFile(_pathDataBase);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> CreateObjectsAsync()
        {
            try
            {
                using var connection = new SQLiteConnection($"Data Source={_pathDataBase}");

                List<string> scripts = new()
                {
                    "CREATE TABLE \"LogsProcess\" (\"Id\" integer NOT NULL PRIMARY KEY AUTOINCREMENT, \"SoftwareId\" integer, \"PID\" integer, \"Type\" text, \"LogValue\" text, \"CreatedAt\" text);",
                    "CREATE TABLE \"Projects\" (\"Id\" integer PRIMARY KEY AUTOINCREMENT, \"Name\" text, \"Path\" text);",
                    "CREATE TABLE \"Repositories\" (\"Id\" integer PRIMARY KEY AUTOINCREMENT, \"Name\" text, \"Url\" text);",
                    "CREATE TABLE \"Softwares\" (\"Id\" integer PRIMARY KEY AUTOINCREMENT, \"ProjectId\" integer, \"RepositoryId\" integer, \"RepositoryUrl\" text, \"Type\" integer, \"Name\" text, \"Path\" text, \"Port\" integer, \"ProcessName\" text, \"Command\" text, \"Workspace\" text, \"PID\" integer, FOREIGN KEY (\"RepositoryId\") REFERENCES \"Repositories\" (\"Id\") ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (\"ProjectId\") REFERENCES \"Projects\" (\"Id\") ON DELETE NO ACTION ON UPDATE NO ACTION);",
                    "CREATE TABLE \"SystemSettings\" (\"Id\" integer PRIMARY KEY AUTOINCREMENT, \"Name\" text, \"Value\" text);"
                };

                foreach (var script in scripts)
                {
                    await connection.ExecuteAsync(script);
                }

                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
