using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class Delay_DelayCauseTest : _setup
    {
        public Project dbproject;
        public User dbuser;
        public Crane dbcrane;
        public Level dblevel;
        public Delay dbdelay1;
        public Delay dbdelay2;
        public DelayCause dbdelayCause1;
        public DelayCause dbdelayCause2;
        public DelayCause dbdelayCause3;
        public DelayCause dbdelayCause4;
        public Delay_DelayCause DelayDelayCause1;
        public Delay_DelayCause DelayDelayCause2;
        public Delay_DelayCause DelayDelayCause3;
        public Delay_DelayCause DelayDelayCause4;
        public Delay_DelayCause DelayDelayCause5;
        public int dbDelay_DelayCauseCount;

        public override void Init()
        {
            Project project;
            User user;
            Crane crane;
            Level level;
            Delay delay1;
            Delay delay2;
            DelayCause delayCause1;
            DelayCause delayCause2;
            DelayCause delayCause3;
            DelayCause delayCause4;
            using (var ctx = new WSProTestContext().Context)
            {
                project = new Project { Name = "test project" };
                user = new User { Email = "test_email", Name = "test", Password = "asd" };
                crane = new Crane { Name = "test crane" };
                level = new Level { Name = "test level" };

                delayCause1 = new DelayCause("jakis case");
                delayCause2 = new DelayCause("jakis inny case", delayCause1);
                delayCause3 = new DelayCause("super kolejny caase", delayCause1);
                delayCause4 = new DelayCause("zupełnie inny parent case");

                delay1 = new Delay
                {
                    Commentary = "Cos nie działa poprawnie",
                    Date = new DateTime(2021, 10, 10),
                    Project = project,
                    User = user,
                    DelayCauses = new List<DelayCause> { delayCause1, delayCause2, delayCause3 }
                };
                delay2 = new Delay
                {
                    Commentary = "tutaj tez nie działa",
                    Crane = crane,
                    Date = new DateTime(2021, 10, 16),
                    Level = level,
                    Project = project,
                    User = user,
                    DelayCauses = new List<DelayCause> { delayCause1, delayCause4 }
                };
                ctx.AddRange(
                    project, user,
                    crane, level, delay1, delay2, delayCause1,
                    delayCause2, delayCause3, delayCause4
                );
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dbproject = ctx.Projects.Find(project.Id);
                dbuser = ctx.Users.Find(user.Id);
                dbcrane = ctx.Cranes.Find(crane.Id);
                dblevel = ctx.Levels.Find(level.Id);
                dbdelay1 = ctx.Delays.Find(delay1.Id);
                dbdelay2 = ctx.Delays.Find(delay2.Id);
                dbdelayCause1 = ctx.DelayCauses.Find(delayCause1.Id);
                dbdelayCause2 = ctx.DelayCauses.Find(delayCause2.Id);
                dbdelayCause3 = ctx.DelayCauses.Find(delayCause3.Id);
                dbdelayCause4 = ctx.DelayCauses.Find(delayCause4.Id);

                DelayDelayCause1 = ctx.Delay_DelayCauses.Find(delayCause1.Id, delay1.Id);
                DelayDelayCause2 = ctx.Delay_DelayCauses.Find(delayCause2.Id, delay1.Id);
                DelayDelayCause3 = ctx.Delay_DelayCauses.Find(delayCause3.Id, delay1.Id);
                DelayDelayCause4 = ctx.Delay_DelayCauses.Find(delayCause1.Id, delay2.Id);
                DelayDelayCause5 = ctx.Delay_DelayCauses.Find(delayCause4.Id, delay2.Id);

                dbDelay_DelayCauseCount = ctx.Delay_DelayCauses.Count();
            }
        }

        [TestFixture]
        private class basic_properties_in_entity : Delay_DelayCauseTest
        {
            [Test]
            public void should_equal_added_count_number()
            {
                Assert.AreEqual(5, dbDelay_DelayCauseCount);
            }

            [Test]
            public void should_have_properly_set_Cause_attribute()
            {
                Assert.AreEqual(dbdelayCause1, DelayDelayCause1.Cause);
                Assert.AreEqual(dbdelayCause2, DelayDelayCause2.Cause);
                Assert.AreEqual(dbdelayCause3, DelayDelayCause3.Cause);

                Assert.AreEqual(dbdelayCause1, DelayDelayCause4.Cause);
                Assert.AreEqual(dbdelayCause4, DelayDelayCause5.Cause);
            }

            [Test]
            public void should_have_properly_set_Delay_attribute()
            {
                Assert.AreEqual(dbdelay1, DelayDelayCause1.Delay);
                Assert.AreEqual(dbdelay1, DelayDelayCause2.Delay);
                Assert.AreEqual(dbdelay1, DelayDelayCause3.Delay);

                Assert.AreEqual(dbdelay2, DelayDelayCause4.Delay);
                Assert.AreEqual(dbdelay2, DelayDelayCause5.Delay);
            }
        }

        [TestFixture]
        private class test_Delay_renference_to_DelayCause_entity : Delay_DelayCauseTest
        {
            [Test]
            public void should_have_proper_references_count()
            {
                Assert.AreEqual(3, dbdelay1.DelayCauses.Count);
                Assert.AreEqual(2, dbdelay2.DelayCauses.Count);
            }

            [Test]
            public void should_have_proper_entities_included()
            {
                Assert.AreEqual(dbdelayCause1, dbdelay1.DelayCauses.ToList()[0]);
                Assert.AreEqual(dbdelayCause2, dbdelay1.DelayCauses.ToList()[1]);
                Assert.AreEqual(dbdelayCause3, dbdelay1.DelayCauses.ToList()[2]);

                Assert.AreEqual(dbdelayCause1, dbdelay2.DelayCauses.ToList()[0]);
                Assert.AreEqual(dbdelayCause4, dbdelay2.DelayCauses.ToList()[1]);
            }
        }
    }
}