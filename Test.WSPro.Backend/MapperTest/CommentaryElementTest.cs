using System.Collections;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class CommentaryElementTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        class TestCreateCommentaryElementDto:CommentaryElementTest
        {
            public CreateCommentaryElementDto Dto;
            public CommentaryElement Entity;
            
            [SetUp]
            public void CreateData()
            {
                Dto = new CreateCommentaryElementDto(new Entity(123), new Entity(321), "content");
                Entity = Mapper.Map<CommentaryElement>(Dto);
            }

            [Test]
            public void ShouldMapElement()
            {
                Assert.NotNull(Entity.Element);
                Assert.AreEqual(123,Entity.Element.Id);
            }

            [Test]
            public void ShouldMapUser()
            {
                Assert.NotNull(Entity.WriteBy);
                Assert.AreEqual(321,Entity.WriteBy.Id);
            }

            [Test]
            public void ShouldMapContent()
            {
                Assert.AreEqual("content",Entity.Content);
            }
        }
        
        private class UpdateCommentaryElementDtoStorage
        {
            public static CommentaryElement ExistedEntity = new ()
            {
                Content = "test content",
                Id = 1000,Element = new Element(){Id = 100},WriteBy = new User(){Id = 20}
            };

            public static CommentaryElement ExpectedEntity = new()
            {
                Content = "new content",
                Id = 1000, Element = new Element() { Id = 123 }, WriteBy = new User() { Id = 321 }
            };

            public static UpdateCommentaryElementDto FullDto =
                new UpdateCommentaryElementDto(new Entity(123), new Entity(321), "new content");

            public static UpdateCommentaryElementDto NullishDto = new UpdateCommentaryElementDto(null, null, null);
            
            public static IEnumerable Data
            {
                get
                {
                    yield return new TestFixtureData(ExistedEntity, FullDto,ExpectedEntity);
                    yield return new TestFixtureData(ExistedEntity, NullishDto,ExistedEntity);
                }
            }
        }

        [TestFixtureSource(typeof(UpdateCommentaryElementDtoStorage), nameof(UpdateCommentaryElementDtoStorage.Data))]
        class TestUpdateCommentaryElementDto:CommentaryElementTest
        {
            public UpdateCommentaryElementDto Dto;
            public CommentaryElement ExistingEntity;
            public CommentaryElement ExpectedEntity;

            public TestUpdateCommentaryElementDto(CommentaryElement existingElement,UpdateCommentaryElementDto dto, CommentaryElement expectedElement)
            {
                ExistingEntity = existingElement;
                Dto = dto;
                ExpectedEntity = expectedElement;
            }
            
            
            [OneTimeSetUp]
            public void CreateData()
            {
                Mapper.Map(Dto,ExistingEntity);
            }
            

            [Test]
            public void ShouldMapElement()
            {
                Assert.AreEqual(ExpectedEntity.Element.Id,ExistingEntity.Element.Id);
            }

            [Test]
            public void ShouldMapUser()
            {
               
                Assert.AreEqual(ExpectedEntity.WriteBy.Id,ExistingEntity.WriteBy.Id);
            }

            [Test]
            public void ShouldMapContent()
            {
                Assert.AreEqual(ExpectedEntity.Content,ExistingEntity.Content);
            }
            
        }
        
        
    }
}