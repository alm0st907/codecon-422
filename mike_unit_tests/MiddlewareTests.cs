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

        /*
        public JObject GetAllTasks(string projectName)
        {
            List<Task> retTaskList = new List<Task>();
            JArray retJList = new JArray();
            retTaskList = engine.GetTasks(projectName);

            retJList = JArray.FromObject(retTaskList);
            JObject finalRet = new JObject();
            finalRet.Add("items", retJList);
            return finalRet;
        }
             */

        [Test]
        public void GetAllTasks()
        {

        }

    }
}