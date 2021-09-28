using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure.ElementStatusTest
{
    
    [TestFixture]
    public class SingleElementTests
    {
        private ElementStatus _elementStatus;
        private Element _element;
        private Project _project;
        
        [OneTimeSetUp]
        public void Init()
        {
            var project = new Project("test");
            var element = new Element(453546, project);
            var elementStatus = new ElementStatus(element, StatusEnum.InProgress);
            
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.AddRange(elementStatus,element,project);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext().Context)
            {
                _project = context.Projects.First();
                _element = context.Elements.First();
                _elementStatus = context.ElementStatuses.First();
            }
        }

        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
        }
        
        [Test]
        public void TestNonRelationalAttributes()
        {
            Assert.AreEqual(StatusEnum.InProgress,_elementStatus.Status);
            Assert.AreEqual(DateTime.Now.Date,_elementStatus.Date);
            Assert.AreEqual(true,_elementStatus.IsActual);
            
        }
        [Test]
        public void TestRelationalAttributes()
        {
            Assert.AreEqual(_element,_elementStatus.Element);
            Assert.AreEqual(_project,_elementStatus.Project);
            Assert.AreEqual(null,_elementStatus.User);
            Assert.AreEqual(null,_elementStatus.PreviousStatus);
        }
    }

    [TestFixture]
    public class ManyElementsTest
    {
        private ElementStatus _elementStatus;
        private ElementStatus _elementStatus2;
        private ElementStatus _elementStatus3;
        private ElementStatus _elementStatus4;
        private List<ElementStatus> _elementStatusList;
        private Element _element;
        private Element _element2;
        private List<Element> _elementList;
        private Project _project;

        
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                _project = new Project("test");
                context.Add(_project); context.SaveChanges();
                
                _element = new Element(453546, _project);
                context.Add(_element); context.SaveChanges();
                
                _element2 = new Element(123113, _project);
                context.Add(_element2); context.SaveChanges();
                
                _elementStatus = new ElementStatus(_element, StatusEnum.InProgress,new DateTime(2021,9,10));
                context.Add(_elementStatus); context.SaveChanges();
                
                _elementStatus2 = new ElementStatus(_element, StatusEnum.Finished,new DateTime(2021,9,12),_elementStatus);
                context.Add(_elementStatus2); context.SaveChanges();
                
                _elementStatus3 = new ElementStatus(_element2, StatusEnum.InProgress,new DateTime(2021,9,10));
                context.Add(_elementStatus3); context.SaveChanges();
                
                _elementStatus4 =
                new ElementStatus(_element2, StatusEnum.Finished, new DateTime(2021, 9, 11));
                context.Add(_elementStatus4); context.SaveChanges();
                
            }

            using (var context = new WSProTestContext().Context)
            {
                _elementList = context.Elements.ToList();
                _elementStatusList = context.ElementStatuses.ToList();
            }
        }

        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
            context.SaveChanges();
        }

        [Test]
        public void TestElementsCount()
        {
            Assert.AreEqual(2,_elementList.Count);
            Assert.AreEqual(4,_elementStatusList.Count);
        }

        [Test]
        public void TestBasicData()
        {
            Assert.AreEqual(453546,_element.RevitID);
            Assert.AreEqual(123113,_element2.RevitID);
            
            Assert.AreEqual(new DateTime(2021,9,10).Date,_elementStatus.Date);
            Assert.AreEqual(453546,_elementStatus.Element.RevitID);
            Assert.AreEqual(StatusEnum.InProgress,_elementStatus.Status);
            
            Assert.AreEqual(new DateTime(2021,9,12).Date,_elementStatus2.Date);
            Assert.AreEqual(453546,_elementStatus2.Element.RevitID);
            Assert.AreEqual(StatusEnum.Finished,_elementStatus2.Status);
        }

        [Test]
        public void TestAddPreviousElementStatus()
        {
            Assert.AreEqual(2,_elementStatusList.Count(es => es.IsActual));
            
            // pass previuous status explicit
            Assert.AreEqual(false,_elementStatus.IsActual);
            Assert.AreEqual(null,_elementStatus.PreviousStatus);
            
            Assert.AreEqual(true,_elementStatus2.IsActual);
            Assert.AreEqual(_elementStatus,_elementStatus2.PreviousStatus);
            
            // pass previous status by elements statuses;
            Assert.AreEqual(false,_elementStatus3.IsActual);
            Assert.AreEqual(null,_elementStatus3.PreviousStatus);
            
            Assert.AreEqual(true,_elementStatus4.IsActual);
            Assert.AreEqual(_elementStatus3,_elementStatus4.PreviousStatus);
            
        }
        
        
    }
}