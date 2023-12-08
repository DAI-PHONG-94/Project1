using Example.Models.Entities;
using Example.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _employee;
        private readonly IRepository<Department> _department;

        public EmployeeController(IRepository<Employee> employee, IRepository<Department> department)
        {
            _employee = employee;
            _department = department;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var employee = await _employee.GetAll();
            return View(employee);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var departments = await _department.GetAll();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employee.Create(employee);
                return RedirectToAction(nameof(Index));
            }

            var departments = await _department.GetAll();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);

            return View(employee);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employee.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employee.Update(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employee.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employee.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employee.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
