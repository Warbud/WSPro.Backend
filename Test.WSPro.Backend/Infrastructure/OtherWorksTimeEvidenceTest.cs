using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class OtherWorksTimeEvidenceTest : _setup
    {
        public OtherWorkOption DBoption1;
        public OtherWorkOption DBoption2;
        public OtherWorkOption DBoption3;
        public OtherWorksTimeEvidence DBotherWorksTimeEvidence1;
        public OtherWorksTimeEvidence DBotherWorksTimeEvidence2;
        public OtherWorksTimeEvidence DBotherWorksTimeEvidence3;
        public OtherWorksTimeEvidence DBotherWorksTimeEvidence4;
        public List<OtherWorksTimeEvidence> DBOtherWorksTimeEvidences;

        public override void Init()
        {
            OtherWorkOption option1;
            OtherWorkOption option2;
            OtherWorkOption option3;

            OtherWorksTimeEvidence otherWorksTimeEvidence1;
            OtherWorksTimeEvidence otherWorksTimeEvidence2;
            OtherWorksTimeEvidence otherWorksTimeEvidence3;
            OtherWorksTimeEvidence otherWorksTimeEvidence4;

            // GroupedOtherWorkTimeEvidence groupedOtherWorkTimeEvidence;
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

                // groupedOtherWorkTimeEvidence = new GroupedOtherWorkTimeEvidence();

                otherWorksTimeEvidence1 = new OtherWorksTimeEvidence
                {
                    Type = CrewWorkTypeEnum.Carpenter, WorkedTime = 10, OtherWorkOption = option1,
                    OtherWorkType = OtherWorkTypeEnum.Additional
                };
                otherWorksTimeEvidence2 = new OtherWorksTimeEvidence
                {
                    Type = CrewWorkTypeEnum.Carpenter, WorkedTime = 100, OtherWorkOption = option2,
                    OtherWorkType = OtherWorkTypeEnum.Additional
                };
                otherWorksTimeEvidence3 = new OtherWorksTimeEvidence
                {
                    Type = CrewWorkTypeEnum.GeneralConstructor, WorkedTime = 14.123123m, OtherWorkOption = option3,
                    OtherWorkType = OtherWorkTypeEnum.Helper, Description = "opis"
                };
                otherWorksTimeEvidence4 = new OtherWorksTimeEvidence
                {
                    Type = CrewWorkTypeEnum.SteelFixer, WorkedTime = 234.1233123m, OtherWorkOption = option1,
                    OtherWorkType = OtherWorkTypeEnum.Helper, Description = "opis2"
                };

                ctx.AddRange(option1, option2, option3,
                    otherWorksTimeEvidence1,
                    otherWorksTimeEvidence2,
                    otherWorksTimeEvidence3,
                    otherWorksTimeEvidence4
                );
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                DBOtherWorksTimeEvidences = ctx.OtherWorksTimeEvidences.ToList();
                DBoption1 = ctx.OtherWorkOptions.Find(option1.Id);
                DBoption2 = ctx.OtherWorkOptions.Find(option2.Id);
                DBoption3 = ctx.OtherWorkOptions.Find(option3.Id);
                DBotherWorksTimeEvidence1 = ctx.OtherWorksTimeEvidences.Find(otherWorksTimeEvidence1.Id);
                DBotherWorksTimeEvidence2 = ctx.OtherWorksTimeEvidences.Find(otherWorksTimeEvidence2.Id);
                DBotherWorksTimeEvidence3 = ctx.OtherWorksTimeEvidences.Find(otherWorksTimeEvidence3.Id);
                DBotherWorksTimeEvidence4 = ctx.OtherWorksTimeEvidences.Find(otherWorksTimeEvidence4.Id);
            }
        }

        [TestFixture]
        private class test_basic_attributes : OtherWorksTimeEvidenceTest
        {
            [Test]
            public void should_have_same_count_as_added()
            {
                Assert.AreEqual(4, DBOtherWorksTimeEvidences.Count);
            }

            [Test]
            public void should_have_proper_Id()
            {
                Assert.That(DBotherWorksTimeEvidence1.Id, Is.TypeOf<int>());
                Assert.That(DBotherWorksTimeEvidence2.Id, Is.TypeOf<int>());
                Assert.That(DBotherWorksTimeEvidence3.Id, Is.TypeOf<int>());
                Assert.That(DBotherWorksTimeEvidence4.Id, Is.TypeOf<int>());
                Assert.That(() =>
                    DBotherWorksTimeEvidence1.Id != DBotherWorksTimeEvidence2.Id &&
                    DBotherWorksTimeEvidence2.Id != DBotherWorksTimeEvidence3.Id &&
                    DBotherWorksTimeEvidence3.Id != DBotherWorksTimeEvidence4.Id
                );
            }

            [Test]
            public void should_have_proper_WorkedTime()
            {
                Assert.AreEqual(10, DBotherWorksTimeEvidence1.WorkedTime);
                Assert.AreEqual(100, DBotherWorksTimeEvidence2.WorkedTime);
                Assert.AreEqual(14.1, DBotherWorksTimeEvidence3.WorkedTime);
                Assert.AreEqual(234.1, DBotherWorksTimeEvidence4.WorkedTime);
            }

            [Test]
            public void should_have_proper_OtherWorkType()
            {
                Assert.AreEqual(OtherWorkTypeEnum.Additional, DBotherWorksTimeEvidence1.OtherWorkType);
                Assert.AreEqual(OtherWorkTypeEnum.Additional, DBotherWorksTimeEvidence2.OtherWorkType);
                Assert.AreEqual(OtherWorkTypeEnum.Helper, DBotherWorksTimeEvidence3.OtherWorkType);
                Assert.AreEqual(OtherWorkTypeEnum.Helper, DBotherWorksTimeEvidence4.OtherWorkType);
            }

            [Test]
            public void should_have_proper_Type()
            {
                Assert.AreEqual(CrewWorkTypeEnum.Carpenter, DBotherWorksTimeEvidence1.Type);
                Assert.AreEqual(CrewWorkTypeEnum.Carpenter, DBotherWorksTimeEvidence2.Type);
                Assert.AreEqual(CrewWorkTypeEnum.GeneralConstructor, DBotherWorksTimeEvidence3.Type);
                Assert.AreEqual(CrewWorkTypeEnum.SteelFixer, DBotherWorksTimeEvidence4.Type);
            }

            [Test]
            public void should_have_proper_OtherWorkOption()
            {
                Assert.AreEqual(DBoption1, DBotherWorksTimeEvidence1.OtherWorkOption);
                Assert.AreEqual(DBoption2, DBotherWorksTimeEvidence2.OtherWorkOption);
                Assert.AreEqual(DBoption3, DBotherWorksTimeEvidence3.OtherWorkOption);
                Assert.AreEqual(DBoption1, DBotherWorksTimeEvidence4.OtherWorkOption);
            }

            [Test]
            public void should_have_proper_GroupedOtherWorkTimeEvidence()
            {
                Assert.AreEqual(null, DBotherWorksTimeEvidence1.GroupedOtherWorkTimeEvidence);
                Assert.AreEqual(null, DBotherWorksTimeEvidence2.GroupedOtherWorkTimeEvidence);
                Assert.AreEqual(null, DBotherWorksTimeEvidence3.GroupedOtherWorkTimeEvidence);
                Assert.AreEqual(null, DBotherWorksTimeEvidence4.GroupedOtherWorkTimeEvidence);
            }
        }
    }
}