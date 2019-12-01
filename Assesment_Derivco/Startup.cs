using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment.Core.DataAccessLayer;
using Assesment.Core.Interfaces;
using Assesment.Core.Interfaces.DataAccess;
using Assesment.Core.Services;
using Assessment.Core.DataAccessLayer;
using Assessment.Core.Interfaces.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Assesment_Derivco
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
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IUserDataSource), typeof(UserDataSource));
            services.AddScoped(typeof(IQueueConfiguration), typeof(QueueConfiguration));
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
                //useExceptionHandler 
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
