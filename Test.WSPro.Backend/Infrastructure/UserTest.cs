using System.Linq;
using NUnit.Framework;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.Infrastructure
{
    public class UserTest
    {
        
        /// <summary>
        /// test sprawdzający przypadek gdy tworzony jest user z podstawowymi parametrami
        /// </summary>
        [Test]
        public void AddUserWithBaseData()
        {
            var user = new User("test email", "test password");
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Users.Add(user);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var users = context.Users.ToList();

                Assert.AreEqual(users.Count, 1);
                Assert.AreEqual(users[0].Email, "test email");
                Assert.AreEqual(users[0].Password, "test password");
                Assert.AreEqual(users[0].Name, null);
                Assert.AreEqual(users[0].Provider, AuthProviderEnum.Origin);
                
                context.Database.EnsureDeleted();
            }


        }

        /// <summary>
        /// test sprawdzający przypadek gdy utworzony jest user z opcjonalną nazwą.
        /// Sprawdza błędne scenariusze: null, pusty string, string będący białymi znakami
        /// oraz pozytywny scenariusz: dowolny string.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedValue"></param>
        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase("   ", null)]
        [TestCase("test name", "test name")]
        public void AddUserWithOptionalNameParameter(string name,string expectedValue)
        {
            var user = new User("test email", "test password",name);
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Users.Add(user);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var users = context.Users.ToList();

                Assert.AreEqual(users.Count, 1);
                Assert.AreEqual(users[0].Email, "test email");
                Assert.AreEqual(users[0].Password, "test password");
                Assert.AreEqual(users[0].Name, expectedValue);
                Assert.AreEqual(users[0].Provider, AuthProviderEnum.Origin);
                
                context.Database.EnsureDeleted();
            }
        }

        /// <summary>
        /// test sprawdzający przypadek gdy utworzony jest user z opcjonalnym parametrem <i>provider</i>.
        /// Sprawdzany jest scenariusz dodania każdej z wartości <i>AuthProviderEnum</i> 
        /// </summary>
        /// <param name="provider"></param>
        [TestCase(AuthProviderEnum.Origin)]
        [TestCase(AuthProviderEnum.ActiveDirectory)]
        public void AddUserWithOptionalProvider(AuthProviderEnum provider)
        {
            var user = new User("test email", "test password","name", provider);
            using (var context = new WSProTestContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Users.Add(user);
                context.SaveChanges();
            }
            
            using (var context = new WSProTestContext())
            {
                var users = context.Users.ToList();

                Assert.AreEqual(users.Count, 1);
                Assert.AreEqual(users[0].Email, "test email");
                Assert.AreEqual(users[0].Password, "test password");
                Assert.AreEqual(users[0].Name, "name");
                Assert.AreEqual(users[0].Provider, provider);
                
                context.Database.EnsureDeleted();
            }
        }
    }
}