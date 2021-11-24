using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class BimModel_LevelTest : _setup
    {
        public Project DBproject;
        public BimModel DBbimModel;
        public BimModel DBbimModel2;
        public Level DBlevel1;
        public Level DBlevel2;
        public Level DBlevel3;

        public override void Init()
        {
            Project project;
            BimModel bimModel;
            BimModel bimModel2;
            Level level1;
            Level level2;
            Level level3;
            using (var ctx = new WSProTestContext().Context)
            {
                project = new Project { Name = "project" };
                level1 = new Level { Name = "L01" };
                level2 = new Level { Name = "L02" };
                level3 = new Level { Name = "L03" };
                bimModel = new BimModel
                {
                    Name = "model główny",
                    ModelUrn = "asdhjhbsadkalu12ygl1kw2lrq134e123",
                    DefaultViewName = "{3D}",
                    Project = project,
                    Levels = new List<Level> { level1, level2 }
                };

                bimModel2 = new BimModel
                {
                    Name = "model główny 2",
                    ModelUrn = "1p2yb3o7tub3xno182397bc123v12",
                    Project = project,
                    Levels = new List<Level> { level1, level2, level3 }
                };

                ctx.AddRange(project, level1, level2, level3, bimModel, bimModel2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBproject = ctx.Projects.Find(project.Id);

                DBbimModel = ctx.BimModels.Include(e => e.Levels)
                    .FirstOrDefault(e => e.Id == bimModel.Id);
                DBbimModel2 = ctx.BimModels.Include(e => e.Levels)
                    .FirstOrDefault(e => e.Id == bimModel2.Id);

                DBlevel1 = ctx.Levels.Find(level1.Id);
                DBlevel2 = ctx.Levels.Find(level2.Id);
                DBlevel3 = ctx.Levels.Find(level3.Id);
            }
        }

        [TestFixture]
        public class test_Level_reference_inside_BimModel : BimModel_LevelTest
        {
            [Test]
            public void should_have_properly_added_level_count()
            {
                Assert.AreEqual(2, DBbimModel.Levels.Count);
                Assert.AreEqual(3, DBbimModel2.Levels.Count);
            }

            [Test]
            public void should_have_correspont_Levels()
            {
                Assert.That(DBbimModel.Levels.Contains(DBlevel1));
                Assert.That(DBbimModel.Levels.Contains(DBlevel2));

                Assert.That(DBbimModel2.Levels.Contains(DBlevel1));
                Assert.That(DBbimModel2.Levels.Contains(DBlevel2));
                Assert.That(DBbimModel2.Levels.Contains(DBlevel3));
            }
        }
    }
}