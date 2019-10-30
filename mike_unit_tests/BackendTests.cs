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
            EngineUnderTest.ConnectToServer();
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


            // Asserts must be done item by item, as DataTable object cannot be compared
            Assert.AreEqual(testProjectTable.Rows.Count, EngineUnderTest.ProjectTable.Rows.Count);  // Ensure there are an equal amount of rows in both tables
            for (int i = 0; i < testProjectTable.Rows.Count; i++)   // iterate through rows
            {
                for (int j = 0; j < testProjectTable.Rows[i].ItemArray.Length; j++) // iterate through data points in rows
                {
                    Assert.AreEqual(testProjectTable.Rows[i].ItemArray[j], EngineUnderTest.ProjectTable.Rows[i].ItemArray[j]);  // compare data
                }
            }

            Assert.AreEqual(testUserTable.Rows.Count, EngineUnderTest.UserTable.Rows.Count);
            for (int i = 0; i < testUserTable.Rows.Count; i++)
            {
                for (int j = 0; j < testUserTable.Rows[i].ItemArray.Length; j++)
                {
                    Assert.AreEqual(testUserTable.Rows[i].ItemArray[j], EngineUnderTest.UserTable.Rows[i].ItemArray[j]);
                }
            }

            Assert.AreEqual(testTaskTable.Rows.Count, EngineUnderTest.TaskTable.Rows.Count);
            for (int i = 0; i < testTaskTable.Rows.Count; i++)
            {
                for (int j = 0; j < testTaskTable.Rows[i].ItemArray.Length; j++)
                {
                    Assert.AreEqual(testTaskTable.Rows[i].ItemArray[j], EngineUnderTest.TaskTable.Rows[i].ItemArray[j]);
                }
            }
        }

        [Test]
        public void TestSetProjectDefconLevel()
        {
            DataTable testProjectTable = new DataTable();

            // existing defcon level in CodeconDB is 5
            EngineUnderTest.SetProjectDefconLevel("Codecon", 4);

            // Check the actual stored value after calling SetProjectDefconLevel
            string query = "select * from Project";
            using (SqlConnection serverConnection = new SqlConnection(EngineUnderTest.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    // create data adapter to read table into DataTable object
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(testProjectTable);
                }
            }

            int actualDefconLevel = Convert.ToInt32(testProjectTable.Rows[0].ItemArray[1].ToString());      // This is dependant on the database tested against

            Assert.IsTrue(actualDefconLevel.Equals(4));

            // Reset the defcon level in database
            query = "UPDATE Project SET defconScale = 5 WHERE projectName = 'Codecon';";
            using (SqlConnection serverConnection = new SqlConnection(EngineUnderTest.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    System.Threading.Tasks.Task.Run(() =>
                    {
                        serverConnection.Open();
                        cmd.ExecuteNonQuery();
                    });
                }
            }

        }

        // TODO: Fix this test
        /*
        [Test]
        public void TestAddProj()
        {
            // Create a test object
            Project newProj = new Project
            {
                projectName = "TEST",
                defconScale = 1,
                dueDate = Convert.ToDateTime("1-1-1999")
            };

            // Call the method
            EngineUnderTest.AddProj(newProj);

            // check if the project was added properly
            DataTable testProjTable = new DataTable();
            string query = "select * from Project";
            using (SqlConnection serverConnection = new SqlConnection(EngineUnderTest.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    // create data adapter to read table into DataTable object
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(testProjTable);
                }
            }

            // **This is dependant on the database tested against**
            Project testProj = new Project();
            testProj.projectName = testProjTable.Rows[1].ItemArray[0].ToString();
            testProj.defconScale = Convert.ToInt32(testProjTable.Rows[1].ItemArray[1].ToString());
            testProj.dueDate = Convert.ToDateTime(testProjTable.Rows[1].ItemArray[2].ToString());


            Assert.AreEqual(newProj.projectName, testProj.projectName);
            Assert.AreEqual(newProj.defconScale, testProj.defconScale);
            Assert.AreEqual(newProj.dueDate, testProj.dueDate);


            // Remove the project
            query = "DELETE FROM Project WHERE projectName = 'TEST';";
            using (SqlConnection serverConnection = new SqlConnection(EngineUnderTest.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    System.Threading.Tasks.Task.Run(() =>
                    {
                        serverConnection.Open();
                        cmd.ExecuteNonQuery();
                    });
                }
            }
        }
        */

        // TODO: Implement this test
        [Test]
        public void TestRemoveProj()
        {

        }
    }
}