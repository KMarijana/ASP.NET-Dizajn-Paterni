using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //prosleđivanje vrednosti iz metoda view bag-u koji vrši prikaz na ekranu
            //interface segregation
            IObaveštenje obaveštenje = new StudentService();
            ViewBag.Obaveštenje = obaveštenje.Prikazi();
            
            //liskov substitution
            INaziv naziv = new PredmetService();
            var prikaziPredmet = naziv.GetNaziv();
           
            naziv = new StudentService();
            var prikaziStudent = naziv.GetNaziv();

            PorukaDobrodošlice porukaDobrodošlice = new PorukaDobrodošlice();
            var prikaziPorukuStudenta = porukaDobrodošlice.Poruka(prikaziStudent);
            ViewBag.Student = prikaziPorukuStudenta;

            PorukaPredmeta porukaPredmeta = new PorukaPredmeta();
            var prikaziPorukuPredmeta = porukaPredmeta.Poruka(prikaziPredmet);
            ViewBag.Predmet = prikaziPorukuPredmeta;

            PorukaPolaganja porukaPolaganja = new PorukaPolaganja();
            var prikaziPorukuPolaganja = porukaPolaganja.Poruka("Polaganja");
            ViewBag.Polaganja = prikaziPorukuPolaganja;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
