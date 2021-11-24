using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class ElementTermTest : _setup
    {
        public Project DBproject;
        public User DBuser;
        public Element DBelement1;
        public Element DBelement2;
        public ElementTerm DBelementTerm;
        public ElementTerm DBelementTerm2;
        public List<ElementTerm> DBElementTermList;

        public override void Init()
        {
            Project project;
            User user;
            Element element1;
            Element element2;
            ElementTerm elementTerm;
            ElementTerm elementTerm2;
            using (var ctx = new WSProTestContext().Context)
            {
                project = new Project { Name = "test project" };
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                element1 = new Element
                {
                    RevitId = 111111,
                    Project = project
                };
                element2 = new Element
                {
                    RevitId = 12314123,
                    Project = project
                };
                elementTerm = new ElementTerm
                {
                    Element = element1
                };
                elementTerm2 = new ElementTerm
                {
                    Element = element2,
                    PlannedStartBP = new DateTime(2021, 1, 10),
                    PlannedFinishBP = new DateTime(2021, 2, 10),
                    PlannedStart = new DateTime(2021, 3, 10),
                    PlannedFinish = new DateTime(2021, 4, 10),
                    RealStart = new DateTime(2021, 5, 10),
                    RealFinish = new DateTime(2021, 6, 10)
                };
                ctx.AddRange(project, user, element1, element2, elementTerm, elementTerm2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBproject = ctx.Projects.Find(project.Id);
                DBuser = ctx.Users.Find(user.Id);
                DBelement1 = ctx.Elements.Find(element1.Id);
                DBelement2 = ctx.Elements.Find(element2.Id);
                DBelementTerm = ctx.ElementTerms.Find(elementTerm.Element.Id);
                DBelementTerm2 = ctx.ElementTerms.Find(elementTerm2.Element.Id);
                DBElementTermList = ctx.ElementTerms.ToList();
            }
        }

        [TestFixture]
        private class test_basic_attributes : ElementTermTest
        {
            [Test]
            public void should_have_added_proper_item_count_to_db()
            {
                Assert.AreEqual(2, DBElementTermList.Count);
            }

            [Test]
            public void should_have_same_Element_reference()
            {
                Assert.AreEqual(DBelement1, DBelementTerm.Element);
                Assert.AreEqual(DBelement2, DBelementTerm2.Element);
            }

            [Test]
            public void should_have_PlannedStartBP()
            {
                Assert.AreEqual(null, DBelementTerm.PlannedStartBP);
                Assert.AreEqual(new DateTime(2021, 1, 10), DBelementTerm2.PlannedStartBP);
            }

            [Test]
            public void should_have_PlannedFinishBP()
            {
                Assert.AreEqual(null, DBelementTerm.PlannedFinishBP);
                Assert.AreEqual(new DateTime(2021, 2, 10), DBelementTerm2.PlannedFinishBP);
            }

            [Test]
            public void should_have_PlannedStart()
            {
                Assert.AreEqual(null, DBelementTerm.PlannedStart);
                Assert.AreEqual(new DateTime(2021, 3, 10), DBelementTerm2.PlannedStart);
            }

            [Test]
            public void should_have_PlannedFinish()
            {
                Assert.AreEqual(null, DBelementTerm.PlannedFinish);
                Assert.AreEqual(new DateTime(2021, 4, 10), DBelementTerm2.PlannedFinish);
            }

            [Test]
            public void should_have_RealStart()
            {
                Assert.AreEqual(null, DBelementTerm.RealStart);
                Assert.AreEqual(new DateTime(2021, 5, 10), DBelementTerm2.RealStart);
            }

            [Test]
            public void should_have_RealFinish()
            {
                Assert.AreEqual(null, DBelementTerm.RealFinish);
                Assert.AreEqual(new DateTime(2021, 6, 10), DBelementTerm2.RealFinish);
            }

            [Test]
            public void should_have_CreatedAt()
            {
                Assert.NotNull(DBelementTerm.CreatedAt);
                Assert.NotNull(DBelementTerm.CreatedAt);
            }

            [Test]
            public void should_have_UpdatedAt()
            {
                Assert.NotNull(DBelementTerm.UpdatedAt);
                Assert.NotNull(DBelementTerm.UpdatedAt);
            }
        }

        [TestFixture]
        private class test_ElementTerm_reference_inside_Element_entity : ElementTermTest
        {
            [Test]
            public void should_refer_to_same_object()
            {
                Assert.AreEqual(DBelementTerm, DBelement1.ElementTerm);
                Assert.AreEqual(DBelementTerm2, DBelement2.ElementTerm);
            }
        }
    }
}