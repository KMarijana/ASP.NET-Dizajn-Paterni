using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class KontekstSkole : DbContext
    {
        //konstruktor koji prosleđuje objekat konstruktoru bazne klase dbcontext
        public KontekstSkole(DbContextOptions<KontekstSkole> options) : base(options)
        {
        }
        //dbset property za svaki entitet/model i odgovara tabelama u bazi
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Polaganje> Polaganja { get; set; }
        public DbSet<Student> Studenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predmet>().ToTable("Predmet");
            modelBuilder.Entity<Polaganje>().ToTable("Polaganje");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
