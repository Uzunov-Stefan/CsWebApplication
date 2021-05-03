using CsWebApp.Data;
using CsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsWebApp.Controllers
{
    public class ApplicationTypeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db) 
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
            return View(objList);
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }

        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ApplicationTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.ApplicationTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
