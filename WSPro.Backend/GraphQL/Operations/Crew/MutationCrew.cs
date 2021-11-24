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

namespace WSPro.Backend.GraphQL.Operations.Crew
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrew : MapperInjection, IGraphQlOperation
    {
        public MutationCrew(IMapper mapper) : base(mapper)
        {
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.Crew>> CreateCrew(CreateCrewDto input,
            [Service] ICrewRepository repository)
        {
            // todo validator 
            var data = Mapper.Map<Domain.Model.Crew>(input);

            return await repository.CreateAsync(data);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.Crew>> UpdateCrew(int id, UpdateCrewDto input,
            [Service] ICrewRepository repository, IResolverContext context)
        {
            var existing = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }

        public async Task<Entity> DeleteCrew(int id, [Service] ICrewRepository repository, IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return new Entity(id);
        }
    }
}