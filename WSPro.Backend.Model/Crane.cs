using System.Linq;
using System.Text.RegularExpressions;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    /// <summary>
    ///     Klasa żurawia. Identyfikuje żuraw na budowie bo jego nazwie.
    /// </summary>
    public class Crane : EntityModificationDate
    {
        private Crane()
        {
        }

        public Crane(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Index żurawia w bazie
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Nazwa żurawia. Należy uruchomić walidator aby sprawdzić poprawność nazwy żurawia
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Metoda sprawdzająca poprawność nazwy żurawia.
        ///     Dopuszczalne nazwy to np. 01,02,...,99
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidName(string? name)
        {
            return name != null && new Regex(@"(?!00)(?=\d{2})").IsMatch(name);
        }
    }
}