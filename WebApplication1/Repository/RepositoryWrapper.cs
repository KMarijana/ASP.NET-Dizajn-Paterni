using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private KontekstSkole _context;
        private IStudentRepository _student;
        private IPredmetRepository _predmet;

        public RepositoryWrapper(KontekstSkole repositoryContext)
        {
            _context = repositoryContext;
        }

        //implementacija nasleđenih metoda
        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_context);
                }
                return _student;
            }
        }

        public IPredmetRepository Predmet
        {
            get
            {
                if (_predmet == null)
                {
                    _predmet = new PredmetRepository(_context);
                }
                return _predmet;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
