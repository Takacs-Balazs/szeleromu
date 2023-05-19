using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadando
{
    internal class Szeleromu
    {
        public string Nev { get; set; }
        public double Teljesitmeny { get; set; }
        public int Magassag { get; set; }
        public string Varos { get; set; }
        public DateTime MukesKezdete { get; set; }
        public Szeleromu(string helyszin, int egységek, int teljesitmeny, int mukesKezdete)
        {
            Nev = helyszin;
            Magassag = egységek;
            Teljesitmeny = teljesitmeny;
            MukesKezdete = new DateTime(mukesKezdete, 1, 1);
        }
        public char GetCategory()
    {
        if (Teljesitmeny >= 1000)
        {
            return 'A';
        }
        else if (Teljesitmeny >= 500 && Teljesitmeny < 1000)
        {
            return 'B';
        }
        else
        {
            return 'C';
        }
    }
    }
}

   


    