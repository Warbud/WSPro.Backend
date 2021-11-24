using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class LevelTest : _setup
    {
        private Level dbLevel;
        private Level dbLevel2;
        private Level dbLevel3;

        public override void Init()
        {
            Level Level;
            Level Level2;
            Level Level3;
            using (var Context = new WSProTestContext().Context)
            {
                Level = new Level { Name = "L01" };
                Level2 = new Level { Name = "B01" };
                Level3 = new Level { Name = "L02" };
                Context.Levels.AddRange(Level, Level2, Level3);
                Context.SaveChanges();
            }

            using (var Context = new WSProTestContext().Context)
            {
                _list = Context.Levels.ToList();
                dbLevel = Context.Levels.Find(Level.Id);
                dbLevel2 = Context.Levels.Find(Level2.Id);
                dbLevel3 = Context.Levels.Find(Level3.Id);
            }
        }

        private List<Level> _list;

        [Test]
        public void test_added_levels_count()
        {
            Assert.AreEqual(3, _list.Count);
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.NotNull(dbLevel.Id);
            Assert.NotNull(dbLevel2.Id);
            Assert.NotNull(dbLevel3.Id);
            Assert.That(() => dbLevel.Id != dbLevel2.Id && dbLevel2.Id != dbLevel3.Id && dbLevel.Id != dbLevel3.Id);
        }

        [Test]
        public void test_Name_attribute()
        {
            Assert.AreEqual("L01", dbLevel.Name);
            Assert.AreEqual("B01", dbLevel2.Name);
            Assert.AreEqual("L02", dbLevel3.Name);
        }

        [Test]
        public void test_CreatedAt_attribute()
        {
            Assert.NotNull(dbLevel.CreatedAt);
            Assert.NotNull(dbLevel2.CreatedAt);
            Assert.NotNull(dbLevel3.CreatedAt);
        }

        [Test]
        public void test_UpdatedAt_attribute()
        {
            Assert.NotNull(dbLevel.UpdatedAt);
            Assert.NotNull(dbLevel2.UpdatedAt);
            Assert.NotNull(dbLevel3.UpdatedAt);
        }
    }
}