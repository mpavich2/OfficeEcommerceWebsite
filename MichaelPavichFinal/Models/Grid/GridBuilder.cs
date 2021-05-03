using Microsoft.AspNetCore.Http;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the GridBuilder class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class GridBuilder
    {
        #region Data members

        /// <summary>
        ///     The route key
        /// </summary>
        protected const string RouteKey = "currentroute";

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the routes.
        /// </summary>
        /// <value>
        ///     The routes.
        /// </value>
        protected RouteDictionary Routes { get; set; }

        /// <summary>
        ///     Gets or sets the session.
        /// </summary>
        /// <value>
        ///     The session.
        /// </value>
        protected ISession Session { get; set; }

        /// <summary>
        ///     Gets the current route.
        /// </summary>
        /// <value>
        ///     The current route.
        /// </value>
        public RouteDictionary CurrentRoute => this.Routes;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GridBuilder" /> class.
        /// </summary>
        /// <param name="sess">The sess.</param>
        public GridBuilder(ISession sess)
        {
            this.Session = sess;
            this.Routes = this.Session.GetObject<RouteDictionary>(RouteKey) ?? new RouteDictionary();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GridBuilder" /> class.
        /// </summary>
        /// <param name="sess">The sess.</param>
        /// <param name="values">The values.</param>
        /// <param name="defaultSortField">The default sort field.</param>
        public GridBuilder(ISession sess, GridDTO values, string defaultSortField)
        {
            this.Session = sess;

            this.Routes = new RouteDictionary();
            this.Routes.PageNumber = values.PageNumber;
            this.Routes.PageSize = values.PageSize;
            this.Routes.SortField = values.SortField ?? defaultSortField;
            this.Routes.SortDirection = values.SortDirection;

            this.SaveRouteSegments();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Saves the route segments.
        /// </summary>
        public void SaveRouteSegments()
        {
            this.Session.SetObject(RouteKey, this.Routes);
        }

        /// <summary>
        ///     Gets the total pages.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public int GetTotalPages(int count)
        {
            var size = this.Routes.PageSize;
            return (count + size - 1) / size;
        }

        #endregion
    }
}