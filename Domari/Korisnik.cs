using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domari
{
    public abstract class Korisnik
    {
        #region Atributi

        string username, password;

        #endregion

        #region Properties

        public string Username
        {
            get => username;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new FormatException("Neispravno uneseno korisničko ime!");

                username = value;
            }
        }

        public string Password
        {
            set
            {
                if (String.IsNullOrWhiteSpace(value)
                    || !value.All(char.IsLetterOrDigit)
                    || value.Length < 7)
                    throw new FormatException("Password mora sadržati slova i brojeve!");

                password = value.GetHashCode().ToString();
            }
        }
        #endregion

        #region Konstruktor

        public Korisnik(string u, string p)
        {
            Username = u;
            Password = p;
        }

        public Korisnik()
        {

        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda za promjenu passworda.
        /// Ukoliko verifikacioni string nije jednak hashiranom passwordu, baca se
        /// izuzetak, kao i u slučaju da password ima nedozvoljenu vrijednost.
        /// Novi password se hashira a zatim spašava.
        /// </summary>
        /// <returns></returns>
        public void PromjenaPassworda(string verifikacija, string novi)
        {
            if (!verifikacija.Equals(this.password.GetHashCode().ToString()))
                throw new FormatException("Nije jednak password!");

            this.Password = novi; // poziva se setter koji provjerava vrijednost, zatim je hashira i spašava
        }

        #endregion
    }
}
