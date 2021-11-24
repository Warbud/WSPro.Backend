using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class ElementTimeEvidenceTest : _setup
    {
        public Crew DBcrew;
        public Project DBproject;
        public User DBuser;
        public Element DBelement1;
        public Element DBelement2;
        public Element DBelement3;
        public ElementsTimeEvidence DBelementsTimeEvidence1;
        public ElementsTimeEvidence DBelementsTimeEvidence2;
        public ElementsTimeEvidence DBelementsTimeEvidence3;
        public ElementsTimeEvidence DBelementsTimeEvidence4;
        public List<ElementsTimeEvidence> DBElementsTimeEvidenceCount;

        public override void Init()
        {
            Crew crew;
            Project project;
            User user;
            Element element1;
            Element element2;
            Element element3;
            ElementsTimeEvidence elementsTimeEvidence1;
            ElementsTimeEvidence elementsTimeEvidence2;
            ElementsTimeEvidence elementsTimeEvidence3;
            ElementsTimeEvidence elementsTimeEvidence4;
            using (var ctx = new WSProTestContext().Context)
            {
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                project = new Project { Name = "Project" };
                crew = new Crew
                {
                    Name = "test crew 1",
                    Owner = user,
                    Project = project,
                    CrewWorkType = CrewWorkTypeEnum.SteelFixer
                };

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
                element3 = new Element
                {
                    RevitId = 543154,
                    Project = project
                };

                elementsTimeEvidence1 = new ElementsTimeEvidence
                {
                    Crew = crew,
                    Project = project,
                    User = user,
                    WorkedTime = 32.52231m,
                    Date = new DateTime(2021, 10, 10)
                };
                elementsTimeEvidence1.Elements.Add(element1);
                elementsTimeEvidence1.Elements.Add(element2);
                elementsTimeEvidence2 = new ElementsTimeEvidence
                {
                    Crew = crew,
                    Project = project,
                    User = user,
                    Elements = new List<Element> { element2 },
                    WorkedTime = 10m,
                    Date = new DateTime(2021, 10, 11)
                };
                elementsTimeEvidence3 = new ElementsTimeEvidence
                {
                    Crew = crew,
                    Project = project,
                    User = user,
                    Elements = new List<Element> { element2, element3 },
                    WorkedTime = 20m,
                    Date = new DateTime(2021, 10, 12)
                };
                elementsTimeEvidence4 = new ElementsTimeEvidence
                {
                    Crew = crew,
                    Project = project,
                    User = user,
                    Elements = new List<Element> { element1, element2, element3 },
                    WorkedTime = 100m,
                    Date = new DateTime(2021, 10, 13)
                };
                ctx.AddRange(
                    crew,
                    project,
                    user,
                    elementsTimeEvidence1,
                    elementsTimeEvidence2,
                    elementsTimeEvidence3,
                    elementsTimeEvidence4,
                    element1,
                    element2,
                    element3
                );
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBElementsTimeEvidenceCount = ctx.ElementsTimeEvidences.ToList();
                DBcrew = ctx.Crews.Find(crew.Id);
                DBproject = ctx.Projects.Find(project.Id);
                DBuser = ctx.Users.Find(user.Id);
                DBelement1 = ctx.Elements.Find(element1.Id);
                DBelement2 = ctx.Elements.Find(element2.Id);
                DBelement3 = ctx.Elements.Find(element3.Id);
                DBelementsTimeEvidence1 = ctx.ElementsTimeEvidences.Include(e => e.Elements)
                    .FirstOrDefault(e => e.Id == elementsTimeEvidence1.Id);
                DBelementsTimeEvidence2 = ctx.ElementsTimeEvidences.Include(e => e.Elements)
                    .FirstOrDefault(e => e.Id == elementsTimeEvidence2.Id);
                DBelementsTimeEvidence3 = ctx.ElementsTimeEvidences.Include(e => e.Elements)
                    .FirstOrDefault(e => e.Id == elementsTimeEvidence3.Id);
                DBelementsTimeEvidence4 = ctx.ElementsTimeEvidences.Include(e => e.Elements)
                    .FirstOrDefault(e => e.Id == elementsTimeEvidence4.Id);
            }
        }

        [TestFixture]
        private class test_basic_attributes : ElementTimeEvidenceTest
        {
            [Test]
            public void should_have_proper_count_element_added()
            {
                Assert.AreEqual(4, DBElementsTimeEvidenceCount.Count);
            }

            [Test]
            public void should_have_proper_Id()
            {
                Assert.That(DBelementsTimeEvidence1.Id, Is.TypeOf<int>());
                Assert.That(DBelementsTimeEvidence2.Id, Is.TypeOf<int>());
                Assert.That(DBelementsTimeEvidence3.Id, Is.TypeOf<int>());
                Assert.That(DBelementsTimeEvidence4.Id, Is.TypeOf<int>());

                Assert.That(() =>
                    DBelementsTimeEvidence1.Id != DBelementsTimeEvidence2.Id &&
                    DBelementsTimeEvidence2.Id != DBelementsTimeEvidence3.Id &&
                    DBelementsTimeEvidence3.Id != DBelementsTimeEvidence4.Id
                );
            }

            [Test]
            public void should_have_properly_added_Element_reference()
            {
                Assert.AreEqual(2, DBelementsTimeEvidence1.Elements.Count);
                Assert.That(DBelementsTimeEvidence1.Elements.Contains(DBelement1));
                Assert.That(DBelementsTimeEvidence1.Elements.Contains(DBelement2));

                Assert.AreEqual(1, DBelementsTimeEvidence2.Elements.Count);
                Assert.That(DBelementsTimeEvidence2.Elements.Contains(DBelement2));

                Assert.AreEqual(2, DBelementsTimeEvidence3.Elements.Count);
                Assert.That(DBelementsTimeEvidence3.Elements.Contains(DBelement2));
                Assert.That(DBelementsTimeEvidence3.Elements.Contains(DBelement3));

                Assert.AreEqual(3, DBelementsTimeEvidence4.Elements.Count);
                Assert.That(DBelementsTimeEvidence4.Elements.Contains(DBelement1));
                Assert.That(DBelementsTimeEvidence4.Elements.Contains(DBelement2));
                Assert.That(DBelementsTimeEvidence4.Elements.Contains(DBelement3));
            }

            [Test]
            public void should_have_proper_Date()
            {
                Assert.AreEqual(new DateTime(2021, 10, 10), DBelementsTimeEvidence1.Date);
                Assert.AreEqual(new DateTime(2021, 10, 11), DBelementsTimeEvidence2.Date);
                Assert.AreEqual(new DateTime(2021, 10, 12), DBelementsTimeEvidence3.Date);
                Assert.AreEqual(new DateTime(2021, 10, 13), DBelementsTimeEvidence4.Date);
            }

            [Test]
            public void should_have_proper_User()
            {
                Assert.AreEqual(DBuser, DBelementsTimeEvidence1.User);
                Assert.AreEqual(DBuser, DBelementsTimeEvidence2.User);
                Assert.AreEqual(DBuser, DBelementsTimeEvidence3.User);
                Assert.AreEqual(DBuser, DBelementsTimeEvidence4.User);
            }

            [Test]
            public void should_have_proper_Project()
            {
                Assert.AreEqual(DBproject, DBelementsTimeEvidence1.Project);
                Assert.AreEqual(DBproject, DBelementsTimeEvidence2.Project);
                Assert.AreEqual(DBproject, DBelementsTimeEvidence3.Project);
                Assert.AreEqual(DBproject, DBelementsTimeEvidence4.Project);
            }

            [Test]
            public void should_have_proper_Crew()
            {
                Assert.AreEqual(DBcrew, DBelementsTimeEvidence1.Crew);
                Assert.AreEqual(DBcrew, DBelementsTimeEvidence2.Crew);
                Assert.AreEqual(DBcrew, DBelementsTimeEvidence3.Crew);
                Assert.AreEqual(DBcrew, DBelementsTimeEvidence4.Crew);
            }

            [Test]
            public void should_have_proper_WorkedTime()
            {
                Assert.AreEqual(32.5m, DBelementsTimeEvidence1.WorkedTime);
                Assert.AreEqual(10, DBelementsTimeEvidence2.WorkedTime);
                Assert.AreEqual(20, DBelementsTimeEvidence3.WorkedTime);
                Assert.AreEqual(100, DBelementsTimeEvidence4.WorkedTime);
            }
        }

        [TestFixture]
        private class test_ElementsTimeEvidence_reference_inside_Element_entity : ElementTimeEvidenceTest
        {
            [Test]
            public void Element_should_have_proper_count_references()
            {
                Assert.AreEqual(2, DBelement1.TimeEvidences.Count);
                Assert.That(DBelement1.TimeEvidences.Contains(DBelementsTimeEvidence1));
                Assert.That(DBelement1.TimeEvidences.Contains(DBelementsTimeEvidence4));

                Assert.AreEqual(4, DBelement2.TimeEvidences.Count);
                Assert.That(DBelement2.TimeEvidences.Contains(DBelementsTimeEvidence1));
                Assert.That(DBelement2.TimeEvidences.Contains(DBelementsTimeEvidence2));
                Assert.That(DBelement2.TimeEvidences.Contains(DBelementsTimeEvidence3));
                Assert.That(DBelement2.TimeEvidences.Contains(DBelementsTimeEvidence4));

                Assert.AreEqual(2, DBelement3.TimeEvidences.Count);
                Assert.That(DBelement3.TimeEvidences.Contains(DBelementsTimeEvidence3));
                Assert.That(DBelement3.TimeEvidences.Contains(DBelementsTimeEvidence4));
            }
        }
    }
}