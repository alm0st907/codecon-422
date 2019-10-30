using NUnit.Framework;
using api.Controllers;
using Newtonsoft.Json;
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
        public void GetAllTasks()
        {
            // Create test object
            JObject retTasks = new JObject();
            JArray testAgainstTasks = new JArray();
            List<Task> expectedTasks = new List<Task>();
            retTasks = ControllerUnderTest.GetAllTasks("Codecon");

            // Ensure that something was returned
            Assert.IsNotNull(retTasks);

            Task testTask1 = new Task
            {
                projectName = "Codecon",
                escalationVal = 1,
                assignee = "Mike",
                taskName = "Do The First Thing",
                description = "The thing that needs to be done first will be done first"
            };

            Task testTask2 = new Task
            {
                projectName = "Codecon",
                escalationVal = 2,
                assignee = "Jeff",
                taskName = "Do The Second Thing",
                description = "The thing that needs to be done second will be done second" 
            };

            Task testTask3 = new Task
            {
                projectName = "Codecon",
                escalationVal = 3,
                assignee = "Slater",
                taskName = "Do The Third Thing",
                description = "The thing that needs to be done third will be done third"
            };

            Task testTask4 = new Task
            {
                projectName = "Codecon",
                escalationVal = 4,
                assignee = "Garrett",
                taskName = "Do The Right Thing",
                description = "There is reddit karma in it for you"
            };

            // 1 4 2 3
            expectedTasks.Add(testTask1);
            expectedTasks.Add(testTask4);
            expectedTasks.Add(testTask2);
            expectedTasks.Add(testTask3);

            testAgainstTasks = JArray.FromObject(expectedTasks);
            JObject finalTestJObj = new JObject();
            finalTestJObj.Add("items", testAgainstTasks);

            Assert.AreEqual(finalTestJObj, retTasks);
        }

    }
}