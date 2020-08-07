using Microsoft.Data.Sqlite;
using DotnetCorp.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DotnetCorp.Services
{
    public class UserService : IUserService
    {
        private const string DatabaseName = "users.db";

        public UserModel[] GetByName(string namePattern)
        {
            var connectionString = new SqliteConnectionStringBuilder { DataSource = DatabaseName }.ToString();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = $"SELECT * FROM users WHERE (firstName like '%{namePattern}%' OR lastName like '%{namePattern}%') AND admin == 'false';";

                var result = new List<UserModel>();
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var user = new UserModel
                        {
                            FirstName = (string) reader["firstName"],
                            LastName = (string) reader["lastName"],
                            Company = (string) reader["company"],
                            Title = (string) reader["title"],
                            EmailAddress = (string) reader["emailAddress"],
                            PhoneNumber = (string) reader["phoneNumber"],
                            DateOfBirth = (string) reader["dateOfBirth"],
                            SocialSecurityNumber = (string) reader["socialSecurityNumber"],
                            Salary = (string) reader["salary"],
                            Admin = (string) reader["admin"],
                        };
                        result.Add(user);
                    }
                }

                return result.ToArray();
            }
        }

        public void ResetDatabase()
        {
            var connectionString = new SqliteConnectionStringBuilder { DataSource = DatabaseName }.ToString();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createCommand = connection.CreateCommand();
                createCommand.CommandText = "DROP TABLE IF EXISTS users;"
                                          + "CREATE TABLE users (firstName TEXT, lastName TEXT, company TEXT, title TEXT, emailAddress TEXT, phoneNumber TEXT, dateOfBirth TEXT, socialSecurityNumber TEXT, salary TEXT, admin TEXT);";
                createCommand.ExecuteNonQuery();
            }
        }

        public void SeedDatabase()
        {
            var userDataString = File.ReadAllText("user_seed_data.json");
            var userDataObject = JsonConvert.DeserializeObject<List<UserModel>>(userDataString);

            var connectionString = new SqliteConnectionStringBuilder { DataSource = DatabaseName }.ToString();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();                
                foreach(var user in userDataObject)
                {   SqliteCommand insertCommand = new SqliteCommand($"INSERT INTO users VALUES ('{user.FirstName}', '{user.LastName}', '{user.Company}', '{user.Title}', '{user.EmailAddress}', '{user.PhoneNumber}', '{user.DateOfBirth}', '{user.SocialSecurityNumber}', '{user.Salary}', '{user.Admin}');", connection);
                    try {
                        insertCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex) {
                        throw new Exception(ex.Message);
                    } 
                }
            }
        }
    }
}
