using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentService service
        , IWebHostEnvironment webHostEnvironment, ILogger<DepartmentsController> logger) : Controller
    {
        private readonly IDepartmentService _service = service;
        private readonly IWebHostEnvironment _env = webHostEnvironment;
        private readonly ILogger<DepartmentsController> _logger = logger;

        // private readonly ILogger _logger = logger;

        public IActionResult Index() // Home Page For Department
        {
            var departments = _service.GetAll();
            return View(departments); // Send Data From Action To View 
        }

        #region Create
        // This Action Will Show The View Of Create A Department
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(DepartmentCreateRequest request)
        {
            if (!ModelState.IsValid) return View(request); // Server Side Validation

            try
            {
                var result = _service.Add(request);
                if (result > 0) return RedirectToAction(nameof(Index));  //???

                ModelState.AddModelError(string.Empty, "Can't create department");
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

            var department = _service.GetById(id.Value);
            if (department is null) return NotFound(); // 404

            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400

            var department = _service.GetById(id.Value);
            if (department is null) return NotFound(); // 404

            return View(department.ToRequest());
        }
        [HttpPost]
        public IActionResult Edit([FromQuery]int id, DepartmentUpdateRequest request)
        {
            try
            {
                var result = _service.Update(request);
                if (result > 0) return RedirectToAction(nameof(Index));  //???

                ModelState.AddModelError(string.Empty, "Can't update department");
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


            var department = _service.GetById(id.Value);
            if (department is null) return NotFound(); // 404
            return View(department);
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
                ModelState.AddModelError(string.Empty, "Can't delete department now");

                return RedirectToAction(nameof(Index));


            }
        }
        #endregion




    }
}
