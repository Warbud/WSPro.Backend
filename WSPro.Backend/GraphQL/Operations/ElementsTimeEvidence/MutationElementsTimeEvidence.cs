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

namespace WSPro.Backend.GraphQL.Operations.ElementsTimeEvidence
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationElementsTimeEvidence:MapperInjection,IGraphQlOperation
    {
        public MutationElementsTimeEvidence(IMapper mapper) : base(mapper)
        {
        }
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.ElementsTimeEvidence>> CreateElementsTimeEvidence(CreateElementsTimeEvidenceDto input,
            [Service] IElementsTimeEvidenceRepository repository)
        {
            var element = Mapper.Map<Domain.Model.ElementsTimeEvidence>(input);
            return repository.CreateAsync(element);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.ElementsTimeEvidence>> UpdateElementsTimeEvidence(int id, UpdateElementsTimeEvidenceDto input,
            [Service] IElementsTimeEvidenceRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id))
                .Include(e=>e.ElementElementsTimeEvidence)
                .FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            // Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing,input);
        }

        [UseProjection]
        public async Task<Domain.Model.ElementsTimeEvidence> DeleteElementsTimeEvidence(int id, 
            [Service] IElementsTimeEvidenceRepository repository,
            IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}