using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using WolfPack.ILoveBeer.Domain.Entities;

namespace WolfPack.ILoveBeer.Infrastructure.Persistence.Tests.Setup
{
    public class DatabaseBuilder
    {
        private const string databaseModuleName = "FakeDatabase";
        private IDbConnection connection;
        private List<IDbCommand> queries = new List<IDbCommand>();

        public DatabaseBuilder()
        {
            connection = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");
        }

        public DatabaseBuilder WithPersonsTable(IEnumerable<Person> persons = null)
        {
            var command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE Persons (" +
                "Id VARCHAR(30) PRIMARY KEY NOT NULL," +
                "FirstName VARCHAR(30) NOT NULL," +
                "LastName VARCHAR(30) NOT NULL," +
                "BirthDate VARCHAR(30) NOT NULL," +
                "Gender INT NOT NULL" +
                ")";
            queries.Add(command);

            foreach (var item in persons ?? Enumerable.Empty<Person>())
            {
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = "INSERT INTO Persons (Id, FirstName, LastName, BirthDate, Gender) VALUES (@Id, @FirstName, @LastName, @BirthDate, @Gender)";
                insertCommand.Parameters.Add(CreateParameter(insertCommand, DbType.String, "@Id", item.Id.ToString()));
                insertCommand.Parameters.Add(CreateParameter(insertCommand, DbType.String, "@FirstName", item.FirstName));
                insertCommand.Parameters.Add(CreateParameter(insertCommand, DbType.String, "@LastName", item.LastName));
                insertCommand.Parameters.Add(CreateParameter(insertCommand, DbType.String, "@BirthDate", item.BirthDate.ToString("yyyyMMdd")));
                insertCommand.Parameters.Add(CreateParameter(insertCommand, DbType.Int32, "@Gender", (int)item.Gender));

                queries.Add(insertCommand);
            }

            return this;
        }

        private static IDbDataParameter CreateParameter(IDbCommand command, DbType type, string name, object value)
        {
            var nameParameter = command.CreateParameter();
            nameParameter.DbType = type;
            nameParameter.ParameterName = name;
            nameParameter.Value = value;
            return nameParameter;
        }

        public IDbConnection Build()
        {
            connection.Open();
            foreach (var query in queries)
            {
                query.ExecuteNonQuery();
            }
            return connection;
        }
    }
}
