using System;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    public class CraneTest
    {
        [Test]
        public void AddCrane_Base()
        {
            var crane = new Crane("01");
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Cranes.Add(crane);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var cranes = context.Cranes.ToList();

                Assert.AreEqual(1,cranes.Count);
                Assert.AreEqual("01",cranes[0].Name);

                context.Database.EnsureDeleted();
            }
        }
    }
}