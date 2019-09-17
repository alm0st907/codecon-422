using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace api.Controllers
{
 
    public class ManageProjectController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public string Index()
        {
            return "oops! something went wrong!\n";
        }

        [HttpGet]
        public JObject GetUserLogin(string userName, string passWd)
        {
            User retUser = new User();
            JObject retJUser = new JObject();
            //retUser = GetUser(userName, passWd);

            retJUser = JObject.FromObject(retUser);
            return retJUser;
        }

        [HttpGet]
        public JObject GetProject(string projectName)
        {
            Project retProj = new Project();
            JObject retJProj = new JObject();
            //retProj = GetProj(projectName);

            retJProj = JObject.FromObject(retProj);
            return retJProj;
        }

        [HttpGet]
        public JObject DummyGetProject()
        {
            DateTime date = new DateTime(2019, 9, 23);
            Project retProj = new Project("Dummy Project", 2, date);
            JObject retJProj = new JObject();
            //retProj = GetProj(projectName);

            retJProj = JObject.FromObject(retProj);
            return retJProj;
        }

        [HttpGet]
        public JObject GetTask(string TaskName)
        {
            Task retTask = new Task();
            JObject retJTask = new JObject();
            //retTask = GetTask(TaskName);

            retJTask = JObject.FromObject(retTask);
            return retJTask;
        }

        [HttpGet]
        public JArray GetAllTasks(string projectName)
        {
            List<Task> retTaskList = new List<Task>();
            JArray retJList = new JArray();
            //retTaskList = GetTasks(projectName);

            retJList = JArray.FromObject(retTaskList);
            return retJList;
        }

        [HttpGet]
        public JArray DummyGetAllTasks(string projectName)
        {
            List<Task> retTaskList = new List<Task>();
            Task t1 = new Task("Dummy Project", 1, "Slater", "Do All the Things", "Just do the things");
            Task t2 = new Task("Dummy Project", 2, "Garrett", "Also Do All the Things", "Just do the things, you just gotta do it");
            JArray retJList = new JArray();
            //retTaskList = GetTasks(projectName);
            retTaskList.Add(t1);
            retTaskList.Add(t2);

            retJList = JArray.FromObject(retTaskList);
            return retJList;
        }

        [HttpPost]
        public  async void CreateUser()
        {
            int check;
            try 
            {
                
                using (var streamReader = new HttpRequestStreamReader(Request.Body, Encoding.UTF8))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var json = await JObject.LoadAsync(jsonReader);
                    var userHolder = json["username"];
                    var emailHolder = json["email"];
                    var passwordHolder = json["password"];
                    
                    User newUser = new User(userHolder.ToString(), emailHolder.ToString(), emailHolder.ToString(), 0);
                    //check = AddUser(newUser);
                }
            }
            catch (Exception e) 
            {
                // handle exception        
            }

        }

        [HttpPost]
        public async void CreateProject()
        {
            int check;
            try
            {

                using (var streamReader = new HttpRequestStreamReader(Request.Body, Encoding.UTF8))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var json = await JObject.LoadAsync(jsonReader);
                    var nameHolder = json["projectName"];
                    var DateHolder = json["launchDate"];

                    Project newProject = new Project(nameHolder.ToString(), 5 , DateTime.Parse(DateHolder.ToString())); //"minimum" or lowest DEFCON value is 5
                    //check = AddProject(newProject);
                }
            }
            catch (Exception e)
            {
                // handle exception        
            }

        }

        [HttpPost]
        public async void CreateTask()
        {
            int check;
            try
            {

                using (var streamReader = new HttpRequestStreamReader(Request.Body, Encoding.UTF8))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var json = await JObject.LoadAsync(jsonReader);
                    var projectNameHolder = json["projectName"];
                    var escalationValHolder = json["escalationValue"];
                    var workerNameHolder = json["assignedWorker"];
                    var taskNameHolder = json["taskName"];
                    var taskDescriptionHolder = json["description"];

                    Task newTask = new Task(projectNameHolder.ToString(), int.Parse(escalationValHolder.ToString()), workerNameHolder.ToString(), taskNameHolder.ToString(), taskDescriptionHolder.ToString());
                                                             
                    //check = AddTask(newTask);
                }
            }
            catch (Exception e)
            {
                // handle exception        
            }

        }

    }
}
