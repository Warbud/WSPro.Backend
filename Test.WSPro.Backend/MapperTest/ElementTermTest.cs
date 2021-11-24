using System;
using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class ElementTermTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateElementTermData
        {
            public static readonly CreateElementTermDto Dto = new(
                new Entity(123),
                new DateTime(2021, 1, 10),
                new DateTime(2021, 2, 10),
                new DateTime(2021, 3, 10),
                new DateTime(2021, 4, 10),
                new DateTime(2021, 5, 10),
                new DateTime(2021, 6, 10)
            );

            public static readonly ElementTerm Expected = new()
            {
                Element = new Element { Id = 123 },
                ElementId = 123,
                PlannedStart = new DateTime(2021, 1, 10),
                PlannedFinish = new DateTime(2021, 2, 10),
                PlannedStartBP = new DateTime(2021, 3, 10),
                PlannedFinishBP = new DateTime(2021, 4, 10),
                RealStart = new DateTime(2021, 5, 10),
                RealFinish = new DateTime(2021, 6, 10)
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(Expected, Dto); }
            }
        }

        [TestFixtureSource(typeof(CreateElementTermData), nameof(CreateElementTermData.Data))]
        private class TestCreateElementTermDto : ElementTermTest
        {
            public readonly CreateElementTermDto Dto;
            public readonly ElementTerm Expected;
            public ElementTerm Mapped;

            public TestCreateElementTermDto(ElementTerm expected, CreateElementTermDto dto)
            {
                Expected = expected;
                Dto = dto;
            }

            [OneTimeSetUp]
            public void init()
            {
                Mapped = Mapper.Map<ElementTerm>(Dto);
            }

            [Test]
            public void ShouldMapElement()
            {
                Assert.AreEqual(Expected.Element.Id, Mapped.Element.Id);
                Assert.AreEqual(Expected.ElementId, Mapped.ElementId);
            }

            [Test]
            public void ShouldMapPlannedStart()
            {
                Assert.AreEqual(Expected.PlannedStart, Mapped.PlannedStart);
            }

            [Test]
            public void ShouldMapPlannedFinish()
            {
                Assert.AreEqual(Expected.PlannedFinish, Mapped.PlannedFinish);
            }

            [Test]
            public void ShouldMapPlannedStartBP()
            {
                Assert.AreEqual(Expected.PlannedStartBP, Mapped.PlannedStartBP);
            }

            [Test]
            public void ShouldMapPlannedFinishBP()
            {
                Assert.AreEqual(Expected.PlannedFinishBP, Mapped.PlannedFinishBP);
            }

            [Test]
            public void ShouldMapRealStart()
            {
                Assert.AreEqual(Expected.RealStart, Mapped.RealStart);
            }

            [Test]
            public void ShouldMapRealFinish()
            {
                Assert.AreEqual(Expected.RealFinish, Mapped.RealFinish);
            }
        }
        
        private class UpdateElementTermData
        {
            public static readonly ElementTerm Existed = new()
            {
                Element = new Element { Id = 123 },
                ElementId = 123,
                PlannedStart = new DateTime(1900, 1, 10),
                PlannedFinish = new DateTime(1900, 2, 10),
                PlannedStartBP = new DateTime(1900, 3, 10),
                PlannedFinishBP = new DateTime(1900, 4, 10),
                RealStart = new DateTime(1900, 5, 10),
                RealFinish = new DateTime(1900, 6, 10)
            };
            public static readonly UpdateElementTermDto Dto = new(
                new DateTime(2021, 1, 10),
                new DateTime(2021, 2, 10),
                new DateTime(2021, 3, 10),
                new DateTime(2021, 4, 10),
                new DateTime(2021, 5, 10),
                new DateTime(2021, 6, 10)
            );
            public static readonly ElementTerm Expected = new()
            {
                Element = new Element { Id = 123 },
                ElementId = 123,
                PlannedStart = new DateTime(2021, 1, 10),
                PlannedFinish = new DateTime(2021, 2, 10),
                PlannedStartBP = new DateTime(2021, 3, 10),
                PlannedFinishBP = new DateTime(2021, 4, 10),
                RealStart = new DateTime(2021, 5, 10),
                RealFinish = new DateTime(2021, 6, 10)
            };

            public static readonly ElementTerm Existed2 = Existed;
            public static readonly UpdateElementTermDto DtoWithNulls = new(
                null,
                null,
                null,
                null,
                null,
                null
            );

            public static readonly ElementTerm Expected2 = Existed2;

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed, Dto, Expected);
                    yield return new TestFixtureData(Existed2, DtoWithNulls, Expected2);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateElementTermData), nameof(UpdateElementTermData.Data))]
        class TestUpdateElementTermDto:ElementTermTest
        {
            public UpdateElementTermDto Dto;
            public ElementTerm Existed;
            public ElementTerm Expected;
            public TestUpdateElementTermDto(ElementTerm existed,UpdateElementTermDto dto, ElementTerm expected)
            {
                Existed = existed;
                Expected = expected;
                Dto = dto;
            }

            [OneTimeSetUp]
            public void CreateData()
            {
                Existed = Mapper.Map(Dto, Existed);
            }
            
            [Test]
            public void ShouldMapElement()
            {
                Assert.AreEqual(Expected.Element.Id, Existed.Element.Id);
                Assert.AreEqual(Expected.ElementId, Existed.ElementId);
            }

            [Test]
            public void ShouldMapPlannedStart()
            {
                Assert.AreEqual(Expected.PlannedStart, Existed.PlannedStart);
            }

            [Test]
            public void ShouldMapPlannedFinish()
            {
                Assert.AreEqual(Expected.PlannedFinish, Existed.PlannedFinish);
            }

            [Test]
            public void ShouldMapPlannedStartBP()
            {
                Assert.AreEqual(Expected.PlannedStartBP, Existed.PlannedStartBP);
            }

            [Test]
            public void ShouldMapPlannedFinishBP()
            {
                Assert.AreEqual(Expected.PlannedFinishBP, Existed.PlannedFinishBP);
            }

            [Test]
            public void ShouldMapRealStart()
            {
                Assert.AreEqual(Expected.RealStart, Existed.RealStart);
            }

            [Test]
            public void ShouldMapRealFinish()
            {
                Assert.AreEqual(Expected.RealFinish, Existed.RealFinish);
            }
        }
    }
}