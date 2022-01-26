using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022
{
    class fuvar
    {
        public int TaxiAzonosító { get; set; }
        public DateTime IndulásIdőpontja { get; set; }
        public int UtazásiIdő { get; set; }
        public double TávMérföldben { get; set; }
        public double ViteldíjDollárban { get; set; }
        public double BorravalóDollárban { get; set; }
        public string FizetésMódja { get; set; }

        public fuvar (string sor)
        {
            string[] x = sor.Split(';');
            this.TaxiAzonosító = int.Parse(x[0]);
            this.IndulásIdőpontja = DateTime.Parse(x[1]);
            this.UtazásiIdő = int.Parse(x[2]);
            this.TávMérföldben = double.Parse(x[3]);
            this.ViteldíjDollárban = double.Parse(x[4]);
            this.BorravalóDollárban = double.Parse(x[5]);
            this.FizetésMódja = x[6];

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<fuvar> fuvarok = new List<fuvar>();
            foreach (var sor in File.ReadAllLines("fuvar.csv").Skip(1))
            {
                fuvarok.Add(new fuvar(sor));
                
            }
            Console.WriteLine($"3.feladat: {fuvarok.Count} fuvar");
            //4.feladat:
            int fuvartszámol = 0;
            double pénztszámol = 0;
            foreach (var f in fuvarok)
            {
                if (f.TaxiAzonosító==6185)
                {
                    fuvartszámol = fuvartszámol + 1;
                    pénztszámol = pénztszámol + f.ViteldíjDollárban;
                }
            }
            Console.WriteLine($"4.feladat: {fuvartszámol} fuvar alatt: {pénztszámol}$");
            //5.feladat:
            int készpénz = 0;
            int bankkártya = 0;
            int vitatott = 0;
            int ingyenes = 0;
            int ismeretlen = 0;
            foreach (var u in fuvarok)
            {
                if (u.FizetésMódja=="készpénz")
                {
                    készpénz = készpénz + 1;
                }
                if (u.FizetésMódja=="bankkártya")
                {
                    bankkártya = bankkártya + 1;
                }
                if (u.FizetésMódja == "vitatott")
                {
                    vitatott = vitatott + 1;
                }
                if (u.FizetésMódja == "ingyenes")
                {
                    ingyenes = ingyenes + 1;
                }
                if (u.FizetésMódja == "ismeretlen")
                {
                    ismeretlen = ismeretlen + 1;
                }
            }
            Console.WriteLine("5.feladat: ");
            Console.WriteLine($"Készpénz: {készpénz} fuvar");
            Console.WriteLine($"Bankkártya: {bankkártya} fuvar");
            Console.WriteLine($"Vitatott: {vitatott} fuvar");
            Console.WriteLine($"Ingyenes: {ingyenes} fuvar");
            Console.WriteLine($"Ismeretlen: {ismeretlen} fuvar");
            Console.ReadKey();
        }
    }
}
