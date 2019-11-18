using Lotto.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            SorsolasokTarolo st = new SorsolasokTarolo();

            #region 1.Feladat
            Console.WriteLine("1. Feladat:");
            st.beolvasFilebol("sorsolasok.csv");
            #endregion

            #region 2.Feladat
            Console.WriteLine("2. Feladat:");
            st.nyeroszamokGeneralasa();
            #endregion

            #region 3.Feladat
            Console.WriteLine("3. Feladat:");
            Console.WriteLine("\t2019 össz. sorsolt szám: " +
                st.getSorsoltSzamokSzamaMegadottDatumig(new DateTime(2019, 12, 31)));
            #endregion

            #region 4.Feladat
            Console.WriteLine("4. Feladat:");
            st.parosParatlan();
            #endregion

            #region 5.Feladat
            Console.WriteLine("5. Feladat: (3 vagy annál több) 45 alatti számok");
            st.legtobbNegyvenotAlattiSzam();
            #endregion

            #region 6.Feladat
            Console.WriteLine("6. Feladat:");
            st.egynelTobbszorStatisztika();
            #endregion

            #region 7.Feladat
            Console.WriteLine("7. Feladat:");
            DateTime startDate = new DateTime(2020, 01, 04);
            st.feltoltMegadottKriteriumokSzerintSorsolasiDatumokkal(startDate, 7, 10);
            #endregion
            
            #region 8.Feladat
            Console.WriteLine("8. Feladat:");
            st.mentesFileba("lottoszamok.csv");
            Console.WriteLine("\tFile mentése befejeződött.");
            Process.Start(Environment.CurrentDirectory);
            #endregion


            Console.ReadKey();
        }
    }
}
