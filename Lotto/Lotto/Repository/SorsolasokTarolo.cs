using Lotto.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto.Repository
{
    class SorsolasokTarolo
    {
        public List<Sorsolas> sorsolasok { get; set; }

        public SorsolasokTarolo()
        {
            sorsolasok = new List<Sorsolas>();
        }

        public void beolvasFilebol(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            HashSet<DateTime> beolvasottEgyediDatumok = new HashSet<DateTime>();
            DateTime date;
            while (!sr.EndOfStream)
            {                
                DateTime.TryParse(sr.ReadLine().Replace(";", ""), out date);
                beolvasottEgyediDatumok.Add(date);
            }

            foreach (DateTime item in beolvasottEgyediDatumok)
            {
                sorsolasok.Add(new Sorsolas(item));
                Console.WriteLine("\t"+item.ToShortDateString());
            }

           
        }

        private List<int> otEgyediSzamGeneralasa() {
            List<int> nyeroszamok = new List<int>();
            Random r;

            do
            {
                r = new Random();
                int szam = r.Next(1, 91);
                if (!nyeroszamok.Contains(szam))
                {
                    nyeroszamok.Add(szam);
                }

            } while (nyeroszamok.Count != 5);
            return nyeroszamok;
        }
        public void nyeroszamokGeneralasa() {
            
            foreach (Sorsolas item in sorsolasok)
            {
                item.nyeroSzamok = otEgyediSzamGeneralasa();
                Console.WriteLine("\t"+item.sorsolasDatum.ToShortDateString()+" "+ 
                    item.nyeroSzamok[0] + " " + 
                    item.nyeroSzamok[1] + " " + 
                    item.nyeroSzamok[2] + " " + 
                    item.nyeroSzamok[3] + " " + 
                    item.nyeroSzamok[4]);
            }
        }

        public int getSorsoltSzamokSzamaMegadottDatumig(DateTime date)
        {
            int counter = 0;

            foreach (Sorsolas item in sorsolasok)
            {
                if (item.sorsolasDatum <= date)
                {
                    counter++;
                }
            }

            return counter * 5;
        }

        public void parosParatlan()
        {
            int paros = 0, paratlan = 0;

            foreach (Sorsolas item in sorsolasok)
            {
                foreach (var szam in item.nyeroSzamok)
                {
                    if (szam % 2 == 0)
                    {
                        paros++;
                    }
                    else
                    {
                        paratlan++;
                    }
                }
            }
            Console.WriteLine("\t"+"Páros: " + paros + " Páratlan: " + paratlan);

        }

        public void legtobbNegyvenotAlattiSzam()
        {
            List<DateTime> negyvenotAlatti = new List<DateTime>();
            foreach (Sorsolas item in sorsolasok)
            {                
                int szamlalo = 0;
                foreach (int szam in item.nyeroSzamok)
                {
                    if (szam<45)
                    {
                        szamlalo++;
                    }
                }
                if (szamlalo >= 3)
                {
                    negyvenotAlatti.Add(item.sorsolasDatum);
                }
            }

            foreach (DateTime item in negyvenotAlatti)
            {
                Console.WriteLine("\t"+item.ToShortDateString());
            }
        }

        public void egynelTobbszorStatisztika() {

            List<int> szamok = new List<int>();

            foreach (Sorsolas item in sorsolasok)
            {
                foreach (int szam in item.nyeroSzamok)
                {
                    szamok.Add(szam);
                }
            }            
            var statisztika = szamok.GroupBy(x => x).ToList();
            foreach (var item in statisztika)
            {
                if (item.Count()>1)
                {
                    Console.WriteLine("\t"+item.Key + ": előfordulása: " + item.Count());
                }
            }
        }


    }
}
