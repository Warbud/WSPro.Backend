using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class Element_ElementsTimeEvidence : EntityModificationDate, IEntity
    {
        public Element Element { get; set; }
        public int ElementId { get; set; }
        public ElementsTimeEvidence ElementsTimeEvidence { get; set; }
        public int ElementsTimeEvidenceId { get; set; }
    }
}