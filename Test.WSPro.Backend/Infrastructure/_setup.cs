using NUnit.Framework;

namespace Test.WSPro.Backend.Infrastructure
{
    public class _setup
    {
        [OneTimeSetUp]
        public void Start()
        {
            new WSProTestContext().Context.Database.EnsureDeleted();
            new WSProTestContext().Context.Database.EnsureCreated();
            Init();
        }

        public virtual void Init()
        {
        }

        [OneTimeTearDown]
        public void End()
        {
            // new WSProTestContext().Context.Database.EnsureDeleted();
        }
    }
}