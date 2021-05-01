using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models.DomainModels;

namespace MichaelPavichFinal.Models
{
    public interface IOfficeProductUnitOfWork
    {
        Repository<OfficeProduct> Products { get; }
        Repository<ProductType> Types { get; }

        void Save();
    }
}
