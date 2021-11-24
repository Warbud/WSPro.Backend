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

namespace WSPro.Backend.GraphQL.Operations.CommentaryElement
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCommentaryElement : MapperInjection, IGraphQlOperation
    {
        public MutationCommentaryElement(IMapper mapper) : base(mapper)
        {
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.CommentaryElement>> CreateCommentaryElement(
            CreateCommentaryElementDto input,
            [Service] ICommentaryElementRepository repository)
        {
            var data = Mapper.Map<Domain.Model.CommentaryElement>(input);
            return await repository.CreateAsync(data);
        }


        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IQueryable<Domain.Model.CommentaryElement>> UpdateCommentaryElement(
            int id,
            UpdateCommentaryElementDto input,
            [Service] ICommentaryElementRepository repository)
        {
            var existing = await (await repository.GetByIdAsync(id))
                .FirstOrDefaultAsync();
            if (existing is null) throw new NotExistException(id);
            Mapper.Map(input, existing);
            return await repository.UpdateAsync(existing);
        }
        
        [UseFirstOrDefault]
        [UseProjection]
        public async Task<Domain.Model.CommentaryElement> DeleteCommentaryElement(int id, [Service] ICommentaryElementRepository repository,IResolverContext context)
        {
            var model = await (await repository.GetByIdAsync(id)).Project(context).FirstOrDefaultAsync();
            if (model is null) throw new NotExistException(id);

            await repository.DeleteAsync(model);
            return model;
        }
    }
}