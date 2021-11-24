using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class OtherWorkOptionTest : _setup
    {
        public OtherWorkOption DBoption1;
        public OtherWorkOption DBoption2;
        public OtherWorkOption DBoption3;
        public List<OtherWorkOption> DBoptionList;

        public override void Init()
        {
            OtherWorkOption option1;
            OtherWorkOption option2;
            OtherWorkOption option3;
            using (var ctx = new WSProTestContext().Context)
            {
                option1 = new OtherWorkOption
                {
                    Name = "test name", CrewType = CrewTypeEnum.HouseCrew, CrewWorkType = CrewWorkTypeEnum.Carpenter
                };
                option2 = new OtherWorkOption
                {
                    Name = "test name2", CrewType = CrewTypeEnum.SubcontractorCrew,
                    CrewWorkType = CrewWorkTypeEnum.GeneralConstructor
                };
                option3 = new OtherWorkOption
                {
                    Name = "test name3", CrewType = CrewTypeEnum.HouseCrew, CrewWorkType = CrewWorkTypeEnum.SteelFixer
                };
                ctx.AddRange(option1, option2, option3);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBoptionList = ctx.OtherWorkOptions.ToList();
                DBoption1 = ctx.OtherWorkOptions.Find(option1.Id);
                DBoption2 = ctx.OtherWorkOptions.Find(option2.Id);
                DBoption3 = ctx.OtherWorkOptions.Find(option3.Id);
            }
        }

        [TestFixture]
        private class test_basic_attributes : OtherWorkOptionTest
        {
            [Test]
            public void should_equal_number_of_added_elements()
            {
                Assert.AreEqual(3, DBoptionList.Count);
            }

            [Test]
            public void should_have_proper_Id()
            {
                Assert.That(DBoption1.Id, Is.TypeOf<int>());
                Assert.That(DBoption2.Id, Is.TypeOf<int>());
                Assert.That(DBoption3.Id, Is.TypeOf<int>());
                Assert.That(() =>
                    DBoption1.Id != DBoption2.Id &&
                    DBoption2.Id != DBoption3.Id
                );
            }

            [Test]
            public void should_have_equal_name_as_passed()
            {
                Assert.AreEqual("test name", DBoption1.Name);
                Assert.AreEqual("test name2", DBoption2.Name);
                Assert.AreEqual("test name3", DBoption3.Name);
            }

            [Test]
            public void should_have_proper_CrewType()
            {
                Assert.AreEqual(CrewTypeEnum.HouseCrew, DBoption1.CrewType);
                Assert.AreEqual(CrewTypeEnum.SubcontractorCrew, DBoption2.CrewType);
                Assert.AreEqual(CrewTypeEnum.HouseCrew, DBoption3.CrewType);
            }

            [Test]
            public void should_have_proper_CrewWorkType()
            {
                Assert.AreEqual(CrewWorkTypeEnum.Carpenter, DBoption1.CrewWorkType);
                Assert.AreEqual(CrewWorkTypeEnum.GeneralConstructor, DBoption2.CrewWorkType);
                Assert.AreEqual(CrewWorkTypeEnum.SteelFixer, DBoption3.CrewWorkType);
            }

            [Test]
            public void should_have_proper_CreatedAt()
            {
                Assert.NotNull(DBoption1.CreatedAt);
                Assert.NotNull(DBoption2.CreatedAt);
                Assert.NotNull(DBoption3.CreatedAt);
            }

            [Test]
            public void should_have_proper_UpdatedAt()
            {
                Assert.NotNull(DBoption1.UpdatedAt);
                Assert.NotNull(DBoption2.UpdatedAt);
                Assert.NotNull(DBoption3.UpdatedAt);
            }
        }
    }
}