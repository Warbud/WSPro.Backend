using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;
using WSPro.Backend.Utils.Exceptions;

namespace WSPro.Backend.GraphQL.Operations.Crane
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrane : MapperInjection, IGraphQlOperation
    {
        public MutationCrane(IMapper mapper) : base(mapper)
        {
        }

        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Crane>> CreateCrane(CreateCraneDto input,
            [Service] ICraneRepository craneRepository)
        {
            var crane = Mapper.Map<Domain.Model.Crane>(input);
            return craneRepository.CreateAsync(crane);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.Crane>> UpdateCrane(int id, UpdateCraneDto input,
            [Service] ICraneRepository craneRepository)
        {
            var existing = await (await craneRepository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await craneRepository.UpdateAsync(existing);
        }
        
        public async Task<Domain.Model.Crane> DeleteCrane(int id, [Service] ICraneRepository craneRepository)
        {
            var crane = await (await craneRepository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (crane is null) throw new NotExistException(id);
            await craneRepository.DeleteAsync(crane);
            return crane;
        }
    }
}