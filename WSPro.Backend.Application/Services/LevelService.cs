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
    public class LevelService:ILevelService
    {
        
        private readonly ILevelRepository _repository;
        private readonly IValidator<CreateLevelDto> _createValidator;
        public LevelService(ILevelRepository repository,IValidator<CreateLevelDto> createValidator)
        {
            this._repository = repository;
            this._createValidator = createValidator;
        }
        
        public Task<Level> GetByIdAsync(GetLevelDto data)
        {
            var level = new Level() { Id = data.Id };
            return _repository.GetByIdAsync(level);
        }

        public Task<IQueryable<Level>> GetAllLevelsAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Level> CreateAsync(CreateLevelDto data, CancellationToken cancellationToken)
        {
            await _createValidator.ValidateAndThrowAsync(data, cancellationToken);
            var level = new Level() { Name = data.Name };
            return await _repository.CreateAsync(level);
        }

        public async Task<Level[]> CreateManyAsync(CreateLevelDto[] data, CancellationToken cancellationToken)
        {
            var tasks = new List<Task>();
            foreach (var dto in data)
            {
                tasks.Add(_createValidator.ValidateAndThrowAsync(dto, cancellationToken));
            }
            await Task.WhenAll(tasks);

            var levels = data.Select(d => new Level() { Name = d.Name }).ToArray();
            return await _repository.CreateRangeAsync(levels);

        }

        public async Task<Level> UpdateAsync(GetLevelDto input, CreateLevelDto data, CancellationToken cancellationToken)
        {
            await _createValidator.ValidateAndThrowAsync(data, cancellationToken);
            var level = new Level() { Id = input.Id, Name = data.Name };
            var exist = await _repository.LevelExistAsync(level);
            if (!exist)
                throw new Exception("Level does not exist");

            return await _repository.UpdateAsync(level);
        }

        public async Task<Level> DeleteAsync(GetLevelDto input, CancellationToken cancellationToken)
        {
            var level = await _repository.GetByIdAsync(new Level() { Id = input.Id });
            if (level == null)
                throw new Exception("Level does not exist");

            return await _repository.DeleteAsync(level);
            
        }
    }
}