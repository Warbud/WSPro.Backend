using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class GroupTermTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        private class CreateData
        {
            public static readonly CreateGroupTermDto Dto = new(
                VerticalEnum.H,
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new Entity(10),
                new Entity(20),
                new Entity(30),
                new[] { new Entity(50), new Entity(51), new Entity(52) }
            );

            public static readonly GroupTerm Expected = new()
            {
                Vertical = VerticalEnum.H,
                PlannedStart = new DateTime(2021, 10, 10),
                PlannedFinish = new DateTime(2021, 10, 10),
                PlannedStartBP = new DateTime(2021, 10, 10),
                PlannedFinishBP = new DateTime(2021, 10, 10),
                RealStart = new DateTime(2021, 10, 10),
                RealFinish = new DateTime(2021, 10, 10),
                Crane = new Crane { Id = 10 },
                Level = new Level { Id = 20 },
                Project = new Project { Id = 30 },
                Terms = new List<ElementTerm>
                    { new() { ElementId = 50 }, new() { ElementId = 51 }, new() { ElementId = 52 } }
            };

            public static IEnumerable Data
            {
                get { yield return new TestFixtureData(Dto, Expected); }
            }
        }

        [TestFixtureSource(typeof(CreateData), nameof(CreateData.Data))]
        private class TestCreateGroupTermDto : GroupTermTest
        {
            public TestCreateGroupTermDto(CreateGroupTermDto dto, GroupTerm expected)
            {
                Dto = dto;
                Expected = expected;
            }

            public CreateGroupTermDto Dto { get; }
            public GroupTerm Expected { get; }
            public GroupTerm Mapped { get; set; }

            [OneTimeSetUp]
            public void create()
            {
                Mapped = Mapper.Map<GroupTerm>(Dto);
            }

            [Test]
            public void ShouldMapVertical()
            {
                Assert.AreEqual(Expected.Vertical, Mapped.Vertical);
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

            [Test]
            public void ShouldMapCrane()
            {
                Assert.AreEqual(Expected.Crane?.Id, Mapped.Crane?.Id);
            }

            [Test]
            public void ShouldMapLevel()
            {
                Assert.AreEqual(Expected.Level?.Id, Mapped.Level?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Mapped.Project?.Id);
            }

            [Test]
            public void ShouldMapTerms()
            {
                Assert.AreEqual(Expected.Terms.Count, Mapped.Terms.Count);
                for (var i = 0; i < Expected.Terms.Count; i++)
                {
                    var expected = Expected.Terms.ToList()[i];
                    var mapped = Mapped.Terms.ToList()[i];

                    Assert.AreEqual(expected.ElementId, mapped.ElementId);
                }
            }
        }

        private class UpdateData
        {
            public static readonly GroupTerm Existed = new()
            {
                Id = 100,
                Vertical = VerticalEnum.V,
                PlannedStart = new DateTime(1900, 10, 10),
                PlannedFinish = new DateTime(1900, 10, 10),
                PlannedStartBP = new DateTime(1900, 10, 10),
                PlannedFinishBP = new DateTime(1900, 10, 10),
                RealStart = new DateTime(1900, 10, 10),
                RealFinish = new DateTime(1900, 10, 10),
                Crane = new Crane { Id = 11 },
                Level = new Level { Id = 21 },
                Project = new Project { Id = 31 },
                Terms = new List<ElementTerm>
                    { new() { ElementId = 41 }, new() { ElementId = 42 }, new() { ElementId = 43 } }
            };

            public static readonly UpdateGroupTermDto NullishDto = new(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );

            public static readonly GroupTerm Expected = Existed;


            public static readonly GroupTerm Existed2 = Existed;

            public static readonly UpdateGroupTermDto FullDto = new(
                VerticalEnum.H,
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new DateTime(2021, 10, 10),
                new Entity(10),
                new Entity(20),
                new Entity(30),
                new[] { new Entity(50), new Entity(51), new Entity(52) }
            );

            public static readonly GroupTerm Expected2 = new()
            {
                Id = 100,
                Vertical = VerticalEnum.H,
                PlannedStart = new DateTime(2021, 10, 10),
                PlannedFinish = new DateTime(2021, 10, 10),
                PlannedStartBP = new DateTime(2021, 10, 10),
                PlannedFinishBP = new DateTime(2021, 10, 10),
                RealStart = new DateTime(2021, 10, 10),
                RealFinish = new DateTime(2021, 10, 10),
                Crane = new Crane { Id = 10 },
                Level = new Level { Id = 20 },
                Project = new Project { Id = 30 },
                Terms = new List<ElementTerm>
                    { new() { ElementId = 50 }, new() { ElementId = 51 }, new() { ElementId = 52 } }
            };

            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(Existed, NullishDto, Expected);
                    yield return new TestFixtureData(Existed2, FullDto, Expected2);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateData), nameof(UpdateData.Data))]
        private class TestUpdateGroupTermDto : GroupTermTest
        {
            public TestUpdateGroupTermDto(GroupTerm existed,
                UpdateGroupTermDto dto,
                GroupTerm expected)
            {
                Existed = existed;
                Dto = dto;
                Expected = expected;
            }

            public GroupTerm Existed { get; }
            public UpdateGroupTermDto Dto { get; }
            public GroupTerm Expected { get; }

            [OneTimeSetUp]
            public void create()
            {
                Mapper.Map(Dto, Existed);
            }
            
            [Test]
            public void ShouldMapId()
            {
                Assert.AreEqual(Expected.Id, Existed.Id);
            }
            
            [Test]
            public void ShouldMapVertical()
            {
                Assert.AreEqual(Expected.Vertical, Existed.Vertical);
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

            [Test]
            public void ShouldMapCrane()
            {
                Assert.AreEqual(Expected.Crane?.Id, Existed.Crane?.Id);
            }

            [Test]
            public void ShouldMapLevel()
            {
                Assert.AreEqual(Expected.Level?.Id, Existed.Level?.Id);
            }

            [Test]
            public void ShouldMapProject()
            {
                Assert.AreEqual(Expected.Project?.Id, Existed.Project?.Id);
            }

            [Test]
            public void ShouldMapTerms()
            {
                Assert.AreEqual(Expected.Terms.Count, Existed.Terms.Count);
                for (var i = 0; i < Expected.Terms.Count; i++)
                {
                    var expected = Expected.Terms.ToList()[i];
                    var existed = Existed.Terms.ToList()[i];

                    Assert.AreEqual(expected.ElementId, existed.ElementId);
                }
            }
            
        }
    }
}