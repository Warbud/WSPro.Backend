using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    /// <summary>
    ///     Klasa żurawia. Identyfikuje żuraw na budowie bo jego nazwie.
    /// </summary>
    public class Crane :EntityModificationDate
    {
        /// <summary>
        ///     Index żurawia w bazie
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///     Nazwa żurawia. Należy uruchomić walidator aby sprawdzić poprawność nazwy żurawia
        /// </summary>
        public string Name { get; set; }
        
        

    }
}