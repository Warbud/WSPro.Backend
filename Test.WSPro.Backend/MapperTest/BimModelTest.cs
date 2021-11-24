using System.Collections.Generic;
using System.Linq;
using Mapster;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class BimModelTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        public class TestCreateBimModelDto : BimModelTest
        {
            public CreateBimModelDto Dto;
            public BimModel Entity;

            [TestFixture]
            public class TestRequiredAttributes : TestCreateBimModelDto
            {
                [OneTimeSetUp]
                public void CreateDto()
                {
                    Dto = new CreateBimModelDto("test name", "model urn", null, new Entity(10), null, null);

                    Entity = Mapper.Map<BimModel>(Dto);
                }

                [Test]
                public void ShouldMapName()
                {
                    Assert.AreEqual("test name", Entity.Name);
                }

                [Test]
                public void ShouldMapModelUrn()
                {
                    Assert.AreEqual("model urn", Entity.ModelUrn);
                }

                [Test]
                public void ShouldMapDefaultViewNameWhileNull()
                {
                    Assert.AreEqual(null, Entity.DefaultViewName);
                }

                [Test]
                public void ShouldMapProject()
                {
                    Assert.AreEqual(10, Entity.Project.Id);
                }

                [Test]
                public void ShouldMapLevelsWithoutNull()
                {
                    Assert.IsEmpty(Entity.Levels);
                }

                [Test]
                public void ShouldMapCranesWithoutNull()
                {
                    Assert.IsEmpty(Entity.Cranes);
                }
            }

            [TestFixture]
            public class TestAllAttributes : TestCreateBimModelDto
            {
                [OneTimeSetUp]
                public void CreateDto()
                {
                    Dto = new CreateBimModelDto(
                        "test name",
                        "model urn",
                        "default name",
                        new Entity(10),
                        new List<Entity> { new(10), new(11) },
                        new List<Entity> { new(2), new(3) });

                    Entity = Mapper.Map<BimModel>(Dto);
                }

                [Test]
                public void ShouldMapName()
                {
                    Assert.AreEqual("test name", Entity.Name);
                }

                [Test]
                public void ShouldMapModelUrn()
                {
                    Assert.AreEqual("model urn", Entity.ModelUrn);
                }

                [Test]
                public void ShouldMapDefaultViewNameWhileNull()
                {
                    Assert.AreEqual("default name", Entity.DefaultViewName);
                }

                [Test]
                public void ShouldMapProject()
                {
                    Assert.AreEqual(10, Entity.Project.Id);
                }

                [Test]
                public void ShouldMapLevels()
                {
                    Assert.IsNotEmpty(Entity.Levels);
                    Assert.AreEqual(2, Entity.Levels.Count);
                    Assert.That(typeof(IList<Level>).IsAssignableFrom(Entity.Levels.GetType()));
                    Assert.That(Entity.Levels.Where(e => e.Id == 10).Count(), Is.EqualTo(1));
                    Assert.That(Entity.Levels.Where(e => e.Id == 11).Count(), Is.EqualTo(1));
                }

                [Test]
                public void ShouldMapCranes()
                {
                    Assert.IsNotEmpty(Entity.Cranes);
                    Assert.AreEqual(2, Entity.Cranes.Count);
                    Assert.That(typeof(IList<Crane>).IsAssignableFrom(Entity.Cranes.GetType()));
                    Assert.That(Entity.Cranes.Where(e => e.Id == 2).Count(), Is.EqualTo(1));
                    Assert.That(Entity.Cranes.Where(e => e.Id == 3).Count(), Is.EqualTo(1));
                }
            }
        }

        [TestFixture]
        public class TestUpdateBimModelDto : BimModelTest
        {
            public BimModel Entity;

            [TestFixture]
            public class TestEntityContainingNulls : TestUpdateBimModelDto
            {
                [OneTimeSetUp]
                public void OnStart()
                {
                    Entity = new BimModel
                    {
                        Id = 10,
                        Name = "stara nazwa",
                        ModelUrn = "Model Urn",
                        Project = new Project { Id = 1 },
                    };
                }
                
                [Test]
                public void ShouldDoNotChangeID()
                {
                    var oldEntityId = Entity.Id;
                    var dto = new UpdateBimModelDto(null,null, null, null, null, null);
                    Mapper.Map(dto, Entity);
                    Assert.AreEqual(oldEntityId, Entity.Id);
                }

                [TestCase(null, "stara nazwa")]
                [TestCase("nowa nazwa", "nowa nazwa")]
                public void ShouldMapName(string passed, string newData)
                {
                    var dto = new UpdateBimModelDto(passed, null, null, null, null, null);
                    Assert.AreEqual(passed, dto.Name);
                    Mapper.Map(dto, Entity);
                    Assert.AreEqual(newData, Entity.Name);
                }
                
                [TestCase(null, "Model Urn")]
                [TestCase("nowy urn", "nowy urn")]
                public void ShouldMapModelUrn(string passed, string newData)
                {
                    var dto = new UpdateBimModelDto(null,passed, null, null, null, null);
                    Assert.AreEqual(passed, dto.ModelUrn);
                    Mapper.Map(dto, Entity);
                    Assert.AreEqual(newData, Entity.ModelUrn);
                }
                
                [TestCase(null, null)]
                [TestCase("nowa główna nazwa", "nowa główna nazwa")]
                public void ShouldMapDefaultViewName(string passed, string newData)
                {
                    var dto = new UpdateBimModelDto(null,null, passed, null, null, null);
                    Assert.AreEqual(passed, dto.DefaultViewName);
                    Mapper.Map(dto, Entity);
                    Assert.AreEqual(newData, Entity.DefaultViewName);
                }
                
                [TestCase(null, 1)]
                [TestCase(2, 2)]
                public void ShouldMapProject(int? passed, int? newData)
                {
                    var dto = new UpdateBimModelDto(null,null, null, new Entity(passed), null, null);
                    Mapper.Map(dto, Entity);
                    Assert.AreEqual(newData, Entity.Project.Id);
                }
                
                [Test]
                public void ShouldMapLevels()
                {
                    Assert.IsEmpty(Entity.Levels);
                    var dto = new UpdateBimModelDto(null,null, null, null, new List<Entity>{new Entity(10),new Entity(11)}, null);
                    Mapper.Map(dto, Entity);
                   
                    Assert.IsNotEmpty(Entity.Levels);
                    Assert.IsNotEmpty(Entity.BimModelsLevels);
                    Assert.AreEqual(2, Entity.Levels.Count);
                    Assert.AreEqual(2, Entity.BimModelsLevels.Count);
                    Assert.That(typeof(IList<Level>).IsAssignableFrom(Entity.Levels.GetType()));
                    Assert.That(Entity.Levels.Where(e => e.Id == 10).Count(), Is.EqualTo(1));
                    Assert.That(Entity.Levels.Where(e => e.Id == 11).Count(), Is.EqualTo(1));
                }
                
                [Test]
                public void ShouldMapCranes()
                {
                    Assert.IsEmpty(Entity.Cranes);
                    var dto = new UpdateBimModelDto(null,null, null, null, null,new List<Entity>{new Entity(1),new Entity(2)});
                    Mapper.Map(dto, Entity);
                   
                    Assert.IsNotEmpty(Entity.Cranes);
                    Assert.AreEqual(2, Entity.Cranes.Count);
                    Assert.That(typeof(IList<Crane>).IsAssignableFrom(Entity.Cranes.GetType()));
                    Assert.That(Entity.Cranes.Where(e => e.Id == 1).Count(), Is.EqualTo(1));
                    Assert.That(Entity.Cranes.Where(e => e.Id == 2).Count(), Is.EqualTo(1));
                }
                
            }
        }
    }
}