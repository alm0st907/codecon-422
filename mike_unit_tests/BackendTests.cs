using api;
using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;

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
            // Create data to compare results against
            DataTable testProjectTable = new DataTable();
            DataTable testUserTable = new DataTable();
            DataTable testTaskTable = new DataTable();

            using (SqlConnection serverConnection = new SqlConnection(EngineUnderTest.conString))
            {
                string query = "select * from Project";
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    // create data adapter to read table into DataTable object
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(testProjectTable);
                }
                query = "select * from [User]";
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(testUserTable);
                }

                query = "select * from Task";
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(testTaskTable);
                }
            }

            // Call function to populate tables
            EngineUnderTest.RetrieveTables();

            Assert.AreEqual(EngineUnderTest.ProjectTable, testProjectTable);
            Assert.AreEqual(EngineUnderTest.UserTable, testUserTable);
            Assert.AreEqual(EngineUnderTest.TaskTable, testTaskTable);
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
        public void TestExecuteSqlCommand()
        {

        }
    }
}