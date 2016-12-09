using System;

namespace WolfPack.ILoveBeer.Domain.Entities
{
    public abstract class EntityBase
    {
        #region Public Properties

        public Guid Id { get; private set; }

        #endregion Public Properties

        #region Protected Constructors

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        protected EntityBase(Guid id)
        {
            Id = id;
        }

        #endregion Protected Constructors
    }
}