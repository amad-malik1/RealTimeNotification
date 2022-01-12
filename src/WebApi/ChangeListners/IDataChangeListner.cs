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
    public  interface IDataChangeListner
    {
        public void RegisterListnerForEmployeeChanges();
        public void UnRegisterListnerForEmployeeChanges();
    }
}
