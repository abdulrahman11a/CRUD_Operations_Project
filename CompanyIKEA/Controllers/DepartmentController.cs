using BLL.Models_DTOS__CustomModel_.Departments;
using CompanyIKEAPL.ViewModels.Department;

using NToastNotify;

namespace CompanyIKEA.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService Serrvice;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment environment;
        private readonly IToastNotification notification;

        public DepartmentController(IDepartmentService departmentSerrvice, ILogger<DepartmentController> logger,
            IWebHostEnvironment environment, IToastNotification notification)
        {
            this.Serrvice = departmentSerrvice;
           
            this.logger = logger;
            this.environment = environment;
            this.notification = notification;
        }

        #region Master Page
        [HttpGet]
        public IActionResult Index()
        {
            return View(Serrvice.GetAll().ToList());
        }
        #endregion

        #region Create Action Http GET-Post
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmetCreateDto creatDto)
        {
            if (!ModelState.IsValid)
                return View(creatDto);

            try
            {
                var res = Serrvice.Create(creatDto);
                if (res > 0)
                {
                    notification.AddSuccessToastMessage("Department created successfully!");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department not created");
                    return View(creatDto);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                if (environment.IsDevelopment())
                {
                    throw; // In development, rethrow the exception
                }
                else
                {
                    notification.AddErrorToastMessage("An error occurred while creating the department.");
                    return RedirectToAction("Index");
                }
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();

            var departmentDetails = Serrvice.GetById(id);
            if (departmentDetails is { })
            {
                var editViewModel = new EditViewModel
                {
                    Name = departmentDetails.Name,
                    Description = departmentDetails.Description,
                    Code = departmentDetails.Code,
                    CreationDate = departmentDetails.CreationDate
                };

                return View(editViewModel);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, EditViewModel updateDto)
        {
            if (!ModelState.IsValid) return View(updateDto);

            var update = new DepartmentUpdateDto()
            {
                Id = id,
                Name = updateDto.Name,
                Description = updateDto.Description,
                Code = updateDto.Code,
                CreationDate = updateDto.CreationDate,
            };

            int result = Serrvice.Update(update);
            if (result > 0)
            {
                notification.AddSuccessToastMessage("Department updated successfully!");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error updating department.");
                return View(updateDto);
            }
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var depar = Serrvice.GetById(id);
            if (depar is { })
            {
                return View(depar);
            }
            return NotFound();
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id)
        {
            try
            {
                if (id is null) return BadRequest("ID cannot be null.");

                var deleteResult = Serrvice.Delete(id);
                if (!deleteResult)
                {
                    return NotFound($"Department with ID {id} was not found.");
                }

                notification.AddSuccessToastMessage("Department deleted successfully!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                notification.AddErrorToastMessage("An error occurred while trying to delete the department.");
                return RedirectToAction("Index");
            }
        }
        // ModelState.IsValid =>//this proprity include All  prameter in Action  is All State is true each prametr
        //ModelState.IsValid == true  else is false  Sutch not enter Name or DAta is ReQuerd
        //Save this not file OR Databas set in console if you  save in file Or DB Use Pakage ===>> SeryalLog

        #endregion
    }
}
