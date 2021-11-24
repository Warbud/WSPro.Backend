using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class WorkerTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateData
        {
            public static readonly CreateWorkerDto ExternalWorkerDto = new(
                CrewWorkTypeEnum.Carpenter,
                new Entity(10),
                null,
                "kowalski"
            );

            public static readonly Worker ExternalWorkerExpected = new()
            {
                CrewWorkType = CrewWorkTypeEnum.Carpenter,
                AddedBy = new User { Id = 10 },
                WarbudId = null,
                Name = "kowalski"
            };

            public static readonly CreateWorkerDto HomeWorkerDto = new(
                CrewWorkTypeEnum.Carpenter,
                new Entity(10),
                "W0123124",
                null
            );

            public static readonly Worker HomeWorkerExpected = new()
            {
                CrewWorkType = CrewWorkTypeEnum.Carpenter,
                AddedBy = new User { Id = 10 },
                WarbudId = "W0123124",
                Name = null
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExternalWorkerDto, ExternalWorkerExpected);
                    yield return new TestFixtureData(HomeWorkerDto, HomeWorkerExpected);
                }
            }
        }

        [TestFixtureSource(typeof(CreateData), nameof(CreateData.Data))]
        private class TestCreateWorkerDto : WorkerTest
        {
            public TestCreateWorkerDto(CreateWorkerDto dto, Worker expected)
            {
                Expected = expected;
                Dto = dto;
            }
            public Worker Expected { get; }
            public Worker Mapped { get; set; }
            public CreateWorkerDto Dto { get; }

            [OneTimeSetUp]
            public void create()
            {
                Mapped = Mapper.Map<Worker>(Dto);
            }

            [Test]
            public void ShouldMapCrewWorkType()
            {
                Assert.AreEqual(Expected.CrewWorkType, Mapped.CrewWorkType);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.AddedBy?.Id, Mapped.AddedBy?.Id);
            }

            [Test]
            public void ShouldMapWarbudId()
            {
                Assert.AreEqual(Expected.WarbudId, Mapped.WarbudId);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual(Expected.Name, Mapped.Name);
            }
        }

        private class UpdateData
        {
          
            
            public static readonly Worker ExistedExternalWorker = new()
            {
                Id = 100,
                CrewWorkType = CrewWorkTypeEnum.Carpenter,
                AddedBy = new User { Id = 10 },
                WarbudId = null,
                Name = "kowalski"
            };
            public static readonly UpdateWorkerDto ExternalWorkerDto = new(
                CrewWorkTypeEnum.GeneralConstructor,
                new Entity(12),
                null,
                "kowalski2"
            );
            public static readonly Worker ExpectedExternalWorker = new()
            {
                Id = 100,
                CrewWorkType = CrewWorkTypeEnum.GeneralConstructor,
                AddedBy = new User { Id = 12 },
                WarbudId = null,
                Name = "kowalski2"
            };
            
          
            
            public static readonly Worker ExistedHomeWorker = new()
            {
                Id = 100,
                CrewWorkType = CrewWorkTypeEnum.Carpenter,
                AddedBy = new User { Id = 10 },
                WarbudId = "W000000",
                Name = null
            };
            public static readonly UpdateWorkerDto HomeWorkerDto = new(
                CrewWorkTypeEnum.GeneralConstructor,
                new Entity(12),
                "W11111111",
                null
            );
            public static readonly Worker ExpectedHomeWorker = new()
            {
                Id = 100,
                CrewWorkType = CrewWorkTypeEnum.GeneralConstructor,
                AddedBy = new User { Id = 12 },
                WarbudId = "W11111111",
                Name = null
            };
            
            
            public static readonly Worker ExistedWorker = new()
            {
                Id = 100,
                CrewWorkType = CrewWorkTypeEnum.Carpenter,
                AddedBy = new User { Id = 10 },
                WarbudId = "W000000",
                Name = null
            };
            public static readonly UpdateWorkerDto NullDto = new(
                null,
                null,
                null,
                null
            );

            public static readonly Worker ExpectedWorker = ExistedWorker;
            
            
            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExistedExternalWorker, ExternalWorkerDto, ExpectedExternalWorker);
                    yield return new TestFixtureData(ExistedHomeWorker, HomeWorkerDto, ExpectedHomeWorker);
                    yield return new TestFixtureData(ExistedWorker, NullDto, ExpectedWorker);
                    
                }
            }
        }

        [TestFixtureSource(typeof(UpdateData), nameof(UpdateData.Data))]
        private class TestUpdateWorkerDto : WorkerTest
        {
            public TestUpdateWorkerDto(Worker existed, UpdateWorkerDto dto,
                Worker expected)
            {
                Dto = dto;
                Existed = existed;
                Expected = expected;
            }

            public Worker Expected { get; }

            public Worker Existed { get; set; }

            public UpdateWorkerDto Dto { get; }

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
            public void ShouldMapCrewWorkType()
            {
                Assert.AreEqual(Expected.CrewWorkType, Existed.CrewWorkType);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.AddedBy?.Id, Existed.AddedBy?.Id);
            }

            [Test]
            public void ShouldMapWarbudId()
            {
                Assert.AreEqual(Expected.WarbudId, Existed.WarbudId);
            }

            [Test]
            public void ShouldMapName()
            {
                Assert.AreEqual(Expected.Name, Existed.Name);
            }
        }
    }
}