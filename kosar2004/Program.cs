using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();
        static Dictionary<string, int> stadionok = new Dictionary<string, int>();
        static List<string> fajlba = new List<string>();

        static void beolv()
        {
            StreamReader sr = new StreamReader("eredmenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] a = sr.ReadLine().Split(';');
                meccsek.Add(new Meccs(a[0], a[1], int.Parse(a[2]), int.Parse(a[3]), a[4], a[5]));
                

            }
            sr.Close(); 
            
        }

        static void harmas()
        {
            Console.WriteLine("3. feladat");
            int hazai = 0;
            int ideg = 0;
            foreach (var t in meccsek)
            {
                if (t.Hazai.Contains("Real Madrid"))
                {
                    hazai++;
                }
            }
            foreach (var z in meccsek)
            {
                if (z.Idegen.Contains("Real Madrid"))
                {
                    ideg++;
                }
                
            }
            Console.WriteLine("Mérkőzések száma Hazai: {0} Idegen: {1}",hazai,ideg);
            //Másik megoldás
            //var hazai = from n in meccsek where n.Hazai == "Real Madrid" select new { Hazai = n.Hazai};

            




        }

        static void negyes()
        {
            Console.WriteLine("4. feladat");
            bool van = true;
            int i = 0;
            while (i < meccsek.Count)
            {
                if (meccsek[i].HPont == meccsek[i].IPont)
                {
                    van = false;
                    Console.WriteLine("Volt döntetlen meccs");
                }
                i++;
            }
            if (van)
            {
                Console.WriteLine("Nem volt döntetlen meccs");
            }
        }

        static void otos()
        {
            Console.WriteLine("5. feladat");
            int i = 0;
            bool van = false;
            while (i < meccsek.Count && !van  )
            {
                if (meccsek[i].Hazai.Contains("Barcelona"))
                {
                    Console.WriteLine(meccsek[i].Hazai + "\n");
                    van = true;
                }
                if (meccsek[i].Idegen.Contains("Barcelona"))
                {
                    Console.WriteLine(meccsek[i].Idegen + "\n");
                    van = true;
                }
                
                i++;
                
            }
            Console.WriteLine("Teljes név:  ", i);

        }

        static void hatos()
        {
            Console.WriteLine("6. feladat");
            for (int i = 0; i < meccsek.Count; i++)
            {
                if (meccsek[i].Ido == "2004-11-21")
                {
                    Console.WriteLine("\t"+ meccsek[i].Hazai + " " + meccsek[i].Idegen + ":(" + meccsek[i].HPont+ ":" + meccsek[i].IPont+ ")");
                }
            }
 
        }
        static void hetedik()
        {
            Console.WriteLine("\n7. feladat");

            foreach (var t in meccsek)
            {
                if (!stadionok.ContainsKey(t.Hely))
                {
                    stadionok.Add(t.Hely, 0);
                }
            }

            foreach (var t in meccsek)
            {
                stadionok[t.Hely]++;
            }

            foreach (var z in stadionok)
            {
                if (z.Value > 20)
                {
                    Console.WriteLine("\t" + z.Key + ": " + z.Value);
                }

            }

        }




        static void nyolcas()
        {
            Console.WriteLine("8.feladat");
            StreamWriter sw = new StreamWriter("meccsek.txt");
            foreach (var t in meccsek)
            {
                sw.WriteLine(t.atalakit());
            }
            sw.Close();



        }
        static void Main(string[] args)
        {
            beolv();
            harmas();
            negyes();
            otos();
            hatos();
            hetedik();
            nyolcas();
            //foreach (var t in meccsek)
            //{
            //    Console.WriteLine($"{t.Hazai}");
            //}
           
            

            Console.ReadKey();
        }
    }
}
