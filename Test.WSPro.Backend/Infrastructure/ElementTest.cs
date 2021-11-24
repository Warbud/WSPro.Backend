using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class ElementTest : _setup
    {
        private List<Element> _elements;
        private Element dbElement1;
        private Element dbElement2;
        private Project dbProject;
        private Crane dbCrane;
        private Level dbLevel;

        public override void Init()
        {
            Element _element1;
            Element _element2;
            Project _project;
            Crane _crane;
            Level _level;
            using (var ctx = new WSProTestContext().Context)
            {
                _project = new Project { Name = "Project" };
                _crane = new Crane { Name = "01" };
                _level = new Level { Name = "L01" };
                _element1 = new Element
                {
                    RevitId = 111111,
                    Project = _project
                };
                _element2 = new Element
                {
                    RevitId = 222222,
                    Project = _project,
                    Area = 123.123234m,
                    Volume = 123.5123m,
                    RunningMetre = 1.1242m,
                    Level = _level,
                    Crane = _crane,
                    Vertical = VerticalEnum.V,
                    RealisationMode = "test",
                    RotationDay = 1
                };

                ctx.AddRange(_project, _level, _crane, _element1, _element2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                _elements = ctx.Elements.ToList();
                dbProject = ctx.Projects.Find(_project.Id);
                dbCrane = ctx.Cranes.Find(_crane.Id);
                dbLevel = ctx.Levels.Find(_level.Id);
                dbElement1 = ctx.Elements.Find(_element1.Id);
                dbElement2 = ctx.Elements.Find(_element2.Id);
            }
        }

        [TestFixture]
        private class basic_Element_properties : ElementTest
        {
            [Test]
            public void test_added_elements_count()
            {
                Assert.AreEqual(2, _elements.Count);
            }

            [Test]
            public void test_Id_attribute()
            {
                Assert.NotNull(dbElement1.Id);
                Assert.NotNull(dbElement2.Id);
                Assert.AreNotEqual(dbElement1.Id, dbElement2.Id);
            }

            [Test]
            public void test_Area_attribute()
            {
                Assert.AreEqual(null, dbElement1.Area);
                Assert.AreEqual(123.123234m, dbElement2.Area);
            }

            [Test]
            public void test_Volume_attribute()
            {
                Assert.AreEqual(null, dbElement1.Volume);
                Assert.AreEqual(123.5123m, dbElement2.Volume);
            }

            [Test]
            public void test_RunningMetre_attribute()
            {
                Assert.AreEqual(null, dbElement1.RunningMetre);
                Assert.AreEqual(1.1242m, dbElement2.RunningMetre);
            }

            [Test]
            public void test_RevitId_attribute()
            {
                Assert.AreEqual(111111, dbElement1.RevitId);
                Assert.AreEqual(222222, dbElement2.RevitId);
            }

            [Test]
            public void test_Vertical_attribute()
            {
                Assert.AreEqual(null, dbElement1.Vertical);
                Assert.AreEqual(VerticalEnum.V, dbElement2.Vertical);
            }

            [Test]
            public void test_RealisationMode_attribute()
            {
                Assert.AreEqual(null, dbElement1.RealisationMode);
                Assert.AreEqual("test", dbElement2.RealisationMode);
            }

            [Test]
            public void test_RotationDay_attribute()
            {
                Assert.AreEqual(null, dbElement1.RotationDay);
                Assert.AreEqual(1, dbElement2.RotationDay);
            }

            [Test]
            public void test_Level_reference()
            {
                Assert.AreEqual(null, dbElement1.Level);
                Assert.AreEqual(dbLevel, dbElement2.Level);
            }

            [Test]
            public void test_Crane_reference()
            {
                Assert.AreEqual(null, dbElement1.Crane);
                Assert.AreEqual(dbCrane, dbElement2.Crane);
            }

            [Test]
            public void test_ElementStatuses_reference()
            {
                Assert.AreEqual(0, dbElement1.ElementStatuses.Count);
                Assert.AreEqual(0, dbElement2.ElementStatuses.Count);
            }

            [Test]
            public void test_Project_reference()
            {
                Assert.AreEqual(dbProject, dbElement1.Project);
                Assert.AreEqual(dbProject, dbElement2.Project);
            }

            [Test]
            public void test_Details_attribute()
            {
                Assert.AreEqual(null, dbElement1.Details);
                Assert.AreEqual(null, dbElement2.Details);
            }

            [Test]
            public void test_IsPrefabricated_attribute()
            {
                Assert.AreEqual(false, dbElement1.IsPrefabricated);
                Assert.AreEqual(false, dbElement2.IsPrefabricated);
            }

            [Test]
            public void test_ElementTerm_reference()
            {
                Assert.AreEqual(null, dbElement1.ElementTerm);
                Assert.AreEqual(null, dbElement2.ElementTerm);
            }

            [Test]
            public void test_ElementsTimeEvidences_reference()
            {
                Assert.AreEqual(0, dbElement1.TimeEvidences.Count);
                Assert.AreEqual(0, dbElement2.TimeEvidences.Count);
            }

            [Test]
            public void test_Comments_reference()
            {
                Assert.AreEqual(0, dbElement1.Comments.Count);
                Assert.AreEqual(0, dbElement2.Comments.Count);
            }
        }
    }
}