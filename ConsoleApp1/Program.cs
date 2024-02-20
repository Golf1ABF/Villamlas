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

            var result = villamlasok
                .Select((v, i) =>
                {
                    var index = v.Orak.FindIndex(x => x > 0);
                    return $"{i + 1};{(index != -1 ? index.ToString() : "null")}";
                });

            File.WriteAllLines("villam_napok_ora.txt", result);

            File.WriteAllLines("../../../src/villam_napok_ora.txt", result);

            var hanyoravolt = villamlasok.Count(x => x.)
        }

    }
}