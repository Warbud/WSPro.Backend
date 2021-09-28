using System;
using System.Collections.Generic;
using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Infrastructure.ProjectTest
{
    [TestFixture]
    public class TestSingleElement
    {
        private List<Project> _projectsDB = new List<Project>();

        private static object[][] _projectCases =
        {
            new object[]
            {
                new Project("project with name"), 
                new Project("project with name"){WebconCode = null,MetodologyCode = null,CentralScheduleSync = false}
            },
            new object[]
            {
                new Project("project with all params","webcon", "metodology"),
                new Project("project with all params"){WebconCode = "webcon",MetodologyCode = "metodology",CentralScheduleSync = false }
            },
            new object[]
            {
                new Project("project with all params and centralScheduleSync as true","webcon", "metodology",true),
                new Project("project with all params and centralScheduleSync as true"){WebconCode = "webcon",MetodologyCode = "metodology",CentralScheduleSync = true }},
            new object[]
            {
                new Project("project with empty metodology code","webcon", "",true),
                new Project("project with empty metodology code"){WebconCode = "webcon",MetodologyCode = null,CentralScheduleSync = false }            
            },
            new object[]
            {
                new Project("project with metodology code as null","webcon", null,true),
                new Project("project with metodology code as null"){WebconCode = "webcon",MetodologyCode = null,CentralScheduleSync = false }            
            },
            new object[]
            {
                new Project("project with webcon code as empty string","", "metodology",true) ,
                new Project("project with webcon code as empty string"){WebconCode = null,MetodologyCode = "metodology",CentralScheduleSync = false }           
            },
            new object[]
            {
                new Project("project with webcon code as null",null, "metodology",true),
                new Project("project with webcon code as null"){WebconCode = null,MetodologyCode = "metodology",CentralScheduleSync = false }
            }
            
        };

        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                foreach (var projectCase in _projectCases)
                {
                    var project = (Project)projectCase[0];
                    context.Add(project);
                    context.SaveChanges();
                    _projectsDB.Add(project);
                }
            }
        }
        
        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
            context.SaveChanges();
        }

        [TestCaseSource(nameof(_projectCases))]
        public void TestRequiredParams(Project projectCreatedBy,Project projectDataShouldEqual)
        {
            var projectFromDB = _projectsDB.Find(p => p.Equals(projectCreatedBy));
            Console.WriteLine(projectFromDB.ToString());
            Assert.AreEqual(projectDataShouldEqual.Name,projectFromDB?.Name);
            Assert.AreEqual(projectDataShouldEqual.MetodologyCode,projectFromDB?.MetodologyCode);
            Assert.AreEqual(projectDataShouldEqual.WebconCode,projectFromDB?.WebconCode);
            Assert.AreEqual(projectDataShouldEqual.CentralScheduleSync,projectFromDB?.CentralScheduleSync);
        }

    }
}