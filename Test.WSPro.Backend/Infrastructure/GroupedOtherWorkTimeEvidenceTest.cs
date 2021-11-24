using System;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class GroupedOtherWorkTimeEvidenceTest : _setup
    {
        public Crew DBcrew;
        public User DBuser;
        public Project DBproject;
        public Level DBlevel;
        public OtherWorkOption DBoption1;
        public OtherWorkOption DBoption2;
        public OtherWorksTimeEvidence DBotherWorksTimeEvidence1;
        public OtherWorksTimeEvidence DBotherWorksTimeEvidence2;
        public GroupedOtherWorkTimeEvidence DBgroupedOtherWorkTimeEvidence;

        public override void Init()
        {
            GroupedOtherWorkTimeEvidence groupedOtherWorkTimeEvidence;
            Crew crew;
            User user;
            Project project;
            Level level;
            OtherWorkOption option1;
            OtherWorkOption option2;
            OtherWorksTimeEvidence otherWorksTimeEvidence1;
            OtherWorksTimeEvidence otherWorksTimeEvidence2;
            using (var ctx = new WSProTestContext().Context)
            {
                level = new Level { Name = "L01" };
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                project = new Project { Name = "Project" };
                crew = new Crew
                {
                    Name = "crew 1",
                    Owner = user,
                    Project = project,
                    CrewWorkType = CrewWorkTypeEnum.SteelFixer
                };

                option1 = new OtherWorkOption
                {
                    Name = "test name", CrewType = CrewTypeEnum.HouseCrew, CrewWorkType = CrewWorkTypeEnum.Carpenter
                };
                option2 = new OtherWorkOption
                {
                    Name = "test name2", CrewType = CrewTypeEnum.SubcontractorCrew,
                    CrewWorkType = CrewWorkTypeEnum.GeneralConstructor
                };


                groupedOtherWorkTimeEvidence = new GroupedOtherWorkTimeEvidence
                {
                    Crew = crew,
                    Level = level,
                    Project = project,
                    Date = new DateTime(2021, 10, 10),
                    CrewType = CrewTypeEnum.HouseCrew
                };

                otherWorksTimeEvidence1 = new OtherWorksTimeEvidence
                {
                    Type = CrewWorkTypeEnum.Carpenter, WorkedTime = 10, OtherWorkOption = option1,
                    OtherWorkType = OtherWorkTypeEnum.Additional,
                    GroupedOtherWorkTimeEvidence = groupedOtherWorkTimeEvidence
                };
                otherWorksTimeEvidence2 = new OtherWorksTimeEvidence
                {
                    Type = CrewWorkTypeEnum.Carpenter, WorkedTime = 100, OtherWorkOption = option2,
                    OtherWorkType = OtherWorkTypeEnum.Additional,
                    GroupedOtherWorkTimeEvidence = groupedOtherWorkTimeEvidence
                };


                ctx.AddRange(option1, option2, otherWorksTimeEvidence1, otherWorksTimeEvidence2,
                    groupedOtherWorkTimeEvidence, project, user, crew, level);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBcrew = ctx.Crews.Find(crew.Id);
                DBuser = ctx.Users.Find(user.Id);
                DBproject = ctx.Projects.Find(project.Id);
                DBlevel = ctx.Levels.Find(level.Id);
                DBoption1 = ctx.OtherWorkOptions.Find(option1.Id);
                DBoption2 = ctx.OtherWorkOptions.Find(option2.Id);
                DBotherWorksTimeEvidence1 = ctx.OtherWorksTimeEvidences.Find(otherWorksTimeEvidence1.Id);
                DBotherWorksTimeEvidence2 = ctx.OtherWorksTimeEvidences.Find(otherWorksTimeEvidence2.Id);
                DBgroupedOtherWorkTimeEvidence =
                    ctx.GroupedOtherWorkTimeEvidences.Find(groupedOtherWorkTimeEvidence.Id);
            }
        }

        [TestFixture]
        private class test_basic_attributes : GroupedOtherWorkTimeEvidenceTest
        {
            [Test]
            public void test_Id()
            {
                Assert.That(DBgroupedOtherWorkTimeEvidence.Id, Is.TypeOf<int>());
            }

            [Test]
            public void test_Crew()
            {
                Assert.AreEqual(DBcrew, DBgroupedOtherWorkTimeEvidence.Crew);
            }

            [Test]
            public void test_Project()
            {
                Assert.AreEqual(DBproject, DBgroupedOtherWorkTimeEvidence.Project);
            }

            [Test]
            public void test_Level()
            {
                Assert.AreEqual(DBlevel, DBgroupedOtherWorkTimeEvidence.Level);
            }

            [Test]
            public void test_Date()
            {
                Assert.AreEqual(new DateTime(2021, 10, 10), DBgroupedOtherWorkTimeEvidence.Date);
            }

            [Test]
            public void test_CrewType()
            {
                Assert.AreEqual(CrewTypeEnum.HouseCrew, DBgroupedOtherWorkTimeEvidence.CrewType);
            }

            [Test]
            public void test_OtherWorksTimeEvidences()
            {
                Assert.AreEqual(2, DBgroupedOtherWorkTimeEvidence.OtherWorksTimeEvidences.Count);
                Assert.That(DBgroupedOtherWorkTimeEvidence.OtherWorksTimeEvidences.Contains(DBotherWorksTimeEvidence1));
                Assert.That(DBgroupedOtherWorkTimeEvidence.OtherWorksTimeEvidences.Contains(DBotherWorksTimeEvidence2));
            }
        }
    }
}