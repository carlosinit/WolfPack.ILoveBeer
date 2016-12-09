using System;

namespace WolfPack.ILoveBeer.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        protected EntityBase(Guid id)
        {
            Id = id;
        }
    }
}