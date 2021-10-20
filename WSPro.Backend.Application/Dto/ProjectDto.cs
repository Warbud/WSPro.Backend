namespace WSPro.Backend.Application.Dto
{
    public record GetProjectDto(int Id);
    public record CreateProjectDto(
        string Name,
        string? WebconCode, 
        string? MetodologyCode, 
        bool CentralScheduleSync = false
        );
}