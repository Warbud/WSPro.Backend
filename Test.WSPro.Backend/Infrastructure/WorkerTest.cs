using System.Collections.Generic;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure.WorkerTest
{
    [TestFixture]
    public class TestWorker
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _worker = new Worker(CrewWorkTypeEnum.GeneralConstructor);
                context.Add(_worker);
                context.SaveChanges();

                _worker2 = new Worker(null);
                context.Add(_worker2);
                context.SaveChanges();
            }
        }

        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
        }

        private Worker _worker;
        private Worker _worker2;


        [Test]
        public void TestWhilePassCrewWorkTypeEnum()
        {
            Assert.AreEqual(CrewWorkTypeEnum.GeneralConstructor, _worker.CrewWorkType);
        }

        [Test]
        public void TestWhilePassCrewWorkTypeEnumAsNull()
        {
            Assert.AreEqual(null, _worker2.CrewWorkType);
        }
    }


    [TestFixture]
    public class TestHouseWorker
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _worker = new HouseWorker("WRB12314", CrewWorkTypeEnum.SteelFixer);
                context.Add(_worker);
                context.SaveChanges();
            }
        }

        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
        }

        private HouseWorker _worker;

        [Test]
        public void NonRelationalData()
        {
            Assert.AreEqual("WRB12314", _worker.WarbudID);
            Assert.AreEqual(CrewWorkTypeEnum.SteelFixer, _worker.CrewWorkType);
        }

        [Test]
        public void RelationalData()
        {
            // Assert.AreEqual(null,_worker.Crew);
            Assert.AreEqual(null, _worker.AddedBy);
            Assert.AreEqual(new List<CrewSummary>(), _worker.CrewSummaries);
        }
    }

    [TestFixture]
    public class TestExternalWorker
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _worker = new ExternalWorker("Jasiu Stasiu", CrewWorkTypeEnum.Carpenter);
                context.Add(_worker);
                context.SaveChanges();
            }
        }

        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
        }

        private ExternalWorker _worker;

        [Test]
        public void NonRelationalData()
        {
            Assert.AreEqual("Jasiu Stasiu", _worker.Name);
            Assert.AreEqual(CrewWorkTypeEnum.Carpenter, _worker.CrewWorkType);
        }

        [Test]
        public void RelationalData()
        {
            // Assert.AreEqual(null,_worker.Crew);
            Assert.AreEqual(null, _worker.AddedBy);
            Assert.AreEqual(new List<CrewSummary>(), _worker.CrewSummaries);
        }
    }
}