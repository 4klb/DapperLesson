using Dapper;
using DapperLesson.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DapperLesson.Data
{
    public class TeamDataAccess
    {
        public List<Team> GetAll()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DESKTOP-S75L8G1; Database=EFCoreStartLesson; Trusted_Connection=true;";
                //connection.Open(); - в Dapper это необязательно 
                var sql = "SELECT * FROM Teams";
                //создавать SqlCommand не надо в Dapper
                return connection.Query<Team>(sql).ToList();
            }
        }
        public void Add(Team team)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DESKTOP-S75L8G1; Database=EFCoreStartLesson; Trusted_Connection=true;"; 
                var sql = "INSERT INTO Teams VALUES (@id, @Name)";
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
                var sql = $"DELETE Teams WHERE {data}";
                connection.Execute(sql, team);
            }
        }
    }
}
