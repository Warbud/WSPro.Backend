using HotChocolate;

namespace WSPro.Backend.GraphQL.Utils
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Exception.Message);
        }
    }
}