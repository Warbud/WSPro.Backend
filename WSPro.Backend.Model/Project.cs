namespace WSPro.Backend.Model
{
    /// <summary>
    /// Klasa projektu. Reprezentuje budowę/projekt na której uruchomiony jest system. 
    /// </summary>
    public class Project
    {
        /// <summary>
        /// ID projektu w bazie danych
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa projektu
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Identyfikator projektu w systemie ERP
        /// </summary>
        public string WebconCode { get; set; }
        /// <summary>
        /// Identyfikator projektu w systemie harmonogramowym
        /// </summary>
        public string? MetodologyCode { get; set; }

        /// <summary>
        /// Parametr określa czy projekt ma być synchronizowany z centralnym harmonogramem DIP. Jeśli tak, to konieczne jest podanie parametru <i>MetodologyCode</i>
        /// </summary>
        public bool CentralScheduleSync { get; set; }

        public Project(string name, string webconCode, string? metodologyCode = null,bool centralScheduleSync = false)
        {
            Name = name;
            WebconCode = webconCode;
            MetodologyCode = MetodologyCodeValidation(metodologyCode);
            CentralScheduleSync = CentralScheduleSyncValidation(centralScheduleSync);
        }

        private string? MetodologyCodeValidation(string? metodologyCode)
        {
            return (string.IsNullOrEmpty(metodologyCode) || string.IsNullOrWhiteSpace(metodologyCode))
                ? null
                : metodologyCode;
        }

        private bool CentralScheduleSyncValidation(bool centralScheduleSync)
        {
            return MetodologyCode != null && centralScheduleSync;
        }
    }
}