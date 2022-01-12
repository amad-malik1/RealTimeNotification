using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace UpWorkTask.BL
{
    public class SQLDataChangeListner : IDataChangeListner
    {
        public List<IDbChangeObserver> _observers { get; set; }
        public IConfiguration _configuration { get; set; }
        public SQLDataChangeListner(IConfiguration configuration)
        {
            _observers = new List<IDbChangeObserver>();
            _configuration = configuration;
            SqlDependency.Start(_configuration.GetConnectionString("MyDbContext"));
            RegisterListnerForEmployeeChanges();
        }

        public void Attach(IDbChangeObserver dbChangeObserver)
        {
            _observers.Add(dbChangeObserver);
        }

        public void Detach(IDbChangeObserver dbChangeObserver)
        {
            _observers.Remove(dbChangeObserver);
        }

        void RegisterListnerForEmployeeChanges()
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

            foreach (IDbChangeObserver observer in _observers)
            {
                observer.RefreshEmployeeData();
            }
            RegisterListnerForEmployeeChanges();
        }

        //void UnRegisterListnerForEmployeeChanges()
        //{
        //    // Release the dependency.
        //    SqlDependency.Stop(_configuration.GetConnectionString("MyDbContext"));
        //}

    }
}
