using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PorukaPredmeta : BaznaPoruka
    {
        public override string Poruka(string poruka)
        {
            return "Svi " + base.Poruka(poruka);
        }
    }
}
