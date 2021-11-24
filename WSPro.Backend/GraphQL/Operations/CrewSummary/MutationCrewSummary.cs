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

namespace WSPro.Backend.GraphQL.Operations.CrewSummary
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrewSummary: MapperInjection, IGraphQlOperation
    {
        public MutationCrewSummary(IMapper mapper) : base(mapper)
        {
        }
        
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.CrewSummary>> CreateCrewSummary(CreateCrewSummaryDto input,
            [Service] ICrewSummaryRepository repository)
        {
            var element = Mapper.Map<Domain.Model.CrewSummary>(input);
            return repository.CreateAsync(element);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.CrewSummary>> UpdateCrewSummary(int id, UpdateCrewSummaryDto input,
            [Service] ICrewSummaryRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }
        
        // todo AddWorkerToCrewSummary

        [UseProjection]
        public async Task<Domain.Model.CrewSummary> DeleteCrewSummary(int id, 
            [Service] ICrewSummaryRepository repository,IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}