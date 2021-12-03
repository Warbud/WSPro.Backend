using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;
using WSPro.Backend.GraphQL.Helpers;

namespace WSPro.Backend.GraphQL.Operations.User
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationUser:IGraphQlOperation
    {
        public async Task<LoginPayload> Login(LoginInput input, [Service] IUserService userService)
        {
            return await userService.Login(input);
        }
        
        public async Task<RegisterPayload> Register(RegisterInput input, [Service] IUserService userService)
        {
            return await userService.Register(input);
        }
    }
}