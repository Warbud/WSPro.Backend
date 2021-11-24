using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class DelayTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }
        
        public class CreateDelayDtoDataStorage
        {
            public static CreateDelayDto Dto = new("komentarz", new (10),
                new (11),new(12),new DateTime(2021,10,10),
                new (15),new []{new Entity(20),new Entity(21)});

            public static Delay ExpectedEntity = new Delay()
            {
                Commentary = "komentarz",
                User = new User() { Id = 10 },
                Level = new Level() { Id = 11 },
                Crane = new Crane() { Id = 12 },
                Date = new DateTime(2021, 10, 10),
                Project = new Project() { Id = 15 },
                DelayCauses = new List<global::WSPro.Backend.Domain.Model.DelayCause>() { new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 20 }, new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 21 } },
            };

            public static CreateDelayDto DtoWithNulls = new CreateDelayDto("komentarz", new Entity(10), null, null,
                new DateTime(2021, 10, 10), new Entity(21), null);

            public static Delay ExpectedEntityWithNulls = new Delay()
            {
                Commentary = "komentarz",
                User = new User() { Id = 10 },
                Level = null,
                Crane = null,
                Date = new DateTime(2021, 10, 10),
                Project = new Project() { Id = 21 },
                DelayCauses = new List<global::WSPro.Backend.Domain.Model.DelayCause>(),
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExpectedEntity, Dto);
                    yield return new TestFixtureData(ExpectedEntityWithNulls, DtoWithNulls);
                }
            }
        }

        
        [TestFixtureSource(typeof(CreateDelayDtoDataStorage), nameof(CreateDelayDtoDataStorage.Data))]
        class TestCreateDelayDto:DelayTest
        {
            public readonly Delay ExpectedEntity;
            public readonly CreateDelayDto Dto;
            public Delay MappedEntity;
            public TestCreateDelayDto(Delay expectedEntity, CreateDelayDto dto)
            {
                ExpectedEntity = expectedEntity;
                Dto = dto;
            }
            
            [OneTimeSetUp]
            public void CreateData()
            {
                MappedEntity = Mapper.Map<Delay>(Dto);
            }

            [Test]
            public void ShouldMapCommentary()
            {
                Assert.AreEqual(ExpectedEntity.Commentary,MappedEntity.Commentary);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(ExpectedEntity.User?.Id,MappedEntity.User?.Id);
            }

            [Test]
            public void ShouldMapLevel()
            {
                Assert.AreEqual(ExpectedEntity.Level?.Id,MappedEntity.Level?.Id);
            }

            [Test]
            public void ShouldMapCrane()
            {
                Assert.AreEqual(ExpectedEntity.Crane?.Id,MappedEntity.Crane?.Id);
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(ExpectedEntity.Date,MappedEntity.Date);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(ExpectedEntity.Project?.Id,MappedEntity.Project?.Id);
            }

            [Test]
            public void ShouldMapDelayCauses()
            {
                Assert.AreEqual(ExpectedEntity.DelayCauses.Count,MappedEntity.DelayCauses.Count);
                for (int i = 0; i < ExpectedEntity.DelayCauses.Count; i++)
                {
                    Assert.That(MappedEntity.DelayCauses.ToList()[i],Has.Property("Id").EqualTo(ExpectedEntity.DelayCauses.ToList()[i].Id));
                }
            }
        }
        
        public class UpdateDelayDtoDataStorage
        {
            public static Delay ExistedEntity = new Delay()
            {
                Id = 10,
                Commentary = "asd",
                User = new User() { Id = 22 },
                Level = new Level() { Id = 21 },
                Crane = new Crane() { Id = 32 },
                Date = new DateTime(2021, 1, 10),
                Project = new Project() { Id = 32 },
                DelayCauses = new List<global::WSPro.Backend.Domain.Model.DelayCause>() { new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 11 }, new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 12 } },
            };
            public static UpdateDelayDto Dto = new("komentarz", new (10),
                new (11),new(12),new DateTime(2021,10,10),
                new (15),new []{new Entity(20),new Entity(21)});

            public static Delay ExpectedEntity = new Delay()
            {Id = 10,
                Commentary = "komentarz",
                User = new User() { Id = 10 },
                Level = new Level() { Id = 11 },
                Crane = new Crane() { Id = 12 },
                Date = new DateTime(2021, 10, 10),
                Project = new Project() { Id = 15 },
                DelayCauses = new List<global::WSPro.Backend.Domain.Model.DelayCause>() { new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 20 }, new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 21 } },
            };
            
            
            public static Delay ExistedEntityWithNulls = new Delay()
            {
                Id = 10,
                Commentary = "asd",
                User = new User(){Id = 123},
                Level = null,
                Crane = null,
                Date = new DateTime(2021, 1, 10),
                Project = new Project() { Id = 32 },
                DelayCauses = new List<global::WSPro.Backend.Domain.Model.DelayCause>() { new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 11 }, new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 12 } },
            };
            
            public static UpdateDelayDto DtoWithNulls = new UpdateDelayDto("komentarz", new Entity(10), null, null,
                new DateTime(2021, 10, 10), new Entity(21), null);

            public static Delay ExpectedEntityWithNulls = new Delay()
            {
                Id = 10,
                Commentary = "komentarz",
                User = new User() { Id = 10 },
                Level = null,
                Crane = null,
                Date = new DateTime(2021, 10, 10),
                Project = new Project() { Id = 21 },
                DelayCauses = new List<global::WSPro.Backend.Domain.Model.DelayCause>() { new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 11 }, new global::WSPro.Backend.Domain.Model.DelayCause() { Id = 12 } },
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExpectedEntity, Dto,ExistedEntity);
                    yield return new TestFixtureData(ExpectedEntityWithNulls, DtoWithNulls,ExistedEntityWithNulls);
                }
            }
        }
        [TestFixtureSource(typeof(UpdateDelayDtoDataStorage), nameof(UpdateDelayDtoDataStorage.Data))]
        public class TestUpdateDelayDto:DelayTest
        {
            public readonly UpdateDelayDto Dto;
            public readonly Delay ExpectedEntity;
            public Delay ExistedEntity;
            
            public TestUpdateDelayDto(Delay expectedEntity, UpdateDelayDto dto, Delay existedEntity)
            {
                Dto = dto;
                ExpectedEntity = expectedEntity;
                ExistedEntity = existedEntity;
            }
            [OneTimeSetUp]
            public void CreateData()
            {
                ExistedEntity = Mapper.Map(Dto, ExistedEntity);
            }

            [Test]
            public void ShouldMapId()
            {
                Assert.AreEqual(ExistedEntity.Id,ExistedEntity.Id);
            }
            
            [Test]
            public void ShouldMapCommentary()
            {
                Assert.AreEqual(ExpectedEntity.Commentary,ExistedEntity.Commentary);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(ExpectedEntity.User?.Id,ExistedEntity.User?.Id);
            }

            [Test]
            public void ShouldMapLevel()
            {
                Assert.AreEqual(ExpectedEntity.Level?.Id,ExistedEntity.Level?.Id);
            }

            [Test]
            public void ShouldMapCrane()
            {
                Assert.AreEqual(ExpectedEntity.Crane?.Id,ExistedEntity.Crane?.Id);
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(ExpectedEntity.Date,ExistedEntity.Date);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(ExpectedEntity.Project?.Id,ExistedEntity.Project?.Id);
            }

            [Test]
            public void ShouldMapDelayCauses()
            {
                Assert.AreEqual(ExpectedEntity.DelayCauses.Count,ExistedEntity.DelayCauses.Count);
                for (int i = 0; i < ExpectedEntity.DelayCauses.Count; i++)
                {
                    Assert.That(ExistedEntity.DelayCauses.ToList()[i],Has.Property("Id").EqualTo(ExpectedEntity.DelayCauses.ToList()[i].Id));
                }
            }
        }
    }
}