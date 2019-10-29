using NUnit.Framework;

namespace Tests
{
    public class BackendTests
    {
        public QueryEngine EngineUnderTest;

        [SetUp]
        public void Setup()
        {
            EngineUnderTest = new QueryEngine();
            EngineUnderTest.TestConnectToServer();
        }

        [Test]
        public void TestRetrieveTables()
        {

        }

        [Test]
        public void TestSetProjectDefconLevel()
        {
            Assert.Pass();
        }

        [Test]
        public void TestAddProj()
        {

        }

        [Test]
        public void TestRemoveProj()
        {

        }

        [Test]
        public void TestGetAllTasks()
        {

        }

        [Test]
        public void TestExecuteSqlCommand
        {

        }
    }
}