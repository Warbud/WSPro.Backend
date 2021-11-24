using System;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class GroupTermTest : _setup
    {
        public GroupTerm DBgroupTerm1;
        public GroupTerm DBgroupTerm2;
        public Crane DBcrane;
        public Level DBlevel;
        public Project DBproject;
        public Element DBelement1;
        public Element DBelement2;
        public Element DBelement3;
        public ElementTerm DBelementTerm1;
        public ElementTerm DBelementTerm2;
        public ElementTerm DBelementTerm3;

        public override void Init()
        {
            GroupTerm groupTerm1;
            GroupTerm groupTerm2;
            Crane crane;
            Level level;
            Project project;
            Element element1;
            Element element2;
            Element element3;
            ElementTerm elementTerm1;
            ElementTerm elementTerm2;
            ElementTerm elementTerm3;
            using (var ctx = new WSProTestContext().Context)
            {
                project = new Project { Name = "test project" };
                element1 = new Element
                {
                    RevitId = 111111,
                    Project = project
                };
                element2 = new Element
                {
                    RevitId = 131234123,
                    Project = project
                };
                element3 = new Element
                {
                    RevitId = 534243,
                    Project = project
                };
                crane = new Crane { Name = "01" };
                level = new Level { Name = "L01" };

                groupTerm1 = new GroupTerm
                {
                    Project = project,
                    Vertical = VerticalEnum.V
                };
                groupTerm2 = new GroupTerm
                {
                    Project = project,
                    Vertical = VerticalEnum.H,
                    PlannedStartBP = new DateTime(2021, 10, 10),
                    PlannedFinishBP = new DateTime(2021, 10, 11),
                    PlannedFinish = new DateTime(2021, 9, 19),
                    PlannedStart = new DateTime(2021, 8, 8),
                    RealStart = new DateTime(2021, 2, 2),
                    RealFinish = new DateTime(2021, 10, 1),
                    Level = level,
                    Crane = crane
                };
                elementTerm1 = new ElementTerm
                {
                    Element = element1,
                    GroupTerm = groupTerm1
                };
                elementTerm2 = new ElementTerm
                {
                    Element = element2,
                    GroupTerm = groupTerm1
                };
                elementTerm3 = new ElementTerm
                {
                    Element = element3,
                    GroupTerm = groupTerm2
                };

                ctx.AddRange(
                    groupTerm1,
                    groupTerm2,
                    crane,
                    level,
                    project,
                    element1,
                    element2,
                    element3,
                    elementTerm1,
                    elementTerm2,
                    elementTerm3
                );
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBgroupTerm1 = ctx.GroupTerms.Find(groupTerm1.Id);
                DBgroupTerm2 = ctx.GroupTerms.Find(groupTerm2.Id);
                DBcrane = ctx.Cranes.Find(crane.Id);
                DBlevel = ctx.Levels.Find(level.Id);
                DBproject = ctx.Projects.Find(project.Id);
                DBelement1 = ctx.Elements.Find(element1.Id);
                DBelement2 = ctx.Elements.Find(element2.Id);
                DBelement3 = ctx.Elements.Find(element3.Id);
                DBelementTerm1 = ctx.ElementTerms.Find(element1.Id);
                DBelementTerm2 = ctx.ElementTerms.Find(element2.Id);
                DBelementTerm3 = ctx.ElementTerms.Find(element3.Id);
            }
        }

        [TestFixture]
        public class test_basic_attributes : GroupTermTest
        {
            [Test]
            public void test_Id()
            {
                Assert.That(DBgroupTerm1.Id, Is.TypeOf<int>());
                Assert.That(DBgroupTerm2.Id, Is.TypeOf<int>());
                Assert.AreNotEqual(DBgroupTerm1.Id, DBgroupTerm2.Id);
            }

            [Test]
            public void test_Vertical()
            {
                Assert.AreEqual(VerticalEnum.V, DBgroupTerm1.Vertical);
                Assert.AreEqual(VerticalEnum.H, DBgroupTerm2.Vertical);
            }

            [Test]
            public void test_PlannedStart()
            {
                Assert.AreEqual(null, DBgroupTerm1.PlannedStart);
                Assert.AreEqual(new DateTime(2021, 8, 8), DBgroupTerm2.PlannedStart);
            }

            [Test]
            public void test_PlannedFinish()
            {
                Assert.AreEqual(null, DBgroupTerm1.PlannedFinish);
                Assert.AreEqual(new DateTime(2021, 9, 19), DBgroupTerm2.PlannedFinish);
            }

            [Test]
            public void test_PlannedStartBP()
            {
                Assert.AreEqual(null, DBgroupTerm1.PlannedStartBP);
                Assert.AreEqual(new DateTime(2021, 10, 10), DBgroupTerm2.PlannedStartBP);
            }

            [Test]
            public void test_PlannedFinishBP()
            {
                Assert.AreEqual(null, DBgroupTerm1.PlannedFinishBP);
                Assert.AreEqual(new DateTime(2021, 10, 11), DBgroupTerm2.PlannedFinishBP);
            }

            [Test]
            public void test_RealStart()
            {
                Assert.AreEqual(null, DBgroupTerm1.RealStart);
                Assert.AreEqual(new DateTime(2021, 2, 2), DBgroupTerm2.RealStart);
            }

            [Test]
            public void test_RealFinish()
            {
                Assert.AreEqual(null, DBgroupTerm1.RealFinish);
                Assert.AreEqual(new DateTime(2021, 10, 1), DBgroupTerm2.RealFinish);
            }

            [Test]
            public void test_Crane()
            {
                Assert.AreEqual(null, DBgroupTerm1.Crane);
                Assert.AreEqual(DBcrane, DBgroupTerm2.Crane);
            }

            [Test]
            public void test_Project()
            {
                Assert.AreEqual(DBproject, DBgroupTerm1.Project);
                Assert.AreEqual(DBproject, DBgroupTerm2.Project);
            }

            [Test]
            public void test_Level()
            {
                Assert.AreEqual(null, DBgroupTerm1.Level);
                Assert.AreEqual(DBlevel, DBgroupTerm2.Level);
            }

            [Test]
            public void test_Terms()
            {
                Assert.AreEqual(2, DBgroupTerm1.Terms.Count);
                Assert.That(DBgroupTerm1.Terms.Contains(DBelementTerm1));
                Assert.That(DBgroupTerm1.Terms.Contains(DBelementTerm2));

                Assert.AreEqual(1, DBgroupTerm2.Terms.Count);
                Assert.That(DBgroupTerm2.Terms.Contains(DBelementTerm3));
            }
        }
    }
}