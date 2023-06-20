using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class PolaganjaController : Controller
    {
        private readonly KontekstSkole _context;
        public PolaganjaController(KontekstSkole context)
        {
            _context = context;
        }
        // prikaz liste predmeta, spajanjem tabela student i predmet
        public IActionResult Index()
        {
            var schoolContext = _context.Polaganja.Include(d => d.Student).ThenInclude(d => d.Polaganja).ThenInclude(s => s.Predmet);
            return View(schoolContext.ToList());
        }
    }
}
