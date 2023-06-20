using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public enum Ocena
    {
        A, B, C, D, F
    }

    public class Polaganje
    {
        // privatni atributi
        private int polaganjeID;
        private int predmetID;
        private int studentID;
        private DateTime datumPolaganja;
        private Ocena? ocena;
        private Predmet predmet;
        private Student student;

        //property
        public int PolaganjeID 
        {
            get { return polaganjeID; }
            set { polaganjeID = value; }
        }

        public int PredmetID 
        {
            get { return predmetID; }
            set { predmetID = value; }
        }

        public int StudentID 
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public DateTime DatumPolaganja 
        {
            get { return datumPolaganja; }
            set { datumPolaganja = value; }
        }

        public Ocena? Ocena 
        {
            get { return ocena; }
            set { ocena = value; }
        }

        public Predmet Predmet 
        {
            get { return predmet; }
            set { predmet = value; }
        }

        public Student Student 
        {
            get { return student; }
            set { student = value; }
        }
    }
}
