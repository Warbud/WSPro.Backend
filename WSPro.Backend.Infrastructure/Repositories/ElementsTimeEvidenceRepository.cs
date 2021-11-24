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
    public class ElementsTimeEvidenceRepository:DbContextInjection,IElementsTimeEvidenceRepository
    {
        public readonly IMapper Mapper;
        public ElementsTimeEvidenceRepository(WSProContext context,IMapper mapper) : base(context)
        {
            Mapper = mapper;
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.ElementsTimeEvidences.AnyAsync(e => e.Id == id);;
        }

        public Task<IQueryable<ElementsTimeEvidence>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<ElementsTimeEvidence>>(Context.ElementsTimeEvidences);
            ;
        }

        public async Task<IQueryable<ElementsTimeEvidence>> GetByIdAsync(int id)
        {
            return Context.ElementsTimeEvidences.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<ElementsTimeEvidence>> CreateAsync(ElementsTimeEvidence item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);;
        }

        public async Task<IQueryable<ElementsTimeEvidence>> UpdateAsync(ElementsTimeEvidence item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);;
        }

        public async Task DeleteAsync(ElementsTimeEvidence item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
            
        }

        public async Task<IQueryable<ElementsTimeEvidence>> UpdateAsync(ElementsTimeEvidence existing, UpdateElementsTimeEvidenceDto dto)
        {
            Mapper.Map(dto, existing);
            existing.AttachEntities(Context);

            // edit elements reference
            var elementElementsTimeEvidencesDto = dto.Elements != null
                ? Mapper.Map<ICollection<Element_ElementsTimeEvidence>>(dto.Elements)
                : new List<Element_ElementsTimeEvidence>();
            elementElementsTimeEvidencesDto.ToList().ForEach(e=>e.ElementsTimeEvidenceId=existing.Id);

            Context.UpdateManyToMany(existing.ElementElementsTimeEvidence,
                elementElementsTimeEvidencesDto,
                e=>new {e.ElementId,e.ElementsTimeEvidenceId});

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