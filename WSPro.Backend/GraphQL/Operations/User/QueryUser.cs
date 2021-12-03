using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;
using WSPro.Backend.GraphQL.Helpers;

namespace WSPro.Backend.GraphQL.Operations.User
{
    [ExtendObjectType(nameof(Query))]
    public class QueryUser : IGraphQlOperation
    {
        [Authorize]
        public async Task<UserPayload> GetMe([Service] IUserService userService)
        {
            return await userService.GetMe<UserPayload>();
        }

        [Authorize]
        public async Task<UserPayload> GetUser([Service] IUserService userService, UserInput input)
        {
            return await userService.GetUser(input);
        }
    }
}