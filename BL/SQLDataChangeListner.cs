using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using UpWorkTask.Data;
using UpWorkTask.Models;

namespace UpWorkTask.BL
{
    public  class SQLDataChangeListner : IDataChangeListner
    {
        public IConfiguration _configuration { get; set; }
        public SQLDataChangeListner(IConfiguration configuration)
        {
            _configuration = configuration;
            SqlDependency.Start(_configuration.GetConnectionString("MyDbContext"));
        }
        public void RegisterListnerForEmployeeChanges()
        {
            // Assume connection is an open SqlConnection.
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MyDbContext")))
            {
                conn.Open();
                // Create a new SqlCommand object.
                using (SqlCommand command = new SqlCommand(
                "SELECT  [Id] ,[Name],[Designation],[Company],[Cityname],[Address],[Gender]  FROM [dbo].[Employee]",
                conn))
                {

                    SqlDependency dependency = new SqlDependency(command);

                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyChange);

                    // Execute the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                           var tmpdata = reader[0].ToString();
                        }
                    }
                }
            }
        }

        void OnDependencyChange(object sender,
           SqlNotificationEventArgs e)
        {
            // Handle the event (for example, invalidate this cache entry).

            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= OnDependencyChange;

            RegisterListnerForEmployeeChanges();
        }

       public void UnRegisterListnerForEmployeeChanges()
        {
            // Release the dependency.
            SqlDependency.Stop(_configuration.GetConnectionString("MyDbContext"));
        }
    }
}
