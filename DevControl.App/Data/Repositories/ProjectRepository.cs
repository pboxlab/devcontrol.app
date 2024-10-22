﻿using Dapper;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using System.Data.SQLite;

namespace DevControl.App.Data.Repositories
{
    public class ProjectRepository
    {
        private readonly string _pathDataBase = $"Data Source={AppConfig.PathDatabase}";

        private const string sqlSelect = @$"
            SELECT
                Id,
                Name,
                Path
            FROM
                Projects";

        private const string sqlInsert = @$"
            INSERT INTO Projects (
                Name,
                Path
            ) VALUES (
                @Name,
                @Path
            )";

        private const string sqlUpdate = @$"
            UPDATE Projects SET
                Name = @Name,
                Path = @Path
            WHERE
                Id   = @Id";

        private const string sqlDelete = @$"
            DELETE FROM
                Projects
            WHERE
                Id = @Id";

        public async Task<List<ProjectEntity>> LoadRecordsAsync()
        {
            try
            {
                using var connection = new SQLiteConnection(_pathDataBase);
                      var result     = await connection.QueryAsync<ProjectEntity>($"{sqlSelect} ORDER BY Name asc");
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ExecuteQueryAsync(ProjectDto dto, TypeQueryExecuteEnum isInsert)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
