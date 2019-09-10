using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class Project
    {
        public string projectName { get; set; }
        public int defconScale { get; set; }
        public DateTime dueDate { get; set; }

        public Project()
        {
            projectName = "";
            defconScale = 0;
            dueDate = new DateTime();
        }

        public Project(string newName, int newScale, DateTime newDate)
        {
            projectName = newName;
            defconScale = newScale;
            dueDate = newDate;
        }
    }
}
