using System;
using WolfPack.ILoveBeer.Domain.ValueObjects;

namespace WolfPack.ILoveBeer.Domain.Entities
{
    public class Beer : EntityBase
    {
        #region Public Properties

        public string Brand { get; private set; }
        public BeerStyle Style { get; private set; }
        public string SubBrand { get; private set; }
        public BeerType Type { get; private set; }

        #endregion Public Properties

        #region Public Constructors

        public Beer(string brand, string subBrand, BeerStyle style, BeerType type)
        {
            Init(brand, subBrand, style, type);
        }

        public Beer(Guid id, string brand, string subBrand, BeerStyle style, BeerType type)
            : base(id)
        {
            Init(brand, subBrand, style, type);
        }

        #endregion Public Constructors

        #region Private Methods

        private void Init(string brand, string subBrand, BeerStyle style, BeerType type)
        {
            Type = type;
            Style = style;
            Brand = brand;
            SubBrand = subBrand;
        }

        #endregion Private Methods
    }
}