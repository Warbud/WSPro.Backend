using System;
using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class GroupedOtherWorkTimeEvidenceTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        public class CreateData
        {
            private static readonly CreateGroupedOtherWorkTimeEvidenceDto Dto = new(
                new Entity(10),
                new Entity(20),
                new Entity(30),
                new DateTime(2021, 10, 10),
                CrewTypeEnum.HouseCrew
            );

            private static readonly GroupedOtherWorkTimeEvidence Expected = new()
            {
                Crew = new Crew { Id = 10 },
                Project = new Project { Id = 20 },
                Level = new Level { Id = 30 },
                Date = new DateTime(2021, 10, 10),
                CrewType = CrewTypeEnum.HouseCrew
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(Dto, Expected); }
            }
        }

        [TestFixtureSource(typeof(CreateData), nameof(CreateData.Data))]
        private class TestCreateGroupedOtherWorkTimeEvidenceDto : GroupedOtherWorkTimeEvidenceTest
        {
            public CreateGroupedOtherWorkTimeEvidenceDto Dto { get; }
            public GroupedOtherWorkTimeEvidence Expected { get; }
            public GroupedOtherWorkTimeEvidence Mapped { get; set; }

            public TestCreateGroupedOtherWorkTimeEvidenceDto(CreateGroupedOtherWorkTimeEvidenceDto dto,
                GroupedOtherWorkTimeEvidence expected)
            {
                Expected = expected;
                Dto = dto;
            }

            [OneTimeSetUp]
            public void create()
            {
                Mapped = Mapper.Map<GroupedOtherWorkTimeEvidence>(Dto);
            }

            [Test]
            public void ShouldMapCrew()
            {
                Assert.AreEqual(Expected.Crew?.Id, Mapped.Crew?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Mapped.Project?.Id);
            }

            [Test]
            public void ShouldMapLevel()
            {
                Assert.AreEqual(Expected.Level?.Id, Mapped.Level?.Id);
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Mapped.Date);
            }

            [Test]
            public void ShouldMapCrewType()
            {
                Assert.AreEqual(Expected.CrewType, Mapped.CrewType);
            }
        }

        public class UpdateData
        {
            public static GroupedOtherWorkTimeEvidence Existed = new()
            {
                Id = 100,
                Crew = new Crew { Id = 10 },
                Project = new Project { Id = 20 },
                Level = new Level { Id = 30 },
                Date = new DateTime(2021, 10, 10),
                CrewType = CrewTypeEnum.HouseCrew
            };

            public static UpdateGroupedOtherWorkTimeEvidenceDto NullishDto = new(
                null,
                null,
                null,
                null,
                null
            );


            public static GroupedOtherWorkTimeEvidence Expected = Existed;

            
            
            public static GroupedOtherWorkTimeEvidence Existed2 = Existed;

            public static UpdateGroupedOtherWorkTimeEvidenceDto Dto = new(
                new Entity(11),
                new Entity(21),
                new Entity(31),
                new DateTime(2021, 1, 10),
                CrewTypeEnum.SubcontractorCrew
            );

            public static GroupedOtherWorkTimeEvidence Expected2 = new()
            {
                Id = 100,
                Crew = new Crew { Id = 11 },
                Project = new Project { Id = 21 },
                Level = new Level { Id = 31 },
                Date = new DateTime(2021, 1, 10),
                CrewType = CrewTypeEnum.SubcontractorCrew
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed, NullishDto, Expected);
                    yield return new TestFixtureData(Existed2, Dto, Expected2);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateData), nameof(UpdateData.Data))]
        public class TestUpdateGroupedOtherWorkTimeEvidenceDto : GroupedOtherWorkTimeEvidenceTest
        {
            public TestUpdateGroupedOtherWorkTimeEvidenceDto(GroupedOtherWorkTimeEvidence existed,
                UpdateGroupedOtherWorkTimeEvidenceDto dto,
                GroupedOtherWorkTimeEvidence expected)
            {
                Existed = existed;
                Dto = dto;
                Expected = expected;
            }

            public UpdateGroupedOtherWorkTimeEvidenceDto Dto { get; set; }
            public GroupedOtherWorkTimeEvidence Existed { get; set; }
            public GroupedOtherWorkTimeEvidence Expected { get; set; }

            [OneTimeSetUp]
            public void create()
            {
                Mapper.Map(Dto, Existed);
            }

            [Test]
            public void ShouldMapId()
            {
                Assert.AreEqual(Expected.Id, Existed.Id);
            }

            [Test]
            public void ShouldMapCrew()
            {
                Assert.AreEqual(Expected.Crew?.Id, Existed.Crew?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Existed.Project?.Id);
            }

            [Test]
            public void ShouldMapLevel()
            {
                Assert.AreEqual(Expected.Level?.Id, Existed.Level?.Id);
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Existed.Date);
            }

            [Test]
            public void ShouldMapCrewType()
            {
                Assert.AreEqual(Expected.CrewType, Existed.CrewType);
            }
        }
    }
}