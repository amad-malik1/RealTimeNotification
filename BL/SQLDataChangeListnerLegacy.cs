using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
    public  class SQLDataChangeListnerLegacy : IDataChangeListner
    {
        public IConfiguration _configuration { get; set; }
        public SQLDataChangeListnerLegacy(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  void RegisterListnerForEmployeeChanges()
        {
            var employeeMapper = new ModelToTableMapper<Employee>();
            employeeMapper.AddMapping(s => s.Name, "Name");

            using (var dep = new SqlTableDependency<Employee>(_configuration.GetConnectionString("MyDbContext"),
                tableName: "Employee",
                schemaName: "dbo",
                mapper: employeeMapper))
            {
                dep.OnChanged += Employee_OnChanged;
                dep.OnError += Employee_OnError;
                dep.Start();
                // Here are some action to be performed.
                // dep.Stop();
            }
        }
        private  void Employee_OnChanged(object sender, RecordChangedEventArgs<Employee> e)
        {
            var chandedEntity = e.Entity;
            switch (e.ChangeType)
            {
                case ChangeType.Delete:
                    // log . email . service call;
                    break;
                case ChangeType.Insert:
                    //log . email . service call;
                    break;
                case ChangeType.Update:
                    //log . email . service call;
                    break;
            }
        }
        private  void Employee_OnError(object sender, ErrorEventArgs e)
        {
            throw e.Error;
        }
        public void UnRegisterListnerForEmployeeChanges()
        {
        }
    }
}
