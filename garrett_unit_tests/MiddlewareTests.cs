using NUnit.Framework;
using api.Controllers;
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
        public void testGetProject()
        {
            var testReturn = ControllerUnderTest.GetProject("Codecon");
            JObject expectedReturn = new JObject
            {
                {"projectName","Codecon" },
                {"defconScale", 4 },
             {"dueDate", "9/19/2019 12:00:00 AM" }
            };

            Assert.IsNotNull(testReturn);

            //Jobjects are weird for unit test
            //date time Jvalue doesnt test well, so convert to string
            //test areequal on string
            //Assert.AreEqual(expectedReturn, testReturn);

            Assert.AreEqual(testReturn["projectName"], expectedReturn["projectName"]);

            Assert.AreEqual(testReturn["defconScale"], expectedReturn["defconScale"]);

            Assert.AreEqual(testReturn["dueDate"].ToString(), expectedReturn["dueDate"].ToString());
        }

    }
}