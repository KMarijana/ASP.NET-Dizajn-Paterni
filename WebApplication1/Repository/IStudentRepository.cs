using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    //nasleđivanje baznog repositorijuma
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        //metoda koja se odnosi samo na studenta
        Student Details(int? id);
    }
}
