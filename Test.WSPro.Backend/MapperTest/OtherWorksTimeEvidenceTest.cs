using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class OtherWorksTimeEvidenceTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateData
        {
            public static readonly CreateOtherWorksTimeEvidenceDto Dto = new(
                10.123m,
                OtherWorkTypeEnum.Additional,
                "opis",
                CrewWorkTypeEnum.Carpenter,
                new Entity(10),
                new Entity(20)
            );

            public static readonly OtherWorksTimeEvidence Expected = new()
            {
                WorkedTime = 10.123m,
                OtherWorkType = OtherWorkTypeEnum.Additional,
                Description = "opis",
                Type = CrewWorkTypeEnum.Carpenter,
                OtherWorkOption = new OtherWorkOption { Id = 10 },
                GroupedOtherWorkTimeEvidence = new GroupedOtherWorkTimeEvidence { Id = 20 }
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(Dto, Expected); }
            }
        }

        [TestFixtureSource(typeof(CreateData), nameof(CreateData.Data))]
        private class TestCreateOtherWorksTimeEvidenceDto : OtherWorksTimeEvidenceTest
        {
            public TestCreateOtherWorksTimeEvidenceDto(CreateOtherWorksTimeEvidenceDto dto,
                OtherWorksTimeEvidence expected)
            {
                Expected = expected;
                Dto = dto;
            }

            public OtherWorksTimeEvidence Expected { get; }
            public OtherWorksTimeEvidence Mapped { get; set; }
            public CreateOtherWorksTimeEvidenceDto Dto { get; }

            [OneTimeSetUp]
            public void create()
            {
                Mapped = Mapper.Map<OtherWorksTimeEvidence>(Dto);
            }

            [Test]
            public void ShouldTestWorkedTime()
            {
                Assert.AreEqual(Expected.WorkedTime, Mapped.WorkedTime);
            }

            [Test]
            public void ShouldTestOtherWorkType()
            {
                Assert.AreEqual(Expected.OtherWorkType, Mapped.OtherWorkType);
            }

            [Test]
            public void ShouldTestDescription()
            {
                Assert.AreEqual(Expected.Description, Mapped.Description);
            }

            [Test]
            public void ShouldTestType()
            {
                Assert.AreEqual(Expected.Type, Mapped.Type);
            }

            [Test]
            public void ShouldTestOtherWorkOption()
            {
                Assert.AreEqual(Expected.OtherWorkOption?.Id, Mapped.OtherWorkOption?.Id);
            }

            [Test]
            public void ShouldTestGroupedOtherWorkTimeEvidence()
            {
                Assert.AreEqual(Expected.GroupedOtherWorkTimeEvidence?.Id, Mapped.GroupedOtherWorkTimeEvidence?.Id);
            }
        }

        private class UpdateData
        {
            public static readonly OtherWorksTimeEvidence Existed = new()
            {
                WorkedTime = 9m,
                OtherWorkType = OtherWorkTypeEnum.Helper,
                Description = "stary opis",
                Type = CrewWorkTypeEnum.GeneralConstructor,
                OtherWorkOption = new OtherWorkOption { Id = 22 },
                GroupedOtherWorkTimeEvidence = new GroupedOtherWorkTimeEvidence { Id = 211 }
            };

            public static readonly UpdateOtherWorksTimeEvidenceDto Dto = new(
                10.123m,
                OtherWorkTypeEnum.Additional,
                "opis",
                CrewWorkTypeEnum.Carpenter,
                new Entity(10),
                new Entity(20)
            );

            public static readonly UpdateOtherWorksTimeEvidenceDto NullDto = new(
                null,
                null,
                null,
                null,
                null,
                null
            );
            public static readonly OtherWorksTimeEvidence Expected = new()
            {
                WorkedTime = 10.123m,
                OtherWorkType = OtherWorkTypeEnum.Additional,
                Description = "opis",
                Type = CrewWorkTypeEnum.Carpenter,
                OtherWorkOption = new OtherWorkOption { Id = 10 },
                GroupedOtherWorkTimeEvidence = new GroupedOtherWorkTimeEvidence { Id = 20 }
            };



            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed, NullDto, Existed);
                    yield return new TestFixtureData(Existed, Dto, Expected);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateData), nameof(UpdateData.Data))]
        private class TestUpdateOtherWorksTimeEvidenceDto : OtherWorksTimeEvidenceTest
        {
            public TestUpdateOtherWorksTimeEvidenceDto(OtherWorksTimeEvidence existed, UpdateOtherWorksTimeEvidenceDto dto,
                OtherWorksTimeEvidence expected)
            {
                Dto = dto;
                Existed = existed;
                Expected = expected;
            }

            public OtherWorksTimeEvidence Expected { get; }

            public OtherWorksTimeEvidence Existed { get; set; }

            public UpdateOtherWorksTimeEvidenceDto Dto { get; }

            [OneTimeSetUp]
            public void create()
            {
                Existed = Mapper.Map(Dto, Existed);
            }

            [Test]
            public void ShouldTestId()
            {
                Assert.AreEqual(Expected.Id, Existed.Id);
            }

            [Test]
            public void ShouldTestWorkedTime()
            {
                Assert.AreEqual(Expected.WorkedTime, Existed.WorkedTime);
            }

            [Test]
            public void ShouldTestOtherWorkType()
            {
                Assert.AreEqual(Expected.OtherWorkType, Existed.OtherWorkType);
            }

            [Test]
            public void ShouldTestDescription()
            {
                Assert.AreEqual(Expected.Description, Existed.Description);
            }

            [Test]
            public void ShouldTestType()
            {
                Assert.AreEqual(Expected.Type, Existed.Type);
            }

            [Test]
            public void ShouldTestOtherWorkOption()
            {
                Assert.AreEqual(Expected.OtherWorkOption?.Id, Existed.OtherWorkOption?.Id);
            }

            [Test]
            public void ShouldTestGroupedOtherWorkTimeEvidence()
            {
                Assert.AreEqual(Expected.GroupedOtherWorkTimeEvidence?.Id, Existed.GroupedOtherWorkTimeEvidence?.Id);
            }
        }
    }
}