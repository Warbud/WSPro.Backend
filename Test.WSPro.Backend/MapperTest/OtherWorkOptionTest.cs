using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class OtherWorkOptionTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        class CreateData
        {
            public static CreateOtherWorkOptionDto Dto = new (
                "test name",
                CrewTypeEnum.HouseCrew,
                CrewWorkTypeEnum.Carpenter
            );

            public static OtherWorkOption Expected = new()
            {
                Name = "test name",
                CrewType = CrewTypeEnum.HouseCrew,
                CrewWorkType = CrewWorkTypeEnum.Carpenter
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Dto, Expected);
                }
            }
        }

        [TestFixtureSource(typeof(CreateData), nameof(CreateData.Data))]
        class TestCreateOtherWorkOptionDto:OtherWorkOptionTest
        {
            public TestCreateOtherWorkOptionDto(CreateOtherWorkOptionDto dto,OtherWorkOption expected)
            {
                Expected = expected;
                Dto = dto;
            }

            public OtherWorkOption Expected { get; set; }
            public OtherWorkOption Mapped { get; set; }
            public CreateOtherWorkOptionDto Dto { get; set; }

            [OneTimeSetUp]
            public void create()
            {
                Mapped = Mapper.Map<OtherWorkOption>(Dto);
            }

            [Test]
            public void ShouldTestName()
            {
                Assert.AreEqual(Expected.Name,Mapped.Name);
            }

            [Test]
            public void ShouldTestCrewType()
            {
                Assert.AreEqual(Expected.CrewType,Mapped.CrewType);
            }

            [Test]
            public void ShouldTestCrewWorkType()
            {
                Assert.AreEqual(Expected.CrewWorkType,Mapped.CrewWorkType);
            }
        }

        class UpdateData
        {
            public static OtherWorkOption Existed = new()
            {
                Id = 100,
                Name = "name",
                CrewType = CrewTypeEnum.SubcontractorCrew,
                CrewWorkType = CrewWorkTypeEnum.GeneralConstructor
            };
            public static UpdateOtherWorkOptionDto NullDto = new (
                null,
                null,
                null
                );

            
            public static UpdateOtherWorkOptionDto Dto = new (
                "test name",
                CrewTypeEnum.HouseCrew,
                CrewWorkTypeEnum.Carpenter
            );

            public static OtherWorkOption Expected = new()
            {
                Id = 100,
                Name = "test name",
                CrewType = CrewTypeEnum.HouseCrew,
                CrewWorkType = CrewWorkTypeEnum.Carpenter
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed,NullDto, Existed);
                    yield return new TestFixtureData(Existed,Dto, Expected);
                }
            }
        }
        [TestFixtureSource(typeof(UpdateData), nameof(UpdateData.Data))]
        class TestUpdateOtherWorkOptionDto:OtherWorkOptionTest
        {
            public TestUpdateOtherWorkOptionDto(OtherWorkOption existed, UpdateOtherWorkOptionDto dto,OtherWorkOption expected)
            {
                Dto = dto;
                Existed = existed;
                Expected = expected;
            }

            public OtherWorkOption Expected { get; set; }

            public OtherWorkOption Existed { get; set; }

            public UpdateOtherWorkOptionDto Dto { get; set; }

            [OneTimeSetUp]
            public void create()
            {
                Existed = Mapper.Map(Dto, Existed);
            }

            [Test]
            public void ShouldTestId()
            {
                Assert.AreEqual(Expected.Id,Existed.Id);
            }

            [Test]
            public void ShouldTestName()
            {
                Assert.AreEqual(Expected.Name,Existed.Name);
            }

            [Test]
            public void ShouldTestCrewType()
            {
                Assert.AreEqual(Expected.CrewType,Existed.CrewType);
            }

            [Test]
            public void ShouldTestCrewWorkType()
            {
                Assert.AreEqual(Expected.CrewWorkType,Existed.CrewWorkType);
            }
        }
    }
}