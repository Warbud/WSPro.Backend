using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class CrewTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        public class TestCreateCrewDto : CrewTest
        {
            public CreateCrewDto Dto;
            public Crew Entity;

            [OneTimeSetUp]
            public void CreateData()
            {
                Dto = new CreateCrewDto("crew name", new Entity(10), new Entity(22), CrewWorkTypeEnum.Carpenter);
                Entity = Mapper.Map<Crew>(Dto);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual("crew name", Entity.Name);
            }

            [Test]
            public void ShouldMapOwner()
            {
                Assert.AreEqual(10, Entity.Owner.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(22, Entity.Project.Id);
            }

            [Test]
            public void ShouldMapCrewWorkType()
            {
                Assert.AreEqual(CrewWorkTypeEnum.Carpenter, Entity.CrewWorkType);
            }
        }

        public class UpdatedCrewDtoDataStorage
        {
            private static readonly Crew ExistingEntity = new()
            {
                Id = 1000,
                Name = "old name",
                Owner = new User { Id = 10 },
                Project = new Project { Id = 100 },
                CrewWorkType = CrewWorkTypeEnum.Carpenter
            };

            private static readonly Crew ExpectedEntity = new()
            {
                Id = 1000,
                Name = "new name",
                Owner = new User { Id = 11 },
                Project = new Project { Id = 111 },
                CrewWorkType = CrewWorkTypeEnum.GeneralConstructor
            };

            private static readonly UpdateCrewDto FullDto = new(
                "new name", new Entity(11),
                new Entity(111), CrewWorkTypeEnum.GeneralConstructor
            );


            private static readonly UpdateCrewDto NullishDto = new(
                null, null,
                null, null
            );

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExistingEntity, FullDto, ExpectedEntity);
                    yield return new TestFixtureData(ExistingEntity, NullishDto, ExistingEntity);
                }
            }
        }

        [TestFixtureSource(typeof(UpdatedCrewDtoDataStorage), nameof(UpdatedCrewDtoDataStorage.Data))]
        public class TestUpdateCrewDto : CrewTest
        {
            public readonly UpdateCrewDto Dto;
            public Crew ExistingEntity;
            public readonly Crew ExpectedEntity;

            public TestUpdateCrewDto(Crew existingEntity, UpdateCrewDto dto, Crew expectedEntity)
            {
                ExistingEntity = existingEntity;
                Dto = dto;
                ExpectedEntity = expectedEntity;
            }

            [OneTimeSetUp]
            public void CreateData()
            {
                Mapper.Map(Dto, ExistingEntity);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual(ExpectedEntity.Name, ExistingEntity.Name);
            }

            [Test]
            public void ShouldMapOwner()
            {
                Assert.AreEqual(ExpectedEntity.Owner.Id, ExistingEntity.Owner.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(ExpectedEntity.Project.Id, ExistingEntity.Project.Id);
            }

            [Test]
            public void ShouldMapCrewWorkType()
            {
                Assert.AreEqual(ExpectedEntity.CrewWorkType, ExistingEntity.CrewWorkType);
            }
        }
    }
}