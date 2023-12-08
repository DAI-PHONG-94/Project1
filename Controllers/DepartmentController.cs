using Example.Models.Entities;
using Example.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
   
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> _department;

        public DepartmentController(IRepository<Department> department)
        {
            _department = department;
        }
        public async Task<IActionResult> Index()
        {
            var department = await _department.GetAll();
            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _department.Create(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var department = await _department.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _department.Update(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        public async Task<IActionResult> Details(int id)
        {
            var department = await _department.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var department = await _department.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _department.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
