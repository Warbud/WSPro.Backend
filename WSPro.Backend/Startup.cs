using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WSPro.Backend.Infrastructure;
using WSPro.Backend.Infrastructure.GraphQL;

namespace WSPro.Backend
{
    public class Startup
    {

        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)    // dependency injection
        {
            Configuration = configuration;
        }
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<WSProContext>(opt => 
                opt.UseNpgsql(Configuration.GetConnectionString("WSProDB"),
                    b => b.MigrationsAssembly("WSPro.Backend")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapGraphQLVoyager("/voyager");
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
            });
        }
    }
}