﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class PorukaDobrodošlice : BaznaPoruka
    {
        public override string Poruka(string poruka)
        {
            return "Dobrodošli " + base.Poruka(poruka);
        }

    }
}
