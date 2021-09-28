using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    public class LevelTest
    {
        [Test]
        public void AddLevel()
        {
            var level = new Level("L00");
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Levels.Add(level);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext().Context)
            {
                var levels = context.Levels.ToList();
                
                Assert.AreEqual(levels.Count,1);
                Assert.AreEqual(levels[0].Name,"L00");
            }
        }
    }
}