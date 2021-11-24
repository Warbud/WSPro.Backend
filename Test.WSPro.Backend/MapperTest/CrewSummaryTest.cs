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
    public class CrewSummaryTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        private class TestCreateCrewSummaryDto : CrewSummaryTest
        {
            public CreateCrewSummaryDto Dto;
            public CrewSummary Entity;

            [SetUp]
            public void CreateData()
            {
                Dto = new CreateCrewSummaryDto(
                    new Entity(10),
                    new DateTime(2021, 10, 10),
                    new DateTime(2021, 11, 10),
                    new Entity(100),
                    new Entity(200),
                    new List<Entity> { new(40), new(41), new(42) }
                );

                Entity = Mapper.Map<CrewSummary>(Dto);
            }

            [Test]
            public void ShouldMapCrew()
            {
                Assert.AreEqual(10, Entity.Crew.Id);
            }

            [Test]
            public void ShouldMapStartDate()
            {
                Assert.AreEqual(new DateTime(2021, 10, 10), Entity.StartDate);
            }

            [Test]
            public void ShouldMapEndDate()
            {
                Assert.AreEqual(new DateTime(2021, 11, 10), Entity.EndDate);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(100, Entity.CrewOwner.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(200, Entity.Project.Id);
            }

            [Test]
            public void ShouldMapWorkers()
            {
                Assert.AreEqual(3, Entity.Workers.Count);

                var worker = Entity.Workers.Where(e => e.Id == 40);
                Assert.That(worker.Count(), Is.EqualTo(1));
                Assert.That(worker.FirstOrDefault(), Is.TypeOf<Worker>());

                worker = Entity.Workers.Where(e => e.Id == 41);
                Assert.That(worker.Count(), Is.EqualTo(1));
                Assert.That(worker.FirstOrDefault(), Is.TypeOf<Worker>());

                worker = Entity.Workers.Where(e => e.Id == 42);
                Assert.That(worker.Count(), Is.EqualTo(1));
                Assert.That(worker.FirstOrDefault(), Is.TypeOf<Worker>());
            }
        }

        [TestFixtureSource(typeof(TestUpdateCrewSummaryDataStorage), nameof(TestUpdateCrewSummaryDataStorage.Data))]
        private class TestUpdateCrewSummaryDto : CrewSummaryTest
        {
            public readonly UpdateCrewSummaryDto Dto;
            public readonly CrewSummary ExistingEntity;
            public readonly CrewSummary ExpectedEntity;

            public TestUpdateCrewSummaryDto(CrewSummary existingEntity, UpdateCrewSummaryDto dto,
                CrewSummary expectedEntity)
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
            public void ShouldMapCrew()
            {
                if (ExpectedEntity.Crew is not null)
                    Assert.AreEqual(ExpectedEntity.Crew.Id, ExistingEntity.Crew.Id);
                else
                    Assert.AreEqual(ExpectedEntity.Crew, ExistingEntity.Crew);
            }

            [Test]
            public void ShouldMapStartDate()
            {
                Assert.AreEqual(ExpectedEntity.StartDate, ExistingEntity.StartDate);
            }

            [Test]
            public void ShouldMapEndDate()
            {
                Assert.AreEqual(ExpectedEntity.EndDate, ExistingEntity.EndDate);
            }

            [Test]
            public void ShouldMapUser()
            {
                if (ExpectedEntity.CrewOwner is not null)
                    Assert.AreEqual(ExpectedEntity.CrewOwner.Id, ExistingEntity.CrewOwner.Id);
                else
                    Assert.AreEqual(ExpectedEntity.CrewOwner, ExistingEntity.CrewOwner);
            }

            [Test]
            public void ShouldMapProject()
            {
                if (ExpectedEntity.Project is not null)
                    Assert.AreEqual(ExpectedEntity.Project.Id, ExistingEntity.Project.Id);
                else
                    Assert.AreEqual(ExpectedEntity.Project, ExistingEntity.Project);
            }

            [Test]
            public void ShouldMapWorkers()
            {
                if (ExpectedEntity.Workers is null)
                    Assert.AreEqual(ExpectedEntity.Workers, ExistingEntity.Workers);
                else
                    Assert.AreEqual(ExpectedEntity.Workers.Count, ExistingEntity.Workers.Count);
            }
        }

        public class TestUpdateCrewSummaryDataStorage
        {
            public static CrewSummary ExistingEntity = new()
            {
                Id = 100,
                Crew = new Crew { Id = 1 },
                Project = new Project { Id = 2 },
                CrewOwner = new User { Id = 30 },
                StartDate = new DateTime(2021, 1, 10),
                EndDate = new DateTime(2021, 2, 10),
                Workers = new List<Worker> { new() { Id = 10 }, new() { Id = 11 }, new() { Id = 12 } }
            };

            public static UpdateCrewSummaryDto Dto = new(
                new Entity(10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 11, 10),
                new Entity(100),
                new Entity(200),
                new List<Entity> { new(40), new(41), new(42) });

            public static CrewSummary ExpectedEntity = new()
            {
                Id = 100,
                Crew = new Crew { Id = 10 },
                Project = new Project { Id = 200 },
                CrewOwner = new User { Id = 100 },
                StartDate = new DateTime(2021, 10, 10),
                EndDate = new DateTime(2021, 11, 10),
                Workers = new List<Worker> { new() { Id = 40 }, new() { Id = 41 }, new() { Id = 42 } }
            };

            public static UpdateCrewSummaryDto NullishDto = new(
                null, null, null, null, null, null);

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExistingEntity, Dto, ExpectedEntity);
                    yield return new TestFixtureData(ExistingEntity, NullishDto, ExistingEntity);
                }
            }
        }
    }
}