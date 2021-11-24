using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class WorkerTimeEvidenceTest : _setup
    {
        internal User dbuser;
        internal Worker dbworker;
        internal Worker dbworker2;
        internal Project dbproject;
        internal Crew dbcrew;
        internal CrewSummary dbcrewSummary;
        internal WorkerTimeEvidence dbworkerTimeEvidence1;
        internal WorkerTimeEvidence dbworkerTimeEvidence2;
        internal WorkerTimeEvidence dbworkerTimeEvidence3;
        internal WorkerTimeEvidence dbworkerTimeEvidence4;
        internal List<WorkerTimeEvidence> dbWorkerTimeEvidences;

        public override void Init()
        {
            User user;
            Worker worker;
            Worker worker2;
            Project project;
            Crew crew;
            CrewSummary crewSummary;
            WorkerTimeEvidence workerTimeEvidence1;
            WorkerTimeEvidence workerTimeEvidence2;
            WorkerTimeEvidence workerTimeEvidence3;
            WorkerTimeEvidence workerTimeEvidence4;
            using (var ctx = new WSProTestContext().Context)
            {
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                worker = new Worker { Name = "ziomo" };
                worker2 = new Worker { WarbudId = "A00123" };
                project = new Project { Name = "Project 2" };
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
                    CrewOwner = user,
                    Workers = new List<Worker> { worker, worker2 }
                };
                workerTimeEvidence1 = new WorkerTimeEvidence
                {
                    Date = new DateTime(2021, 10, 1),
                    Worker = worker,
                    SetByEngineer = user,
                    Project = project,
                    WorkedTime = 10.5m,
                    CrewSummary = crewSummary
                };
                workerTimeEvidence2 = new WorkerTimeEvidence
                {
                    Date = new DateTime(2021, 10, 2),
                    Worker = worker,
                    SetByEngineer = user,
                    Project = project,
                    WorkedTime = 9,
                    CrewSummary = crewSummary
                };
                workerTimeEvidence3 = new WorkerTimeEvidence
                {
                    Date = new DateTime(2021, 10, 1),
                    Worker = worker2,
                    SetByEngineer = user,
                    Project = project,
                    WorkedTime = 5,
                    CrewSummary = crewSummary
                };
                workerTimeEvidence4 = new WorkerTimeEvidence
                {
                    Date = new DateTime(2021, 10, 2),
                    Worker = worker2,
                    SetByEngineer = user,
                    Project = project,
                    WorkedTime = 3,
                    CrewSummary = crewSummary
                };
                ctx.AddRange(user, worker, worker2, project, crew, crewSummary, workerTimeEvidence1,
                    workerTimeEvidence2, workerTimeEvidence3, workerTimeEvidence4);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dbWorkerTimeEvidences = ctx.WorkerTimeEvidences.ToList();
                dbcrew = ctx.Crews.Find(crew.Id);
                dbproject = ctx.Projects.Find(project.Id);
                dbuser = ctx.Users.Find(user.Id);
                dbworker = ctx.Workers.Find(worker.Id);
                dbworker2 = ctx.Workers.Find(worker2.Id);
                dbcrewSummary = ctx.CrewSummaries.Find(crewSummary.Id);

                dbworkerTimeEvidence1 = ctx.WorkerTimeEvidences.Find(workerTimeEvidence1.Id);
                dbworkerTimeEvidence2 = ctx.WorkerTimeEvidences.Find(workerTimeEvidence2.Id);
                dbworkerTimeEvidence3 = ctx.WorkerTimeEvidences.Find(workerTimeEvidence3.Id);
                dbworkerTimeEvidence4 = ctx.WorkerTimeEvidences.Find(workerTimeEvidence4.Id);
            }
        }

        [TestFixture]
        private class test_basic_data : WorkerTimeEvidenceTest
        {
            [Test]
            public void should_have_proper_entities_count_in_db()
            {
                Assert.AreEqual(4, dbWorkerTimeEvidences.Count);
            }

            [Test]
            public void should_have_properly_set_Id()
            {
                Assert.That(dbworkerTimeEvidence1.Id, Is.TypeOf<int>());
                Assert.That(dbworkerTimeEvidence2.Id, Is.TypeOf<int>());
                Assert.That(dbworkerTimeEvidence3.Id, Is.TypeOf<int>());
                Assert.That(dbworkerTimeEvidence4.Id, Is.TypeOf<int>());

                Assert.That(() => dbworkerTimeEvidence1.Id !=
                    dbworkerTimeEvidence2.Id && dbworkerTimeEvidence2.Id !=
                    dbworkerTimeEvidence3.Id && dbworkerTimeEvidence3.Id !=
                    dbworkerTimeEvidence4.Id);
            }

            [Test]
            public void should_have_properly_set_Date_attribute()
            {
                Assert.AreEqual(new DateTime(2021, 10, 1), dbworkerTimeEvidence1.Date);
                Assert.AreEqual(new DateTime(2021, 10, 2), dbworkerTimeEvidence2.Date);
                Assert.AreEqual(new DateTime(2021, 10, 1), dbworkerTimeEvidence3.Date);
                Assert.AreEqual(new DateTime(2021, 10, 2), dbworkerTimeEvidence4.Date);
            }

            [Test]
            public void should_have_properly_set_Worker_reference()
            {
                Assert.AreEqual(dbworker, dbworkerTimeEvidence1.Worker);
                Assert.AreEqual(dbworker, dbworkerTimeEvidence2.Worker);
                Assert.AreEqual(dbworker2, dbworkerTimeEvidence3.Worker);
                Assert.AreEqual(dbworker2, dbworkerTimeEvidence4.Worker);
            }

            [Test]
            public void should_have_properly_set_SetByEngineer_reference()
            {
                Assert.AreEqual(dbuser, dbworkerTimeEvidence1.SetByEngineer);
                Assert.AreEqual(dbuser, dbworkerTimeEvidence2.SetByEngineer);
                Assert.AreEqual(dbuser, dbworkerTimeEvidence3.SetByEngineer);
                Assert.AreEqual(dbuser, dbworkerTimeEvidence4.SetByEngineer);
            }

            [Test]
            public void should_have_properly_set_Project_reference()
            {
                Assert.AreEqual(dbproject, dbworkerTimeEvidence1.Project);
                Assert.AreEqual(dbproject, dbworkerTimeEvidence2.Project);
                Assert.AreEqual(dbproject, dbworkerTimeEvidence3.Project);
                Assert.AreEqual(dbproject, dbworkerTimeEvidence4.Project);
            }

            [Test]
            public void should_have_properly_set_WorkedTime_attribute()
            {
                Assert.AreEqual(10.5m, dbworkerTimeEvidence1.WorkedTime);
                Assert.AreEqual(9, dbworkerTimeEvidence2.WorkedTime);
                Assert.AreEqual(5, dbworkerTimeEvidence3.WorkedTime);
                Assert.AreEqual(3, dbworkerTimeEvidence4.WorkedTime);
            }

            [Test]
            public void should_have_properly_set_CrewSummary_reference()
            {
                Assert.AreEqual(dbcrewSummary, dbworkerTimeEvidence1.CrewSummary);
                Assert.AreEqual(dbcrewSummary, dbworkerTimeEvidence2.CrewSummary);
                Assert.AreEqual(dbcrewSummary, dbworkerTimeEvidence3.CrewSummary);
                Assert.AreEqual(dbcrewSummary, dbworkerTimeEvidence4.CrewSummary);
            }
        }

        [TestFixture]
        private class Worker_entity : WorkerTimeEvidenceTest
        {
            [Test]
            public void should_have_properly_set_WorkerTimeEvidence_relationship()
            {
                Assert.AreEqual(2, dbworker.TimeEvidences.Count);
                Assert.AreEqual(2, dbworker2.TimeEvidences.Count);

                Assert.AreEqual(dbworkerTimeEvidence1, dbworker.TimeEvidences.ToList()[0]);
                Assert.AreEqual(dbworkerTimeEvidence2, dbworker.TimeEvidences.ToList()[1]);
                Assert.AreEqual(dbworkerTimeEvidence3, dbworker2.TimeEvidences.ToList()[0]);
                Assert.AreEqual(dbworkerTimeEvidence4, dbworker2.TimeEvidences.ToList()[1]);
            }
        }

        [TestFixture]
        private class CrewSummary_entity : WorkerTimeEvidenceTest
        {
            [Test]
            public void should_have_properly_set_WorkerTimeEvidence_relationship()
            {
                Assert.AreEqual(4, dbcrewSummary.TimeEvidences.Count);

                Assert.AreEqual(dbworkerTimeEvidence1, dbcrewSummary.TimeEvidences.ToList()[0]);
                Assert.AreEqual(dbworkerTimeEvidence2, dbcrewSummary.TimeEvidences.ToList()[1]);
                Assert.AreEqual(dbworkerTimeEvidence3, dbcrewSummary.TimeEvidences.ToList()[2]);
                Assert.AreEqual(dbworkerTimeEvidence4, dbcrewSummary.TimeEvidences.ToList()[3]);
            }
        }
    }
}