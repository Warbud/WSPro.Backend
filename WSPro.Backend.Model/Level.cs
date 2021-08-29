using System.Text.RegularExpressions;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    /// <summary>
    /// Klasa poziomu
    /// </summary>
    public class Level:EntityModificationDate
    {
        /// <summary>
        /// Indeks w bazie poziomu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa poziomu
        /// </summary>
        public string Name { get; set; }

        public Level(string name)
        {
            Name = name;
        }
        
        /// <summary>
        /// Metoda sprawdzająca poprawność nazwy poziomu.
        /// Dopuszczalne nazwy to np. B00,B01...B99, L00..L99, F
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidName(string? name)
        {
            return name != null && new Regex(@"F|B\d{2}|L\d{2}").IsMatch(name);
        }
    }
}