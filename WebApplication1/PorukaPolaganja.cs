using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PorukaPolaganja : BaznaPoruka
    {
        public override string Poruka(string poruka)
        {
            return "Sva " + base.Poruka(poruka);
        }
    }
}
