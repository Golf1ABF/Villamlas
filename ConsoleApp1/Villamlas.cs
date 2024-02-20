using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Villamlas
    {
        public int Augusztusnapjai { get; set; }
        public List<int> Orak { get; set; }

        public Villamlas(string sor)
        {
            string[] s = sor.Split(";");
            this.Augusztusnapjai = int.Parse(s[0]);
            this.Orak = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                Orak.Add(int.Parse(s[i]));
            }
        }

        public override string ToString()
        {
            return string.Join(";", Orak);
        }
    }
}
