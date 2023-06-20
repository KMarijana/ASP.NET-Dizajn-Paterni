using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IStudentService
    {
        void Create(Student student);
        Student Details(int? id);
        void Delete(Student student);
        Student FindByID(int? id);
        List<Student> FindAll();
        void Update(Student student);
    }
}
