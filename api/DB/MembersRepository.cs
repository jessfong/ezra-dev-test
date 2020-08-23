using EzraTest.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EzraTest.DB
{
    public class MembersRepository : IMembersRepository
    {
        private string _connectionString;

        public MembersRepository() : this("app.db") { }

        public MembersRepository(string connectionString)
        {
            _connectionString = $"Data Source={connectionString}";
        }

        /// <inheritdoc />
        public IEnumerable<Member> GetMembers()
        {
            return ExecuteQuery("SELECT * FROM MEMBERS", null, (reader) =>
            {
                return new Member
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2)
                };
            });
        }

        /// <inheritdoc />
        public Member GetMember(string id)
        {
            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@ID", id)
            };

            return ExecuteQuery($"SELECT * FROM MEMBERS WHERE ID = @ID", parameters, (reader) =>
            {
                return new Member
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2)
                };
            }).FirstOrDefault();
        }

        /// <inheritdoc />
        public void AddMember(Member member)
        {
            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@ID", member.Id),
                new SqliteParameter("@Name", member.Name),
                new SqliteParameter("@Email", member.Email)
            };

            ExecuteNonQuery($"INSERT INTO MEMBERS (ID, Name, Email) VALUES (@ID, @Name, @Email)", parameters);
        }

        /// <inheritdoc />
        public void UpdateMember(string id, Member member)
        {
            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@ID", id),
                new SqliteParameter("@Name", member.Name),
                new SqliteParameter("@Email", member.Email)
            };

            ExecuteNonQuery($"UPDATE MEMBERS SET NAME = @Name, EMAIL = @Email WHERE ID = @ID", parameters);
        }

        /// <inheritdoc />
        public void DeleteMember(string id)
        {
            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@ID", id)
            };

            ExecuteNonQuery($"DELETE FROM MEMBERS WHERE ID = @ID", parameters);
        }

        private IEnumerable<T> ExecuteQuery<T>(string commandText, SqliteParameter[] parameters, Func<SqliteDataReader, T> func)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = commandText;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                    command.Prepare();
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return func(reader);
                    }
                }
            }
        }

        private void ExecuteNonQuery(string commandText, SqliteParameter[] parameters)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = commandText;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                    command.Prepare();
                }

                command.ExecuteNonQuery();
            }
        }
    }
}