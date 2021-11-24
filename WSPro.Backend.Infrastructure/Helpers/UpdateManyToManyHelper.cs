using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WSPro.Backend.Infrastructure.Helpers
{
    public static class Helper
    {
        public static IEnumerable<TEntity> LeftComplementRight<TEntity, TKey>(
            this IEnumerable<TEntity> left,
            IEnumerable<TEntity> right,
            Func<TEntity, TKey> keyRetrievalFunction)
        {
            var leftSet = left.ToList();
            var rightSet = right.ToList();

            var leftSetKeys = leftSet.Select(keyRetrievalFunction);
            var rightSetKeys = rightSet.Select(keyRetrievalFunction);

            var deltaKeys = leftSetKeys.Except(rightSetKeys);
            var leftComplementRightSet = leftSet.Where(i => deltaKeys.Contains(keyRetrievalFunction.Invoke(i)));
            return leftComplementRightSet;
        }
        
        public static void UpdateManyToMany<TDependentEntity, TKey>(
            this DbContext Context,
            IEnumerable<TDependentEntity> dbEntries,
            IEnumerable<TDependentEntity> updatedEntries,
            Func<TDependentEntity, TKey> keyRetrievalFunction)
            where TDependentEntity : class
        {
            var oldItems = dbEntries.ToList();
            var newItems = updatedEntries.ToList();
            var toBeRemoved = oldItems.LeftComplementRight(newItems, keyRetrievalFunction);
            var toBeAdded = newItems.LeftComplementRight(oldItems, keyRetrievalFunction);
            // var toBeUpdated = oldItems.Intersect(newItems, keyRetrievalFunction);

            Context.Set<TDependentEntity>().RemoveRange(toBeRemoved);
            Context.Set<TDependentEntity>().AddRange(toBeAdded);
            // foreach (var entity in toBeUpdated)
            // {
            //     var changed = newItems.Single(i => keyRetrievalFunction.Invoke(i).Equals(keyRetrievalFunction.Invoke(entity)));
            //     Context.Entry(entity).CurrentValues.SetValues(changed);
            // }
        }
        public static IEnumerable<TEntity> Intersect<TEntity, TKey>(
            this IEnumerable<TEntity> left,
            IEnumerable<TEntity> right,
            Func<TEntity, TKey> keyRetrievalFunction)
        {
            var leftSet = left.ToList();
            var rightSet = right.ToList();

            var leftSetKeys = leftSet.Select(keyRetrievalFunction);
            var rightSetKeys = rightSet.Select(keyRetrievalFunction);

            var intersectKeys = leftSetKeys.Intersect(rightSetKeys);
            var intersectionEntities = leftSet.Where(i => intersectKeys.Contains(keyRetrievalFunction.Invoke(i)));
            return intersectionEntities;
        }
    }
}