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

namespace WSPro.Backend.GraphQL.Operations.OtherWorkOption
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationOtherWorkOption:MapperInjection,IGraphQlOperation
    {
        public MutationOtherWorkOption(IMapper mapper) : base(mapper)
        {
        }
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.OtherWorkOption>> CreateOtherWorkOption(CreateOtherWorkOptionDto input,
            [Service] IOtherWorkOptionRepository repository)
        {
            var element = Mapper.Map<Domain.Model.OtherWorkOption>(input);
            return repository.CreateAsync(element);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.OtherWorkOption>> UpdateOtherWorkOption(int id, UpdateOtherWorkOptionDto input,
            [Service] IOtherWorkOptionRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }

        [UseProjection]
        public async Task<Domain.Model.OtherWorkOption> DeleteOtherWorkOption(int id, [Service] IOtherWorkOptionRepository repository)
        {
            var model = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}