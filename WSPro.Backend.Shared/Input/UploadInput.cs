using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Shared.Enum;

namespace WSPro.Backend.Shared.Input
{
    public record UploadInput(string Value,int projectId, DataImportType DataType, AppEnum AppName);
}