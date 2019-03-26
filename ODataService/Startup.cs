using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using ODataService.Models;

namespace ODataService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(b =>
            {
                b.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var documents = builder.EntitySet<BaseDocument>("Documents");
            var customers = builder.EntitySet<Customer>("Customers");
            var orders = builder.EntitySet<Order>("Orders");
            var contracts = builder.EntitySet<Contract>("Contracts");
            var products = builder.EntitySet<Product>("Products");
            var orderDetails = builder.EntitySet<OrderDetail>("OrderDetails");

            documents.EntityType.HasKey(t => t.ID);
            customers.EntityType.HasKey(t => t.CustomerID);
            products.EntityType.HasKey(t => t.ProductID);
            orderDetails.EntityType.HasKey(t => t.OrderDetailID);
            orders.EntityType.DerivesFrom<BaseDocument>();
            contracts.EntityType.DerivesFrom<BaseDocument>();

            builder.Action("InitializeDatabase");
            builder.Function("TotalSalesByYear")
                .Returns<decimal>()
                .Parameter<int>("year");

            return builder.GetEdmModel();
        }
    }
}
