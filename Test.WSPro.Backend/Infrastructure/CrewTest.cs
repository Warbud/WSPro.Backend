using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class CrewTest : _setup
    {
        private List<Crew> dbcrews;
        private Crew dbcrew;
        private Crew dbcrew2;
        private Project dbproject;
        private User dbuser;

        public override void Init()
        {
            Crew crew;
            Crew crew2;
            Project project;
            User user;
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
                crew2 = new Crew
                {
                    Name = "test crew 2",
                    Owner = user,
                    Project = project,
                    CrewWorkType = CrewWorkTypeEnum.Carpenter
                };
                ctx.AddRange(user, project, crew, crew2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                dbcrews = ctx.Crews.ToList();
                dbcrew = ctx.Crews.Find(crew.Id);
                dbcrew2 = ctx.Crews.Find(crew2.Id);
                dbproject = ctx.Projects.Find(project.Id);
                dbuser = ctx.Users.Find(user.Id);
            }
        }

        [Test]
        public void test_crews_count()
        {
            Assert.AreEqual(2, dbcrews.Count);
        }

        [Test]
        public void test_Id_attributes()
        {
            Assert.NotNull(dbcrew.Id);
            Assert.NotNull(dbcrew2.Id);
            Assert.That(() => dbcrew.Id != dbcrew2.Id);
        }

        [Test]
        public void test_Name_attribute()
        {
            Assert.AreEqual("test crew 1", dbcrew.Name);
            Assert.AreEqual("test crew 2", dbcrew2.Name);
        }

        [Test]
        public void test_Owner_reference()
        {
            Assert.AreEqual(dbuser.Id, dbcrew.UserId);
            Assert.AreEqual(dbuser, dbcrew.Owner);
            Assert.AreEqual(dbuser.Id, dbcrew2.UserId);
            Assert.AreEqual(dbuser, dbcrew2.Owner);
        }

        [Test]
        public void test_Project_reference()
        {
            Assert.AreEqual(dbproject.Id, dbcrew.ProjectId);
            Assert.AreEqual(dbproject.Id, dbcrew2.ProjectId);

            Assert.AreEqual(dbproject, dbcrew.Project);
            Assert.AreEqual(dbproject, dbcrew2.Project);
        }

        [Test]
        public void test_CrewWorkType_reference()
        {
            Assert.AreEqual(CrewWorkTypeEnum.SteelFixer, dbcrew.CrewWorkType);
            Assert.AreEqual(CrewWorkTypeEnum.Carpenter, dbcrew2.CrewWorkType);
        }
    }
}