using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class BimModelRepository : DbContextInjection, IBimModelsRepository
    {
        public BimModelRepository(WSProContext context, IMapper mapper) : base(context)
        {
            Mapper = mapper;
        }

        public readonly IMapper Mapper;

        public Task<bool> ExistAsync(int id)
        {
            return Context.BimModels.AnyAsync(e => e.Id == id);
        }

        public Task<IQueryable<BimModel>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<BimModel>>(Context.BimModels);
        }

        public async Task<IQueryable<BimModel>> GetByIdAsync(int id)
        {
            return Context.BimModels.Where(e => e.Id == id);
        }

        public async Task<IQueryable<BimModel>> CreateAsync(BimModel item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<BimModel>> UpdateAsync(BimModel item)
        {
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(BimModel item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public async Task<IQueryable<BimModel>> UpdateAsync(BimModel existing, UpdateBimModelDto dto)
        {
            existing.AttachEntities(Context);
            Mapper.Map(dto, existing);

            // edit levels references
            var bimModelLevelsDto = dto.Levels != null
                ? Mapper.Map<ICollection<BimModel_Level>>(dto.Levels)
                : new List<BimModel_Level>();
            bimModelLevelsDto.ToList().ForEach(e => e.ModelId = existing.Id);

            Context.UpdateManyToMany(existing.BimModelsLevels, bimModelLevelsDto, e => new { e.ModelId, e.LevelId });

            // edit crane references
            var bimModelCranesDto = dto.Cranes != null
                ? Mapper.Map<ICollection<BimModel_Crane>>(dto.Cranes)
                : new List<BimModel_Crane>();
            bimModelCranesDto.ToList().ForEach(e => e.ModelId = existing.Id);

            Context.UpdateManyToMany(existing.BimModelsCranes, bimModelCranesDto, e => new { e.ModelId, e.CraneId });


            Context.Update(existing);
            foreach (var entityEntry in Context.ChangeTracker.Entries())
            {
                Console.Write(entityEntry.Entity.GetType().Name + "\t-\t");
                Console.WriteLine(entityEntry.State.ToString());
            }

            await Context.SaveChangesAsync();
            return await GetByIdAsync(existing.Id);
        }
    }
}