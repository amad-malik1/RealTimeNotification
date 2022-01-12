using Microsoft.EntityFrameworkCore;
using UpWorkTask.Data;
using UpWorkTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpWorkTask.Controllers
{
    public class EmployeesManager : IEmployeesManager
    {
        private readonly MyDbContext _context;
        public EmployeesManager(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }
        public async Task<Employee> GetEmployee(string id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            return employee;
        }
        public async Task<bool> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
                throw new Exception("Id is not matching for employee object");

            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    throw new Exception("Employee not found");
                }
            }
            return false;
        }
        public async Task<Employee> PostEmployee(Employee employee)
        {

            try
            {
                employee.Id = Guid.NewGuid().ToString();
                _context.Employee.Add(employee);

                Notification notification = new Notification()
                {
                    EmployeeName = employee.Name,
                    TranType = "Add"
                };
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return employee;
        }
        public async Task<bool> DeleteEmployee(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            _context.Employee.Remove(employee);

            await _context.SaveChangesAsync();
            return true;
        }
        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
