using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class WorkerTest : _setup
    {
        private Worker dbWorker1;
        private Worker dbWorker2;
        private List<Worker> dbWorkers;
        private User dbUser;

        public override void Init()
        {
            Worker _worker1;
            Worker _worker2;
            User _user;
            using (var Context = new WSProTestContext().Context)
            {
                _user = new User { Email = "test_email", Name = "test", Password = "asd" };
                _worker1 = new Worker
                {
                    CrewWorkType = CrewWorkTypeEnum.Carpenter,
                    WarbudId = "TestID",
                    AddedBy = _user
                };

                _worker2 = new Worker
                {
                    Name = "Janek Kowalski",
                    CrewWorkType = CrewWorkTypeEnum.GeneralConstructor,
                    AddedBy = _user
                };
                Context.AddRange(_worker1, _worker2, _user);
                Context.SaveChanges();
            }

            using (var Context = new WSProTestContext().Context)
            {
                dbWorkers = Context.Workers.ToList();
                dbWorker1 = Context.Workers.Find(_worker1.Id);
                dbWorker2 = Context.Workers.Find(_worker2.Id);
            }
        }

        [Test]
        public void test_added_workers_count()
        {
            Assert.AreEqual(2, dbWorkers.Count);
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.NotNull(dbWorker1.Id);
            Assert.NotNull(dbWorker2.Id);
            Assert.That(() => dbWorker1.Id != dbWorker2.Id);
        }

        [Test]
        public void test_CrewWorkType_attribute()
        {
            Assert.AreEqual(CrewWorkTypeEnum.Carpenter, dbWorker1.CrewWorkType);
            Assert.AreEqual(CrewWorkTypeEnum.GeneralConstructor, dbWorker2.CrewWorkType);
        }

        [Test]
        public void test_IsHouseWorker_attribute()
        {
            Assert.AreEqual(true, dbWorker1.IsHouseWorker);
            Assert.AreEqual(false, dbWorker2.IsHouseWorker);
        }

        [Test]
        public void test_AddedBy_reference()
        {
            Assert.AreEqual(dbUser, dbWorker1.AddedBy);
            Assert.AreEqual(dbUser, dbWorker2.AddedBy);
        }

        [Test]
        public void test_WarbudID_attribute()
        {
            Assert.AreEqual("TestID", dbWorker1.WarbudId);
            Assert.AreEqual(null, dbWorker2.WarbudId);
        }

        [Test]
        public void test_Name_attribute()
        {
            Assert.AreEqual(null, dbWorker1.Name);
            Assert.AreEqual("Janek Kowalski", dbWorker2.Name);
        }

        [Test]
        public void test_CrewSummaries_reference()
        {
            Assert.AreEqual(0, dbWorker1.CrewSummaries.Count);
            Assert.AreEqual(0, dbWorker2.CrewSummaries.Count);
        }

        [Test]
        public void test_TimeEvidences_reference()
        {
            Assert.AreEqual(0, dbWorker1.TimeEvidences.Count);
            Assert.AreEqual(0, dbWorker2.TimeEvidences.Count);
        }
    }
}