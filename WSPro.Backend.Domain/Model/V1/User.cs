using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    /// <summary>
    ///     Klasa użytkownika. Reprezentuje użytkownika korzystającego z systemu
    /// </summary>
    public class User : EntityModificationDate
    {
        /// <summary>
        ///     Id użytkownika w bazie
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Imię i nazwisko / pseudonim / nick użytkownika - opcjonalny
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///     Adres email użytkownika
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Hasło użytkownika
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Metoda logowania użytkownika
        /// </summary>
        public AuthProviderEnum Provider { get; set; }

        // private string? NameValidator(string name)
        // {
        //     return string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) ? null : name;
        // }
        //
        // private AuthProviderEnum AuthProviderValidator(AuthProviderEnum? provider)
        // {
        //     return provider ?? AuthProviderEnum.Origin;
        // }
    }
}