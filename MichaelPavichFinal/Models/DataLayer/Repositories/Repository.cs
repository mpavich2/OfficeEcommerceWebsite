using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the Repository class. Implements the IRepository interface.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MichaelPavichFinal.Models.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Data members

        private int? count;

        #endregion

        #region Properties

        protected OfficeProductContext Context { get; set; }
        private DbSet<T> Dbset { get; }

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        public int Count => this.count ?? this.Dbset.Count();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public Repository(OfficeProductContext ctx)
        {
            this.Context = ctx;
            this.Dbset = this.Context.Set<T>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Lists the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> List(QueryOptions<T> options)
        {
            var query = this.buildQuery(options);
            return query.ToList();
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            return this.Dbset.Find(id);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T Get(string id)
        {
            return this.Dbset.Find(id);
        }

        /// <summary>
        ///     Gets the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public virtual T Get(QueryOptions<T> options)
        {
            var query = this.buildQuery(options);
            return query.FirstOrDefault();
        }

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(T entity)
        {
            this.Dbset.Add(entity);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(T entity)
        {
            this.Dbset.Update(entity);
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            this.Dbset.Remove(entity);
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        public virtual void Save()
        {
            this.Context.SaveChanges();
        }

        private IQueryable<T> buildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = this.Dbset;
            foreach (var include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            if (options.HasWhere)
            {
                foreach (var clause in options.WhereClauses)
                {
                    query = query.Where(clause);
                }

                this.count = query.Count();
            }

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                {
                    query = query.OrderBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(options.OrderBy);
                }
            }

            if (options.HasPaging)
            {
                query = query.PageBy(options.PageNumber, options.PageSize);
            }

            return query;
        }

        #endregion
    }
}