using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Models
{
    public interface IOfficeProductUnitOfWork
    {
        Repository<OfficeProduct> Products { get; }
        Repository<ProductType> Types { get; }
        Repository<Image> Images { get; }

        void Save();
    }
}
