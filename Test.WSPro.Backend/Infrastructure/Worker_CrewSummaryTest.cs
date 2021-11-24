using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class Worker_CrewSummaryTest : _setup
    {
        internal Project dbproject;
        internal User dbuser;
        internal Worker dbworker;
        internal Worker dbworker2;
        internal Worker dbworker3;
        internal Worker dbworker4;
        internal Crew dbcrew;
        internal Crew dbcrew2;
        internal CrewSummary dbcrewSummary;
        internal CrewSummary dbcrewSummary2;
        internal Worker_CrewSummary DBworkerCrewSummary;
        internal Worker_CrewSummary DBworkerCrewSummary2;
        internal Worker_CrewSummary DBworkerCrewSummary3;
        internal Worker_CrewSummary DBworkerCrewSummary4;

        internal List<Worker_CrewSummary> WorkerCrewSummaryList;

        public override void Init()
        {
            Project project;
            User user;
            Worker worker;
            Worker worker2;
            Worker worker3;
            Worker worker4;
            Crew crew;
            Crew crew2;
            CrewSummary crewSummary;
            CrewSummary crewSummary2;

            using (var ctx = new WSProTestContext().Context)
            {
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                project = new Project { Name = "Project" };
                crew = new Crew
                    { Name = "crewName", Project = project, Owner = user, CrewWorkType = CrewWorkTypeEnum.SteelFixer };
                crew2 = new Crew
                    { Name = "crew 2", Project = project, Owner = user, CrewWorkType = CrewWorkTypeEnum.Carpenter };


                worker = new Worker { Name = "ziomo" };
                worker2 = new Worker { WarbudId = "A00123" };
                worker3 = new Worker { Name = "ziomo 2" };
                worker4 = new Worker { WarbudId = "HRH1029837" };


                crewSummary = new CrewSummary
                {
                    Crew = crew,
                    Project = project,
                    CrewOwner = user,
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2020, 1, 30),
                    Workers = new List<Worker> { worker, worker2 }
                };
                crewSummary2 = new CrewSummary
                {
                    Crew = crew2,
                    Project = project,
                    CrewOwner = user,
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2020, 1, 30),
                    Workers = new List<Worker> { worker3, worker4 }
                };

                ctx.AddRange(user, project, worker, worker2, worker3,
                    worker4, crew, crew2, crewSummary, crewSummary2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dbproject = ctx.Projects.Find(project.Id);
                dbuser = ctx.Users.Find(user.Id);
                dbworker = ctx.Workers.Find(worker.Id);
                dbworker2 = ctx.Workers.Find(worker2.Id);
                dbworker3 = ctx.Workers.Find(worker3.Id);
                dbworker4 = ctx.Workers.Find(worker4.Id);
                dbcrew = ctx.Crews.Find(crew.Id);
                dbcrew2 = ctx.Crews.Find(crew2.Id);
                dbcrewSummary = ctx.CrewSummaries.Find(crewSummary.Id);
                dbcrewSummary2 = ctx.CrewSummaries.Find(crewSummary2.Id);
                //
                WorkerCrewSummaryList = ctx.Worker_CrewSummaries.ToList();
                //
                DBworkerCrewSummary = ctx.Worker_CrewSummaries.Find(worker.Id, crewSummary.Id);
                DBworkerCrewSummary2 = ctx.Worker_CrewSummaries.Find(worker2.Id, crewSummary.Id);
                DBworkerCrewSummary3 = ctx.Worker_CrewSummaries.Find(worker3.Id, crewSummary2.Id);
                DBworkerCrewSummary4 = ctx.Worker_CrewSummaries.Find(worker4.Id, crewSummary2.Id);
            }
        }

        [TestFixture]
        private class base_model_test : Worker_CrewSummaryTest
        {
            [Test]
            public void test_items_count()
            {
                Assert.AreEqual(4, WorkerCrewSummaryList.Count);
            }

            [Test]
            public void test_Worker_reference()
            {
                Assert.AreEqual(2, dbcrewSummary.Workers.Count);
                Assert.AreEqual(dbworker, DBworkerCrewSummary.Worker);
                Assert.AreEqual(dbworker2, DBworkerCrewSummary2.Worker);


                Assert.AreEqual(2, dbcrewSummary2.Workers.Count);
                Assert.AreEqual(dbworker3, DBworkerCrewSummary3.Worker);
                Assert.AreEqual(dbworker4, DBworkerCrewSummary4.Worker);
            }

            [Test]
            public void test_CrewSummary_reference()
            {
                Assert.AreEqual(dbcrewSummary, DBworkerCrewSummary.CrewSummary);
                Assert.AreEqual(dbcrewSummary, DBworkerCrewSummary2.CrewSummary);
                Assert.AreEqual(dbcrewSummary2, DBworkerCrewSummary3.CrewSummary);
                Assert.AreEqual(dbcrewSummary2, DBworkerCrewSummary4.CrewSummary);
            }

            [Test]
            public void test_CreatedAt_attribute()
            {
                Assert.NotNull(DBworkerCrewSummary.CreatedAt);
                Assert.NotNull(DBworkerCrewSummary2.CreatedAt);
                Assert.NotNull(DBworkerCrewSummary3.CreatedAt);
                Assert.NotNull(DBworkerCrewSummary4.CreatedAt);
            }

            [Test]
            public void test_UpdatedAt_attribute()
            {
                Assert.NotNull(DBworkerCrewSummary.UpdatedAt);
                Assert.NotNull(DBworkerCrewSummary2.UpdatedAt);
                Assert.NotNull(DBworkerCrewSummary3.UpdatedAt);
                Assert.NotNull(DBworkerCrewSummary4.UpdatedAt);
            }
        }

        [TestFixture]
        public class test_reference_from_CrewSummary_to_Worker : Worker_CrewSummaryTest
        {
            [Test]
            public void should_have_proper_count_references()
            {
                Assert.AreEqual(2, dbcrewSummary.Workers.Count);
                Assert.AreEqual(2, dbcrewSummary2.Workers.Count);
            }

            [Test]
            public void should_have_proper_references_to_Worker_CrewSummary_entity()
            {
                Assert.AreEqual(dbworker, dbcrewSummary.Workers.ToList()[0]);
                Assert.AreEqual(dbworker2, dbcrewSummary.Workers.ToList()[1]);
                Assert.AreEqual(dbworker3, dbcrewSummary2.Workers.ToList()[0]);
                Assert.AreEqual(dbworker4, dbcrewSummary2.Workers.ToList()[1]);
            }
        }

        [TestFixture]
        public class test_reference_from_Worker_model_to_CrewSummary : Worker_CrewSummaryTest
        {
            [Test]
            public void should_have_proper_references_count()
            {
                Assert.AreEqual(1, dbworker.CrewSummaries.Count);
                Assert.AreEqual(1, dbworker2.CrewSummaries.Count);
                Assert.AreEqual(1, dbworker3.CrewSummaries.Count);
                Assert.AreEqual(1, dbworker4.CrewSummaries.Count);
            }

            [Test]
            public void should_have_proper_reference_to_CrewSummary_entity()
            {
                Assert.AreEqual(dbcrewSummary, dbworker.CrewSummaries.First());
                Assert.AreEqual(dbcrewSummary, dbworker2.CrewSummaries.First());
                Assert.AreEqual(dbcrewSummary2, dbworker3.CrewSummaries.First());
                Assert.AreEqual(dbcrewSummary2, dbworker4.CrewSummaries.First());
            }
        }
    }
}