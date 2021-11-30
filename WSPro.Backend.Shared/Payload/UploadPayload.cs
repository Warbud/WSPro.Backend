using System.Collections.Generic;
using WSPro.Backend.Shared.Importers;

namespace WSPro.Backend.Shared.Payload
{
    public record UploadValidatePayload(ICollection<Dictionary<string,ParsedValue>> data);
    public record UploadImportedPayload(bool data);
}