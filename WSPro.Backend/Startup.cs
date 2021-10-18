using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WSPro.Backend.GraphQL;
using WSPro.Backend.GraphQL.Crane;
using WSPro.Backend.GraphQL.Element;
using WSPro.Backend.GraphQL.Project;
using WSPro.Backend.GraphQL.Utils;
using WSPro.Backend.Infrastructure;

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
            services.AddPooledDbContextFactory<WSProContext>(opt =>
                opt.UseNpgsql(_configuration.GetConnectionString("WSProDB"),
                    b => b.MigrationsAssembly("WSPro.Backend")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<QueryCrane>()
                .AddType<QueryProject>()
                .AddType<QueryElement>()
                .AddMutationType<Mutation>()
                .AddType<MutationCrane>()
                .AddErrorFilter<GraphQLErrorFilter>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
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