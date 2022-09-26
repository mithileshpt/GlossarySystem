using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Glossary.Application;
using Glossary.Application.terms.command;
using Glossary.Application.terms.command.handler;
using Glossary.Infrastructure.dataAccess;
using Glossary.Infrastructure.steple.CQRS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Glossary.Api
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
            services.AddControllers();
            //services.AddSwaggerGen();
            services.AddDbContext<GlossaryDbContext>(opt =>
             opt.UseSqlite("Filename=Glossary.db", optdb => { 
                 optdb.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
             })
             .EnableSensitiveDataLogging()
             );
            services.AddTransient<ICommandHandler<AddTermDefinationCommand>, AddTermDefinationCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateTermDefinationCommand>, UpdateTermDefinationCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteTermDefinationCommand>, DeleteTermDefinationCommandHandler>();
            services.AddScoped<Messages>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
