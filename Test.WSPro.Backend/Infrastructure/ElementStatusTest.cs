using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class ElementStatusTest : _setup
    {
        public Project DBproject;
        public Element DBelement1;
        public Element DBelement2;
        public User DBuser;
        public ElementStatus DBelementStatus1;
        public ElementStatus DBelementStatus2;
        public ElementStatus DBelementStatus3;
        public ElementStatus DBelementStatus4;
        public List<ElementStatus> DBElementStatusList;

        public override void Init()
        {
            Project project;
            Element element1;
            Element element2;
            User user;
            ElementStatus elementStatus1;
            ElementStatus elementStatus2;
            ElementStatus elementStatus3;
            ElementStatus elementStatus4;
            using (var ctx = new WSProTestContext().Context)
            {
                project = new Project
                {
                    Name = "test project",
                    SupportedStatuses = new List<StatusEnum>
                    {
                        StatusEnum.Finished, StatusEnum.InProgress
                    }
                };
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

                elementStatus1 = new ElementStatus
                {
                    Date = new DateTime(2021, 10, 10),
                    Element = element1,
                    Project = project,
                    Status = StatusEnum.Finished,
                    SetBy = user
                };
                elementStatus2 = new ElementStatus
                {
                    Date = new DateTime(2021, 10, 11),
                    Element = element1,
                    Project = project,
                    Status = StatusEnum.Finished,
                    SetBy = user
                };
                elementStatus3 = new ElementStatus
                {
                    Date = new DateTime(2021, 10, 9),
                    Element = element2,
                    Project = project,
                    Status = StatusEnum.InProgress,
                    SetBy = user
                };
                elementStatus4 = new ElementStatus
                {
                    Date = new DateTime(2021, 10, 9),
                    Element = element2,
                    Project = project,
                    Status = StatusEnum.InProgress,
                    SetBy = user
                };

                ctx.AddRange(project, user, element1, element2,
                    elementStatus1, elementStatus2, elementStatus3, elementStatus4
                );
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBElementStatusList = ctx.ElementStatuses.ToList();
                DBproject = ctx.Projects.Find(project.Id);
                DBelement1 = ctx.Elements.Find(element1.Id);
                DBelement2 = ctx.Elements.Find(element2.Id);
                DBuser = ctx.Users.Find(user.Id);
                DBelementStatus1 = ctx.ElementStatuses.Find(elementStatus1.Id);
                DBelementStatus2 = ctx.ElementStatuses.Find(elementStatus2.Id);
                DBelementStatus3 = ctx.ElementStatuses.Find(elementStatus3.Id);
                DBelementStatus4 = ctx.ElementStatuses.Find(elementStatus4.Id);
            }
        }

        [TestFixture]
        private class test_basic_ElementStatus_attributes : ElementStatusTest
        {
            [Test]
            public void should_have_proper_added_elements_count()
            {
                Assert.AreEqual(4, DBElementStatusList.Count);
            }

            [Test]
            public void should_have_proper_Id_attribute()
            {
                Assert.That(DBelementStatus1.Id, Is.TypeOf<int>());
                Assert.That(DBelementStatus2.Id, Is.TypeOf<int>());
                Assert.That(DBelementStatus3.Id, Is.TypeOf<int>());
                Assert.That(DBelementStatus4.Id, Is.TypeOf<int>());

                Assert.That(() =>
                    DBelementStatus1.Id != DBelementStatus2.Id &&
                    DBelementStatus2.Id != DBelementStatus3.Id &&
                    DBelementStatus3.Id != DBelementStatus4.Id
                );
            }

            [Test]
            public void should_have_proper_date()
            {
                Assert.AreEqual(new DateTime(2021, 10, 10), DBelementStatus1.Date);
                Assert.AreEqual(new DateTime(2021, 10, 11), DBelementStatus2.Date);
                Assert.AreEqual(new DateTime(2021, 10, 9), DBelementStatus3.Date);
                Assert.AreEqual(new DateTime(2021, 10, 9), DBelementStatus4.Date);
            }

            [Test]
            public void should_have_proper_Status()
            {
                Assert.AreEqual(StatusEnum.Finished, DBelementStatus1.Status);
                Assert.AreEqual(StatusEnum.Finished, DBelementStatus2.Status);
                Assert.AreEqual(StatusEnum.InProgress, DBelementStatus3.Status);
                Assert.AreEqual(StatusEnum.InProgress, DBelementStatus4.Status);
            }

            [Test]
            public void should_have_proper_Element()
            {
                Assert.AreEqual(DBelement1, DBelementStatus1.Element);
                Assert.AreEqual(DBelement1, DBelementStatus2.Element);
                Assert.AreEqual(DBelement2, DBelementStatus3.Element);
                Assert.AreEqual(DBelement2, DBelementStatus4.Element);
            }

            [Test]
            public void should_have_proper_SetBy()
            {
                Assert.AreEqual(DBuser, DBelementStatus1.SetBy);
                Assert.AreEqual(DBuser, DBelementStatus2.SetBy);
                Assert.AreEqual(DBuser, DBelementStatus3.SetBy);
                Assert.AreEqual(DBuser, DBelementStatus4.SetBy);
            }

            [Test]
            public void should_have_proper_Project()
            {
                Assert.AreEqual(DBproject, DBelementStatus1.Project);
                Assert.AreEqual(DBproject, DBelementStatus2.Project);
                Assert.AreEqual(DBproject, DBelementStatus3.Project);
                Assert.AreEqual(DBproject, DBelementStatus4.Project);
            }
        }

        [TestFixture]
        private class test_ElementStatus_reference_inside_Element_model : ElementStatusTest
        {
            [Test]
            public void should_have_properly_count()
            {
                Assert.AreEqual(2, DBelement1.ElementStatuses.Count);
                Assert.AreEqual(2, DBelement2.ElementStatuses.Count);
            }

            [Test]
            public void should_have_proper_setted_responded_statuses()
            {
                Assert.AreEqual(DBelementStatus1, DBelement1.ElementStatuses.ToList()[0]);
                Assert.AreEqual(DBelementStatus2, DBelement1.ElementStatuses.ToList()[1]);
                Assert.AreEqual(DBelementStatus3, DBelement2.ElementStatuses.ToList()[0]);
                Assert.AreEqual(DBelementStatus4, DBelement2.ElementStatuses.ToList()[1]);
            }
        }
    }
}