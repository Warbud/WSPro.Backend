using FluentValidation;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;
using WSPro.Backend.Domain.ServiceInstallers;
using WSPro.Backend.Domain.Validators.V1;
using WSPro.Backend.GraphQL;
using WSPro.Backend.GraphQL.Crane;
using WSPro.Backend.GraphQL.Utils;
using WSPro.Backend.Infrastructure;
using WSPro.Backend.Infrastructure.Repositories;

namespace WSPro.Backend
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) // dependency injection
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddDbContextPool<WSProContext>(opt =>
                    opt.UseNpgsql(_configuration.GetConnectionString("WSProDB"),
                        b => b.MigrationsAssembly("WSPro.Backend")))
                .InstallDomainServices()
                .InstallInfrastructureServices()
                .InstallGraphQlServices();
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

            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            });
        }
    }
}