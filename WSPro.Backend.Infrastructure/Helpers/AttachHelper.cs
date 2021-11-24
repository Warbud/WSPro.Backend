using System.Collections;
using System.Linq;
using WSPro.Backend.Domain.Helpers;

namespace WSPro.Backend.Infrastructure.Helpers
{
    internal static class AttachHelper
    {
        public static void AttachEntities(this IEntity entity, WSProContext context)
        {
            foreach (var propertyInfo in entity.GetType().GetProperties().Where(e =>
                e.PropertyType.GetInterface(nameof(IEntity)) != null || e.PropertyType.IsGenericType))
            {
                var data = propertyInfo.GetValue(entity);
                if (data != null)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(data.GetType()))
                    {
                        foreach (var val in (IEnumerable)data)
                            if (val != null && !val.GetType().IsEnum)
                                context.Attach(val);
                    }
                    else
                    {
                        if (!data.GetType().IsEnum && data.GetType().IsClass)
                        {
                            context.Attach(data);
                        }
                    }
                }
            }
        }
    }
}