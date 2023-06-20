using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Service;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class PredmetiController : Controller
    {
        private readonly IPredmetService _predmetService;

        public PredmetiController(IPredmetService predmetService)
        {
            _predmetService = predmetService;
        }

        // GET: Predmeti
        public IActionResult Index()
        {
            return View(_predmetService.FindAll());
        }
       
        // GET: Predmeti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Predmeti/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PredmetID,Naziv,Bodovi")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                _predmetService.Create(predmet);
                return RedirectToAction(nameof(Index));
            }
            return View(predmet);
        }

        // GET: Predmeti/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _predmetService.FindByID(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Predmeti/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = _predmetService.FindByID(id);

            if (await TryUpdateModelAsync(courseToUpdate,
                "",
                c => c.Bodovi, c => c.Naziv))
            {
                try
                {
                    _predmetService.Update(courseToUpdate);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Greška prilikom izmene podataka. " +
                        "Pokušajte ponovo.");
                }
            }
            return View(courseToUpdate);
        }

        // GET: Predmeti/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _predmetService.FindByID(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Predmeti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _predmetService.FindByID(id);
            _predmetService.Delete(course);
            return RedirectToAction(nameof(Index));
        }
    }
}