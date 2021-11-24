using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class CraneTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        class TestCreateCraneDtoMapToCrane:CraneTest
        {
            public CreateCraneDto Dto;
            public Crane Entity;

            [SetUp]
            public void CreateData()
            {
                Dto = new CreateCraneDto("01");

                Entity = Mapper.Map<Crane>(Dto);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual("01",Entity.Name);
            }
        }

        [TestFixture]
        class TestUpdateCraneDtoMapToCrane:CraneTest
        {
            public UpdateCraneDto Dto;
            public Crane Entity;

            [SetUp]
            public void CreateData()
            {
                Entity = new Crane()
                {
                    Id = 123,
                    Name = "02"
                };
                
                Dto = new UpdateCraneDto("01");

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