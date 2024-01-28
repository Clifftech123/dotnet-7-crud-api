using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using dotnet_7_crud_api.Helpers;

namespace dotnet_7_crud_api.Data
{
    public class DataContext
    {
        private readonly DbSettings _dbSettings;

        public DataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_dbSettings.ConnectionString);
        }

        public async Task Init()
        {
            await InitDatabase();
            await InitTables();
        }

        private async Task InitDatabase()
        {
            // create database if it doesn't exist
            var builder = new SqlConnectionStringBuilder(_dbSettings.ConnectionString);
            var databaseName = builder.InitialCatalog;
            builder.InitialCatalog = "master";
            using var connection = new SqlConnection(builder.ConnectionString);
            var sql = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{databaseName}') CREATE DATABASE [{databaseName}];";
            await connection.ExecuteAsync(sql);
        }

        private async Task InitTables()
        {
            // create tables if they don't exist
            using var connection = CreateConnection();
            await _initUsers();

            async Task _initUsers()
            {
                var sql = @"
                IF OBJECT_ID('Users', 'U') IS NULL
                CREATE TABLE Users (
                    Id INT NOT NULL PRIMARY KEY IDENTITY,
                    Title NVARCHAR(MAX),
                    FirstName NVARCHAR(MAX),
                    LastName NVARCHAR(MAX),
                    Email NVARCHAR(MAX),
                    Role INT,
                    PasswordHash NVARCHAR(MAX)
                );
            ";
                await connection.ExecuteAsync(sql);
            }
        }
    }
}