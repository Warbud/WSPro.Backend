using WSPro.Backend.Model.General;
using WSPro.Backend.Utils;

namespace WSPro.Backend.Model
{
    /// <summary>
    ///     Klasa projektu. Reprezentuje budowę/projekt na której uruchomiony jest system.
    /// </summary>
    public class Project : EntityModificationDate
    {
        private Project()
        {
        }

        public Project(string name, string? webconCode = null, string? metodologyCode = null,
            bool centralScheduleSync = false)
        {
            Name = name;
            WebconCode = WebconCodeValidation(webconCode);
            MetodologyCode = MetodologyCodeValidation(metodologyCode);
            CentralScheduleSync = CentralScheduleSyncValidation(centralScheduleSync);
        }

        /// <summary>
        ///     ID projektu w bazie danych
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Nazwa projektu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Identyfikator projektu w systemie ERP
        /// </summary>
        public string? WebconCode { get; set; }

        /// <summary>
        ///     Identyfikator projektu w systemie harmonogramowym
        /// </summary>
        public string? MetodologyCode { get; set; }

        /// <summary>
        ///     Parametr określa czy projekt ma być synchronizowany z centralnym harmonogramem DIP. Jeśli tak, to konieczne jest
        ///     podanie parametru <i>MetodologyCode</i>
        /// </summary>
        public bool CentralScheduleSync { get; set; }

        private string? WebconCodeValidation(string? value)
        {
            return Parser.NullParser(value);
        }

        private string? MetodologyCodeValidation(string? value)
        {
            return Parser.NullParser(value);
        }

        private bool CentralScheduleSyncValidation(bool centralScheduleSync)
        {
            return MetodologyCode != null && WebconCode != null && centralScheduleSync;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            var projectToCheck = (Project)obj;
            return projectToCheck.Name == Name &&
                   projectToCheck.CentralScheduleSync == CentralScheduleSync &&
                   projectToCheck.MetodologyCode == MetodologyCode &&
                   projectToCheck.WebconCode == WebconCode &&
                   projectToCheck.CreatedAt == CreatedAt &&
                   projectToCheck.UpdatedAt == UpdatedAt;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}