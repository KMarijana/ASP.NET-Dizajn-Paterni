using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IRepositoryBase<T>
    {
        //metode koje se nasleđuju, tip se navodi posebno za svaku klasu koja ga naslđuje
        List<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindByID(int? id);
    }
}
