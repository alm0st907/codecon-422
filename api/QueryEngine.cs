using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;


namespace api
{
    public class QueryEngine
    {
        string conString;
        DataTable ProjectTable;
        DataTable UserTable;
        DataTable TaskTable;

        //default the connection to our supplied string
        //otherwise we use the given string in params
        public QueryEngine(string connection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CodeconDB;Integrated Security=True")
        {
            conString = connection;
        }

        public int ConnectToServer()
        {
            //conString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CodeconDB;Integrated Security=True"; // This may need to be modified if running on non-windows OS

            ProjectTable = new DataTable();
            UserTable = new DataTable();
            TaskTable = new DataTable();

            try
            {
                RetrieveTables();
                return 0;
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        private void RetrieveTables()
        {
            using (SqlConnection serverConnection = new SqlConnection(conString))
            {
                string query = "select * from Project";
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    ProjectTable.Clear();
                    // create data adapter to read table into DataTable object
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(ProjectTable);
                }

                query = "select * from [User]";
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    UserTable.Clear();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(UserTable);
                }

                query = "select * from Task";
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    TaskTable.Clear();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(TaskTable);
                }
            }
        }

        public async void ExecuteSQLCommand(string query)    // executes an sql command asycronusly
        {
            using (SqlConnection serverConnection = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, serverConnection))
                {
                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        serverConnection.Open();
                        cmd.ExecuteNonQuery();
                    });
                }
            }
        }


        public User GetUser(string username, string password)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            User fetchedUser = new User();

            try
            {
                var fetchedUserRow = from Row in UserTable.AsEnumerable()
                                     where Row.Field<string>("username") == username
                                     where Row.Field<string>("password") == password
                                     select Row;

                if (fetchedUserRow.AsEnumerable().Count() == 0)      // User not found
                {
                    return null;
                }

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


        public int AddUser(User newUser)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                List<int> fetchedUserIDs = (from Column in UserTable.AsEnumerable()     // pulls existing IDs
                                            select Column.Field<int>("id")).ToList();

                newUser.id = fetchedUserIDs.Max() + 1;  // adds new ID

                string query = "INSERT INTO [User] VALUES('" + newUser.username + "', '"
                    + newUser.email + "', '"
                    + newUser.passWord + "', "
                    + newUser.id + ");";
                ExecuteSQLCommand(query);
                return 0;
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        public int RemoveUser(string username)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                // check if the user is already gone
                List<string> fetchedUsernames = (from Column in UserTable.AsEnumerable()     // pulls existing usernames
                                                 select Column.Field<string>("username")).ToList();

                if (fetchedUsernames.Contains(username))
                {
                    string query = "DELETE FROM [User] WHERE username = '" + username + "';";
                    ExecuteSQLCommand(query);
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                return -1;
            }
        }


        public Project GetProj(string projectName)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            Project fetchedProject = new Project();

            try
            {
                var fetchedProjectRow = from Row in ProjectTable.AsEnumerable()
                                        where Row.Field<string>("projectName") == projectName
                                        select Row;

                if (fetchedProjectRow.AsEnumerable().Count() == 0)      // project not found
                {
                    return null;
                }

                fetchedProject.defconScale = (from Row in ProjectTable.AsEnumerable()
                                              where Row.Field<string>("projectName") == projectName
                                              select Row.Field<int>("defconScale")).ToList().ElementAt(0);

                fetchedProject.dueDate = (from Row in ProjectTable.AsEnumerable()
                                          where Row.Field<string>("projectName") == projectName
                                          select Row.Field<DateTime>("dueDate")).ToList().ElementAt(0);

                fetchedProject.projectName = projectName;
            }
            catch (SqlException e)
            {
                return null;
            }
            return fetchedProject;
        }

        public int AddProj(Project newProject)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                string query = "INSERT INTO Project VALUES('" + newProject.projectName + "', "
                    + newProject.defconScale + ", '"
                    + newProject.dueDate + "');";
                ExecuteSQLCommand(query);
                return 0;
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        public int RemoveProj(string projectName)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                // check if the user is already gone
                List<string> fetchedProjNames = (from Column in ProjectTable.AsEnumerable()     // pulls existing usernames
                                                 select Column.Field<string>("projectName")).ToList();

                if (fetchedProjNames.Contains(projectName))
                {
                    string query = "DELETE FROM Project WHERE projectName = '" + projectName + "';";
                    ExecuteSQLCommand(query);
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                return -1;
            }
        }


        public int SetProjectDefconLevel(string projectName, int newLevel)      // sets the new level passed. The newLevel is NOT additive
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                // check if the user is already gone
                List<string> fetchedProjNames = (from Column in ProjectTable.AsEnumerable()     // pulls existing usernames
                                                 select Column.Field<string>("projectName")).ToList();

                if (fetchedProjNames.Contains(projectName))
                {
                    string query = "UPDATE Project SET defconScale = " + newLevel
                        + " WHERE projectName = '"
                        + projectName + "';";
                    ExecuteSQLCommand(query);
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        public Task GetTask(string taskName)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            Task fetchedTask = new Task();

            try
            {
                var fetchedTaskRow = from Row in TaskTable.AsEnumerable()
                                     where Row.Field<string>("taskName") == taskName
                                     select Row;

                if (fetchedTaskRow.AsEnumerable().Count() == 0)      // project not found
                {
                    return null;
                }

                fetchedTask.projectName = (from Row in TaskTable.AsEnumerable()
                                           where Row.Field<string>("taskName") == taskName
                                           select Row.Field<string>("projectName")).ToList().ElementAt(0);

                fetchedTask.escalationVal = (from Row in TaskTable.AsEnumerable()
                                             where Row.Field<string>("taskName") == taskName
                                             select Row.Field<int>("escalationValue")).ToList().ElementAt(0);

                fetchedTask.assignee = (from Row in TaskTable.AsEnumerable()
                                        where Row.Field<string>("taskName") == taskName
                                        select Row.Field<string>("assignee")).ToList().ElementAt(0);

                fetchedTask.description = (from Row in TaskTable.AsEnumerable()
                                           where Row.Field<string>("taskName") == taskName
                                           select Row.Field<string>("description")).ToList().ElementAt(0);

                fetchedTask.taskName = taskName;
            }
            catch (SqlException e)
            {
                return null;
            }
            return fetchedTask;
        }

        public int AddTask(Task newTask)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                string query = "INSERT INTO Task VALUES('" + newTask.projectName + "', '"
                    + newTask.escalationVal + "', '"
                    + newTask.assignee + "', '"
                    + newTask.taskName + "', '"
                    + newTask.description + "');";
                ExecuteSQLCommand(query);
                return 0;
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        public int RemoveTask(string taskName)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                // check if the user is already gone
                List<string> fetchedTaskNames = (from Column in TaskTable.AsEnumerable()     // pulls existing usernames
                                                 select Column.Field<string>("taskName")).ToList();

                if (fetchedTaskNames.Contains(taskName))
                {
                    string query = "DELETE FROM Task WHERE taskName = '" + taskName + "';";
                    ExecuteSQLCommand(query);
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        public List<Task> GetTasks(string projectName)
        {
            RetrieveTables();       // get a fresh copy of the database tables before every query to prevent errors
            try
            {
                List<Task> returnList = new List<Task>();
                var fetchedTasks = from Row in TaskTable.AsEnumerable()
                                   where Row.Field<string>("projectName") == projectName
                                   select Row;

                foreach (DataRow r in fetchedTasks)
                {
                    Task rowTask = new Task();
                    rowTask.projectName = r.Field<string>("projectName");
                    rowTask.taskName = r.Field<string>("taskName");
                    rowTask.escalationVal = r.Field<int>("escalationValue");
                    rowTask.assignee = r.Field<string>("assignee");
                    rowTask.description = r.Field<string>("description");
                    returnList.Add(rowTask);
                }

                return returnList;
            }
            catch (SqlException e)
            {
                return null;
            }
        }
    }


}