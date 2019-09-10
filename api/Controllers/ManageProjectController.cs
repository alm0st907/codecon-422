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
        public int[] retArray = { 1, 2, 3, 4, 5 }; 
        public int size = 5;
        // GET: /<controller>/
        [HttpGet]
        public string Index()
        {
            return "Your api hasn't exploded yet";
        }

        [HttpGet]
        public string Newroute()
        {
            return "this is a different route";
        }

        [HttpGet]
        public ActionResult<string> Datareturn(int id)
        {
           id--;
            if (id < size  && id > 0)
                return "the return is " + (retArray[id ].ToString());
            else
                return "out of bounds";
        }

        [HttpPost]
        public  async void Test()
        {
            try 
            {
                
                using (var streamReader = new HttpRequestStreamReader(Request.Body, Encoding.UTF8))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var json = await JObject.LoadAsync(jsonReader);
                    // process JSON
                    Console.WriteLine($"Here is some of the {json["things"]}");
                }
            }
            catch (Exception e) 
            {
                // handle exception        
            }

        }

    }
}
