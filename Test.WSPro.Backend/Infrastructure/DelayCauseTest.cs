﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Infrastructure.DelayCauseTest
{
    [TestFixture]
    public class TestSingleElement
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _delayCause = new DelayCause("test delay cause");
                context.Add(_delayCause);
                context.SaveChanges();
            }
        }

        [OneTimeTearDown]
        public void Close()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
        }

        private DelayCause _delayCause;

        [Test]
        public void TestBasicAttributes()
        {
            Assert.AreEqual("test delay cause", _delayCause.Name);
            Assert.AreEqual(true, _delayCause.IsMain);
            Assert.AreEqual(null, _delayCause.Parent);
        }
    }

    [TestFixture]
    public class TestAddManyElements
    {
        [OneTimeSetUp]
        public void Init()
        {
            using (var context = new WSProTestContext().Context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _delayCause = new DelayCause("first");
                context.Add(_delayCause);
                context.SaveChanges();

                _delayCause2 = new DelayCause("second", _delayCause);
                context.Add(_delayCause2);
                context.SaveChanges();

                _delayCause3 = new DelayCause("third", _delayCause);
                context.Add(_delayCause3);
                context.SaveChanges();

                _delayCause4 = new DelayCause("forth", _delayCause3);
                context.Add(_delayCause4);
                context.SaveChanges();
            }

            using (var context = new WSProTestContext().Context)
            {
                _delayCausesList = context.DelayCauses.Include(dc => dc.Parent).ToList();
            }
        }

        [OneTimeTearDown]
        public void Close()
        {
            using var context = new WSProTestContext().Context;
            context.Database.EnsureDeleted();
        }

        private DelayCause _delayCause;
        private DelayCause _delayCause2;
        private DelayCause _delayCause3;
        private DelayCause _delayCause4;
        private List<DelayCause> _delayCausesList;

        [Test]
        public void FirstTest()
        {
            Assert.AreEqual("first", _delayCause.Name);
            Assert.AreEqual(true, _delayCause.IsMain);
            Assert.AreEqual(null, _delayCause.Parent);

            Assert.AreEqual("second", _delayCause2.Name);
            Assert.AreEqual(false, _delayCause2.IsMain);
            Assert.AreEqual(_delayCause, _delayCause2.Parent);

            Assert.AreEqual("third", _delayCause3.Name);
            Assert.AreEqual(false, _delayCause3.IsMain);
            Assert.AreEqual(_delayCause, _delayCause3.Parent);

            Assert.AreEqual("forth", _delayCause4.Name);
            Assert.AreEqual(false, _delayCause4.IsMain);
            Assert.AreEqual(_delayCause3, _delayCause4.Parent);
        }
    }
}