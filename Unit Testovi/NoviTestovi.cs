using Domari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;



namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]

        [ExpectedException(typeof(NotImplementedException))]
        public void TestZamjenskiObjekat()
        {
            StudentskiDom dom = new StudentskiDom(15);

            Student s = new Student();
            s.Skolovanje = new Skolovanje();
            s.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s, 0);

            IPodaci paviljon = new Paviljon();

            List<Student> studenti = dom.DajStudenteIzPaviljona(paviljon);

            Assert.IsTrue(studenti.Find(student => student.IdentifikacioniBroj == s.IdentifikacioniBroj) != null);
        }


        #endregion

        #region TDD

        [TestMethod]
        public void TestPrviCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(1, 1);

            Assert.AreEqual(1800, skolarina);
        }

        [TestMethod]
        public void TestDrugiCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(2, 2);

            Assert.AreEqual(2000, skolarina);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravniPodaci()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(7, 0);
        }


        [TestMethod]
        public void TestPromjenaSobePovecajKapacitet()
        {
            StudentskiDom dom = new StudentskiDom(10);
            Soba s = new Soba(199, 2);
            dom.PromjenaSobe(s, 5);
            Assert.AreEqual(5, s.Kapacitet);
        }

        [TestMethod]
        public void TestPromjenaSobeIsprazniSobu()
        {
            StudentskiDom dom = new StudentskiDom(10);
            Soba s = new Soba(199, 2);
            dom.PromjenaSobe(s, 2);
            Assert.AreEqual(0, s.Stanari.Count);
        }
        [TestMethod]
        public void TestPromjenaPromjenaBrojaSobe1()
        {
            Soba s = new Soba(199, 2);
            s.PromjenaBrojaSobe(100);
            Assert.AreEqual(2, s.Kapacitet);
        }


        [TestMethod]
        public void TestPromjenaPromjenaBrojaSobe2()
        {
            Soba s = new Soba(200, 3);
            s.PromjenaBrojaSobe(301);
            Assert.AreEqual(4, s.Kapacitet);
        }

        #endregion
        static LicniPodaci l;
        static Skolovanje skol;
        static Student s;
        static StudentskiDom sd;
        static Soba soba;
        static IPodaci paviljon;



        //Testiranje dodavanja studenta u studentski dom
        [TestMethod]
        public void TestDodajStudenta()
        {//dodajemo studenta
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            sd.UpisUDom(s, 1, true);
            sd.RadSaStudentom(s, 0);
            //provjeramo da li je student dodan u listu studenata jer je dodat samo 1 student
            Assert.AreEqual(1, sd.Studenti.Count);
            //provjeravamo da li se nalazi student kojeg smo mi ddali
            Assert.IsTrue(sd.Studenti.Contains(s));

        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void TestStudentskiDomDodavanjeIstogStudenta()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            sd.UpisUDom(s, 1, true);
            sd.RadSaStudentom(s, 0);
            //provjeramo da li je student dodan u listu studenata jer je dodat samo 1 student
            Assert.AreEqual(1, sd.Studenti.Count);
            //provjeravamo da li se nalazi student kojeg smo mi ddali
            Assert.IsTrue(sd.Studenti.Contains(s));
            sd.RadSaStudentom(s, 0);


        }
        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void TestStudentskiDomRadSaStudnetom2()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            sd.RadSaStudentom(s, 2);
            //promjena sobe
            sd.PromjenaSobe(soba, 3);
            Assert.AreEqual(3, soba.Kapacitet);

            sd.PromjenaSobe(soba, 0);
            Assert.AreEqual(0, soba.Stanari);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        //nije stanar ni jedne sobe
        public void TestSDRadSaStudentom1()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            sd.RadSaStudentom(s, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestPaviljon()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            paviljon.DajImePaviljona();
        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void KorisnikPromjenaPass()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            s.PromjenaPassworda("asdfq", "asdvb1234");
        }

        [TestMethod]
        public void TestIzbaciStudenta()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            sd.UpisUDom(s, 1, true);
            sd.RadSaStudentom(s, 0);
            //provjeramo da li je student dodan u listu studenata jer je dodat samo 1 student
            Assert.AreEqual(1, sd.Studenti.Count);
            //provjeravamo da li se nalazi student kojeg smo mi ddali
            Assert.IsTrue(sd.Studenti.Contains(s));
            soba.DodajStanara(s);
            Assert.IsTrue(soba.DaLiJeStanar(s));
            soba.IzbaciStudenta(s);
            Assert.IsFalse(soba.DaLiJeStanar(s));
            sd.RadSaStudentom(s, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void studentskiDomException()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol); 
            Student s2 = new Student("imee", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(100, 1);
            paviljon = new Paviljon();

            sd.UpisUDom(s, 2, false);
            soba.DodajStanara(s);
            sd.UpisUDom(s2, 1, false);


        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void studentskiDomException2()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol); 
            Student s2 = new Student("imee", "P21as12s", l, null, skol);
            Student s3 = new Student("imeee", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(100, 2);
            paviljon = new Paviljon();

            sd.UpisUDom(s, 1, true);
            soba.DodajStanara(s);
            sd.UpisUDom(s2, 1, false);
            soba.DodajStanara(s2);
            sd.UpisUDom(s3, 1, false);


        }

        [TestMethod]
        public void TestIsprazniSobu()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            sd.UpisUDom(s, 1, true);
            sd.RadSaStudentom(s, 0);
            //provjeramo da li je student dodan u listu studenata jer je dodat samo 1 student
            Assert.AreEqual(1, sd.Studenti.Count);
            //provjeravamo da li se nalazi student kojeg smo mi ddali
            Assert.IsTrue(sd.Studenti.Contains(s));
            soba.DodajStanara(s);
            Assert.IsTrue(soba.DaLiJeStanar(s));
            soba.IsprazniSobu();
            Assert.IsFalse(soba.DaLiJeStanar(s));


        }


        [TestMethod]
        public void TestSkolovanjePromjenaCiklusa()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();

            Assert.AreEqual(2000, skol.PromjenaGodineStudija(1, 2));


        }

        [TestMethod]
        public void TestSobaPromjenaSobe()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(100, 1);
            soba.DodajStanara(s);
            paviljon = new Paviljon();

            soba.PromjenaBrojaSobe(1);
            Assert.AreEqual(100, soba.BrojSobe);

            soba.PromjenaBrojaSobe(169);
            Assert.AreEqual(2, soba.Kapacitet);


            soba.PromjenaBrojaSobe(200);
            Assert.AreEqual(3, soba.Kapacitet);

            soba.PromjenaBrojaSobe(369);
            Assert.AreEqual(4, soba.Kapacitet);
            soba.PromjenaBrojaSobe(100);
            Assert.AreEqual(2, soba.Kapacitet);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void sobaException()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
           LicniPodaci l2 = new LicniPodaci("Imee", "Prezimee", "mjestoo", "email2", "slika2", "1111111111112", Spol.Muško, DateTime.Now);
           Student s2 = new Student("ime2", "P21as12s", l, null, skol);
            LicniPodaci l3 = new LicniPodaci("Imeee", "Prezimeee", "mjestooo", "email3", "slika3", "1111111111113", Spol.Muško, DateTime.Now);
           Student s3 = new Student("ime3", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(100, 2);
            paviljon = new Paviljon();
            soba.DodajStanara(s);
            soba.DodajStanara(s2);
            soba.DodajStanara(s3);




        }

        [TestMethod]
        public void TestPromjenaPromjenaBrojaSobe3()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
           Student s = new Student("ime", "P21as12s", l, null, skol);
            LicniPodaci l2 = new LicniPodaci("Imee", "Prezimee", "mjestoo", "email2", "slika2", "1111111111112", Spol.Muško, DateTime.Now);
            Student s2 = new Student("ime2", "P21as12s", l, null, skol);
            LicniPodaci l3 = new LicniPodaci("Imeee", "Prezimeee", "mjestooo", "email3", "slika3", "1111111111113", Spol.Muško, DateTime.Now);
            Student s3 = new Student("ime3", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(200, 3);
            paviljon = new Paviljon();
            soba.DodajStanara(s);
            soba.DodajStanara(s2);
            soba.DodajStanara(s3);

            soba.PromjenaBrojaSobe(2);
            Assert.AreEqual(2, soba.Stanari.Count);
        }


        [TestMethod]
        public void testStudent()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Now);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();
            Assert.AreEqual("ime", s.Username);
            Assert.AreEqual(1000, s.StanjeRacuna);
            s.AzurirajStanjeRacuna(100);
            Assert.AreEqual(1100, s.StanjeRacuna);

            s.PromjenaInformacijaOSkolovanju("Elektrotehnički fakultet", 1, 2);
            Assert.AreEqual(2, skol.CiklusStudija);
            s.PromjenaInformacijaOSkolovanju("Elektrotehnički fakultet", 2, 2);
            Assert.AreEqual(2, skol.GodinaStudija);
            s.PromjenaInformacijaOSkolovanju("Poljoprivredni fakultet", 2, 2);
            Assert.AreEqual("Poljoprivredni fakultet", skol.MaticniFakultet);

        }
        [TestMethod]
        public void testPlicniPodaci()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Today);
            skol = new Skolovanje();
            s = new Student("ime", "P21as12s", l, null, skol);
            sd = new StudentskiDom(500);
            soba = new Soba(1, 100);
            paviljon = new Paviljon();

            Assert.AreEqual("Ime", l.Ime);
            Assert.AreEqual("Prezime", l.Prezime);
            Assert.AreEqual("mjesto", l.MjestoRodjenja);
            Assert.AreEqual("email", l.Email);
            Assert.AreEqual("slika", l.Slika);
            Assert.AreEqual("1111111111111", l.JMBG);
            Assert.AreEqual(Spol.Muško, l.Spol);
            Assert.AreEqual(DateTime.Today, l.DatumRodjenja);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void KorisnikExepction()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Today);
            skol = new Skolovanje();
            s = new Student("", "asd", l, null, skol);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void KorisnikExepction2()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Today);
            skol = new Skolovanje();
            s = new Student("Asd", "asd", l, null, skol);

        }
        [TestMethod]
         [ExpectedException(typeof(FormatException))]
         public void testExepctionLicniPodaci()
        {
            l = new LicniPodaci("Im2e", "Prezime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Today);

        }
        [TestMethod]
         [ExpectedException(typeof(FormatException))]
         public void testExepctionLicniPodaci2()
        {
            l = new LicniPodaci("Ime", "Pre2zime", "mjesto", "email", "slika", "1111111111111", Spol.Muško, DateTime.Today);

        }
        
        [TestMethod]
         [ExpectedException(typeof(FormatException))]
         public void testExepctionLicniPodaci3()
        {
            l = new LicniPodaci("Ime", "Prezime", "", "email", "slika", "1111111111111", Spol.Muško, DateTime.Today);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void testExepctionLicniPodaci4()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "", "slika", "1111111111111", Spol.Muško, DateTime.Today);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void testExepctionLicniPodaci5()
        {
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "email", "slika", "11a", Spol.Muško, DateTime.Today);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void testExepctionLicniPodaci6()
        {
            DateTime datum = new DateTime(22,03,5000);
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "mail", "slika", "1111111111111", Spol.Muško,datum);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void testExepctionLicniPodaci7()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
           
            l = new LicniPodaci("Ime", "Prezime", "mjesto", "mail", "slika", "1111111111111", Spol.Muško, tomorrow);

        }
        

        [TestMethod]
        public void testLicnipodaci()
        {
            LicniPodaci podaci = new LicniPodaci();
            Assert.IsInstanceOfType(podaci, typeof(LicniPodaci));




        }
        [TestMethod]
        public void testDodajStanara()
        {
            Student s = new Student("ime", "P21as12s", l, null, skol);
            Soba soba = new Soba(1, 2);
            soba.DodajStanara(s);

            Assert.AreEqual(2, soba.Kapacitet);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testDodajStanaraexception()
        {
            Student s = new Student("ime", "P21as12s", l, null, skol);
            Soba soba = new Soba(100, 2);

            soba.IzbaciStudenta(s);
            
        }


        [TestMethod]
        public void testStudentskiDom()
        {
            StudentskiDom sd = new StudentskiDom(10);
            Assert.IsInstanceOfType(sd, typeof(StudentskiDom));
        }

        [TestMethod]
        public void testSoba()
        {
            Soba s = new Soba(10, 5);
            Assert.IsInstanceOfType(s, typeof(Soba));
        }

        [TestMethod]
        public void testSkolovanje()
        {
            Skolovanje s = new Skolovanje();
            Assert.IsInstanceOfType(s, typeof(Skolovanje));
        }

        [TestMethod]
        public void testAzurirajStanjeRacuna1()
        {
            Student s = new Student("ime", "P21as12s", l, null, skol);
            s.AzurirajStanjeRacuna(1000);
            Assert.AreEqual(2000, s.StanjeRacuna);
        }

        [TestMethod]
        public void testAzurirajStanjeRacuna2()
        {
            Student s = new Student("ime", "P21as12s", l, null, skol);
            s.AzurirajStanjeRacuna(-100);
            Assert.AreEqual(900, s.StanjeRacuna);
        }

    }
}




