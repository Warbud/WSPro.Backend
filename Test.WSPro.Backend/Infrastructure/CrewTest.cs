﻿using System.Collections.Generic;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure.CrewTest
{
    [TestFixture]
    public class TestCrewBasics
    {
        private Crew _crew;

        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _crew = new Crew("crew name", CrewWorkTypeEnum.SteelFixer,CrewTypeEnum.HouseCrew);
                context.Add(_crew);
                context.SaveChanges();
            }
        }

        [OneTimeTearDown]
        public void OnClose()
        {
            using var context = new WSProTestContext();
            context.Database.EnsureDeleted();
        }

        [Test]
        public void TestNonRelationalData()
        {
            Assert.AreEqual("crew name",_crew.Name);
            Assert.AreEqual(CrewWorkTypeEnum.SteelFixer,_crew.CrewWorkType);
            Assert.AreEqual(CrewTypeEnum.HouseCrew,_crew.CrewType);
        }

        [Test]
        public void TestRelationalData()
        {
            Assert.AreEqual(null,_crew.User);
            Assert.AreEqual(null,_crew.Project);
            
        }
    }
}