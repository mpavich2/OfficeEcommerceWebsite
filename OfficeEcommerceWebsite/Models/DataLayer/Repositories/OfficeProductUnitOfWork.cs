namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the OfficeProductUnitOfWork class. Implements the IOfficeProductUnitOfWork interface.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="MichaelPavichFinal.Models.IOfficeProductUnitOfWork" />
    public class OfficeProductUnitOfWork : IOfficeProductUnitOfWork
    {
        #region Data members

        private Repository<OfficeProduct> productData;

        private Repository<ProductType> typeData;

        private Repository<Image> imageData;

        #endregion

        #region Properties

        private OfficeProductContext Context { get; }

        /// <summary>
        ///     Gets the products.
        /// </summary>
        /// <value>
        ///     The products.
        /// </value>
        public Repository<OfficeProduct> Products
        {
            get
            {
                if (this.productData == null)
                {
                    this.productData = new Repository<OfficeProduct>(this.Context);
                }

                return this.productData;
            }
        }

        /// <summary>
        ///     Gets the types.
        /// </summary>
        /// <value>
        ///     The types.
        /// </value>
        public Repository<ProductType> Types
        {
            get
            {
                if (this.typeData == null)
                {
                    this.typeData = new Repository<ProductType>(this.Context);
                }

                return this.typeData;
            }
        }

        /// <summary>
        ///     Gets the images.
        /// </summary>
        /// <value>
        ///     The images.
        /// </value>
        public Repository<Image> Images
        {
            get
            {
                if (this.imageData == null)
                {
                    this.imageData = new Repository<Image>(this.Context);
                }

                return this.imageData;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OfficeProductUnitOfWork" /> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public OfficeProductUnitOfWork(OfficeProductContext ctx)
        {
            this.Context = ctx;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        public void Save()
        {
            this.Context.SaveChanges();
        }

        #endregion
    }
}