using Dapper;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Models;
using System.Data.SQLite;

namespace DevControl.App.Data.Repositories
{
    public class ProgramRepository
    {
        private readonly string _pathDataBase = $"Data Source={AppConfig.PathDatabase}";

        private const string sqlSelect = @$"
            SELECT
	            p.Id,
	            p.ProjectId,
	            g.Name AS ProjectName,
	            p.RepositoryUrl,
	            p.Type,
	            p.Name,
	            p.Path,
	            p.Port,
	            p.ProcessName,
	            p.Command,
	            p.Workspace,
	            p.PID
            FROM
                Softwares AS p
                LEFT JOIN Projects AS g ON p.ProjectId = g.Id";

        private const string sqlInsert = @$"
            INSERT INTO Softwares (
                ProjectId,
                RepositoryUrl,
                Type,
                Name,
                Path,
                Port,
                Command,
                Workspace,
                ProcessName
            ) VALUES (
                @ProjectId,
                @RepositoryUrl,
                @Type,
                @Name,
                @Path,
                @Port,
                @Command,
                @Workspace,
                @ProcessName
            )";

        private const string sqlUpdate = @$"
            UPDATE Softwares SET
                Id            = @Id,
                ProjectId     = @ProjectId,
                RepositoryUrl = @RepositoryUrl,
                Type          = @Type,
                Name          = @Name,
                Path          = @Path,
                Port          = @Port,
                Command       = @Command,
                Workspace     = @Workspace,
                ProcessName   = @ProcessName
            WHERE
                Id            = @Id";

        private const string sqlDelete = @$"
            DELETE FROM
                Softwares
            WHERE
                Id = @Id";

        public async Task<List<ProgramEntity>> LoadRecords(ProgramaModel query)
        {
            var where = " WHERE 1=1 ";
            where += query.ProjectId != null ? $" AND p.ProjectId = {query.ProjectId} " : "";
            where += query.Type      != null ? $" AND p.Type      = {(int)query.Type} " : "";

            where += " ORDER BY p.Name asc ";

            using var connection = new SQLiteConnection(_pathDataBase);
            var result = await connection.QueryAsync<ProgramEntity>(sqlSelect + where, query);
            return result.ToList();
        }

        public async void ExecuteQuery(ProgramDto dto, TypeQueryExecuteEnum isInsert)
        {
            var query = isInsert switch
            {
                TypeQueryExecuteEnum.Insert => sqlInsert,
                TypeQueryExecuteEnum.Update => sqlUpdate,
                TypeQueryExecuteEnum.Delete => sqlDelete,
                _ => throw new NotImplementedException(),
            };
            using var connection = new SQLiteConnection(_pathDataBase);
            await connection.ExecuteAsync(query, dto);
        }
    }
}
