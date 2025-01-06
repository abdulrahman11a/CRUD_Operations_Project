using DAL.Entities;
using BLL.Models_DTOS__CustomModel_.Employee;
using DAL.Presistance.Repo.Employee;
using Microsoft.EntityFrameworkCore;
using Azure;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeGetAllDTO> GetAllEmployees(string Search)
        {
            var employees = _employeeRepository.GetIqueryable()
                .Where(e => !e.IsDeleted &&
                            (string.IsNullOrEmpty(Search) ||
                             e.Name.ToLower().Contains(Search.ToLower()) ||
                             e.Email.ToLower().Contains(Search.ToLower()))) // this so bad performace
                .Include(e => e.Department)
                .Select(e => new EmployeeGetAllDTO
                {
                    Id = e.Id,
                    Age = e.Age,
                    IsActive = e.IsActive,
                    Name = e.Name,
                    Salary = e.Salary,
                    Email = e.Email
                })
                .ToList();

            return employees;
        }


        public EmployeeDetailsDTO? GetEmployeeById(int? id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null) return null;

            return new EmployeeDetailsDTO()
            {
                Id= employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender.ToString(),
                EmpType = employee.EmpType.ToString(),
                IsActive = employee.IsActive
            };
        }

        public int CreateEmployee(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Gender = employeeDto.Gender,
                EmpType = employeeDto.EmpType,
                IsActive = true,
                DepartmentId= employeeDto.DepartmentId
            };
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(EmployeeUpdateDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                  Email= employeeDto.Email,
                  PhoneNumber=employeeDto.PhoneNumber,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
            };
            return _employeeRepository.Update(employee);
        }

        public bool DeleteEmployee(int? id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null) return false;
            return _employeeRepository.Delete(employee) > 0;
        }
    }
}
