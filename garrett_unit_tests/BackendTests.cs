using NUnit.Framework;
using api;
using System.Collections.Generic;

namespace Tests
{
    public class BackendTests
    {
        public QueryEngine EngineUnderTest;
        [SetUp]
        public void Setup()
        {
            EngineUnderTest = new QueryEngine();
            //this is typically done in the middleware, must do here
            EngineUnderTest.ConnectToServer();

        }

        [Test]
        public void GetTasks()
        {
            List<Task> taskList = new List<Task>();
            
            //expected tasks within list
            Task t1 = new Task("Codecon",1,"Mike","Do The First Thing","The thing that needs to be done first will be done first");
            Task t2 = new Task("Codecon", 2, "Jeff", "Do The Second Thing", "The thing that needs to be done second will be done second");
            Task t3 = new Task("Codecon", 3, "Slater", "Do The Third Thing", "The thing that needs to be done third will be done third");
            Task t4 = new Task("Codecon", 4, "Garrett", "Do The Right Thing", "There is reddit karma in it for you");
            //create the expected list
            taskList.Add(t1); taskList.Add(t2); taskList.Add(t3); taskList.Add(t4);

            List<Task> testReturn = EngineUnderTest.GetTasks("Codecon");
            //prepare for comparison
            HashSet<Task> input = new HashSet<Task>(taskList);
            HashSet<Task> output = new HashSet<Task>(testReturn);

            //need to implement comparison on our custom type
            //to string is the settling point
            Assert.AreEqual(input.ToString(), output.ToString());
        }

        //this test will add a task to the thing, must remove later
        [Test]
        public void AddTask()
        {
            Task testTask = new Task("Codecon", 1, "Garrett", "Test", "Test");
            EngineUnderTest.AddTask(testTask);
            Task returnTask = EngineUnderTest.GetTask("Test");

            Assert.AreEqual(testTask.ToString(), returnTask.ToString());
            //removing the task we just added, risky but works for now
            EngineUnderTest.ExecuteSQLCommand("Delete from Task where taskName='Test'");
            
        }

        [Test]
        public void RemoveTask()
        {
            //ensure known db state before test
            EngineUnderTest.ExecuteSQLCommand("Delete from Task where taskName='Test'");

            //use sql to create task
            EngineUnderTest.ExecuteSQLCommand("insert into task(projectName, escalationValue, assignee, taskName, description) values('Codecon', 5, 'Garrett', 'test', 'test')");

            Assert.AreEqual(EngineUnderTest.RemoveTask("test"),0);
            var test = EngineUnderTest.GetTask("test");

            //assert that task is no longer present
            Assert.IsNull(EngineUnderTest.GetTask("test"));
        }
    }
}