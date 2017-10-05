using NUnit;
using NUnit.Framework;

namespace AG.TweeterApp
{
    [TestFixture]
    public class TweetManagerTests
    {
        [Test]
        public void UsersInitialisedTest()
        {
            TweetManager manager = new TweetManager(null,null);
            Assert.IsInstanceOf<IUserRepository>(manager.UserRepository);
        }
    }
}