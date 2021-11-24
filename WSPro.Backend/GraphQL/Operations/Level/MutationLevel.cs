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

namespace WSPro.Backend.GraphQL.Operations.Level
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationLevel : MapperInjection, IGraphQlOperation
    {
        public MutationLevel(IMapper mapper) : base(mapper)
        {
        }

        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Level>> CreateLevel(CreateLevelDto input, [Service] ILevelRepository levelRepository)
        {
            var level = Mapper.Map<Domain.Model.Level>(input);
            return levelRepository.CreateAsync(level);
        }
        
        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.Level>> UpdateLevel(int id, UpdateLevelDto input,
            [Service] ILevelRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }
        
        public async Task<Domain.Model.Level> DeleteLevel(int id, [Service] ILevelRepository repository)
        {
            var data = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (data is null) throw new NotExistException(id);
            await repository.DeleteAsync(data);
            return data;
        }
    }
}