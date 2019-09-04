﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManageProjectController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public string Index()
        {
            return "Your api hasn't exploded yet";
        }
    }
}
