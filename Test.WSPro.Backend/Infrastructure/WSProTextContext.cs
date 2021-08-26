using WSPro.Backend.Infrastructure;

namespace Test.WSPro.Backend.Infrastructure
{
    public class WSProTestContext:WSProContext
    {
        private const string ConnectionString = "Host=localhost;Database=wspro_test;Username=postgres;Password=admin";
        
        public WSProTestContext():base(ConnectionString)
        { }
    }
}