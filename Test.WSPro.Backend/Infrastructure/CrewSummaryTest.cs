using System;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class CrewSummaryTest : _setup
    {
        private CrewSummary dbCrewSummary;
        private CrewSummary dbCrewSummary2;
        private Crew dbCrew;
        private Project dbProject;
        private User dbUser;

        public override void Init()
        {
            CrewSummary crewSummary;
            CrewSummary crewSummary2;
            Crew crew;
            Project project;
            User user;
            using (var ctx = new WSProTestContext().Context)
            {
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                project = new Project { Name = "Project" };
                crew = new Crew
                {
                    Name = "crew 1",
                    Owner = user,
                    Project = project,
                    CrewWorkType = CrewWorkTypeEnum.SteelFixer
                };
                crewSummary = new CrewSummary
                {
                    Crew = crew,
                    Project = project,
                    StartDate = new DateTime(2021, 10, 1),
                    EndDate = new DateTime(2021, 10, 20),
                    CrewOwner = user
                };
                crewSummary2 = new CrewSummary
                {
                    Crew = crew,
                    Project = project,
                    StartDate = new DateTime(1990, 11, 1),
                    EndDate = new DateTime(1990, 11, 20),
                    CrewOwner = user
                };

                ctx.AddRange(user, project, crew, crewSummary, crewSummary2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dbCrewSummary = ctx.CrewSummaries.Find(crewSummary.Id);
                dbCrewSummary2 = ctx.CrewSummaries.Find(crewSummary2.Id);
                dbCrew = ctx.Crews.Find(crew.Id);
                dbProject = ctx.Projects.Find(project.Id);
                dbUser = ctx.Users.Find(user.Id);
            }
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.NotNull(dbCrewSummary.Id);
            Assert.NotNull(dbCrewSummary2.Id);
            Assert.That(() => dbCrewSummary.Id != dbCrewSummary2.Id);
        }

        [Test]
        public void test_Crew_reference()
        {
            Assert.AreEqual(dbCrew.Id, dbCrewSummary.CrewId);
            Assert.AreEqual(dbCrew, dbCrewSummary.Crew);
            Assert.AreEqual(dbCrew.Id, dbCrewSummary2.CrewId);
            Assert.AreEqual(dbCrew, dbCrewSummary2.Crew);
        }

        [Test]
        public void test_StartDate_attribute()
        {
            Assert.AreEqual(new DateTime(2021, 10, 1), dbCrewSummary.StartDate);
            Assert.AreEqual(new DateTime(1990, 11, 1), dbCrewSummary2.StartDate);
        }

        [Test]
        public void test_EndDate_attribute()
        {
            Assert.AreEqual(new DateTime(2021, 10, 20), dbCrewSummary.EndDate);
            Assert.AreEqual(new DateTime(1990, 11, 20), dbCrewSummary2.EndDate);
        }

        [Test]
        public void test_CrewOwner_reference()
        {
            Assert.AreEqual(dbUser.Id, dbCrewSummary.UserId);
            Assert.AreEqual(dbUser, dbCrewSummary.CrewOwner);
            Assert.AreEqual(dbUser.Id, dbCrewSummary2.UserId);
            Assert.AreEqual(dbUser, dbCrewSummary2.CrewOwner);
        }

        [Test]
        public void test_TimeEvidences_reference()
        {
            Assert.AreEqual(0, dbCrewSummary.TimeEvidences.Count);
            Assert.AreEqual(0, dbCrewSummary2.TimeEvidences.Count);
        }

        [Test]
        public void test_Workers_reference()
        {
            Assert.AreEqual(0, dbCrewSummary.Workers.Count);
            Assert.AreEqual(0, dbCrewSummary2.Workers.Count);
        }

        [Test]
        public void test_Project_reference()
        {
            Assert.AreEqual(dbProject.Id, dbCrewSummary.ProjectId);
            Assert.AreEqual(dbProject, dbCrewSummary.Project);
            Assert.AreEqual(dbProject.Id, dbCrewSummary2.ProjectId);
            Assert.AreEqual(dbProject, dbCrewSummary2.Project);
        }
    }
}