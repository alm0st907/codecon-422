using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace api
{
    public class QueryEngine
    {
        private string ConnectionString;
        private void ConnectToServer()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "SA";
            //builder.Password = "your_password";
            builder.InitialCatalog = "CodeconDB";
            ConnectionString = builder.ConnectionString;        

            // need to add a reference to System.Data.Linq to create the DataCOntext.
            // with the DataContex we will be able to represent entries in the database as classes
            // We will also be able to run Language integrated queries on these object and the database
            // to streamline database integration
        }

        public User GetUser(string username)
        {}

        public void AddUser(User newUser)
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

    }
	

}