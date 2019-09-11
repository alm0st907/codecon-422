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

    }

}