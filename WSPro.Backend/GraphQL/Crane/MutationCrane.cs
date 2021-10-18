using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrane
    {
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public async Task<Model.Crane> CreateCrane(CreateCraneInput input, [ScopedService] WSProContext context)
        {
            if (!Model.Crane.IsValidName(input.Name))
                throw new Exception("Invalid crane name");
            
            var crane = new Model.Crane(input.Name);
            await context.Cranes.AddAsync(crane);
            await context.SaveChangesAsync();
            return crane;
        }
        
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public async Task<Model.Crane[]> CreateCraneRange(CreateCraneInput[] input, [ScopedService] WSProContext context)
        {
            Model.Crane[] craneRange = new Model.Crane[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var craneInput = input[i];
                if (!Model.Crane.IsValidName(craneInput.Name))
                    throw new Exception("Invalid crane name : " + craneInput.Name);

                craneRange.SetValue(new Model.Crane(craneInput.Name), i);
            }
            await context.Cranes.AddRangeAsync(craneRange);
            await context.SaveChangesAsync();
            return craneRange;
        }
        
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public async Task<Model.Crane> UpdateCrane(GetCraneInput input,UpdateCraneInput data, [ScopedService] WSProContext context)
        {
            var crane = await context.Cranes.FirstOrDefaultAsync(c => c.Id == input.Id);
            if (crane == null)
                throw new Exception("Cannot find crane with id: " + input.Id);
            
            if (!Model.Crane.IsValidName(data.Name))
                throw new Exception("Invalid crane name");
            
            crane.Name = data.Name;
            await context.SaveChangesAsync();
            return crane;
        }
        
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public async Task<Model.Crane> DeleteCrane(GetCraneInput input, [ScopedService] WSProContext context)
        {
            var crane = await context.Cranes.FirstOrDefaultAsync(c => c.Id == input.Id);
            if (crane == null)
                throw new Exception("Cannot find crane with id: " + input.Id);

            context.Remove(crane);
            await context.SaveChangesAsync();
            return crane;
        }

        
    }
}