namespace BLL.Models_DTOS__CustomModel_.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeGetAllDTO> GetAllEmployees(string Search);
        EmployeeDetailsDTO? GetEmployeeById(int? id);
        int CreateEmployee(EmployeeCreateDto employeeDto);
        int UpdateEmployee(EmployeeUpdateDto employeeDto);
        bool DeleteEmployee(int? id);
    }
}
