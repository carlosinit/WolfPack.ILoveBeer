using System.Collections.Generic;
using WolfPack.ILoveBeer.Domain.Entities;

namespace WolfPack.ILoveBeer.Infrastructure.Persistence.Contracts
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
    }
}
