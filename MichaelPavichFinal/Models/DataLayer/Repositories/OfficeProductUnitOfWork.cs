using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Models
{
    public class OfficeProductUnitOfWork : IOfficeProductUnitOfWork
    {
        private OfficeProductContext context { get; set; }
        public OfficeProductUnitOfWork(OfficeProductContext ctx) => context = ctx;

        private Repository<OfficeProduct> productData;

        public Repository<OfficeProduct> Products
        {
            get
            {
                if (this.productData == null)
                {
                    this.productData = new Repository<OfficeProduct>(context);
                }

                return this.productData;
            }
        }

        private Repository<ProductType> typeData;

        public Repository<ProductType> Types
        {
            get
            {
                if (this.typeData == null)
                {
                    this.typeData = new Repository<ProductType>(context);
                }

                return this.typeData;
            }
        }

        private Repository<Image> imageData;

        public Repository<Image> Images
        {
            get
            {
                if (this.imageData == null)
                {
                    this.imageData = new Repository<Image>(context);
                }

                return this.imageData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
