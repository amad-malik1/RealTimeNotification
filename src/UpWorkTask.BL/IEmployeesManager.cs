using Microsoft.EntityFrameworkCore;
using UpWorkTask.Data;
using UpWorkTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpWorkTask.Controllers
{
    public interface IEmployeesManager 
    {
        public  Task<IEnumerable<Employee>> GetEmployee();
        public  Task<Employee> GetEmployee(string id);
        public Task<bool> PutEmployee(string id, Employee employee);
        public  Task<Employee> PostEmployee(Employee employee);
        public Task<bool> DeleteEmployee(string id);
    }
}
