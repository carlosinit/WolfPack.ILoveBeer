﻿using System;

namespace WolfPack.ILoveBeer.Infrastructure.Persistence.Model
{
    internal class PersonPersistence
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int Gender { get; set; }
    }
}