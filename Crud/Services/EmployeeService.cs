using Crud.Contrats;
using Crud.Models;

namespace Crud.Services
{
    public class EmployeeService : ICrud<Employee>
    {
        public List<Employee> Employees { get; set; }

        public EmployeeService()
        {
          // Employees = new List<Employee>();
        }

        private int LastId() 
        {
            return (Employees.LastOrDefault()?.Id ?? 0) + 1;
        }
        private int GetIndex(int id) 
        {
            return Employees.FindLastIndex(employee => employee.Id == id);
     
        }

        public int Create(Employee entity)
        {
            if (Employees == null)
                throw new Exception("There's no employee exist");

            if (entity == null)
                throw new Exception("Null entity");

            if (entity.Email == null)
                throw new Exception("Null Email");
            if(!Employees.Any(employee => employee.Email == entity.Email)) 
                
            {
                entity.Id = LastId();
                entity.CreateAt = DateTime.Now;
                Employees.Add(entity);
                return entity.Id;
            }
            throw new Exception("There's exist the mail already");

            
        }

        public bool Update(int id, Employee entity)
        {
            int index = GetIndex(id);
            if (index > -1) 
            {
                Employees[index].Email = entity.Email;
                Employees[index].Id = id;
                Employees[index].Name = entity.Name;
                Employees[index].Phone = entity.Phone;
                Employees[index].CreateAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            int index = GetIndex(id);
            if (index > -1)
            {
                Employees.RemoveAt(index);
                return true;
            }
            return false;
        }

        public Employee? Get(int id)
        {
            int index = GetIndex(id);
            if (index > -1) 
            {
                return Employees[index];
            }
            return null;
        }
        public List<Employee> GetAll()
        {
            return Employees;
        }
    }
}
