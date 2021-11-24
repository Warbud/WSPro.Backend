using System;
using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class ElementStatusTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateElementStatusData
        {
            public static readonly CreateElementStatusDto Dto = new(new DateTime(2021, 10, 10),
                StatusEnum.Finished, new Entity(10), new Entity(20), new Entity(30));

            public static readonly ElementStatus ExpectedEntity = new()
            {
                Date = new DateTime(2021, 10, 10),
                Status = StatusEnum.Finished,
                Element = new Element { Id = 10 },
                SetBy = new User { Id = 20 },
                Project = new Project { Id = 30 }
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(ExpectedEntity, Dto); }
            }
        }

        [TestFixtureSource(typeof(CreateElementStatusData), nameof(CreateElementStatusData.Data))]
        private class TestCreateElementStatusDto : ElementStatusTest
        {
            public CreateElementStatusDto Dto;
            public readonly ElementStatus Expected;
            public ElementStatus Mapped;

            public TestCreateElementStatusDto(ElementStatus expected, CreateElementStatusDto dto)
            {
                Expected = expected;
                Dto = dto;

                
            }
            [OneTimeSetUp]
            public void CreateData()
            {
                Mapped = Mapper.Map<ElementStatus>(Dto);
            }

            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Mapped.Date);
            }

            [Test]
            public void ShouldMapStatus()
            {
                Assert.AreEqual(Expected.Status, Mapped.Status);
            }

            [Test]
            public void ShouldMapElement()
            {
                Assert.AreEqual(Expected.Element?.Id, Mapped.Element?.Id);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.SetBy?.Id, Mapped.SetBy?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Mapped.Project?.Id);
            }
        }

        private class UpdateElementStatusData
        {
            public static readonly ElementStatus Existed = new()
            {
                Id = 123,
                Date = new DateTime(2021, 10, 10),
                Status = StatusEnum.Finished,
                Element = new Element { Id = 10 },
                SetBy = new User { Id = 20 },
                Project = new Project { Id = 30 }
            };

            public static readonly UpdateElementStatusDto DtoWithNulls = new(null, null, null, null, null);
            public static readonly ElementStatus Expected = Existed;


            public static readonly ElementStatus Existed2 = Existed;

            public static readonly UpdateElementStatusDto DtoWithValues = new(new DateTime(2021, 12, 1),
                StatusEnum.InProgress, new Entity(30), new Entity(100), new Entity(21));

            public static readonly ElementStatus Expected2 = new()
            {
                Id = 123,
                Date = new DateTime(2021, 12, 1),
                Status = StatusEnum.InProgress,
                Element = new Element { Id = 30 },
                SetBy = new User { Id = 100 },
                Project = new Project { Id = 21 }
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Expected, DtoWithNulls, Existed);
                    yield return new TestFixtureData(Expected2, DtoWithValues, Existed2);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateElementStatusData), nameof(UpdateElementStatusData.Data))]
        private class TestUpdateElementStatusDto : ElementStatusTest
        {
            public ElementStatus Expected;
            public UpdateElementStatusDto Dto;
            public ElementStatus Existed;

            public TestUpdateElementStatusDto(ElementStatus expected, UpdateElementStatusDto dto, ElementStatus existed)
            {
                Expected = expected;
                Dto = dto;
                Existed = existed;
            }

            [OneTimeSetUp]
            public void Start()
            {
                Existed = Mapper.Map(Dto, Existed);
            }

            [Test]
            public void ShouldMapId()
            {
                Assert.AreEqual(Expected.Id,Existed.Id);
            }
            
            [Test]
            public void ShouldMapDate()
            {
                Assert.AreEqual(Expected.Date, Existed.Date);
            }

            [Test]
            public void ShouldMapStatus()
            {
                Assert.AreEqual(Expected.Status, Existed.Status);
            }

            [Test]
            public void ShouldMapElement()
            {
                Assert.AreEqual(Expected.Element?.Id, Existed.Element?.Id);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.AreEqual(Expected.SetBy?.Id, Existed.SetBy?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Existed.Project?.Id);
            }
        }
    }
}