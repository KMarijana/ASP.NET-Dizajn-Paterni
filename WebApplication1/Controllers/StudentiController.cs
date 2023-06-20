using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class StudentiController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentiController(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        // GET: Predmeti
        public IActionResult Index()
        {
            return View(_studentService.FindAll());
        }

        // GET: Studenti/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var student = _studentService.Details(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Studenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studenti/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
        [Bind("BrojIndexa,Ime,Prezime")] Models.Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.Create(student);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Greška prilikom izmene podataka. " +
                    "Pokušajte ponovo ");
            }
            return View(student);
        }

        // GET: Predmeti/Edit/5
        public IActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var student = _studentService.FindByID(id);
             if (student == null)
             {
                 return NotFound();
             }
             return View(student);
         }

        // POST: Studenti/Edit/5
        [HttpPost, ActionName("Edit")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> EditPost(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var studentToUpdate = _studentService.FindByID(id);
             if (await TryUpdateModelAsync(
                 studentToUpdate,
                 "",
                 s => s.Ime, s => s.Prezime, s => s.BrojIndexa))
             {
                 try
                 {
                     _studentService.Update(studentToUpdate);
                     return RedirectToAction(nameof(Index));
                 }
                 catch (DbUpdateException)
                 {
                     ModelState.AddModelError("", "Gre[ka prilikom izmene podataka. " 
                         + "Pokušajte ponovo ponovo");
                 }
             }
             return View(studentToUpdate);
         }

        // GET: Studenti/Delete/5
        public IActionResult Delete(int? id, bool? saveChangesError = false)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var student = _studentService.FindByID(id);

             if (student == null)
             {
                 return NotFound();
             }

             if (saveChangesError.GetValueOrDefault())
             {
                 ViewData["ErrorMessage"] =
                     "Brisanje neuspešno. Pokušajte ponovo.";
             }

             return View(student);
         }
        
         // POST: Studenti/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public IActionResult DeleteConfirmed(int id)
         {
             var student = _studentService.FindByID(id);
             if (student == null)
             {
                 return RedirectToAction(nameof(Index));
             }

             try
             {
                 _studentService.Delete(student);
                 return RedirectToAction(nameof(Index));
             }
             catch (DbUpdateException)
             {
                 return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
             }
         }
    }
}
