using ConsoleApp1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Villamlas> villamlasok = new List<Villamlas>();

            using (StreamReader sr = new StreamReader(@"../../../src/villam.txt"))
            {
                while (!sr.EndOfStream)
                {
                    villamlasok.Add(new Villamlas(sr.ReadLine()));
                }
            }

            foreach (var item in villamlasok)
            {
                Console.WriteLine(item);
            }

            int[] osszeg = new int[villamlasok.Count()];
            int maxVillam = 0;
            int maxNap = 0;

            for (int i = 0; i < villamlasok.Count; i++)
            {
                int villamokSzama = villamlasok[i].Orak.Max();
                osszeg[i] = villamokSzama;

                if (villamokSzama > maxVillam)
                {
                    maxVillam = villamokSzama;
                    maxNap = i;
                }
            }

            Console.WriteLine($"A legtöbb villám a(z) {maxNap + 1}. napon volt, " +
                              $"a(z) {Array.IndexOf(osszeg, maxVillam)}. órában: {maxVillam} villám.");

            var result4 = villamlasok
                .Select((v, i) =>
                {
                    var index = v.Orak.FindIndex(x => x > 0);
                    return $"{i + 1};{(index != -1 ? index+1 : "null")}";
                });

            File.WriteAllLines("../../../src/villam_napok_ora.txt", result4);

            int result5 = villamlasok.SelectMany(v => v.Orak).Count(e => e > 0);

            Console.WriteLine($"Összesen {result5} olyan óra volt, amikor villámlott.");

            int result6 = villamlasok.FindIndex(v => v.Orak.Sum() < 200);

            if (result6 != -1)
                Console.WriteLine($"Az első nap, amikor 200-nál kevesebb villámlás volt: {result6 + 1}. nap.");
            else
                Console.WriteLine("Nem található olyan nap, ahol 200-nál kevesebb villámlás volt.");

            int result7 = villamlasok.FindIndex(e => e.Orak.Sum() == 0);

            if (result7 == 0)
            {
                Console.WriteLine("HIBA! Minden nap villámlott.");
            }
            else Console.WriteLine($"A {result7 + 1}. napon nem volt villámlás");

            int result8 = villamlasok.Count(v => v.Orak[0] > 0 && v.Orak[1] > 0);

            Console.WriteLine($"{result8 * 2} óra volt");

        }

    }
}