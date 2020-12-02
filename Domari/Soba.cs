using System;
using System.Collections.Generic;
using System.Text;

namespace Domari
{
    public class Soba
    {
        #region Atributi

        int brojSobe, kapacitet;
        List<Student> stanari;

        #endregion

        #region Properties

        public int BrojSobe
        {
            get => brojSobe;
        }

        public int Kapacitet
        {
            get => kapacitet;
            set => kapacitet = value;
        }

        public List<Student> Stanari
        {
            get => stanari;
        }

        #endregion

        #region Konstruktor

        public Soba(int id, int veličina)
        {
            brojSobe = id;
            kapacitet = veličina;
            stanari = new List<Student>();
        }

        #endregion

        #region Metode

        public void DodajStanara(Student student)
        {
            if (Stanari.Count == Kapacitet)
                throw new InvalidOperationException("Soba je popunjena!");

            Stanari.Add(student);
        }

        public void IsprazniSobu()
        {
            Stanari.Clear();
        }

        public void IzbaciStudenta(Student student)
        {
            Student stanar = Stanari.Find(s => s.IdentifikacioniBroj == student.IdentifikacioniBroj);

            if (stanar == null)
                throw new ArgumentException("Student nije stanar sobe!");

            Stanari.Remove(stanar);
        }

        public bool DaLiJeStanar(Student student)
        {
            return Stanari.Find(s => s.IdentifikacioniBroj == student.IdentifikacioniBroj) != null;
        }

        /// <summary>
        /// Metoda u kojoj se vrši promjena broja sobe.
        /// Ukoliko je broj između 100 i 199, kapacitet sobe je 2.
        /// Ukoliko je broj između 200 i 299, kapacitet sobe je 3.
        /// Ukoliko je broj između 300 i 399, kapacitet sobe je 4.
        /// Svi ostali brojevi nisu ispravni.
        /// Ukoliko u sobi ima više stanara od novog kapaciteta, potrebno ih je izbaciti iz sobe.
        /// </summary>
        /// <param name="noviBroj"></param>
        public void PromjenaBrojaSobe(int noviBroj)
        {
            if (noviBroj < this.Kapacitet)
            {
                List<Student> stanari = this.Stanari;
                for (int i = 0; i < this.Kapacitet - noviBroj; i++)
                {
                    this.IzbaciStudenta(stanari[i]);
                }
            }

            if (noviBroj >= 100 && noviBroj <= 199)
            {
                this.Kapacitet = 2;
            }
            else if (noviBroj >= 200 && noviBroj <= 299)
            {
                this.Kapacitet = 3;
            }
            else if (noviBroj >= 300 && noviBroj <= 399)
            {
                this.Kapacitet = 4;
            }
            else
            {
                Console.WriteLine("Broj sobe nije validan!");
            }
        }

        #endregion
    }
}
