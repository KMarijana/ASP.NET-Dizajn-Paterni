using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class StudentService : IStudentService, INaziv, IObaveštenje
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRepositoryWrapper _repository;
        private List<Student> _studenti;

        public StudentService() { }

        //dependency inversion
        public StudentService(IStudentRepository studentRepository, IRepositoryWrapper repository)
        {
            _studentRepository = studentRepository;
            _repository = repository;
            _studenti = _studentRepository.FindAll();
        }

        //implemetnacija nsleđenih metoda
        public void Create(Student student)
        {
            _studentRepository.Create(student);
            _repository.Save();
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
            _repository.Save();
        }

        public Student Details(int? id)
        {
            return _studentRepository.Details(id);
        }
     
        public void Update(Student student)
        {
            _studentRepository.Update(student);
            _repository.Save();
        }

        public Student FindByID(int? id)
        {
            return _studentRepository.FindByID(id);
        }

        public List<Student> FindAll()
        {
            return _studentRepository.FindAll();
        }

        public string GetNaziv()
        {
            return "Studenti";
        }

        public string Prikazi()
        {
            return "Škola - Evidencija polaganja predmeta i studenata";
        }
    }
}
