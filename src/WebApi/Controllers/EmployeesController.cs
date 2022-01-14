using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UpWorkTask.Data;
using UpWorkTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpWorkTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesManager _employeesManager;

        public EmployeesController(IEmployeesManager employeesManager)
        {
            _employeesManager = employeesManager;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _employeesManager.GetEmployee();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployee(string id)
        {
            return await _employeesManager.GetEmployee(id);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<bool> PutEmployee(string id, Employee employee)
        {
            return await _employeesManager.PutEmployee(id, employee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Employee> PostEmployee(Employee employee)
        {
            return await _employeesManager.PostEmployee( employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployee(string id)
        {
            return await _employeesManager.DeleteEmployee(id);
        }

    }
}
