using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class CraneTest : _setup
    {
        public override void Init()
        {
            using (var Context = new WSProTestContext().Context)
            {
                _crane1 = new Crane
                {
                    Name = "01"
                };
                _crane2 = new Crane
                {
                    Name = "02"
                };
                _crane3 = new Crane
                {
                    Name = "03"
                };
                Context.Cranes.AddRange(_crane1, _crane2, _crane3);
                Context.SaveChanges();
            }

            using (var Context = new WSProTestContext().Context)
            {
                _craneList = Context.Cranes.ToList();
            }
        }

        private List<Crane> _craneList;
        private Crane _crane1;
        private Crane _crane2;
        private Crane _crane3;

        [Test]
        public void test_added_cranes_count()
        {
            Assert.AreEqual(3, _craneList.Count);
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.That(_crane1.Id, Is.TypeOf<int>());
            Assert.That(_crane2.Id, Is.TypeOf<int>());
            Assert.That(_crane3.Id, Is.TypeOf<int>());
            Assert.AreNotEqual(_crane1.Id, _crane2.Id);
            Assert.AreNotEqual(_crane2.Id, _crane3.Id);
            Assert.AreNotEqual(_crane3.Id, _crane1.Id);
        }

        [Test]
        public void test_Name_attribute()
        {
            Assert.AreEqual("01", _crane1.Name);
            Assert.AreEqual("02", _crane2.Name);
            Assert.AreEqual("03", _crane3.Name);
        }
    }
}