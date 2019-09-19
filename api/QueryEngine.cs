using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace api
{
    public class QueryEngine
    {
        SqlConnection serverConnection;
        DataTable ProjectTable;
        DataTable UserTable;
        DataTable TaskTable;

        public void ConnectToServer()
        {
            var constring = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CodeconDB;Integrated Security=True"; // This may need to be modified if running on non-windows OS
            serverConnection = new SqlConnection(constring);

            ProjectTable = new DataTable();
            UserTable = new DataTable();
            TaskTable = new DataTable();

            RetrieveTables();
        }

        private void RetrieveTables()
        {
            string query = "select * from Project";
            SqlCommand cmd = new SqlCommand(query, serverConnection);
            serverConnection.Open();

            // create data adapter to read table into DataTable object
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ProjectTable);

            query = "select * from [User]";
            cmd = new SqlCommand(query, serverConnection);

            da = new SqlDataAdapter(cmd);
            da.Fill(UserTable);

            query = "select * from Task";
            cmd = new SqlCommand(query, serverConnection);

            da = new SqlDataAdapter(cmd);
            da.Fill(TaskTable);

            serverConnection.Close();
        }
        
        
        public User GetUser(string username, string password)
        {
            User fetchedUser = new User();

            try
            {
                var fetchedUserRow = from Row in UserTable.AsEnumerable()
                                     where Row.Field<string>("username") == username
                                     where Row.Field<string>("password") == password
                                     select Row;

                fetchedUser.email = (from Row in UserTable.AsEnumerable()
                                    where Row.Field<string>("username") == username
                                    where Row.Field<string>("password") == password
                                    select Row.Field<string>("email")).ToList().ElementAt(0);

                fetchedUser.id = (from Row in UserTable.AsEnumerable()
                                  where Row.Field<string>("username") == username
                                  where Row.Field<string>("password") == password
                                  select Row.Field<int>("id")).ToList().ElementAt(0);

                fetchedUser.username = username;
                fetchedUser.passWord = password;
            }
            catch (SqlException e)
            {
                return null;
            }
            return fetchedUser;
        }
        
        /*
        public void AddUser(User newUser)   // needs to support generating a user id 
        {}
        public void RemoveUser(string username)
        {}

        public Project GetProj(string projectName)
        {}
        public void AddProj(Project newProject)
        {}
        public void RemoveProj(string projectName)
        {}

        public Task GetTask(string taskName)
        {}
        public void AddTask(Task newTask)
        {}
        public void RemoveTask(string taskName)
        {}

        public void SetProjectDefconLevel(string projectName, int newLevel)
        {}
        
        public List<Task> GetTasks(string projectName)
        {}
        */

    }
	

}