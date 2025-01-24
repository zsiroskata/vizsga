using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace vizsga
{
    internal class Vizsgazo
    {
        public string Nev { get; set; }
        public double IT { get; set; }
        public double Programozas { get; set; }
        public double HalozatA { get; set; }
        public double HalozatB { get; set; }
        public double HalozatC { get; set; }
        public double HalozatD { get; set; }
        public double SzobeliAngol { get; set; }
        public double SzobeliIT { get; set; }

        public Vizsgazo(string sor)
        {
            var s = sor.Split(";");
            Nev = s[0];
            IT = double.Parse(s[1]);
            Programozas = double.Parse(s[2]);
            HalozatA = double.Parse(s[3]);
            HalozatB = double.Parse(s[4]);
            HalozatC = double.Parse(s[5]);
            HalozatD = double.Parse(s[6]);
            SzobeliAngol = double.Parse(s[7]);
            SzobeliIT = double.Parse(s[8]);
        }

        public double vegeredmeny(double szam)
        {
            return szam * 100;
        }

        public string erdemjegy(double jegy)
        {
            jegy = jegy * 100;
            string szoveg= string.Empty;
            if (jegy >= 81 && jegy <= 100)
            {
                szoveg = "jeles";
            }
            else if (jegy >= 71 && jegy <= 80)
            {
                szoveg = "jó";
            }
            else if (jegy >= 61 && jegy <= 70)
            {
                szoveg = "közepes";
            }
            else if (jegy >= 51 && jegy <= 60)
            {
                szoveg = "elégséges";
            }
            else 
            {
                szoveg = "elégtelen";
            }


            return szoveg;
        }

        public double LegjobbEredmeny()
        {
            return new List<double> { IT, Programozas, HalozatA, HalozatB, HalozatC, HalozatD, SzobeliAngol, SzobeliIT }.Max()*100;
        }

        public double LeggyengebbEredmeny()
        {
            return new List<double> { IT, Programozas, HalozatA, HalozatB, HalozatC, HalozatD, SzobeliAngol, SzobeliIT }.Min()*100;
        }
    }
}
