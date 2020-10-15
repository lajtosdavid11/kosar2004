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
        static void Main(string[] args)
        {
            beolv();
            harmas();
            //foreach (var t in meccsek)
            //{
            //    Console.WriteLine($"{t.Hazai}");
            //}
           
            

            Console.ReadKey();
        }
    }
}
