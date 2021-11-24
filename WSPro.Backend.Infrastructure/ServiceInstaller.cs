using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Infrastructure.Interfaces;
using WSPro.Backend.Infrastructure.Repositories;

namespace WSPro.Backend.Infrastructure
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IBimModelsRepository, BimModelRepository>()
                .AddScoped<ICommentaryElementRepository, CommentaryElementRepository>()
                .AddScoped<ICraneRepository, CraneRepository>()
                .AddScoped<ICrewRepository, CrewRepository>()
                .AddScoped<ICrewSummaryRepository, CrewSummaryRepository>()
                .AddScoped<IDelayCauseRepository, DelayCauseRepository>()
                .AddScoped<IDelayRepository, DelayRepository>()
                .AddScoped<IElementRepository, ElementRepository>()
                .AddScoped<IElementStatusRepository, ElementStatusRepository>()
                .AddScoped<IElementsTimeEvidenceRepository, ElementsTimeEvidenceRepository>()
                .AddScoped<IElementTermRepository, ElementTermRepository>()
                .AddScoped<IGroupedOtherWorkTimeEvidenceRepository, GroupedOtherWorkTimeEvidenceRepository>()
                .AddScoped<IGroupTermRepository, GroupTermRepository>()
                .AddScoped<ILevelRepository, LevelRepository>()
                .AddScoped<IOtherWorkOptionRepository, OtherWorkOptionRepository>()
                .AddScoped<IOtherWorksTimeEvidenceRepository, OtherWorksTimeEvidenceRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<IWorkerRepository, WorkerRepository>()
                .AddScoped<IWorkerTimeEvidenceRepository, WorkerTimeEvidenceRepository>()
                ;

            return serviceCollection;
        }
    }
}