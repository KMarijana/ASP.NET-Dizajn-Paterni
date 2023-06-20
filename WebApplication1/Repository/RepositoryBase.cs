using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected KontekstSkole Context { get; set; }

        private List<T> _list;
        public RepositoryBase(KontekstSkole repositoryContext)
        {
            Context = repositoryContext;
            _list = Context.Set<T>().ToList();
        }

        //implementacija metoda, rad sa bazom podatka
        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public List<T> FindAll()
        {
            return _list;
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public T FindByID(int? id)
        {
            return Context.Set<T>().Find(id);
        }
    }
}
