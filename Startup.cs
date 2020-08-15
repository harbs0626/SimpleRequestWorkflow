using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleRequestWorkflow.Models;

namespace SimpleRequestWorkflow
{
    public class Startup
    {
        public IConfiguration _Configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            this._Configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(this._Configuration["ConnectionStrings:WorkflowDBConn"]));

            services.AddTransient<IWorkflowRepository, EFWorkflowRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    });

                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
