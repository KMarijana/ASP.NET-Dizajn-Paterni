using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IPredmetService
    {
        void Create(Predmet predmet);
        void Delete(Predmet predmet);
        Predmet FindByID(int? id);
        List<Predmet> FindAll();
        void Update(Predmet predmet);
    }
}
