using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
    public class PredmetRepository : RepositoryBase<Predmet>, IPredmetRepository
    {
        public PredmetRepository(KontekstSkole repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
