using System.Collections.Generic;
using WSPro.Backend.Extensions.DataImporter.Interfaces;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress
{
    public class General : IDataImporter
    {
        public Dictionary<string, int> Created { get; set; } = new();
        public Dictionary<string, int> Updated { get; set; } = new();

        private readonly IProjectRepository _projectRepository;
        private readonly IElementRepository _elementRepository;

        public General(IProjectRepository projectRepository, IElementRepository elementRepository)
        {
            _projectRepository = projectRepository;
            _elementRepository = elementRepository;
        }
        
    }
}