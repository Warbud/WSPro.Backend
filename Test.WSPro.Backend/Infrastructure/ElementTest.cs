using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    public class ElementTest
    {
        /// <summary>
        ///     Test sprawdza dodanie podstawowych wymaganych parametrów.
        ///     Parametry opcjonalne maja być null'ami.
        /// </summary>
        [Test]
        public void AddElement_OnlyRequired()
        {
            
            var project = new Project("test project", "webcon code");

            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
             
                
                context.Projects.Add(project);
                context.SaveChanges();
            }
           
            using (var context = new WSProTestContext())
            {
                var element = new Element()
                {
                    RevitID = 11111,
                    ProjectID = context.Projects.Single(p => p.Name == project.Name && p.WebconCode == project.WebconCode).Id
                };
                
                context.Elements.Add(element);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext())
            {
                var elements = context.Elements.ToList();
                Assert.AreEqual(1, elements.Count);
                Assert.AreEqual(11111, elements[0].RevitID);
                Assert.AreEqual(null, elements[0].Area);
                Assert.AreEqual(null, elements[0].Crane);
                Assert.AreEqual(null, elements[0].Level);
                Assert.AreEqual(null, elements[0].Vertical);
                Assert.AreEqual(null, elements[0].Volume);
                Assert.AreEqual(null, elements[0].RealisationMode);
                Assert.AreEqual(null, elements[0].RotationDay);
                Assert.AreEqual(null, elements[0].RunningMetre);
                Assert.AreEqual(0, elements[0].ElementStatusList.Count);
                Assert.AreEqual(
                    context
                        .Projects
                        .Single(p =>
                            p.Name == project.Name &&
                            p.WebconCode == project.WebconCode)
                        .Id,
                    elements[0].ProjectID);
                
                Assert.AreEqual(
                    context
                        .Projects
                        .Single(p => 
                            p.Name == project.Name && 
                            p.WebconCode == project.WebconCode)
                        .Id,
                    elements[0].Project.Id);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void AddManyElements()
        {
            var proj1 = new Project("test project", "webcon code");
            var proj2 = new Project("test project2", "webcon code2");
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Projects.AddRange(new List<Project>(){ proj1,proj2 });
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var projects = context.Projects.ToList();
                var elem1 = new Element()
                {
                    RevitID = 123,
                    Project = projects.Single(p => p.Name == proj1.Name)
                };
                var elem2 = new Element()
                {
                    RevitID = 231,
                    Project = projects.Single(p => p.Name == proj2.Name)
                };
                
                context.Elements.AddRange(new List<Element>() { elem1,elem2 });
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var projects = context.Projects.ToList();
                var elements = context.Elements.ToList();

                Assert.AreEqual(projects.Count, 2);
                Assert.AreEqual(projects[0].Name, "test project");
                Assert.AreEqual(projects[1].Name, "test project2");
                Assert.AreEqual(projects[0].WebconCode, "webcon code");
                Assert.AreEqual(projects[1].WebconCode, "webcon code2");

                Assert.AreEqual(2,elements.Count);
                Assert.AreEqual(123,elements[0].RevitID);
                Assert.AreEqual(231,elements[1].RevitID);
                Assert.AreEqual(projects[0].Id, elements[0].Project.Id);
                Assert.AreEqual(projects[1].Id, elements[1].Project.Id);
                
                
                context.Database.EnsureDeleted();
            }
        }

        /// <summary>
        /// Test sprawdzajacy dodanie elementu bez wymaganych danych
        /// </summary>
        [Test]
        public void AddElementWithError()
        {
            var elem = new Element()
            {
                RevitID = 111
                // nie ma przekazanych wymaganych parametrów
            };
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Elements.Add(elem);
                var databaseSaveDelegate = new TestDelegate(() => context.SaveChanges());
                Assert.Throws<DbUpdateException>(databaseSaveDelegate);
            }
        }

        /// <summary>
        /// Test parsowania wartości w parametrze Vertical
        /// </summary>
        [Test]
        public void TestVerticalEnumValues()
        {
            var project = new Project("test project", "webcon code");
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
             
                
                context.Projects.Add(project);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext())
            {
                var element = new Element()
                {
                    RevitID = 11111,
                    ProjectID = context.Projects.Single(p => p.Name == project.Name && p.WebconCode == project.WebconCode).Id,
                    Vertical = VerticalEnum.V
                };
                
                context.Elements.Add(element);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext())
            {
                var elements = context.Elements.ToList();
                Assert.AreEqual(VerticalEnum.V, elements[0].Vertical);
                Assert.AreEqual(11111, elements[0].RevitID);
                Assert.AreEqual(context.Projects.Single(p => p.Name == project.Name && p.WebconCode == project.WebconCode).Id, elements[0].Project.Id);
            }
        }
    }
}