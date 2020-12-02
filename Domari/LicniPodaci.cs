using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domari
{
    public enum Spol
    {
        Muško,
        Žensko
    }

    public class LicniPodaci
    {
        #region Atributi

        string ime, prezime, mjestoRodjenja, email, slika, jmbg;
        Spol spol;
        DateTime datumRodjenja;

        #endregion

        #region Properties

        public string Ime
        {
            get => ime;
            set
            {
                if (String.IsNullOrWhiteSpace(value)
                    || !(value.Substring(0, 1).Any(char.IsUpper)
                    && value.Substring(1).All(char.IsLower)))
                    throw new FormatException("Ime nije ispravno!");

                ime = value;
            }
        }

        public string Prezime
        {
            get => prezime;
            set
            {
                if (String.IsNullOrWhiteSpace(value)
                    || !(value.Substring(0, 1).Any(char.IsUpper)
                    && value.Substring(1).All(char.IsLower)))
                    throw new FormatException("Prezime nije ispravno!");

                prezime = value;
            }
        }

        public string MjestoRodjenja
        {
            get => mjestoRodjenja;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new FormatException("Mjesto rođenja je prazno!");

                mjestoRodjenja = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new FormatException("Polje email je prazno!");

                email = value;
            }
        }

        public string Slika
        {
            get => slika;
            set => slika = value;
        }

        public string JMBG
        {
            get => jmbg;
            set
            {
                if (String.IsNullOrWhiteSpace(value)
                    || value.Length != 13
                    || !value.All(char.IsDigit))
                    throw new FormatException("Neispravan format matičnog broja!");

                jmbg = value;
            }
        }

        public Spol Spol
        {
            get => spol;
            set => spol = value;
        }

        public DateTime DatumRodjenja
        {
            get => datumRodjenja;
            set
            {
                if (value > DateTime.Now)
                    throw new FormatException("Neispravan datum!");

                datumRodjenja = value;
            }
        }

        #endregion

        #region Konstruktor

        public LicniPodaci(string i, string p, string m, string e, string s, string j, Spol sp, DateTime d)
        {
            Ime = i;
            Prezime = p;
            MjestoRodjenja = m;
            Email = e;
            Slika = s;
            JMBG = j;
            Spol = sp;
            DatumRodjenja = d;
        }

        public LicniPodaci()
        {

        }

        #endregion

    }
}
