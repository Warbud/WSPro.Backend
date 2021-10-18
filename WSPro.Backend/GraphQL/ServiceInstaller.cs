using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.GraphQL.Crane;
using WSPro.Backend.GraphQL.Utils;

namespace WSPro.Backend.GraphQL
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallGraphQlServices(this IServiceCollection service)
        {
            service.AddScoped<Query>()
                .AddScoped<QueryCrane>()
                .AddScoped<Mutation>()
                .AddScoped<MutationCrane>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddTypeExtension<QueryCrane>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<MutationCrane>()
                .AddErrorFilter<GraphQLErrorFilter>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
            return service;
        }
    }
}