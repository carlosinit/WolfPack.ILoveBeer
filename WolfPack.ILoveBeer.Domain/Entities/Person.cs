using System;
using System.Collections.Generic;
using WolfPack.ILoveBeer.Domain.ValueObjects;

namespace WolfPack.ILoveBeer.Domain.Entities
{
    public class Person : EntityBase
    {
        #region Private Fields

        private readonly List<Beer> _lovedBeers = new List<Beer>();

        #endregion Private Fields

        #region Public Properties

        public DateTime BirthDate { get; private set; }
        public string FirstName { get; private set; }
        public Gender Gender { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyCollection<Beer> LovedBeers { get { return _lovedBeers.AsReadOnly(); } }

        #endregion Public Properties

        #region Public Constructors

        public Person(string firstName, string lastName, DateTime birthDate, Gender gender)
        {
            Update(firstName, lastName, birthDate, gender);
        }

        public Person(Guid id, string firstName, string lastName, DateTime birthDate, Gender gender) :
            base(id)
        {
            Update(firstName, lastName, birthDate, gender);
        }

        #endregion Public Constructors

        #region Public Methods

        public void Love(Beer beer)
        {
            if (_lovedBeers.Contains(beer))
            {
                throw new InvalidOperationException("This beer is already loved by this person");
            }
            _lovedBeers.Add(beer);
        }

        public void Update(string firstName, string lastName, DateTime birthDate, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (birthDate == default(DateTime)) throw new ArgumentOutOfRangeException(nameof(birthDate));

            BirthDate = birthDate;
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
        }

        #endregion Public Methods
    }
}