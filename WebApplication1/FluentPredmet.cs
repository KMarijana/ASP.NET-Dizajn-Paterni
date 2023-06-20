using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class FluentPredmet
    {
        private Predmet predmet = new Predmet();
        
        public FluentPredmet NazivPredmeta(string Naziv)
        {
            predmet.Naziv = Naziv;
            return this;
        }

        public FluentPredmet IDPredmeta(int PredmetID)
        {
            predmet.PredmetID = PredmetID;
            return this;
        }

        public FluentPredmet BodoviPredmeta(int Bodovi)
        {
            predmet.Bodovi = Bodovi;
            return this;
        }

        public Predmet KreirajPredmet()
        {
            return predmet;
        }

    }
}
