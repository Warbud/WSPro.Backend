namespace WSPro.Backend.Domain.Enums
{
    public enum AppEnum
    {
        ModelViewer,
        WorkProgressMonolithic,
        WorkProgressPrecast,
        WorkProgressGeneral,
        WorkersLogWorkTimeEvidence,
        WorkersLogLabourInput
    }

    public enum AppModulesEnum
    {
        WorkProgressBasePlan,
        WorkProgressStatuses,
        WorkProgressTerms,
        WorkProgressDelays,
        WorkProgressElementComments,
        WorkersLogWorkTimeEvidence,
        WorkersLogLabourInput,
    }
    
    public static class Modules
    {
        public static class WorkProgress
        {
            public static readonly string BasePlan = "BasePlan";
            public static readonly string Statuses = "Statuses";
            public static readonly string Terms = "Terms";
            public static readonly string Delays = "Delays";
            public static readonly string ElementComments = "ElementComments";
        }
        
        public static class WorkersLog
        {
            public static readonly string WorkTimeEvidence = "WorkTimeEvidence";
            public static readonly string LabourInput = "LabourInput";
        }
    }
}