using NUnit.Framework;
using api.Controllers;

namespace Tests
{
    public class MiddlewareTests
    {
        [SetUp]
        public void Setup()
        {
            ManageProjectController controllerUnderTest = new ManageProjectController();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void testGetProject()
        {
            Assert.Pass();
        }

        [Test]
        public void testCreateProject()
        {
            Assert.Fail();
        }

        [Test]
        public void testCreateTask()
        {
            Assert.Pass();
        }
    }
}