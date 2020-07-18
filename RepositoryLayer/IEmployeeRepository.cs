using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
   public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeeList();

        public Task<Employee> GetEmployee(long id);
       
        public Task SaveEmployee(Employee model);

        public Task UpdateEmployee(long id ,Employee model);

        public Task DeleteEmployee(long id);

    }
}
