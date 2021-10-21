using System;
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
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IValidator<CreateProjectDto> _validator;

        public ProjectService(IProjectRepository repository, IValidator<CreateProjectDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Task<Project> GetByIdAsync(GetProjectDto data)
        {
            var project = new Project() { Id = data.Id };
            return _repository.GetByIdAsync(project);
        }

        public Task<IQueryable<Project>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Project> CreateAsync(CreateProjectDto data, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(data, cancellationToken);
            var project = new Project() { Name = data.Name, MetodologyCode = data.MetodologyCode, WebconCode = data.WebconCode, CentralScheduleSync = data.CentralScheduleSync};
            return await _repository.CreateAsync(project);
        }

        public async Task<Project> UpdateAsync(GetProjectDto input, CreateProjectDto data, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(data,cancellationToken);
            var project = new Project() { Id = input.Id };
            return await _repository.UpdateAsync(project);
        }

        public Task<Project> DeleteAsync(GetProjectDto input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}