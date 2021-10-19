using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Application.Services
{
    public class CraneService:ICraneService
    {
        private readonly ICraneRepository _craneRepository;
        private readonly IValidator<CreateCraneDto> _craneDtoValidation;
        
        public CraneService(ICraneRepository craneRepository, IValidator<CreateCraneDto> validator)
        {
            _craneRepository = craneRepository;
            _craneDtoValidation = validator;
        }
        

        public  Task<Crane> GetCraneByID(GetCraneDto data)
        {
            return  _craneRepository.GetByIdAsync(data.Id);
        }

        public  Task<IQueryable<Crane>> GetAllCranes()
        {
            return  _craneRepository.GetAllAsync();
        }

        public async Task<Crane> CreateAsync(CreateCraneDto data, CancellationToken cancellationToken)
        {
            await _craneDtoValidation.ValidateAndThrowAsync(data, cancellationToken);

            var crane = new Crane(){Name = data.Name};
            
            return await _craneRepository.CreateAsync(crane);
        }

        public async Task<Crane[]> CreateManyAsync(CreateCraneDto[] data, CancellationToken cancellationToken)
        {
            var tasks = new List<Task>();
            foreach (var createCraneDto in data)
            {
                tasks.Add(_craneDtoValidation.ValidateAndThrowAsync(createCraneDto, cancellationToken));
            }

            await Task.WhenAll(tasks);    // throw error while sth is not valid
            
            var cranes = data.Select(d => new Crane(){Name = d.Name}).ToArray();
            return await _craneRepository.CreateRangeAsync(cranes);
        }

        public async Task<Crane> UpdateAsync(GetCraneDto input, CreateCraneDto data, CancellationToken cancellationToken)
        {
            await _craneDtoValidation.ValidateAndThrowAsync(data,cancellationToken);
            var crane = new Crane(){Id = input.Id, Name = data.Name};
            
            var exist = await _craneRepository.CraneExistAsync(crane);
            if (!exist)
            {
                throw new Exception("Crane does not exist");
            }
            
            return await _craneRepository.UpdateAsync(crane);
        }

        public async Task<Crane> DeleteAsync(GetCraneDto input, CancellationToken cancellationToken)
        {
            var crane = await _craneRepository.GetByIdAsync(input.Id);
            if (crane == null) 
                throw new Exception("Cannot find crane");
            
            return await _craneRepository.DeleteAsync(crane);
        }
    }
}