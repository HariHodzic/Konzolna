using System;
using Konzolna.Models;
using Konzolna.EF;
using System.Collections.Generic;
using System.Linq;

namespace Konzolna
{
    class Program
    {
        static void Main(string[] args)
        {
            string crt = "=======================================================";
            MyContext db = new MyContext();
            int x;
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
            List<Kupac> kupci = db.Kupac.ToList();
            foreach(Kupac k in kupci)
            {

                Console.WriteLine("ID Kupca: " + k.Id);
                Console.WriteLine("Ime Kupca: " + k.Naziv);
                Console.WriteLine("ID opstine prebivalista kupca: " + k.OpstinaPrebivalistaID);
                Console.WriteLine("ID opstine rodjenja kupca: " + k.OpstinaRodjenjaID);
                Console.WriteLine(crt);

            }
            db.Dispose();
        }
    }
}
