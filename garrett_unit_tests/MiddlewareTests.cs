using NUnit.Framework;
using api.Controllers;

namespace Tests
{
    public class MiddlewareTests
    {
        ManageProjectController ControllerUnderTest;
        [SetUp]
        public void Setup()
        {
            ControllerUnderTest = new ManageProjectController();
        }

        [Test]
        public void testGetProject()
        {
            Assert.AreEqual(ControllerUnderTest.Index(), "oops! something went wrong!\n");
        }

        [Test]
        public void testGetUser()
        {
             
        }

        [Test]
        public void testGetTask()
        {
             
        }

        [Test]
        public void testGetAllTasks()
        {
             
        }

        [Test]
        public void testCreateUser()
        {
             
        }

        [Test]
        public void testCreateProject()
        {
             
        }

        [Test]
        public void testCreateTask()
        {
             
        }

    }
}