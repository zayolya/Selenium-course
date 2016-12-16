using first_project.app;
using NUnit.Framework;

namespace first_project
{
    [TestFixture]
    public class TestBase
    {
        public Application app;

        [SetUp]
        public void Start()
        {
            app = new Application();
        }

        [TearDown]
        public void Stop()
        {
            app.Quit();
            app = null;
        }
    }
}
