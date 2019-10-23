using NUnit.Framework;
using api.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public void TestGetTask()
        {
            var testReturn = ControllerUnderTest.GetTask("Do The Second Thing");

            JObject expectedReturn = new JObject {
                {"projectName","Codecon" },
                {"escalationVal",2 },
                {"assignee", "Jeff" },
                {"description", "The thing that needs to be done second will be done second" }
            };

            //Check that the test return is not nulll
            //then check each value to see if it is what it should be
            Assert.IsNotNull(testReturn);

            Assert.AreEqual(testReturn["projectName"], expectedReturn["projectName"]);

            Assert.AreEqual(testReturn["escalationValue"], expectedReturn["escalationValue"]);

            Assert.AreEqual(testReturn["assignee"], expectedReturn["assignee"]);

            Assert.AreEqual(testReturn["description"], expectedReturn["description"]);
        }

        [Test]
        public void TestCreateProject()
        {

            Assert.Pass();
        }

        [Test]
        public void TestCreateTask()
        {
            Assert.Pass();
        }
    }
}