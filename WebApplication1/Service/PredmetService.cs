using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class PredmetService : IPredmetService, INaziv
    {
        // privatni atributi
        private readonly IPredmetRepository _predmetRepository;
        private readonly IRepositoryWrapper _repository;
        private List<Predmet> _predmeti;

        //konstruktor bez parametara
        public PredmetService() { }

        //konstuktora sa parametrima, implementacija dependency inversion
        public PredmetService(IPredmetRepository predmetRepository, IRepositoryWrapper repository)
        {
            _predmetRepository = predmetRepository;
            _repository = repository;
            _predmeti = _predmetRepository.FindAll();
        }

        //implementacija nasleđenih metoda
        public void Create(Predmet predmet)
        {
            _predmetRepository.Create(predmet);
            _repository.Save();
        }

        public void Delete(Predmet predmet)
        {
            _predmetRepository.Delete(predmet);
            _repository.Save();
        }

        public Predmet FindByID(int? id)
        {
            return _predmetRepository.FindByID(id);
        }

        public List<Predmet> FindAll()
        {
            return _predmetRepository.FindAll();
        }

        public void Update(Predmet predmet)
        {
            _predmetRepository.Update(predmet);
            _repository.Save();
        }

        public string GetNaziv()
        {
            return "Predmeti";
        }
    }
}
