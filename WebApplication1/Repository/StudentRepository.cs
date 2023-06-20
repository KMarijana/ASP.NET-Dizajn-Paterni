using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private KontekstSkole _context;

        public StudentRepository(KontekstSkole repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public Student Details(int? id)
        {
            return _context.Studenti.Include(s => s.Polaganja).ThenInclude(e => e.Predmet).FirstOrDefault(m => m.StudentID == id);
        }
    }
}
