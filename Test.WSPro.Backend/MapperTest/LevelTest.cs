using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class LevelTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        class TestCreateLevelDtoMapToLevel:LevelTest
        {
            public CreateLevelDto Dto;
            public Level Entity;

            [SetUp]
            public void CreateData()
            {
                Dto = new CreateLevelDto("01");

                Entity = Mapper.Map<Level>(Dto);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual("01",Entity.Name);
            }
        }

        [TestFixture]
        class TestUpdateLevelDtoMapToLevel:LevelTest
        {
            public UpdateLevelDto Dto;
            public Level Entity;

            [SetUp]
            public void CreateData()
            {
                Entity = new Level()
                {
                    Id = 123,
                    Name = "02"
                };
                
                Dto = new UpdateLevelDto("01");

                Mapper.Map(Dto,Entity);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual("01",Entity.Name);
            }

            [Test]
            public void ShouldDoNotTouchId()
            {
                Assert.AreEqual(123,Entity.Id);
            }
        }

    }
}