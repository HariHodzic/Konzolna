using System;
using Konzolna.Models;
using Konzolna.EF;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Konzolna
{
    class Program
    {
        static string crt = "=======================================================";
        static void Main(string[] args)
        {
            int x = 1;
            UnosFaktura();
            while (x == 1)
            {
                UnosProizvoda();

                UnosStavkeFakture();
                Console.WriteLine("Unesite broj 1 ako zelite unijeti novi zapis:");
                x = Convert.ToInt32(Console.ReadLine());
            }

            UnosKupaca();
            UnosOpstina();
            Ispis();
            MyContext db = new MyContext();
            Faktura l = db.Faktura.First(a => a.Id == 1);
            Console.WriteLine();
            float Suma = db.StavkaFakture.Where(s => s.FakturaID == l.Id).Sum(x => x.Kolicina * x.Proizvod.Cijena);
            Console.WriteLine("Suma je " + Suma);//OVO JE NACIN RACUNANJA SUME PREKO SQL UPITA
            float suma=0;
            List<StavkaFakture> sf = db.StavkaFakture
                .Include("Proizvod")
                .Where(s => s.FakturaID == l.Id).ToList();
            foreach (StavkaFakture s in sf)
            {
                suma = suma + s.Proizvod.Cijena * s.Kolicina;
            }
            Console.WriteLine("Suma je " + suma);//OVO JE NACIN RACUNANJA sume U APLIKACIJI

            db.Dispose();
            
        }
        private static void UnosProizvoda()
        {
            MyContext db = new MyContext();
            Console.WriteLine(crt);

            Proizvod f = new Proizvod();
            Console.WriteLine("Unesite ime proizvoda:");
            f.Naziv =Console.ReadLine();
            Console.WriteLine("Unesite cijenu proizvoda:");
            f.Cijena = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite mjernu jedinicu proizvoda:");
            f.JedinicaMjere = Console.ReadLine(); 
            db.Add(f);
            db.SaveChanges();
            db.Dispose();
        }
        private static void UnosStavkeFakture()
        {
            MyContext db = new MyContext();
            Console.WriteLine(crt);

            StavkaFakture f = new StavkaFakture();
            Console.WriteLine("Unesite ID fakture za ovu stavku:");
            f.FakturaID = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite ID proizvoda:");
            f.ProizvodID = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite kolicinu:");
            f.Kolicina = int.Parse(Console.ReadLine());

            db.Add(f);
            db.SaveChanges();
            db.Dispose();
        }
        private static void UnosFaktura()
        {
            MyContext db = new MyContext();
            Console.WriteLine(crt);

            Faktura f = new Faktura();
            f.Datum = DateTime.Now;
            Ispis();
            Console.WriteLine("Unesite ID kupca:");
            f.KupacID = int.Parse(Console.ReadLine());
            db.Add(f);
            db.SaveChanges();
            db.Dispose();
        }
        private static void UnosKupaca()
        {
            MyContext db = new MyContext();
            int x = 1;
            Console.WriteLine("Unesite broj 1 ako zelite unijeti novog kupca:");
            x = Convert.ToInt32(Console.ReadLine());
            while (x == 1)
            {
                x = 0;
                Console.WriteLine("Unesite ime novog kupca:");
                Kupac k = new Kupac();
                k.Naziv = Console.ReadLine();
                Console.WriteLine("Unesite ID opstine prebivalista kupca:");
                k.OpstinaPrebivalistaID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Unesite ID opstine rodjenja kupca:");
                k.OpstinaRodjenjaID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Unesite broj 1 ako zelite nastaviti:");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(crt);
                db.Add(k);
                db.SaveChanges();
            }
            Console.WriteLine(crt);
            db.Dispose();
        }
        private static void UnosOpstina()
        {
            MyContext db = new MyContext();
            int x = 1;
            Console.WriteLine("Unesite broj 1 ako zelite unijeti novu opstinu:");
            x = Convert.ToInt32(Console.ReadLine());
            while (x == 1)
            {

                x = 0;
                Console.WriteLine("Unesite ime nove opstine:");
                Opstina o = new Opstina();
                o.Naziv = Console.ReadLine();
                Console.WriteLine("Unesite ime drzave opstine:");
                o.Drzava = Console.ReadLine();
                Console.WriteLine("Unesite broj 1 ako zelite nastaviti:");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(crt);
                db.Add(o);
                db.SaveChanges();
            }
            db.Dispose();
        }
        private static void Ispis()
        {
            MyContext db = new MyContext();
            List<Kupac> kupci = db.Kupac
               .Include(a => a.OpstinaRodjenja)
               .Include("OpstinaPrebivalista")
               .ToList();
            foreach (Kupac k in kupci)
            {
                Opstina oRod = k.OpstinaRodjenja;
                Opstina oPreb = k.OpstinaPrebivalista;
                Console.WriteLine("ID Kupca: " + k.Id);
                Console.WriteLine("Ime Kupca: " + k.Naziv);
                Console.WriteLine("ID opstine prebivalista kupca: " + k.OpstinaPrebivalistaID);
                Console.WriteLine("Ime opstine prebivalista kupca: " + oPreb.Naziv);
                Console.WriteLine("ID opstine rodjenja kupca: " + k.OpstinaRodjenjaID);
                Console.WriteLine("Ime opstine rodjenja kupca: " + oRod.Naziv);
                Console.WriteLine(crt);
                db.Dispose();
            }
        }
    }
}
