using NUnit.Framework;
using api;
using System;

namespace Tests
{
    public class BackendTests
    {
        QueryEngine QueryEngineUnderTest;

        [SetUp]
        public void Setup()
        {
            QueryEngineUnderTest = new QueryEngine();
            QueryEngineUnderTest.ConnectToServer();
        }

        [Test]
        public void TestGetProject()
        {
            var testReturn = QueryEngineUnderTest.GetProj("Codecon");
            DateTime expectedDate = DateTime.Parse("9/19/2019 12:00:00 AM");
            Project expectedReturn = new Project("Codecon", 4, expectedDate);


            Assert.IsNotNull(testReturn);

            //Jobjects are weird for unit test
            //date time Jvalue doesnt test well, so convert to string


            Assert.AreEqual(testReturn.projectName, expectedReturn.projectName);

            Assert.AreEqual(testReturn.defconScale, expectedReturn.defconScale);

            Assert.AreEqual(testReturn.dueDate.ToString(), expectedReturn.dueDate.ToString());
        }

        [Test]
        public void TestGetTask()
        {
            var testReturn = QueryEngineUnderTest.GetTask("Do The Second Thing");

            Task expectedReturn = new Task("Codecon", 2, "Jeff", "Do the Second Thing", "The thing that needs to be done second will be done second");

            //Check that the test return is not nulll
            //then check each value to see if it is what it should be
            Assert.IsNotNull(testReturn);

            Assert.AreEqual(testReturn.projectName, expectedReturn.projectName);

            Assert.AreEqual(testReturn.escalationVal, expectedReturn.escalationVal);

            Assert.AreEqual(testReturn.assignee, expectedReturn.assignee);

            Assert.AreEqual(testReturn.description, expectedReturn.description);
        }

        [Test]
        public void TestGetUser()
        {
            var testReturn = QueryEngineUnderTest.GetUser("Jeff", "enieminiemoe");

            User expectedReturn = new User("Jeff", "jeff@hotmail.com", "enieminiemoe", 1);// ('Jeff', 'jeff@hotmail.com', 'enieminiemoe', 1);
            Assert.IsNotNull(testReturn);

            Assert.AreEqual(testReturn.username, expectedReturn.username);
            Assert.AreEqual(testReturn.email, expectedReturn.email);
            Assert.AreEqual(testReturn.passWord, expectedReturn.passWord);
            Assert.AreEqual(testReturn.id, expectedReturn.id);
        }

        [Test]
        public void TestAddUser()
        {
            User testUser = new User("tesitus", "Test@Test.Test", "test", 0);
            QueryEngineUnderTest.AddUser(testUser);

            var testReturn = QueryEngineUnderTest.GetUser("tesitus", "test");

            //Ensure All values are the same as testUser
            Assert.IsNotNull(testReturn);
            Assert.AreEqual(testReturn.username, testUser.username);
            Assert.AreEqual(testReturn.email, testUser.email);
            Assert.AreEqual(testReturn.passWord, testUser.passWord);

            //remove dummy user
            //QueryEngineUnderTest.RemoveUser("tesitus");
            QueryEngineUnderTest.ExecuteSQLCommand("Delete from [User] where username='tesitus'");
        }

        [Test]
        public void TestRemoveUser()
        {
            QueryEngineUnderTest.ExecuteSQLCommand("Delete from [User] where username='tesitus2'");
            //User testUser = new User("tesitus2", "Test2@Test.Test", "test", 0); //Create the test user
            //add the test user, then attempt to remove the user
            QueryEngineUnderTest.ExecuteSQLCommand("insert into [user](username, email, password, id) values('tesitus2', 'Test2@Test.Test', 'test', 7)");
            QueryEngineUnderTest.RemoveUser("tesitus2");
            
            //confirm the test user was removed, by checking if GetUser returns null
            Assert.IsNull(QueryEngineUnderTest.GetUser("tesitus2", "test"));
        }
    }
}
