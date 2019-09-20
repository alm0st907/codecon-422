using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api
{
    public class Task
    {
        public string projectName { get; set; }
        public int escalationVal { get; set; }
        public string assignee { get; set; }
        public string taskName { get; set; }
        public string description { get; set; }

        public Task()
        {
            projectName = "";
            escalationVal = 0;
            assignee = "";
            taskName = "";
            description = "";
        }

        public Task(string newProj, int newEscVal, string newAssn, string newTask, string newDesc)
        {
            projectName = newProj;
            escalationVal = newEscVal;
            assignee = newAssn;
            taskName = newTask;
            description = newDesc;
        }
    }
}
