using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class DelayCauseTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixtureSource(typeof(CreateDelayCauseDtoDataStorage), nameof(CreateDelayCauseDtoDataStorage.Data))]
        public class CreateDelayCauseTestDto : DelayCauseTest
        {
            public readonly CreateDelayCauseDto Dto;
            public readonly DelayCause ExpectedEntity;
            public DelayCause MappedEntity;

            public CreateDelayCauseTestDto(DelayCause expectedEntity, CreateDelayCauseDto dto)
            {
                ExpectedEntity = expectedEntity;
                Dto = dto;
            }

            [OneTimeSetUp]
            public void Create()
            {
                MappedEntity = Mapper.Map<DelayCause>(Dto);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual(ExpectedEntity.Name, MappedEntity.Name);
            }

            [Test]
            public void ShouldMapIsMain()
            {
                Assert.AreEqual(ExpectedEntity.IsMain, MappedEntity.IsMain);
            }

            [Test]
            public void ShouldMapParent()
            {
                Assert.AreEqual(ExpectedEntity.Parent?.Id, MappedEntity.Parent?.Id);
            }
        }

        public class CreateDelayCauseDtoDataStorage
        {
            public static CreateDelayCauseDto Dto = new("test name", true, null);
            public static DelayCause ExpectedEntity = new() { Name = "test name", IsMain = true, Parent = null };

            public static CreateDelayCauseDto DtoWithParent = new("test name", true, new Entity(10));

            public static DelayCause ExpectedEntityWithParent = new()
                { Name = "test name", IsMain = true, Parent = new DelayCause { Id = 10 } };


            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExpectedEntity, Dto);
                    yield return new TestFixtureData(ExpectedEntityWithParent, DtoWithParent);
                }
            }
        }

        public class UpdateDelayCauseDtoDataStorage
        {
            public static DelayCause ExistedEntity = new() { Name = "name", IsMain = false, Parent = null };
            public static UpdateDelayCauseDto Dto = new("test name", true, null);
            public static DelayCause ExpectedEntity = new() { Name = "test name", IsMain = true, Parent = null };


            public static DelayCause ExistedEntityWithParent = new()
                { Name = "name", IsMain = false, Parent = new DelayCause { Id = 1 } };

            public static UpdateDelayCauseDto DtoWithParent = new("test name", true, new Entity(10));

            public static DelayCause ExpectedEntityWithParent = new()
                { Name = "test name", IsMain = true, Parent = new DelayCause { Id = 10 } };


            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExpectedEntity, Dto, ExistedEntity);
                    yield return new TestFixtureData(ExpectedEntityWithParent, DtoWithParent, ExistedEntityWithParent);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateDelayCauseDtoDataStorage), nameof(UpdateDelayCauseDtoDataStorage.Data))]
        public class UpdateDelayCauseTestDto : DelayCauseTest
        {
            public readonly UpdateDelayCauseDto TestDto;
            public readonly DelayCause ExpectedEntity;
            public DelayCause ExistedEntity;

            public UpdateDelayCauseTestDto(DelayCause expectedEntity, UpdateDelayCauseDto testDto,
                DelayCause existedEntity)
            {
                ExistedEntity = existedEntity;
                ExpectedEntity = expectedEntity;
                TestDto = testDto;
            }

            [OneTimeSetUp]
            public void CreateData()
            {
                ExistedEntity = Mapper.Map(TestDto, ExistedEntity);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual(ExpectedEntity.Name, ExistedEntity.Name);
            }

            [Test]
            public void ShouldMapIsMain()
            {
                Assert.AreEqual(ExpectedEntity.IsMain, ExistedEntity.IsMain);
            }

            [Test]
            public void ShouldMapParent()
            {
                Assert.AreEqual(ExpectedEntity.Parent?.Id, ExistedEntity.Parent?.Id);
            }
        }
    }
}