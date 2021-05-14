using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeEcommerceWebsite.Models;

namespace OfficeEcommerceWebsite
{
    /// <summary>
    ///     Defines the startup class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class Startup
    {
        #region Properties

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <value>
        ///     The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Methods

        // Use this method to add services to the container.
        /// <summary>
        ///     Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddDbContext<OfficeProductContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("OfficeProductContext")));

            // add this
            services.AddIdentity<User, IdentityRole>(options =>
                    {
                        options.Password.RequiredLength = 6;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireUppercase = false;
                    }).AddEntityFrameworkStores<OfficeProductContext>()
                    .AddDefaultTokenProviders();
        }

        // Use this method to configure the HTTP request pipeline.
        /// <summary>
        ///     Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // add this
            app.UseAuthorization(); // add this

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                // route for Admin area
                endpoints.MapAreaControllerRoute(
                    "admin",
                    "Admin",
                    "Admin/{controller=Book}/{action=Index}/{id?}");

                // route for paging, sorting, and filtering
                endpoints.MapControllerRoute(
                    "",
                    "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{type}");

                // route for paging and sorting only
                endpoints.MapControllerRoute(
                    "",
                    "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}");

                // default route
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });

            OfficeProductContext.CreateAdminUser(app.ApplicationServices).Wait();
        }

        #endregion
    }
}