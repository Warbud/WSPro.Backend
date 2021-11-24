using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class DelayCauseTest : _setup
    {
        private DelayCause dbDelayCause1;
        private DelayCause dbDelayCause2;
        private List<DelayCause> dbDelayCauses;

        public override void Init()
        {
            DelayCause delayCause1;
            DelayCause delayCause2;
            using (var ctx = new WSProTestContext().Context)
            {
                delayCause1 = new DelayCause("Cos tam nei dziala");
                delayCause2 = new DelayCause("bo wiatr", delayCause1);
                ctx.AddRange(delayCause1, delayCause2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dbDelayCauses = ctx.DelayCauses.ToList();
                dbDelayCause1 = ctx.DelayCauses.Find(delayCause1.Id);
                dbDelayCause2 = ctx.DelayCauses.Find(delayCause2.Id);
            }
        }


        [Test]
        public void test_items_count()
        {
            Assert.AreEqual(2, dbDelayCauses.Count);
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.NotNull(dbDelayCause1.Id);
            Assert.NotNull(dbDelayCause2.Id);
            Assert.That(() => dbDelayCause1.Id != dbDelayCause2.Id);
        }

        [Test]
        public void test_Name_attribute()
        {
            Assert.AreEqual("Cos tam nei dziala", dbDelayCause1.Name);
            Assert.AreEqual("bo wiatr", dbDelayCause2.Name);
        }

        [Test]
        public void test_IsMain_attribute()
        {
            Assert.AreEqual(true, dbDelayCause1.IsMain);
            Assert.AreEqual(false, dbDelayCause2.IsMain);
        }

        [Test]
        public void test_Parent_attribute()
        {
            Assert.AreEqual(null, dbDelayCause1.Parent);
            Assert.AreEqual(dbDelayCause1, dbDelayCause2.Parent);
        }
    }
}