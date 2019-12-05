using NUnit.Framework;
using api.Controllers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using api;


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

        //MORE TESTS
        [Test]
        public void testGetProjectDoesNotExist()
        {
            var testReturn = ControllerUnderTest.GetProject("fakeTestistan");

            JObject expectedReturn = new JObject
            {
                {"projectName","Codecon" },
                {"defconScale", 4 },
                {"dueDate", "9/19/2019 12:00:00 AM" }
            };

            Assert.IsNull(testReturn);

        }
        //EVIL LAUGH
        //even more tests
        [Test]
        public void testGetTaskDoesNotExist()
        {
            var testReturn = ControllerUnderTest.GetTask("this does not exist i promise");

            JObject expectedReturn = new JObject {
                {"projectName","Codecon" },
                {"escalationVal",2 },
                {"assignee", "Jeff" },
                {"description", "The thing that needs to be done second will be done second" }
            };

            //Check that the test return is not nulll
            //then check each value to see if it is what it should be
            Assert.IsNull(testReturn);

        }
        //more tests

        //more tests
        [Test]
        public void GetAllTasksProjectDoesNotExist()
        {
            // Create test object
            JObject retTasks = new JObject();
            retTasks = ControllerUnderTest.GetAllTasks("nonexistant");
    
            // Ensure check for null return
            Assert.IsEmpty(retTasks["items"]);
        }
        //look at these tests oh goodness
    }
}