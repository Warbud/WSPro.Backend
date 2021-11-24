using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class ProjectTest : _setup
    {
        private List<Project> _projectList;
        private Project project1;
        private Project project2;
        private Project project3;
        private Project project4;

        public override void Init()
        {
            using (var ctx = new WSProTestContext().Context)
            {
                project1 = new Project
                {
                    Name = "Project 1",
                    WebconCode = "Webcon",
                    MetodologyCode = "Methodolody",
                    CentralScheduleSync = true,
                    SupportedStatuses = new List<StatusEnum>() { StatusEnum.Finished, StatusEnum.InProgress }
                };
                project2 = new Project
                {
                    Name = "Project 2",
                    MetodologyCode = "Methodolody code 2",
                    CentralScheduleSync = true,
                    SupportedStatuses = new List<StatusEnum>() { StatusEnum.Finished }
                };
                project3 = new Project
                {
                    Name = "Project 3",
                    MetodologyCode = "Methodolody code 2",
                    SupportedStatuses = new List<StatusEnum>() { StatusEnum.Finished, StatusEnum.InProgress }
                };
                project4 = new Project
                {
                    Name = "Project 4",
                    SupportedStatuses = new List<StatusEnum>() { StatusEnum.InProgress }
                };

                ctx.Projects.AddRange(project1, project2, project3, project4);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                _projectList = ctx.Projects.ToList();
            }
        }

        [TestFixture]
        private class test_basic_attributes : ProjectTest
        {
            [Test]
            public void test_projects_added_count()
            {
                Assert.AreEqual(4, _projectList.Count);
            }

            [Test]
            public void test_Id_attribute()
            {
                Assert.NotNull(project1.Id);
                Assert.NotNull(project2.Id);
                Assert.NotNull(project3.Id);
                Assert.NotNull(project4.Id);
                Assert.That(
                    () => project1.Id != project2.Id && project2.Id != project3.Id && project3.Id != project4.Id);
            }

            [Test]
            public void test_Name_attribute()
            {
                Assert.AreEqual("Project 1", project1.Name);
                Assert.AreEqual("Project 2", project2.Name);
                Assert.AreEqual("Project 3", project3.Name);
                Assert.AreEqual("Project 4", project4.Name);
            }

            [Test]
            public void test_WebconCode_attribute()
            {
                Assert.AreEqual("Webcon", project1.WebconCode);
                Assert.AreEqual(null, project2.WebconCode);
                Assert.AreEqual(null, project3.WebconCode);
                Assert.AreEqual(null, project4.WebconCode);
            }

            [Test]
            public void test_MetodologyCode_attribute()
            {
                Assert.AreEqual("Methodolody", project1.MetodologyCode);
                Assert.AreEqual("Methodolody code 2", project2.MetodologyCode);
                Assert.AreEqual("Methodolody code 2", project3.MetodologyCode);
                Assert.AreEqual(null, project4.MetodologyCode);
            }

            [Test]
            public void test_CentralScheduleSync_attribute()
            {
                Assert.AreEqual(true, project1.CentralScheduleSync);
                Assert.AreEqual(true, project2.CentralScheduleSync);
                Assert.AreEqual(false, project3.CentralScheduleSync);
                Assert.AreEqual(false, project4.CentralScheduleSync);
            }

            [Test]
            public void test_SupportedStatuses_attribute()
            {
                Assert.AreEqual(2, project1.SupportedStatuses.Count());
                Assert.That(project1.SupportedStatuses.Contains(StatusEnum.InProgress));
                Assert.That(project1.SupportedStatuses.Contains(StatusEnum.Finished));
                
                Assert.AreEqual(1, project2.SupportedStatuses.Count());
                Assert.That(project2.SupportedStatuses.Contains(StatusEnum.Finished));
                
                Assert.AreEqual(2, project3.SupportedStatuses.Count());
                Assert.That(project3.SupportedStatuses.Contains(StatusEnum.InProgress));
                Assert.That(project3.SupportedStatuses.Contains(StatusEnum.Finished));
                
                Assert.AreEqual(1, project4.SupportedStatuses.Count());
                Assert.That(project4.SupportedStatuses.Contains(StatusEnum.InProgress));
            }

            [Test]
            public void test_BimModels()
            {
                Assert.AreEqual(0, project1.Models.Count);
                Assert.AreEqual(0, project2.Models.Count);
                Assert.AreEqual(0, project3.Models.Count);
                Assert.AreEqual(0, project4.Models.Count);
            }
        }
    }
}