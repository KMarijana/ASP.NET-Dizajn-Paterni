using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Predmet
    {
        //public property
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PredmetID { get; set; }
        public string Naziv { get; set; }
        public int Bodovi { get; set; }

        // kolekcija koja omogućava crud operacije i naznačuje da da može predmet imati više polaganja
        public ICollection<Polaganje> Polaganja { get; set; }
    }
}
