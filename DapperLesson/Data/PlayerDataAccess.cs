using Dapper;
using DapperLesson.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DapperLesson.Data
{
    public class PlayerDataAccess
    {
        public List<Player> GetAll()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DESKTOP-S75L8G1; Database=EFCoreStartLesson; Trusted_Connection=true;";
                var sql = "SELECT * FROM Players";
                return connection.Query<Player>(sql).ToList();
            }
        }
        public void Add(Team team)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DESKTOP-S75L8G1; Database=EFCoreStartLesson; Trusted_Connection=true;";
                var sql = "INSERT INTO Players VALUES (@id, @FullName, @Number, @TeamId)";
                connection.Execute(sql, team);
            }
        }
        public void Create(Team team, string name)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DESKTOP-S75L8G1; Database=EFCoreStartLesson; Trusted_Connection=true;";
                var sql = $"CREATE TABLE {name}";
                connection.Execute(sql, team);
            }
        }
        public void DeleteByData(Team team, string data)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DESKTOP-S75L8G1; Database=EFCoreStartLesson; Trusted_Connection=true;";
                var sql = $"DELETE Players WHERE {data}";
                connection.Execute(sql, team);
            }
        }
    }
}
