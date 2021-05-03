using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the Cart class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class Cart
    {
        #region Data members

        private const string CartKey = "mycart";
        private const string CountKey = "mycount";

        #endregion

        #region Properties

        private List<CartItem> Items { get; set; }
        private List<CartItemDTO> StoredItems { get; set; }

        /// <summary>
        ///     Gets or sets the session.
        /// </summary>
        /// <value>
        ///     The session.
        /// </value>
        private ISession Session { get; }

        /// <summary>
        ///     Gets or sets the request cookies.
        /// </summary>
        /// <value>
        ///     The request cookies.
        /// </value>
        private IRequestCookieCollection RequestCookies { get; }

        /// <summary>
        ///     Gets or sets the response cookies.
        /// </summary>
        /// <value>
        ///     The response cookies.
        /// </value>
        private IResponseCookies ResponseCookies { get; }

        /// <summary>
        ///     Gets the subtotal.
        /// </summary>
        /// <value>
        ///     The subtotal.
        /// </value>
        public double Subtotal => this.Items.Sum(i => i.Subtotal);

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        public int? Count => this.Session.GetInt32(CountKey) ?? this.RequestCookies.GetInt32(CountKey);

        /// <summary>
        ///     Gets the list.
        /// </summary>
        /// <value>
        ///     The list.
        /// </value>
        public IEnumerable<CartItem> List => this.Items;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Cart" /> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public Cart(HttpContext ctx)
        {
            this.Session = ctx.Session;
            this.RequestCookies = ctx.Request.Cookies;
            this.ResponseCookies = ctx.Response.Cookies;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Loads the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Load(Repository<OfficeProduct> data)
        {
            this.Items = this.Session.GetObject<List<CartItem>>(CartKey);
            if (this.Items == null)
            {
                this.Items = new List<CartItem>();
                this.StoredItems = this.RequestCookies.GetObject<List<CartItemDTO>>(CartKey);
            }

            if (this.StoredItems?.Count > this.Items?.Count)
            {
                foreach (var storedItem in this.StoredItems)
                {
                    var book = data.Get(new QueryOptions<OfficeProduct> {
                        Include = "Type",
                        Where = b => b.OfficeProductId == storedItem.OfficeProductId
                    });
                    if (book != null)
                    {
                        var dto = new OfficeProductDTO();
                        dto.Load(book);

                        var item = new CartItem {
                            Product = dto,
                            Quantity = storedItem.Quantity
                        };
                        this.Items.Add(item);
                    }
                }

                this.Save();
            }
        }

        /// <summary>
        ///     Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CartItem GetById(int id)
        {
            return this.Items.FirstOrDefault(ci => ci.Product.OfficeProductId == id);
        }

        /// <summary>
        ///     Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(CartItem item)
        {
            var itemInCart = this.GetById(item.Product.OfficeProductId);

            if (itemInCart == null)
            {
                this.Items.Add(item);
            }
            else
            {
                itemInCart.Quantity += 1;
            }
        }

        /// <summary>
        ///     Edits the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Edit(CartItem item)
        {
            var itemInCart = this.GetById(item.Product.OfficeProductId);
            if (itemInCart != null)
            {
                itemInCart.Quantity = item.Quantity;
            }
        }

        /// <summary>
        ///     Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Remove(CartItem item)
        {
            this.Items.Remove(item);
        }

        /// <summary>
        ///     Clears this instance.
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        public void Save()
        {
            if (this.Items.Count == 0)
            {
                this.Session.Remove(CartKey);
                this.Session.Remove(CountKey);
                this.ResponseCookies.Delete(CartKey);
                this.ResponseCookies.Delete(CountKey);
            }
            else
            {
                this.Session.SetObject(CartKey, this.Items);
                this.Session.SetInt32(CountKey, this.Items.Count);
                this.ResponseCookies.SetObject(CartKey, this.Items.ToDTO());
                this.ResponseCookies.SetInt32(CountKey, this.Items.Count);
            }
        }

        #endregion
    }
}