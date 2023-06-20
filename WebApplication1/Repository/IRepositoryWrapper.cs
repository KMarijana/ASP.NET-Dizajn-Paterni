using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    //grupisanje interfejsa i predstavlja tačku pristupa
    public interface IRepositoryWrapper
    {
        //property
        IStudentRepository Student { get; }
        IPredmetRepository Predmet { get; }
        void Save();
    }
}
