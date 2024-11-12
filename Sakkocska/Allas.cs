using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakkocska
{
    public class Allas : IComparable<Allas>
    {
        DateTime mentesiIdo;
        /// <summary>
        /// Az állás mentésének adatai
        /// </summary>
        /// <param name="id">A játék azonosítója</param>
        /// <param name="vilagos">A világos bábuk játékosának neve</param>
        /// <param name="sotet">A sötét bábuk játékosának neve</param>
        /// <param name="tabla">8x8-as string tömb, benne a bábuk pl. vH --> </param>
        /// <param name="vilagosJon"></param>
        /// <param name="mentesiIdo"></param>

        public Allas(int id, string vilagos, string sotet, string[,] tabla, bool vilagosJon, string mentesiIdo = "1900.01.01")
        {
            Id = id;
            Vilagos = vilagos;
            Sotet = sotet;
            Tabla = tabla;
            VilagosJon = vilagosJon;
            MentesiIdo = DateTime.Parse( mentesiIdo);

        }
        public Allas(string sor) {

            string[] s = sor.Split(';');
            Id = int.Parse(s[0]);
            Vilagos = s[1];
            Sotet = s[2];
            VilagosJon = bool.Parse(s[3]);
            MentesiIdo = DateTime.Parse(s[4]);

            string[,] ujTabla = new string[8, 8];
            int index = 5;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ujTabla[i, j] = s[index];
                    index++;
                }
            }
            Tabla = ujTabla;    

        }

        public int Id { get; set; }
        public string  Vilagos { get; set; }
        public string Sotet { get; set; }
        public string[,] Tabla { get; set; }
        public bool VilagosJon { get; set; }
        public DateTime MentesiIdo
        {
            get { return mentesiIdo; }
            set { if (value == DateTime.Parse("1900.01.01"))
                    mentesiIdo = DateTime.Now;
                else
                    mentesiIdo = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Játék azonosítója {Id}\n");
            sb.Append($"Metési idő: {MentesiIdo.ToString()}\n");
            sb.Append($"Világos játékos: {Vilagos}\n");
            sb.Append($"Sötét játékos: {Sotet}\n");
            string kovi = VilagosJon ? "Világos" : "Sötét";
            sb.Append($"Következő játékos: {kovi}\n");
            for (int i = 0; i < Tabla.GetLength(0); i++)
            {
                for (int j = 0; j < Tabla.GetLength(1); j++)
                {
                    sb.Append(Tabla[i, j] + " | ");
                }
                sb.Append('\n');
                sb.Append(new string('-', 40));
                sb.Append('\n');
            }
            

            return  sb.ToString();
                
        }

        public string KovetkezoJatekos()
        {
            return VilagosJon ? Vilagos : Sotet;
        }

        public int CompareTo(Allas allas)
        {
            if (this.MentesiIdo < allas.MentesiIdo)
            {
                return -1;
            }
            else if (this.MentesiIdo > allas.MentesiIdo)
            {
                return 1;
            }
            else
                return 0;
        }
    }
}
