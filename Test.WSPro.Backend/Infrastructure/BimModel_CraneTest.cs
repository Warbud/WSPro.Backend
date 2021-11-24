using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class BimModel_CraneTest : _setup
    {
        public Project DBproject;
        public BimModel DBbimModel;
        public BimModel DBbimModel2;
        public BimModel DBbimModel3;
        public Crane DBcrane1;
        public Crane DBcrane2;
        public Crane DBcrane3;

        public override void Init()
        {
            Project project = new() { Name = "project" };
            BimModel bimModel;
            BimModel bimModel2;
            BimModel bimModel3;
            Crane crane1 = new() { Name = "01" };
            Crane crane2 = new() { Name = "02" };
            Crane crane3 = new() { Name = "03" };
            using (var ctx = new WSProTestContext().Context)
            {
                ctx.AddRange(project, crane1, crane2, crane3);
                ctx.SaveChanges();
               
            }

            bimModel = new BimModel
            {
                Name = "model główny",
                ModelUrn = "asdhjhbsadkalu12ygl1kw2lrq134e123",
                DefaultViewName = "{3D}",
                Project = project,
                Cranes = new List<Crane> { crane1, crane2 }
            };

            bimModel2 = new BimModel
            {
                Name = "model główny 2",
                ModelUrn = "1p2yb3o7tub3xno182397bc123v12",
                Project = project,
                Cranes = new List<Crane> { crane1, crane2, crane3 }
            };

            using (var ctx = new WSProTestContext().Context)
            {
                ctx.AttachRange(project, crane1, crane2, crane3);
                ctx.AddRange(bimModel, bimModel2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBproject = ctx.Projects.FirstOrDefault(e => e.Id == project.Id);

                DBbimModel = ctx.BimModels.Include(e => e.Cranes)
                    .FirstOrDefault(e => e.Id == bimModel.Id);
                DBbimModel2 = ctx.BimModels.Include(e => e.Cranes)
                    .FirstOrDefault(e => e.Id == bimModel2.Id);


                DBcrane1 = ctx.Cranes.FirstOrDefault(e => e.Id == crane1.Id);
                DBcrane2 = ctx.Cranes.FirstOrDefault(e => e.Id == crane2.Id);
                DBcrane3 = ctx.Cranes.FirstOrDefault(e => e.Id == crane3.Id);
            }

        }

        [TestFixture]
        [Order(1)]
        private class test_Crane_reference_inside_BimModel : BimModel_CraneTest
        {
            [Test]
            public void should_have_properly_added_crane_count()
            {
                Assert.AreEqual(2, DBbimModel.Cranes.Count);
                Assert.AreEqual(3, DBbimModel2.Cranes.Count);
            }

            [Test]
            public void should_have_correspond_Cranes()
            {
                Assert.That(DBbimModel.Cranes.Contains(DBcrane1));
                Assert.That(DBbimModel.Cranes.Contains(DBcrane2));

                Assert.That(DBbimModel2.Cranes.Contains(DBcrane1));
                Assert.That(DBbimModel2.Cranes.Contains(DBcrane2));
                Assert.That(DBbimModel2.Cranes.Contains(DBcrane3));

            }
        }
        [TestFixture]
        [Order(2)]
        public class Test_add_existing_crane_to_model:BimModel_CraneTest
        {
            [OneTimeSetUp]
            public void init()
            {
                BimModel bimModel3;
                using (var ctx = new WSProTestContext().Context)
                {
                    var project = new Project() { Id = DBproject.Id };
                    var crane1 = new Crane { Id = DBcrane1.Id };
                    var crane2 = new Crane { Id = DBcrane2.Id };
                    ctx.AttachRange(project,crane1,crane2);
                    bimModel3 = new BimModel
                    {
                        Name = "model główny 3",
                        ModelUrn = "aw3tgw4arwer43",
                        ProjectId = project.Id,
                        Cranes = {crane1,crane2}
                    };
                    ctx.Add(bimModel3);
                    ctx.SaveChanges();
                }
            
                using (var ctx = new WSProTestContext().Context)
                {
                    DBbimModel3 = ctx.BimModels.Include(e => e.Cranes)
                        .FirstOrDefault(e => e.Id == bimModel3.Id);
                }
            }

            [Test]
            public void should_contain_existing_cranes()
            {
                Assert.AreEqual(2,DBbimModel3.Cranes.Count);
            }
        }
    }
}