using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure.ElementTest
{
    [TestFixture]
    public class TestSingleElementWithRequiredAttributes
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                _project = new Project("test");
                context.Add(_project);
                context.SaveChanges();

                _element = new Element(11111, _project);
                context.Add(_element);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext().Context)
            {
                _elementList = context.Elements.ToList();
            }
        }


        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
            context.SaveChanges();
        }

        private Element _element;
        private Project _project;
        private List<Element> _elementList;

        /// <summary>
        ///     Test sprawdza dodanie podstawowych wymaganych parametrów.
        ///     Parametry opcjonalne maja być null'ami.
        /// </summary>
        [Test]
        public void TestRequiredAttributes()
        {
            Assert.AreEqual(1, _elementList.Count);
            Assert.AreEqual(11111, _element.RevitID);
            Assert.AreEqual(null, _element.Area);
            Assert.AreEqual(null, _element.Crane);
            Assert.AreEqual(null, _element.Level);
            Assert.AreEqual(null, _element.Vertical);
            Assert.AreEqual(null, _element.Volume);
            Assert.AreEqual(null, _element.RealisationMode);
            Assert.AreEqual(null, _element.RotationDay);
            Assert.AreEqual(null, _element.RunningMetre);
            Assert.AreEqual(0, _element.ElementStatusList.Count);
            Assert.AreEqual(_project.Id, _element.Project.Id);
        }
    }

    [TestFixture]
    public class TestSingleElementBasicAttributes
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _project = new Project("test");
                context.Add(_project);
                context.SaveChanges();

                _element = new Element(11111, _project)
                {
                    Area = 11.111m,
                    Volume = 312.123m,
                    RunningMetre = 12354.123m,
                    Vertical = VerticalEnum.V,
                    RealisationMode = "strop",
                    RotationDay = 13
                };

                context.Add(_element);
                context.SaveChanges();
            }
        }


        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
            context.SaveChanges();
        }

        private Element _element;
        private Project _project;

        [Test]
        public void TestBasicAttributes()
        {
            Assert.AreEqual(11111, _element.RevitID);
            Assert.AreEqual(_project.Id, _element.Project.Id);

            Assert.AreEqual(11.111m, _element.Area);
            Assert.AreEqual(312.123m, _element.Volume);
            Assert.AreEqual(12354.123m, _element.RunningMetre);
            Assert.AreEqual(VerticalEnum.V, _element.Vertical);
            Assert.AreEqual("strop", _element.RealisationMode);
            Assert.AreEqual(13, _element.RotationDay);
        }
    }
}