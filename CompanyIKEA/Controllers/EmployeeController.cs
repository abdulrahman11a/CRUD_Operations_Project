using BLL.Models_DTOS__CustomModel_.Employee;
using DAL.CommonEnum;
using NToastNotify;

namespace CompanyIKEAPL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IToastNotification _notification;

        public EmployeeController(IEmployeeService employeeService, IToastNotification notification)
        {
            _employeeService = employeeService;
            _notification = notification;
        }
        [HttpGet]
        public IActionResult Index(string Search)
        {
            var employees = _employeeService.GetAllEmployees(Search);
            return View(employees); 
        }

        public IActionResult Details(int? id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return View(employee);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employeeDto);
                _notification.AddSuccessToastMessage("Employee created successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDto);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound();
            ViewBag.primary = employee.Id;
            var updateDto = new EmployeeUpdateDto()
            {
                
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,

                // Convert string to Gender and EmployeeType enums, case-insensitive
                Gender = Enum.Parse<Gender>(employee.Gender, true), // Case-insensitive
                EmpType = Enum.Parse<EmployeeType>(employee.EmpType, true) // Case-insensitive
            };



            return View(updateDto); 
        }

        [HttpPost]
        public IActionResult Update(EmployeeUpdateDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employeeDto);
                _notification.AddSuccessToastMessage("Employee updated successfully!");
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit));
        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound();

            var result = _employeeService.DeleteEmployee(id);
            if (result)
            {
                _notification.AddSuccessToastMessage("Employee deleted successfully.");
            }
            else
            {
                _notification.AddErrorToastMessage("Failed to delete the employee.");
            }

            return RedirectToAction(nameof(Index));
        }



    }
}
