
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SimplifiedCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> Records = new List<string>(); // In-memory storage

        public IActionResult Index()
        {
            return View(Records); // Show all records
        }

        public IActionResult Create()
        {
            return View(); // Show create form
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Records.Add(name); // Add new record
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id >= 0 && id < Records.Count)
            {
                ViewBag.Id = id;
                ViewBag.Name = Records[id];
                return View(); // Show edit form
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            if (id >= 0 && id < Records.Count && !string.IsNullOrEmpty(name))
            {
                Records[id] = name; // Update record
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < Records.Count)
            {
                Records.RemoveAt(id); // Remove record
            }
            return RedirectToAction("Index");
        }
    }
}
