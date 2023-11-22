using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objecCategoryList = _context.categories.ToList();
            return View(objecCategoryList);
        }
        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Item Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var CategoryFromDb = _context.categories.FirstOrDefault(c => c.Id == id);
            if (CategoryFromDb == null) return NotFound();
            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Item Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var CategoryFromDb = _context.categories.Find(id);
            if (CategoryFromDb == null) return NotFound();
            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var item = _context.categories.Find(id);
            if (item == null) return NotFound();
            _context.categories.Remove(item);
            _context.SaveChanges();
            TempData["success"] = "Item Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
