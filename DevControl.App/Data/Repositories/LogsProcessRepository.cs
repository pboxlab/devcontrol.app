﻿using Dapper;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Models;
using System.Data.SQLite;

namespace DevControl.App.Data.Repositories
{
    public class LogsProcessRepository
    {
        private readonly string _pathDataBase = $"Data Source={AppConfig.PathDatabase}";

        private const string sqlSelect = @"
            SELECT
                Id,
                SoftwareId,
                PID,
                Type,
                LogValue,
                CreatedAt
            FROM
                LogsProcess";

        private const string sqlInsert = @"
            INSERT INTO LogsProcess (
                SoftwareId,
                PID,
                Type,
                LogValue,
                CreatedAt
            ) VALUES (
                @SoftwareId,
                @PID,
                @Type,
                @LogValue,
                datetime()
            )";

        private const string sqlDelete = @"
            DELETE FROM
                LogsProcess
            WHERE 
                SoftwareId = @SoftwareId";

        public async Task<List<LogsProcessEntity>> LoadRecordsAsync(LogsProcessModel query)
        {
            try
            {
                var where = " WHERE 1=1";
                where += query.SoftwareId != null ? $" AND SoftwareId = {query.SoftwareId}" : "";
                where += query.PID        != null ? $" AND PID        = {query.PID}" : "";
                where += query.Type       != null ? $" AND Type       = '{query.Type}'" : "";

                using var connection = new SQLiteConnection(_pathDataBase);
                var result = await connection.QueryAsync<LogsProcessEntity>($"{sqlSelect} {where} ORDER BY CreatedAt ASC");
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ExecuteQueryAsync(LogsProcessDto dto, TypeQueryExecuteEnum isInsert)
        {
            try
            {
                var query = isInsert switch
                {
                    TypeQueryExecuteEnum.Insert => sqlInsert,
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
