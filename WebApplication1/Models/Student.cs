using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        //public property
        public int StudentID { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string BrojIndexa { get; set; }

        //objekat tipa Polaganje, i kolekcija omogućava crud operacije
        public ICollection<Polaganje> Polaganja { get; set; }
    }
}
