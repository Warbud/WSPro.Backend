using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.GraphQL.Crane;
using WSPro.Backend.GraphQL.Level;
using WSPro.Backend.GraphQL.Utils;

namespace WSPro.Backend.GraphQL
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallGraphQlServices(this IServiceCollection service)
        {
            service.AddScoped<Query>()
                .AddScoped<QueryCrane>()
                .AddScoped<QueryLevel>()
                .AddScoped<Mutation>()
                .AddScoped<MutationCrane>()
                .AddScoped<MutationLevel>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddTypeExtension<QueryCrane>()
                .AddTypeExtension<QueryLevel>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<MutationCrane>()
                .AddTypeExtension<MutationLevel>()
                .AddErrorFilter<GraphQLErrorFilter>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
            return service;
        }
    }
}