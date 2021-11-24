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

namespace WSPro.Backend.GraphQL.Operations.Project
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationProject : MapperInjection, IGraphQlOperation
    {
        public MutationProject(IMapper mapper) : base(mapper)
        {
        }

        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Project>> CreateProject(CreateProjectDto input,
            [Service] IProjectRepository repository)
        {
            // todo validator
            var createdProject = Mapper.Map<Domain.Model.Project>(input);
            return repository.CreateAsync(createdProject);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.Project>> UpdateProject(int id, UpdateProjectDto input,
            [Service] IProjectRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }

        [UseProjection]
        public async Task<Domain.Model.Project> DeleteProject(int id, [Service] IProjectRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id)).FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            await repository.DeleteAsync(existing);
            return existing;
        }
    }
}