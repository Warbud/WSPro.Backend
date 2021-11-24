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
    public class ElementsTimeEvidenceTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateElementsTimeEvidenceData
        {
            public static readonly CreateElementsTimeEvidenceDto Dto = new(
                new[] { new Entity(1), new Entity(2) },
                new DateTime(2021, 10, 10),
                new Entity(21),
                new Entity(31),
                new Entity(40),
                123.3123m
            );

            public static readonly ElementsTimeEvidence Expected = new()
            {
                Elements = new List<Element> { new() { Id = 1 }, new() { Id = 2 } },
                Date = new DateTime(2021, 10, 10),
                User = new User { Id = 21 },
                Project = new Project { Id = 31 },
                Crew = new Crew { Id = 40 },
                WorkedTime = 123.3123m
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(Expected, Dto); }
            }
        }

        [TestFixtureSource(typeof(CreateElementsTimeEvidenceData), nameof(CreateElementsTimeEvidenceData.Data))]
        private class TestCreateElementsTimeEvidenceDto : ElementsTimeEvidenceTest
        {
            public readonly ElementsTimeEvidence Expected;
            public readonly CreateElementsTimeEvidenceDto Dto;
            public ElementsTimeEvidence Mapped;

            public TestCreateElementsTimeEvidenceDto(ElementsTimeEvidence expected, CreateElementsTimeEvidenceDto dto)
            {
                Expected = expected;
                Dto = dto;
            }

            [OneTimeSetUp]
            public void CreateData()
            {
                Mapped = Mapper.Map<ElementsTimeEvidence>(Dto);
            }

            [Test]
            public void ShouldMapElements()
            {
                Assert.AreEqual(Expected.Elements.Count, Mapped.Elements.Count);
                for (var i = 0; i < Expected.Elements.Count; i++)
                {
                    var expected = Expected.Elements.ToList()[i];
                    var mapped = Mapped.Elements.ToList()[i];
                    Assert.AreEqual(expected.Id, mapped.Id);
                }
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Mapped.Date);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.User?.Id, Mapped.User?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Mapped.Project?.Id);
            }

            [Test]
            public void ShouldMapCrew()
            {
                Assert.AreEqual(Expected.Crew?.Id, Mapped.Crew?.Id);
            }

            [Test]
            public void ShouldMapWorkedTime()
            {
                Assert.AreEqual(Expected.WorkedTime, Mapped.WorkedTime);
            }
        }

        private class UpdateElementsTimeEvidenceData
        {
            public static readonly ElementsTimeEvidence Existed = new()
            {
                Id = 123,
                Elements = new List<Element> { new() { Id = 10 }, new() { Id = 11 } },
                Date = new DateTime(2021, 1, 1),
                User = new User { Id = 20 },
                Project = new Project { Id = 32 },
                Crew = new Crew { Id = 21 },
                WorkedTime = 312.321m
            };

            public static readonly UpdateElementsTimeEvidenceDto DtoWithNull =
                new(null, null, null, null, null, null);

            public static readonly ElementsTimeEvidence Expected = Existed;

            public static readonly ElementsTimeEvidence Existed2 = Existed;

            public static readonly UpdateElementsTimeEvidenceDto DtoWithAllData =
                new(new[] { new Entity(22), new Entity(32) }, new DateTime(2021, 10, 10),
                    new Entity(111), new Entity(121), new Entity(131), 444.444m);

            public static readonly ElementsTimeEvidence Expected2 = new()
            {
                Id = 123,
                Elements = new List<Element> { new() { Id = 22 }, new() { Id = 32 } },
                Date = new DateTime(2021, 10, 10),
                User = new User { Id = 111 },
                Project = new Project { Id = 121 },
                Crew = new Crew { Id = 131 },
                WorkedTime = 444.444m
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed, DtoWithNull, Expected);
                    yield return new TestFixtureData(Existed2, DtoWithAllData, Expected2);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateElementsTimeEvidenceData), nameof(UpdateElementsTimeEvidenceData.Data))]
        public class TestUpdateElementsTimeEvidenceDto : ElementsTimeEvidenceTest
        {
            public ElementsTimeEvidence Existed;
            public UpdateElementsTimeEvidenceDto Dto;
            public ElementsTimeEvidence Expected;

            public TestUpdateElementsTimeEvidenceDto(ElementsTimeEvidence existed, UpdateElementsTimeEvidenceDto dto,
                ElementsTimeEvidence expected)
            {
                Existed = existed;
                Dto = dto;
                Expected = expected;
            }


            [OneTimeSetUp]
            public void CreateData()
            {
                Mapper.Map(Dto, Existed);
            }


            [Test]
            public void ShouldMapElements()
            {
                Assert.AreEqual(Expected.Elements.Count, Existed.Elements.Count);
                for (var i = 0; i < Expected.Elements.Count; i++)
                {
                    var expected = Expected.Elements.ToList()[i];
                    var mapped = Existed.Elements.ToList()[i];
                    Assert.AreEqual(expected.Id, mapped.Id);
                }
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Existed.Date);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.User?.Id, Existed.User?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Existed.Project?.Id);
            }

            [Test]
            public void ShouldMapCrew()
            {
                Assert.AreEqual(Expected.Crew?.Id, Existed.Crew?.Id);
            }

            [Test]
            public void ShouldMapWorkedTime()
            {
                Assert.AreEqual(Expected.WorkedTime, Existed.WorkedTime);
            }
        }
    }
}