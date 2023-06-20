using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        public static void Initialize(KontekstSkole context)
        {
            context.Database.EnsureCreated();

            // Provera da li postoje podaci u bazi
            if (context.Studenti.Any())
            {
                return;   // Baza podataka je popunjena
            }
            
            var studenti = new Student[]
            {
                new Student{Ime="Ana", Prezime="Nikolić", BrojIndexa="MIT 3/22"},
                new Student{Ime="Marko",Prezime="Dimitrijević",BrojIndexa="SI 4/20"},
                new Student{Ime="Aleksa",Prezime="Savić",BrojIndexa="IT 5/19"},
                new Student{Ime="Gabriela",Prezime="Marković",BrojIndexa="MIT 8/20"},
                new Student{Ime="Ivana",Prezime="Marković",BrojIndexa="MIT 10/22"},
                new Student{Ime="Petar",Prezime="Kostić",BrojIndexa="IT 3/16"},
                new Student{Ime="Laura",Prezime="Petrović",BrojIndexa="SI 16/19"},
                new Student{Ime="Nina",Prezime="Perić",BrojIndexa="SI 2/20"}
            };
            // behaviour -iterator
            foreach (Student s in studenti)
            {
                context.Studenti.Add(s);
            }
            context.SaveChanges();

            // kreacioni - fluent interface
            List<Predmet> fluentPredmeti = new List<Predmet>();

            fluentPredmeti.Add(new FluentPredmet()
                .IDPredmeta(1)
                .NazivPredmeta("Matematika")
                .BodoviPredmeta(5)
                .KreirajPredmet());
            fluentPredmeti.Add(new FluentPredmet()
                .IDPredmeta(2)
                .NazivPredmeta("Fizika")
                .BodoviPredmeta(6)
                .KreirajPredmet());
            fluentPredmeti.Add(new FluentPredmet()
                .IDPredmeta(3)
                .NazivPredmeta("Programiranje")
                .BodoviPredmeta(7)
                .KreirajPredmet());
            fluentPredmeti.Add(new FluentPredmet()
                .IDPredmeta(4)
                .NazivPredmeta("Engleski jezik")
                .BodoviPredmeta(5)
                .KreirajPredmet());

            foreach (Predmet p in fluentPredmeti)
            {
                context.Predmeti.Add(p);
            }
            context.SaveChanges();

            var polaganja = new Polaganje[]
            {
                new Polaganje{StudentID=1,PredmetID=1,DatumPolaganja=DateTime.Parse("2023-09-01"),Ocena=Ocena.A},
                new Polaganje{StudentID=1,PredmetID=2,DatumPolaganja=DateTime.Parse("2023-06-01"),Ocena=Ocena.C},
                new Polaganje{StudentID=1,PredmetID=3,DatumPolaganja=DateTime.Parse("2023-09-11"),Ocena=Ocena.B},
                new Polaganje{StudentID=2,PredmetID=4,DatumPolaganja=DateTime.Parse("2023-06-01"),Ocena=Ocena.B},
                new Polaganje{StudentID=2,PredmetID=1,DatumPolaganja=DateTime.Parse("2023-09-01"),Ocena=Ocena.F},
                new Polaganje{StudentID=2,PredmetID=2,DatumPolaganja=DateTime.Parse("2023-09-01"),Ocena=Ocena.F},
                new Polaganje{StudentID=3,PredmetID=3,DatumPolaganja=DateTime.Parse("2023-09-11"),Ocena=Ocena.A},
                new Polaganje{StudentID=4,PredmetID=4,DatumPolaganja=DateTime.Parse("2023-09-01"),Ocena=Ocena.A},
                new Polaganje{StudentID=4,PredmetID=1,DatumPolaganja=DateTime.Parse("2023-06-21"),Ocena=Ocena.F},
                new Polaganje{StudentID=5,PredmetID=2,DatumPolaganja=DateTime.Parse("2023-09-01"),Ocena=Ocena.C},
                new Polaganje{StudentID=6,PredmetID=3,DatumPolaganja=DateTime.Parse("2023-09-01"),Ocena=Ocena.A},
                new Polaganje{StudentID=7,PredmetID=4,DatumPolaganja=DateTime.Parse("2023-09-21"),Ocena=Ocena.A},
            };
            foreach (Polaganje p in polaganja)
            {
                context.Polaganja.Add(p);
            }
            context.SaveChanges();
        }
    }
}
