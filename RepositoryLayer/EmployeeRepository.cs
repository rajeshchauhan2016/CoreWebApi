using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace RepositoryLayer
{
   public class EmployeeRepository: IEmployeeRepository
    {
        private EmployeeContext context;

        public EmployeeRepository(EmployeeContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            List<Employee> employeeDataList = await this.context.Employees.ToListAsync();
            return employeeDataList;
        }

        public async Task<Employee> GetEmployee(long id)
        {
            Employee model = await this.context.Employees.Where(p => p.EmployeeId == id).FirstOrDefaultAsync();

            return model;

        }
        public async Task SaveEmployee(Employee model)
        {
            try
            {

                context.Employees.Add(model);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateEmployee(long id,Employee model)
        {
            try
            {
                var employeeDetail = await context.Employees.Where(p => p.EmployeeId == id).FirstOrDefaultAsync();

                if (employeeDetail != null)
                {
                    context.Entry(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteEmployee(long id)
        {
            try
            {
                var employeeDetail = await context.Employees.Where(p => p.EmployeeId == id).FirstOrDefaultAsync();

                if (employeeDetail != null)
                {
                    context.Entry(employeeDetail).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



    }
}
