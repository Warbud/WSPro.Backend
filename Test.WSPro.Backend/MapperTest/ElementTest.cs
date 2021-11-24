using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class ElementTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixtureSource(typeof(CreateElementDtoDataStorage), nameof(CreateElementDtoDataStorage.FixtureParams))]
        private class TestCreateElementDto : ElementTest
        {
            private readonly CreateElementDto Dto;
            private readonly Element ExpectedEntity;
            private Element MapedEntity;

            public TestCreateElementDto(CreateElementDto dto, Element expectedElement)
            {
                Dto = dto;
                ExpectedEntity = expectedElement;
            }

            [OneTimeSetUp]
            public void CreateData()
            {
                MapedEntity = Mapper.Map<Element>(Dto);
            }

            [Test]
            public void ShouldMapArea()
            {
                Assert.AreEqual(ExpectedEntity.Area, MapedEntity.Area);
            }

            [Test]
            public void ShouldMapVolume()
            {
                Assert.AreEqual(ExpectedEntity.Volume, MapedEntity.Volume);
            }

            [Test]
            public void ShouldMapRunningMetre()
            {
                Assert.AreEqual(ExpectedEntity.RunningMetre, MapedEntity.RunningMetre);
            }

            [Test]
            public void ShouldMapRevitId()
            {
                Assert.AreEqual(ExpectedEntity.RevitId, MapedEntity.RevitId);
            }

            [Test]
            public void ShouldMapVertical()
            {
                Assert.AreEqual(ExpectedEntity.Vertical, MapedEntity.Vertical);
            }

            [Test]
            public void ShouldMapRealisationMode()
            {
                Assert.AreEqual(ExpectedEntity.RealisationMode, MapedEntity.RealisationMode);
            }

            [Test]
            public void ShouldMapRotationDay()
            {
                Assert.AreEqual(ExpectedEntity.RotationDay, MapedEntity.RotationDay);
            }

            [Test]
            public void ShouldMapLevel()
            {
                if (ExpectedEntity.Level is not null)
                    Assert.AreEqual(ExpectedEntity.Level.Id, MapedEntity.Level?.Id);
                else
                    Assert.AreEqual(ExpectedEntity.Level, MapedEntity.Level);
            }

            [Test]
            public void ShouldMapCrane()
            {
                if (ExpectedEntity.Crane is not null)
                    Assert.AreEqual(ExpectedEntity.Crane.Id, MapedEntity.Crane?.Id);
                else
                    Assert.AreEqual(ExpectedEntity.Crane, MapedEntity.Crane);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(ExpectedEntity.Project.Id, MapedEntity.Project?.Id);
            }

            [Test]
            public void ShouldMapDetails()
            {
                Assert.AreEqual(ExpectedEntity.Details, MapedEntity.Details);
            }

            [Test]
            public void ShouldMapIsPrefabricated()
            {
                Assert.AreEqual(ExpectedEntity.IsPrefabricated, MapedEntity.IsPrefabricated);
            }

            [Test]
            public void ShouldMapElementTerm()
            {
                if (ExpectedEntity.ElementTerm is not null)
                    Assert.AreEqual(ExpectedEntity.ElementTerm.ElementId, MapedEntity.ElementTerm?.ElementId);
                else
                    Assert.AreEqual(ExpectedEntity.ElementTerm, MapedEntity.ElementTerm);
            }

            [Test]
            public void ShouldMapBimModel()
            {
                if (ExpectedEntity.BimModel is not null)
                    Assert.AreEqual(ExpectedEntity.BimModel.Id, MapedEntity.BimModel?.Id);
                else
                    Assert.AreEqual(ExpectedEntity.BimModel, MapedEntity.BimModel);
            }
        }

        public class CreateElementDtoDataStorage
        {
            public static CreateElementDto RequiredDto = new(null, null, null,
                123456, null, null, null, null, null,
                new Entity(123), null, false, null);

            public static Element RequiredExpectedEntity = new()
                { RevitId = 123456, Project = new Project { Id = 123 }, IsPrefabricated = false };


            private static readonly CreateElementDto FullDto = new(124.123m, 10.623444m, 590.0123m,
                123123, VerticalEnum.H, "test name", 123, new Entity(10),
                new Entity(2), new Entity(123), "data", false, new Entity(10));

            private static readonly Element FullExpectedEntity = new()
            {
                Area = 124.123m, Volume = 10.623444m, RunningMetre = 590.0123m, RevitId = 123123,
                Vertical = VerticalEnum.H,
                RealisationMode = "test name", RotationDay = 123, Level = new Level { Id = 10 },
                Crane = new Crane { Id = 2 }, Project = new Project { Id = 123 },
                Details = "data", IsPrefabricated = false, BimModel = new BimModel { Id = 10 }
            };

            public static IEnumerable FixtureParams
            {
                get
                {
                    yield return new TestFixtureData(RequiredDto, RequiredExpectedEntity);
                    yield return new TestFixtureData(FullDto, FullExpectedEntity);
                }
            }
        }

        private class UpdateElementDtoDataStorage
        {
            public static Element ExistingElement = new()
            {
                Id = 10,
                Area = 124.123m, Volume = 10.623444m, RunningMetre = 590.0123m, RevitId = 123123,
                Vertical = VerticalEnum.H,
                RealisationMode = "test name", RotationDay = 123, Level = new Level { Id = 10 },
                Crane = new Crane { Id = 2 }, Project = new Project { Id = 123 },
                Details = "data", IsPrefabricated = false, BimModel = new BimModel { Id = 10 }
            };

            public static UpdateElementDto UpdateDto = new(123.123m, 123.123m, 
                345345.234m, 1233321123, VerticalEnum.V, "nowe realisation mode", 
                3123, new Entity(11), new Entity(21), new Entity(321), "new details", 
                true, new Entity(11));

            public static UpdateElementDto UpdateNullDto = new(null, null, null, null,
                null, null, null,null,null,null,null,
                null,null);

            public static Element ExpectedElement = new()
            {
                Id = 10,
                Area = 123.123m, Volume = 123.123m, RunningMetre = 345345.234m, RevitId = 1233321123,
                Vertical = VerticalEnum.V,
                RealisationMode = "nowe realisation mode", RotationDay = 3123, Level = new Level { Id = 11 },
                Crane = new Crane { Id = 21 }, Project = new Project { Id = 321 },
                Details = "new details", IsPrefabricated = true, BimModel = new BimModel { Id = 11 }

            };
            
            public static IEnumerable FixtureParams
            {
                get
                {
                    yield return new TestFixtureData(ExistingElement,UpdateDto, ExpectedElement);
                    yield return new TestFixtureData(ExistingElement,UpdateNullDto, ExistingElement);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateElementDtoDataStorage), nameof(UpdateElementDtoDataStorage.FixtureParams))]
        private class TestUpdateElementDto : ElementTest
        {
             private readonly UpdateElementDto Dto;
            private readonly Element ExpectedEntity;
            private Element ExistingElement;

            public TestUpdateElementDto(Element existingElement,UpdateElementDto dto, Element expectedElement )
            {
                ExistingElement = existingElement;
                Dto = dto;
                ExpectedEntity = expectedElement;
            }

            [OneTimeSetUp]
            public void CreateData()
            {
                 Mapper.Map(Dto,ExistingElement);
            }

            [Test]
            public void ShouldMapArea()
            {
                Assert.AreEqual(ExpectedEntity.Area, ExistingElement.Area);
            }

            [Test]
            public void ShouldMapVolume()
            {
                Assert.AreEqual(ExpectedEntity.Volume, ExistingElement.Volume);
            }

            [Test]
            public void ShouldMapRunningMetre()
            {
                Assert.AreEqual(ExpectedEntity.RunningMetre, ExistingElement.RunningMetre);
            }

            [Test]
            public void ShouldMapRevitId()
            {
                Assert.AreEqual(ExpectedEntity.RevitId, ExistingElement.RevitId);
            }

            [Test]
            public void ShouldMapVertical()
            {
                Assert.AreEqual(ExpectedEntity.Vertical, ExistingElement.Vertical);
            }

            [Test]
            public void ShouldMapRealisationMode()
            {
                Assert.AreEqual(ExpectedEntity.RealisationMode, ExistingElement.RealisationMode);
            }

            [Test]
            public void ShouldMapRotationDay()
            {
                Assert.AreEqual(ExpectedEntity.RotationDay, ExistingElement.RotationDay);
            }

            [Test]
            public void ShouldMapLevel()
            {
                if (ExpectedEntity.Level is not null)
                    Assert.AreEqual(ExpectedEntity.Level.Id, ExistingElement.Level?.Id);
                else
                    Assert.AreEqual(ExpectedEntity.Level, ExistingElement.Level);
            }

            [Test]
            public void ShouldMapCrane()
            {
                if (ExpectedEntity.Crane is not null)
                    Assert.AreEqual(ExpectedEntity.Crane.Id, ExistingElement.Crane?.Id);
                else
                    Assert.AreEqual(ExpectedEntity.Crane, ExistingElement.Crane);
            }

            [Test]
            public void ShouldMapProject()
            {
                
                Assert.AreEqual(ExpectedEntity.Project.Id, ExistingElement.Project?.Id);
            }

            [Test]
            public void ShouldMapDetails()
            {
                Assert.AreEqual(ExpectedEntity.Details, ExistingElement.Details);
            }

            [Test]
            public void ShouldMapIsPrefabricated()
            {
                Assert.AreEqual(ExpectedEntity.IsPrefabricated, ExistingElement.IsPrefabricated);
            }

            [Test]
            public void ShouldMapElementTerm()
            {
                if (ExpectedEntity.ElementTerm is not null)
                    Assert.AreEqual(ExpectedEntity.ElementTerm.ElementId, ExistingElement.ElementTerm?.ElementId);
                else
                    Assert.AreEqual(ExpectedEntity.ElementTerm, ExistingElement.ElementTerm);
            }

            [Test]
            public void ShouldMapBimModel()
            {
                if (ExpectedEntity.BimModel is not null)
                    Assert.AreEqual(ExpectedEntity.BimModel.Id, ExistingElement.BimModel?.Id);
                else
                    Assert.AreEqual(ExpectedEntity.BimModel, ExistingElement.BimModel);
            }
        }
    }
}