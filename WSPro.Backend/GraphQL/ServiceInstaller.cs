using System.Linq;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Authorization;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.GraphQL.Utils;

namespace WSPro.Backend.GraphQL
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallGraphQlServices(this IServiceCollection service)
        {
            var graphqlService = service.AddGraphQLServer();
            graphqlService
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<UploadType>();

            foreach (var type in typeof(Query).Assembly.GetTypes().OrderBy(e => e.Name))
                if (type.GetInterface(typeof(IGraphQlOperation).Name) != null)
                {
                    service.AddScoped(type);
                    graphqlService.AddTypeExtension(type);
                }

            graphqlService.AddErrorFilter<GraphQLErrorFilter>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddAuthorization();
            return service;
        }
    }
}