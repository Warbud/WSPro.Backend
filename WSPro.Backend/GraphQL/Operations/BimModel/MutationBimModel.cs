using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;
using WSPro.Backend.Utils.Exceptions;

namespace WSPro.Backend.GraphQL.Operations.BimModel
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationBimModel : MapperInjection, IGraphQlOperation
    {
        public MutationBimModel(IMapper mapper) : base(mapper)
        {
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.BimModel>> CreateBimModel(CreateBimModelDto input,
            [Service] IBimModelsRepository repository)
        {
            // todo validator 
            var bimModel = Mapper.Map<Domain.Model.BimModel>(input);

            return await repository.CreateAsync(bimModel);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.BimModel>> UpdateBimModel(int id, UpdateBimModelDto input,
            [Service] IBimModelsRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id))
                .Include(e=>e.BimModelsLevels)
                .Include(e=>e.BimModelsCranes)
                .FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            return await repository.UpdateAsync(existing,input);
        }

        public async Task<Domain.Model.BimModel> DeleteBimModel(int id, [Service] IBimModelsRepository repository)
        {
            var model = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}