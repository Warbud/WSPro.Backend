using System;
using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class WorkerTimeEvidenceTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateData
        {
            public static readonly CreateWorkerTimeEvidenceDto Dto = new(
                new DateTime(2021, 10, 10),
                new Entity(10),
                new Entity(20),
                new Entity(30),
                123.4123m,
                new Entity(40)
            );

            public static readonly WorkerTimeEvidence Expected = new()
            {
                Date = new DateTime(2021, 10, 10),
                Worker = new Worker { Id = 10 },
                SetByEngineer = new User { Id = 20 },
                Project = new Project { Id = 30 },
                WorkedTime = 123.4123m,
                CrewSummary = new CrewSummary { Id = 40 }
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(Dto, Expected); }
            }
        }

        [TestFixtureSource(typeof(CreateData), nameof(CreateData.Data))]
        private class TestCreateWorkerTimeEvidenceDto : WorkerTimeEvidenceTest
        {
            public TestCreateWorkerTimeEvidenceDto(CreateWorkerTimeEvidenceDto dto,
                WorkerTimeEvidence expected)
            {
                Dto = dto;
                Expected = expected;
            }

            public WorkerTimeEvidence Expected { get; }
            public CreateWorkerTimeEvidenceDto Dto { get; }

            [OneTimeSetUp]
            public void create()
            {
                Mapped = Mapper.Map<WorkerTimeEvidence>(Dto);
            }

            public WorkerTimeEvidence Mapped { get; set; }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Mapped.Date);
            }

            [Test]
            public void ShouldMapWorker()
            {
                Assert.AreEqual(Expected.Worker?.Id, Mapped.Worker?.Id);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.SetByEngineer?.Id, Mapped.SetByEngineer?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Mapped.Project?.Id);
            }

            [Test]
            public void ShouldMapWorkedTime()
            {
                Assert.AreEqual(Expected.WorkedTime, Mapped.WorkedTime);
            }

            [Test]
            public void ShouldMapCrewSummary()
            {
                Assert.AreEqual(Expected.CrewSummary?.Id, Mapped.CrewSummary?.Id);
            }
        }

        private class UpdateData
        {
            public static readonly WorkerTimeEvidence Existed = new()
            {
                Date = new DateTime(2021, 1, 10),
                Worker = new Worker { Id = 1 },
                SetByEngineer = new User { Id = 2 },
                Project = new Project { Id = 3 },
                WorkedTime = 1.4123m,
                CrewSummary = new CrewSummary { Id = 4 }
            };

            public static readonly UpdateWorkerTimeEvidenceDto Dto = new(
                new DateTime(2021, 10, 10),
                new Entity(10),
                new Entity(20),
                new Entity(30),
                123.4123m,
                new Entity(40)
            );

            public static readonly WorkerTimeEvidence Expected = new()
            {
                Date = new DateTime(2021, 10, 10),
                Worker = new Worker { Id = 10 },
                SetByEngineer = new User { Id = 20 },
                Project = new Project { Id = 30 },
                WorkedTime = 123.4123m,
                CrewSummary = new CrewSummary { Id = 40 }
            };

            public static readonly WorkerTimeEvidence Existed2 = Existed;

            public static readonly UpdateWorkerTimeEvidenceDto NullDto = new(
                null,
                null,
                null,
                null,
                null,
                null
            );

            public static readonly WorkerTimeEvidence Expected2 = Existed;

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed, Dto, Expected);
                    yield return new TestFixtureData(Existed2, NullDto, Expected2);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateData), nameof(UpdateData.Data))]
        private class TestUpdateWorkerTimeEvidenceDto : WorkerTimeEvidenceTest
        {
            public WorkerTimeEvidence Expected { get; }
            public UpdateWorkerTimeEvidenceDto Dto { get; }
            public WorkerTimeEvidence Existed { get; set; }

            public TestUpdateWorkerTimeEvidenceDto(WorkerTimeEvidence existed,
                UpdateWorkerTimeEvidenceDto dto,
                WorkerTimeEvidence expected)
            {
                Existed = existed;
                Expected = expected;
                Dto = dto;
            }

            [OneTimeSetUp]
            public void create()
            {
                Existed = Mapper.Map(Dto, Existed);
            }


            [Test]
            public void ShouldMapId()
            {
                Assert.AreEqual(Expected.Id, Existed.Id);
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Existed.Date);
            }

            [Test]
            public void ShouldMapWorker()
            {
                Assert.AreEqual(Expected.Worker?.Id, Existed.Worker?.Id);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.SetByEngineer?.Id, Existed.SetByEngineer?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Existed.Project?.Id);
            }

            [Test]
            public void ShouldMapWorkedTime()
            {
                Assert.AreEqual(Expected.WorkedTime, Existed.WorkedTime);
            }

            [Test]
            public void ShouldMapCrewSummary()
            {
                Assert.AreEqual(Expected.CrewSummary?.Id, Existed.CrewSummary?.Id);
            }
        }
    }
}