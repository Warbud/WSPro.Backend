using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.GraphQL.Element
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationElement
    {
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public async Task<Domain.Model.V1.Element> CreateElement([ScopedService] WSProContext context,Domain.Model.V1.Element input)
        {
            // var data = new Domain.Model.V1.Element(input.RevitID, input.Project);
            // var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == input.ProjectId);
            //
            // var element = new Model.Element(input.RevitId, project);
            //
            await context.Elements.AddAsync(input);

            // var crane = new Model.Crane(input.Name);
            // await context.Cranes.AddAsync(crane);
            await context.SaveChangesAsync();
            return input;

        }
    }
}