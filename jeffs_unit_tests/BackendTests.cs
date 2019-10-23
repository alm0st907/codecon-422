using NUnit.Framework;
using api;

namespace Tests
{
    public class BackendTests
    {
        QueryEngine QueryEngineUnderTest;

        [SetUp]
        public void Setup()
        {
            QueryEngineUnderTest = new QueryEngine();
        }

        [Test]
        public void TestGetProject()
        {
            var testReturn = QueryEngineUnderTest.GetProj("Codecon");
            DateTime expectedDate = DateTime.ToDate("9/19/2019 12:00:00 AM");
            Project expectedReturn = new Project("Codecon", 5, );
           

            Assert.IsNotNull(testReturn);

            //Jobjects are weird for unit test
            //date time Jvalue doesnt test well, so convert to string
            

            Assert.AreEqual(testReturn, expectedReturn);

            /*Assert.AreEqual(testReturn["defconScale"], expectedReturn["defconScale"]);

            Assert.AreEqual(testReturn["dueDate"].ToString(), expectedReturn["dueDate"].ToString());*/
        }

        [Test]
        public void TestGetTask()
        {
            var testReturn = QueryEngineUnderTest.GetTask("Do The Second Thing");

            Task expectedReturn = new Task ("Codecon",2, "Jeff", "Do the Second Thing", "The thing that needs to be done second will be done second");

            //Check that the test return is not nulll
            //then check each value to see if it is what it should be
            Assert.IsNotNull(testReturn);

            Assert.AreEqual(testReturn, expectedReturn);

            /*Assert.AreEqual(testReturn["escalationValue"], expectedReturn["escalationValue"]);

            Assert.AreEqual(testReturn["assignee"], expectedReturn["assignee"]);

            Assert.AreEqual(testReturn["description"], expectedReturn["description"]);*/
        }

        [Test]
        public void TestGetUser()
        {
            var testReturn = QueryEngineUnderTest.GetUser("Jeff", "enieminiemoe");
            
            User expectedReturn = new User("Jeff", "jeff@hotmail.com", "enieminiemoe", 1);// ('Jeff', 'jeff@hotmail.com', 'enieminiemoe', 1);
            Assert.IsNotNull(testReturn);

            Assert.AreEqual(testReturn, expectedReturn);
        }

        [Test]
        public void TestAddUser()
        {
            Assert.Pass();
        }

        [Test]
        public void TestRemoveUser()
        {
            Assert.Pass();
        }
    }
}