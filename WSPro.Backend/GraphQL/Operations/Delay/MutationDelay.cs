using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.Projections.Expressions;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;
using WSPro.Backend.Utils.Exceptions;

namespace WSPro.Backend.GraphQL.Operations.Delay
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationDelay : MapperInjection, IGraphQlOperation
    {
        public MutationDelay(IMapper mapper) : base(mapper)
        {
        }
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Delay>> CreateDelay(CreateDelayDto input,
            [Service] IDelayRepository repository)
        {
            var element = Mapper.Map<Domain.Model.Delay>(input);
            return repository.CreateAsync(element);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.Delay>> UpdateDelay(int id, UpdateDelayDto input,
            [Service] IDelayRepository repository,IResolverContext context)
        {
            var existing = await (await repository.GetByIdAsync(id))
                .Include(e=>e.DelayDelayCause)
                .FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            return await repository.UpdateAsync(existing,input);
        }
        
        [UseProjection]
        public async Task<Domain.Model.Delay> DeleteDelay(int id, [Service] IDelayRepository repository,IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}