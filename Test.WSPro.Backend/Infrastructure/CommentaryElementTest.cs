using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Domain.Model;

namespace Test.WSPro.Backend.Infrastructure
{
    [TestFixture]
    public class CommentaryElementTest : _setup
    {
        private Element _element;
        private Project _project;
        private User _user;
        private CommentaryElement _commentaryElement1;
        private CommentaryElement _commentaryElement2;
        private List<CommentaryElement> _commentaryElements;

        public override void Init()
        {
            using (var ctx = new WSProTestContext().Context)
            {
                _project = new Project { Name = "123" };
                _element = new Element { RevitId = 123, Project = _project };
                _user = new User { Email = "test_email", Name = "test", Password = "asd" };
                _commentaryElement1 = new CommentaryElement
                {
                    Content = "cos tam popsute",
                    Element = _element,
                    WriteBy = _user
                };
                _commentaryElement2 = new CommentaryElement
                {
                    Content = "cos znow nie tak",
                    Element = _element,
                    WriteBy = _user
                };
                ctx.AddRange(_project, _element, _user, _commentaryElement1, _commentaryElement2);
                ctx.SaveChanges();
            }

            using (var ctx = new WSProTestContext().Context)
            {
                _commentaryElements = ctx.CommentaryElements.ToList();
            }
        }

        [Test]
        public void test_added_comments_count()
        {
            Assert.AreEqual(2, _commentaryElements.Count);
        }

        [Test]
        public void test_Id_attribute()
        {
            Assert.NotNull(_commentaryElement1.Id);
            Assert.NotNull(_commentaryElement2.Id);
        }

        [Test]
        public void test_Element_reference()
        {
            Assert.AreEqual(_element.Id, _commentaryElement1.ElementId);
            Assert.AreEqual(_element, _commentaryElement1.Element);
            Assert.AreEqual(_element.Id, _commentaryElement2.ElementId);
            Assert.AreEqual(_element, _commentaryElement2.Element);
        }

        [Test]
        public void test_Comment_on_Element_reference()
        {
            Assert.AreEqual(2, _element.Comments.Count);
            Assert.That(_element.Comments.Contains(_commentaryElement1));
            Assert.That(_element.Comments.Contains(_commentaryElement2));
        }

        [Test]
        public void test_User_reference()
        {
            Assert.AreEqual(_user.Id, _commentaryElement1.UserId);
            Assert.AreEqual(_user, _commentaryElement1.WriteBy);
            Assert.AreEqual(_user.Id, _commentaryElement2.UserId);
            Assert.AreEqual(_user, _commentaryElement2.WriteBy);
        }

        [Test]
        public void test_Content_attribute()
        {
            Assert.AreEqual("cos tam popsute", _commentaryElement1.Content);
            Assert.AreEqual("cos znow nie tak", _commentaryElement2.Content);
        }
    }
}