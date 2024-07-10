using Dapper;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using System.Data.SQLite;

namespace DevControl.App.Data.Repositories
{
    public class ConfiguracaoRepository
    {
        private readonly string _pathDataBase = $"Data Source={AppConfig.PathDatabase}";

        private const string sqlSelect = @$"
            SELECT
                Id,
                Name,
                Value
            FROM
                SystemSettings";

        private const string sqlInsert = @$"
            INSERT INTO SystemSettings (
                Id,
                Name,
                Value
            ) VALUES (
                @Id,
                @Name,
                @Value
            )";

        private const string sqlUpdate = @$"
            UPDATE SystemSettings SET
                Id    = @Id,
                Name  = @Name,
                Value = @Value
            WHERE
                Id    = @Id";

        private const string sqlDelete = @$"
            DELETE FROM
                SystemSettings
            WHERE
                Id = @Id";

        public async Task<List<ConfiguracaoEntity>> LoadRecords()
        {
            using var connection = new SQLiteConnection(_pathDataBase);
            var result = await connection.QueryAsync<ConfiguracaoEntity>(sqlSelect);
            return result.ToList();
        }

        public async void ExecuteQuery(ConfiguracaoDto dto, TypeQueryExecuteEnum isInsert)
        {
            var query = isInsert switch
            {
                TypeQueryExecuteEnum.Insert => sqlInsert,
                TypeQueryExecuteEnum.Update => sqlUpdate,
                TypeQueryExecuteEnum.Delete => sqlDelete,
            };
            using var connection = new SQLiteConnection(_pathDataBase);
            await connection.ExecuteAsync(query, dto);
        }
    }
}
