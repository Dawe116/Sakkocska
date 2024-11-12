using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sakkocska
{
    internal class Program 
    {
        static List<Allas> allasok = new List<Allas>();
        static void Main(string[] args)
        {
            string[,] tabla1 = new string[8, 8];

            for (int i = 0; i < tabla1.GetLength(0); i++)
            {
                for (int j = 0; j < tabla1.GetLength(1); j++)
                {
                    tabla1[i, j] = "0";
                }

            }
            Allas aktualisAllas = new Allas(0,"Micheal Jackson", "William Jackson", tabla1,true);
            Console.WriteLine(aktualisAllas);

            string[] bemenet = File.ReadAllLines("Mentesek.txt");
            foreach (string item in bemenet)
            {
                allasok.Add(new Allas(item));
            }
            foreach(Allas item in allasok)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }
            //Kivel játszott Michael Jackson? Az összes játékostárs nevét írássa ki egymást alá!
            List<string> michaelJacksonOpponents = new List<string>();
            foreach (Allas item in allasok)
            {
                if (item.Vilagos == "Michael Jackson")
                    michaelJacksonOpponents.Add(item.Sotet);
                if (item.Sotet == "Michael Jackson")
                    michaelJacksonOpponents.Add(item.Vilagos);
            }
            Console.WriteLine(string.Join("\n",michaelJacksonOpponents));
            Console.WriteLine($"Az első mentett állás következő játékosa: {allasok[0].KovetkezoJatekos()}");
            Console.WriteLine();

            //Legkorábbi mentés meghatározása
            Allas legkorabbi = allasok[0];
            for (int i = 0; i < allasok.Count; i++)
            {
                if (allasok[i].MentesiIdo < legkorabbi.MentesiIdo)
                    legkorabbi = allasok[i];
            }
            Console.WriteLine($"A legkorábbi mentés: {legkorabbi}");


            //Játszott Kaszparov vagy nem?

            int index = 0;
            while (index < allasok.Count && 
                !(allasok[index].Vilagos.Contains("Kaszparov")) || 
                allasok[index].Sotet.Contains("Kaszparov"))
            {

                index++;
            }

            if(index < allasok.Count())
            {
                Console.WriteLine("Van");
            }
            else { Console.WriteLine("nincs"); }
            Console.WriteLine();

            //bool vanE = false;
            //for (int j = 0; j < allasok.Count; j++)
            //{
            //    if (allasok[j].Sotet.Contains("Kaszparov") || allasok[j].Vilagos.Contains("Kaszparov"))
            //        vanE = true;
            //    break;

            //}
            //if (vanE == true) {
            //    Console.WriteLine("Van");
            //}
            //else
            //    Console.WriteLine("nincs");

            //Van e benne vB?
            index = 0;
            while(index < allasok.Count &&
                !TaralmazErtek(allasok[index].Tabla,"vB"))
            {
                index++;
            }

            if(index < allasok.Count)
                Console.WriteLine(allasok[index]);
            else
                Console.WriteLine("Nincs ilyen állás");

            Console.WriteLine(allasok[0].CompareTo(allasok[1]));

            Console.ReadLine();
        }

        static bool TaralmazErtek(string[,] matrix, string v)
        {
            bool vanE = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j] == v) 
                        vanE = true;
                }
            }
            return vanE;
        }


    }
}
