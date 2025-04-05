using Azure.Core;
using Demo.BusinessLayer.DataTransferObjects.Employees;
using Demo.DataAccessLayer.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeesController(IEmployeeService service
        , IWebHostEnvironment webHostEnvironment, ILogger<EmployeesController> logger) : Controller
    {
        private readonly IEmployeeService _service = service;
        private readonly IWebHostEnvironment _env = webHostEnvironment;
        private readonly ILogger<EmployeesController> _logger = logger;

        // private readonly ILogger _logger = logger;

        public IActionResult Index() // Home Page For Employee
        {
            var Employees = _service.GetAll();
            return View(Employees); // Send Data From Action To View 
        }

        #region Create
        // This Action Will Show The View Of Create A Employee
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid) return View(request); // Server Side Validation

            try
            {
                var result = _service.Add(request);
                if (result > 0) return RedirectToAction(nameof(Index));  //???

                ModelState.AddModelError(string.Empty, "Can't create Employee");
                return View(request);
            }
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                // Log => Production
                _logger.LogError(ex.Message);

            }
            return View(request);

        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400

            var Employee = _service.GetById(id.Value);
            if (Employee is null) return NotFound(); // 404

            return View(Employee);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400

            var Employee = _service.GetById(id.Value);
            if (Employee is null) return NotFound(); // 404

            var request = new EmployeeUpdateRequest()
            {
                Address = Employee.Address,
                Email = Employee.Email,
                Age = Employee.Age,

                Gender = Enum.Parse<Gender>(Employee.Gender), // string to enum(Gender)
                EmployeeType = Enum.Parse<EmployeeType>(Employee.EmployeeType),

                Id = Employee.Id,
                Name = Employee.Name,
                IsActive = Employee.IsActive,
                HiringDate = Employee.HiringDate,
                PhoneNumber = Employee.PhoneNumber,
                Salary = Employee.Salary

            };

            return View(request);
        }
        [HttpPost]
        public IActionResult Edit([FromQuery] int id, EmployeeUpdateRequest request)
        {
            try
            {
                var result = _service.Update(request);
                if (result > 0) return RedirectToAction(nameof(Index));  //???

                ModelState.AddModelError(string.Empty, "Can't update Employee");
                return View(request);
            }
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                // Log => Production
                _logger.LogError(ex.Message);

            }
            return View(request);

        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();


            var Employee = _service.GetById(id.Value);
            if (Employee is null) return NotFound(); // 404
            return View(Employee);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfigureDelete(int? id)
        {
            if (!id.HasValue) return NotFound();
            try
            {
                var result = _service.Delete(id.Value);
                if (result) return RedirectToAction(nameof(Index));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, "Can't delete Employee now");

                return RedirectToAction(nameof(Index));


            }
        }
        #endregion




    }
}
