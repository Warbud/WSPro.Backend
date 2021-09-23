using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WSPro.Backend.Model.Enums;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class ElementStatus:EntityModificationDate
    {
        // non relational attributes
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public StatusEnum Status { get; set; }
        public bool IsActual { get; set; }
        
        
        // relational attributes
        public Element Element { get; set; }
        public User User { get; set; }
        private int? UserId { get; set; }
        public Project Project { get; set; }
        private int? ProjectId { get; set; }
        public ElementStatus PreviousStatus { get; set; }
        private int? PreviousStatusId { get; set; }

        private ElementStatus()
        {
            
        }

        public ElementStatus(Element element, StatusEnum status, DateTime? date = null, ElementStatus? previousStatus = null)
        {
            Element = element;
            Project = element.Project;
            Status = status;
            Date = date ?? DateTime.Now.Date;
            IsActual = true;            
            
            HandleManipulatePreviousStatus(previousStatus);
        }
        
        
        private void HandleManipulatePreviousStatus(ElementStatus? previousStatus)
        {
            var previousStatusToSet = previousStatus ?? GetPreviousElementStatusFromElement();
            if (previousStatusToSet is null) return;
            
            previousStatusToSet.IsActual = false;
            PreviousStatus = previousStatusToSet;
        }

        private ElementStatus? GetPreviousElementStatusFromElement()
        {
            var elementStatusList = Element.ElementStatusList.ToList();
            if (elementStatusList.Count ==0) return null;
            
            (DateTime?,ElementStatus) highestElement = (null, null);
            
            foreach (var elementStatus in elementStatusList)
            {
                if (highestElement.Item1 is null)
                {
                    highestElement.Item1 = elementStatus.Date;
                    highestElement.Item2 = elementStatus;
                }

                if (elementStatus.Date > highestElement.Item1)
                {
                    highestElement.Item1 = elementStatus.Date;
                    highestElement.Item2 = elementStatus;
                }
            }

            return highestElement.Item2;
        }

        
    }
}