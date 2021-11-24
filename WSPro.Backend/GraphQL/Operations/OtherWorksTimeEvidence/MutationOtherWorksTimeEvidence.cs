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

namespace WSPro.Backend.GraphQL.Operations.OtherWorksTimeEvidence
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationOtherWorksTimeEvidence:MapperInjection,IGraphQlOperation
    {
        public MutationOtherWorksTimeEvidence(IMapper mapper) : base(mapper)
        {
        }
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.OtherWorksTimeEvidence>> CreateOtherWorksTimeEvidence(CreateOtherWorksTimeEvidenceDto input,
            [Service] IOtherWorksTimeEvidenceRepository repository)
        {
            var element = Mapper.Map<Domain.Model.OtherWorksTimeEvidence>(input);
            return repository.CreateAsync(element);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.OtherWorksTimeEvidence>> UpdateOtherWorksTimeEvidence(int id, UpdateOtherWorksTimeEvidenceDto input,
            [Service] IOtherWorksTimeEvidenceRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }

        [UseProjection]
        public async Task<Domain.Model.OtherWorksTimeEvidence> DeleteOtherWorksTimeEvidence(int id, 
            [Service] IOtherWorksTimeEvidenceRepository repository,
            IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}