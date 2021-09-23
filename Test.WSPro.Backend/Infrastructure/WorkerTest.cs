using System.Collections.Generic;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure.WorkerTest
{
    [TestFixture]
    public class TestWorker
    {
        private Worker _worker;
        private Worker _worker2;
        
       
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext())
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
            using var context = new WSProTestContext();
            context.Database.EnsureDeleted();
        }
        
        
        [Test]
        public void TestWhilePassCrewWorkTypeEnum()
        {
            Assert.AreEqual(CrewWorkTypeEnum.GeneralConstructor,_worker.CrewWorkTypeEnum);
        }
        
        [Test]
        public void TestWhilePassCrewWorkTypeEnumAsNull()
        {
            Assert.AreEqual(null,_worker2.CrewWorkTypeEnum);
        }
    }
    
    
    
    [TestFixture]
    public class TestHouseWorker
    {
        private HouseWorker _worker;

        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _worker = new HouseWorker("WRB12314",CrewWorkTypeEnum.SteelFixer);
                context.Add(_worker);
                context.SaveChanges();
            }
        }
        
        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext();
            context.Database.EnsureDeleted();
        }

        [Test]
        public void NonRelationalData()
        {
            Assert.AreEqual("WRB12314",_worker.WarbudID);
            Assert.AreEqual(CrewWorkTypeEnum.SteelFixer,_worker.CrewWorkTypeEnum);
        }
        [Test]
        public void RelationalData()
        {
            // Assert.AreEqual(null,_worker.Crew);
            Assert.AreEqual(null,_worker.AddedBy);
            Assert.AreEqual(new List<CrewSummary>(),_worker.CrewSummaries);
        }

    }
    [TestFixture]
    public class TestExternalWorker
    {
        private ExternalWorker _worker;

        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _worker = new ExternalWorker("Jasiu Stasiu",CrewWorkTypeEnum.Carpenter);
                context.Add(_worker);
                context.SaveChanges();
            }
        }
        
        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext();
            context.Database.EnsureDeleted();
        }

        [Test]
        public void NonRelationalData()
        {
            Assert.AreEqual("Jasiu Stasiu",_worker.Name);
            Assert.AreEqual(CrewWorkTypeEnum.Carpenter,_worker.CrewWorkTypeEnum);
        }
        [Test]
        public void RelationalData()
        {
            // Assert.AreEqual(null,_worker.Crew);
            Assert.AreEqual(null,_worker.AddedBy);
            Assert.AreEqual(new List<CrewSummary>(),_worker.CrewSummaries);
        }

    }
}