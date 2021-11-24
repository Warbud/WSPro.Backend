using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class BimModelTest : _setup
    {
        public Project DBproject;
        public BimModel DBbimModel;
        public BimModel DBbimModel2;

        public override void Init()
        {
            Project project;
            BimModel bimModel;
            BimModel bimModel2;
            using (var ctx = new WSProTestContext().Context)
            {
                project = new Project { Name = "project" };

                bimModel = new BimModel
                {
                    Name = "model główny",
                    ModelUrn = "asdhjhbsadkalu12ygl1kw2lrq134e123",
                    DefaultViewName = "{3D}",
                    Project = project
                };

                bimModel2 = new BimModel
                {
                    Name = "model główny 2",
                    ModelUrn = "1p2yb3o7tub3xno182397bc123v12",
                    Project = project
                };

                ctx.AddRange(project, bimModel, bimModel2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBproject = ctx.Projects.Find(project.Id);
                DBbimModel = ctx.BimModels.Find(bimModel.Id);
                DBbimModel2 = ctx.BimModels.Find(bimModel2.Id);
            }
        }

        [TestFixture]
        private class test_basic_attributes : BimModelTest
        {
            [Test]
            public void should_have_proper_Id()
            {
                Assert.That(DBbimModel.Id, Is.TypeOf<int>());
                Assert.That(DBbimModel2.Id, Is.TypeOf<int>());
                Assert.AreNotEqual(DBbimModel.Id, DBbimModel2.Id);
            }

            [Test]
            public void should_have_proper_name()
            {
                Assert.AreEqual("model główny", DBbimModel.Name);
                Assert.AreEqual("model główny 2", DBbimModel2.Name);
            }

            [Test]
            public void should_have_proper_ModelUrn()
            {
                Assert.AreEqual("asdhjhbsadkalu12ygl1kw2lrq134e123", DBbimModel.ModelUrn);
                Assert.AreEqual("1p2yb3o7tub3xno182397bc123v12", DBbimModel2.ModelUrn);
            }

            [Test]
            public void should_have_proper_DefaultViewName()
            {
                Assert.AreEqual("{3D}", DBbimModel.DefaultViewName);
                Assert.AreEqual(null, DBbimModel2.DefaultViewName);
            }

            [Test]
            public void should_have_proper_Project()
            {
                Assert.AreEqual(DBproject.Id, DBbimModel.ProjectId);
                Assert.AreEqual(DBproject, DBbimModel.Project);

                Assert.AreEqual(DBproject.Id, DBbimModel2.ProjectId);
                Assert.AreEqual(DBproject, DBbimModel2.Project);
            }
        }

        [TestFixture]
        private class Test_BimModel_reference_in_Project : BimModelTest
        {
            [Test]
            public void should_have_proper_references_to_models()
            {
                Assert.AreEqual(2, DBproject.Models.Count);
                Assert.That(DBproject.Models.Contains(DBbimModel));
                Assert.That(DBproject.Models.Contains(DBbimModel2));
            }
        }
        
    }
}