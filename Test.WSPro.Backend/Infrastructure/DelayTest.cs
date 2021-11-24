using System;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class DelayTest : _setup
    {
        private Level dblevel;
        private Crane dbcrane;
        private Delay dbdelay;
        private Delay dbdelay2;
        private Project dbproject;
        private User dbuser;

        public override void Init()
        {
            Level level;
            Crane crane;
            Delay delay;
            Delay delay2;
            User user;
            Project project;
            using (var ctx = new WSProTestContext().Context)
            {
                level = new Level { Name = "L01" };
                crane = new Crane { Name = "01" };
                project = new Project { Name = "test project" };
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                delay = new Delay
                {
                    Crane = crane,
                    Level = level,
                    Date = new DateTime(2021, 9, 10),
                    Commentary = "test comment",
                    Project = project,
                    User = user
                };
                delay2 = new Delay
                {
                    Date = new DateTime(2002, 1, 10),
                    Commentary = "test comment2",
                    Project = project,
                    User = user
                };

                ctx.AddRange(level, crane, project, user, delay, delay2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dblevel = ctx.Levels.Find(level.Id);
                dbcrane = ctx.Cranes.Find(crane.Id);
                dbdelay = ctx.Delays.Find(delay.Id);
                dbdelay2 = ctx.Delays.Find(delay2.Id);
                dbproject = ctx.Projects.Find(project.Id);
                dbuser = ctx.Users.Find(user.Id);
            }
        }

        [Test]
        public void test_added_count()
        {
            using (var ctx = new WSProTestContext().Context)
            {
                Assert.AreEqual(2, ctx.Delays.Count());
            }
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.NotNull(dbdelay.Id);
            Assert.NotNull(dbdelay2.Id);
            Assert.That(() => dbdelay.Id != dbdelay2.Id);
        }

        [Test]
        public void test_Commentary_attribute()
        {
            Assert.AreEqual("test comment", dbdelay.Commentary);
            Assert.AreEqual("test comment2", dbdelay2.Commentary);
        }

        [Test]
        public void test_User_reference()
        {
            Assert.AreEqual(dbuser, dbdelay.User);
            Assert.AreEqual(dbuser, dbdelay2.User);
        }

        [Test]
        public void test_Level_reference()
        {
            Assert.AreEqual(dblevel, dbdelay.Level);
            Assert.AreEqual(null, dbdelay2.Level);
        }

        [Test]
        public void test_Crane_reference()
        {
            Assert.AreEqual(dbcrane, dbdelay.Crane);
            Assert.AreEqual(null, dbdelay2.Crane);
        }

        [Test]
        public void test_Date_attribute()
        {
            Assert.AreEqual(new DateTime(2021, 9, 10), dbdelay.Date);
            Assert.AreEqual(new DateTime(2002, 1, 10), dbdelay2.Date);
        }

        [Test]
        public void test_Project_reference()
        {
            Assert.AreEqual(dbproject, dbdelay.Project);
            Assert.AreEqual(dbproject, dbdelay2.Project);
        }

        [Test]
        public void test_DelayCauses_reference()
        {
            Assert.AreEqual(0, dbdelay.DelayCauses.Count);
            Assert.AreEqual(0, dbdelay2.DelayCauses.Count);
        }
    }
}