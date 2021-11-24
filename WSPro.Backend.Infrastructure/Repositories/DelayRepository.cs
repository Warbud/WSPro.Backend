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
    public class DelayRepository:DbContextInjection,IDelayRepository
    {
        public DelayRepository(WSProContext context,IMapper mapper) : base(context)
        {
            Mapper = mapper;
        }
        public readonly IMapper Mapper;
        public Task<bool> ExistAsync(int id)
        {
            return Context.Delays.AnyAsync(e => e.Id == id);
        }

        public Task<IQueryable<Delay>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Delay>>(Context.Delays);
        }

        public async Task<IQueryable<Delay>> GetByIdAsync(int id)
        {
            return Context.Delays.Where(e => e.Id == id);
        }

        public async Task<IQueryable<Delay>> CreateAsync(Delay item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<Delay>> UpdateAsync(Delay item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(Delay item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public async Task<IQueryable<Delay>> UpdateAsync(Delay item, UpdateDelayDto dto)
        {
            item.AttachEntities(Context);
            Mapper.Map(dto, item);
            
            // edit delayCauses refereces
            var delayDelayCauseDto = dto.DelayCauses != null
                ? Mapper.Map<ICollection<Delay_DelayCause>>(dto.DelayCauses)
                : new List<Delay_DelayCause>();
            delayDelayCauseDto.ToList().ForEach(e=>e.DelayId = item.Id);
            
            Context.UpdateManyToMany(item.DelayDelayCause,
                delayDelayCauseDto, 
                cause =>new {cause.DelayCauseId,cause.DelayId});

            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }
    }
}