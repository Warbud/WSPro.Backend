using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WSPro.Backend.Application;
using WSPro.Backend.Domain;
using WSPro.Backend.Extensions;
using WSPro.Backend.GraphQL;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContextPool<WSProContext>(opt =>
                {
                    opt.UseNpgsql(_configuration.GetConnectionString("WSProDB"),
                            b => b.MigrationsAssembly("WSPro.Backend"))
                        .EnableSensitiveDataLogging();
                })
                .InstallDomainServices()
                .InstallInfrastructureServices()
                .InstallApplicationServices()
                .InstallGraphQlServices()
                .InstallExtension();
            // .AddCoreAdmin(); // do ogarnięcia co tu w sumie jest potrzebne


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapGraphQLVoyager("/voyager");
            });
            // app.UseStaticFiles();

            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            });
        }
    }
}