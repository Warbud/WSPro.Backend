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

namespace WSPro.Backend.GraphQL.Operations.GroupedOtherWorkTimeEvidence
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationGroupedOtherWorkTimeEvidence:MapperInjection,IGraphQlOperation
    {
        public MutationGroupedOtherWorkTimeEvidence(IMapper mapper) : base(mapper)
        {
        }
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.GroupedOtherWorkTimeEvidence>> CreateGroupedOtherWorkTimeEvidence(CreateGroupedOtherWorkTimeEvidenceDto input,
            [Service] IGroupedOtherWorkTimeEvidenceRepository repository)
        {
            var element = Mapper.Map<Domain.Model.GroupedOtherWorkTimeEvidence>(input);
            return repository.CreateAsync(element);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.GroupedOtherWorkTimeEvidence>> UpdateGroupedOtherWorkTimeEvidence(int id, UpdateGroupedOtherWorkTimeEvidenceDto input,
            [Service] IGroupedOtherWorkTimeEvidenceRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }

        [UseProjection]
        public async Task<Domain.Model.GroupedOtherWorkTimeEvidence> DeleteGroupedOtherWorkTimeEvidence(int id,
            [Service] IGroupedOtherWorkTimeEvidenceRepository repository,
            IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}