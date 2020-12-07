using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBConnExample.models;
using Microsoft.Extensions.Configuration;

namespace DBConnExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBConnectionTestController
    {
        //string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;Initial Catalog=SampleDB;User ID=admin;Password=abcd1234";
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        IConfiguration configuration;
        string connectionString = "";

        public DBConnectionTestController(IConfiguration iConfig) {
            this.configuration = iConfig;

            // use configuration to retrieve connection string from appsettings.json
            //this.connectionString = this.configuration.GetSection("ConnectionString").Value;

            // use the SqlConnectionStringBuilder to create our connection string
            this.stringBuilder.DataSource = this.configuration.GetSection("DBConnectionString").GetSection("Url").Value;
            this.stringBuilder.InitialCatalog = this.configuration.GetSection("DBConnectionString").GetSection("Database").Value;
            this.stringBuilder.UserID = this.configuration.GetSection("DBConnectionString").GetSection("User").Value;
            this.stringBuilder.Password = this.configuration.GetSection("DBConnectionString").GetSection("Password").Value;

            this.connectionString = stringBuilder.ConnectionString;

        }


        [HttpGet("{searchString}")]
        public List<Customer> GetCustomer(string searchString) {
            List<Customer> customers = new List<Customer>();

            // code goes here       

            return customers;
        }

    }

    
}