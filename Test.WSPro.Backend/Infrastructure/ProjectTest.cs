using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    public class ProjectTest
    {
        /// <summary>
        /// Test.WSPro.Backend sprawdzający tylko obowiązkowe parametry - <i>Name</i> oraz <i>WebconCode</i>
        /// </summary>
        [Test]
        public void AddProjectWithBaseParameters()
        {
            var project = new Project("project name", "webcon code");
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Projects.Add(project);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var projects = context.Projects.ToList();

                Assert.AreEqual(projects.Count, 1);
                Assert.AreEqual(projects[0].Name, "project name");
                Assert.AreEqual(projects[0].WebconCode, "webcon code");
                Assert.AreEqual(projects[0].MetodologyCode, null);
                Assert.AreEqual(projects[0].CentralScheduleSync, false);
                
                context.Database.EnsureDeleted();
            }
        }
        
        /// <summary>
        /// test sprawdzający warunek gdy podany jest błędny <i>MetodologyCode</i>
        /// natomiast wymuszone jest podanie parametru <i>CentralScheduleSync</i> jako <b>true</b>
        /// </summary>
        /// <param name="metodology"></param>
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddProjectWithNullMetodologyButSynchronizedWithCentralSchedule(string metodology)
        {
            var project = new Project("project name", "webcon code",metodology,true);
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Projects.Add(project);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var projects = context.Projects.ToList();

                Assert.AreEqual(projects.Count, 1);
                Assert.AreEqual(projects[0].Name, "project name");
                Assert.AreEqual(projects[0].WebconCode, "webcon code");
                Assert.AreEqual(projects[0].MetodologyCode, null);
                Assert.AreEqual(projects[0].CentralScheduleSync, false);
                // tutaj zmiana! jeśli brak metodology code nie może synchronizować się z harmonogramem

                context.Database.EnsureDeleted();
            }
        }

        /// <summary>
        /// test sprawdzający czy poprawnie określany jest parametr <i>CentralScheduleSync</i>
        /// w przypadku gdy parametr <i>MetodologyCode</i> ma poprawną wartość
        /// </summary>
        /// <param name="centralScheduleSync"></param>
        [TestCase(true)]
        [TestCase(false)]
        public void AddProjectComplete(bool centralScheduleSync)
        {
            var project = new Project("project name", "webcon code","code",centralScheduleSync);
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Projects.Add(project);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var projects = context.Projects.ToList();

                Assert.AreEqual(projects.Count, 1);
                Assert.AreEqual(projects[0].Name, "project name");
                Assert.AreEqual(projects[0].WebconCode, "webcon code");
                Assert.AreEqual(projects[0].MetodologyCode, "code");
                Assert.AreEqual(projects[0].CentralScheduleSync, centralScheduleSync);

                context.Database.EnsureDeleted();
            }
        }
    }
}