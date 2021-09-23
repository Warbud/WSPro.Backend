using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Infrastructure.CraneTest
{
    
    [TestFixture]
    public class CraneTest
    {
        private Crane _crane;
        private List<Crane> _craneList;
        
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                _crane = new Crane("01");
                context.Cranes.Add(_crane);
                context.SaveChanges();
            }


            using (var context = new WSProTestContext())
            {
                _craneList = context.Cranes.ToList();
            }
        }
        
        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext();
            context.Database.EnsureDeleted();
            context.SaveChanges();
        }
        
        [Test]
        public void TestCrane()
        {
           Assert.AreEqual(1,_craneList.Count);
           Assert.AreEqual("01",_crane.Name);
        }
    }
}