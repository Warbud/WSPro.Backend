using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrane
    {
        private ICraneRepository _repository;
        public MutationCrane(ICraneRepository repository)
        {
            _repository = repository;
        }
        // [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public Task<Domain.Model.V1.Crane> CreateCrane(CreateCraneInput input)
        {
            return _repository.CreateAsync(input.Name);
            // if (!Domain.Model.V1.Crane.IsValidName(input.Name))
            //     throw new Exception("Invalid crane name");
            //
            // var crane = new Domain.Model.V1.Crane(input.Name);
            // await context.Cranes.AddAsync(crane);
            // await context.SaveChangesAsync();
            // return crane;
        }
        
        // [UseDbContext(typeof(WSProContext))]
        // [UseProjection]
        // public async Task<Domain.Model.V1.Crane[]> CreateCraneRange(CreateCraneInput[] input, [ScopedService] WSProContext context)
        // {
        //     Domain.Model.V1.Crane[] craneRange = new Domain.Model.V1.Crane[input.Length];
        //     for (int i = 0; i < input.Length; i++)
        //     {
        //         var craneInput = input[i];
        //         if (!Domain.Model.V1.Crane.IsValidName(craneInput.Name))
        //             throw new Exception("Invalid crane name : " + craneInput.Name);
        //
        //         craneRange.SetValue(new Domain.Model.V1.Crane(craneInput.Name), i);
        //     }
        //     await context.Cranes.AddRangeAsync(craneRange);
        //     await context.SaveChangesAsync();
        //     return craneRange;
        // }
        
        // [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public Task<Domain.Model.V1.Crane> UpdateCrane(GetCraneInput input,UpdateCraneInput data)
        {
            return _repository.UpdateAsync(input.Id, data.Name);

            // var crane = await context.Cranes.FirstOrDefaultAsync(c => c.Id == input.Id);
            // if (crane == null)
            //     throw new Exception("Cannot find crane with id: " + input.Id);
            //
            // if (!Domain.Model.V1.Crane.IsValidName(data.Name))
            //     throw new Exception("Invalid crane name");
            //
            // crane.Name = data.Name;
            // await context.SaveChangesAsync();
            // return crane;
        }
        
        // [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public Task<Domain.Model.V1.Crane> DeleteCrane(GetCraneInput input)
        {
            return _repository.DeleteAsync(input.Id);
            // var crane = await context.Cranes.FirstOrDefaultAsync(c => c.Id == input.Id);
            // if (crane == null)
            //     throw new Exception("Cannot find crane with id: " + input.Id);
            //
            // context.Remove(crane);
            // await context.SaveChangesAsync();
            // return crane;
        }
    
        
    }
}