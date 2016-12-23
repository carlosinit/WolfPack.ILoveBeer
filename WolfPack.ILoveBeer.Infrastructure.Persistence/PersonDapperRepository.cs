using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WolfPack.ILoveBeer.Domain.Entities;
using WolfPack.ILoveBeer.Infrastructure.Persistence.Contracts;
using Dapper;
using WolfPack.ILoveBeer.Domain.ValueObjects;
using WolfPack.ILoveBeer.Infrastructure.Persistence.Model;

namespace WolfPack.ILoveBeer.Infrastructure.Persistence
{
    public class PersonDapperRepository : IPersonRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public PersonDapperRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<Person> GetAll()
        {
            using (var connection = dbConnectionFactory.GetConnection())
            {
                var persons = connection.Query<PersonPersistence>("SELECT * FROM Persons");
                return
                    persons.Select(
                        person =>
                            new Person(Guid.Parse(person.Id), person.FirstName, person.LastName,
                                DateTime.ParseExact(person.BirthDate, "yyyyMMdd", CultureInfo.InvariantCulture),
                                (Gender) person.Gender));
            }
        }
    }
}