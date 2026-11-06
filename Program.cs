namespace zombihaboru
{
    internal class Program
    {
        static Random r = new Random();
        static string[] NevekLetrehozasa(int db)
        {
            string[] nevekOsszes = { "Molnár", "Ádám", "Bence", "Csaba", "Dávid", "Erik", "Ferenc", "Gábor", "Hunor", "István", "János", "Károly", "Levente", "Márk", "Norbert", "Péter", "Richárd", "Sándor", "Tamás", "Viktor", "Zoltán", "Anna", "Barbara", "Csilla", "Dóra", "Eszter", "Fanni", "Hanna", "Kata", "Lilla", "Zsófia" };
            string[] nevek = new string[db];
            for (int i = 0; i < db; i++)
            {
                int index = r.Next(0, nevekOsszes.Length);
                nevek[i] = nevekOsszes[index];
            }
            return nevek;
        }

        static void Kiir(string[] nevek)
        {
            foreach (var item in nevek)
            {
                Console.Write(item + " ");

            }
            Console.WriteLine();
        }
        static int[] EleteroBeallitasa(int lakossagSzama)
        {
            int[] eleterok = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                eleterok[i] = 100;
            }
            return eleterok;
        }

        static int[] TamadoeroBeallitasa(int zombikSzama)
        {
            int[] tamadoEreje = new int[zombikSzama];
            for (int i = 0; i < zombikSzama; i++)
            {
                tamadoEreje[i] = 20;
            }
            return tamadoEreje;
        }
        static void KiirPopntok(int[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item + " ");
            }
        }
        static bool VanEEloLakos(int[] eleterok)
        {
            foreach (var item in eleterok)
            {
                if (item > 0)
                {
                    return true;
                }
            }
            return false;
        }
        static void Jatek(int[] lakossagEletereje, int[] zombiTamadoEreje, string[] lakossag, string[] zombik)

        {

            while (VanEEloLakos(lakossagEletereje) && VanEEloLakos(zombiTamadoEreje))

            {

                for (int i = 0; i < zombik.Length; i++)

                {

                    if (zombiTamadoEreje[i] > 0 && VanEEloLakos(lakossagEletereje))

                    {

                        int ember = r.Next(lakossag.Length);

                        if (lakossagEletereje[ember] > 0)

                        {

                            lakossagEletereje[ember] -= zombiTamadoEreje[i];

                        }

                        if (lakossagEletereje[ember] < 0)

                        {

                            lakossagEletereje[ember] = 0;

                        }

                        zombiTamadoEreje[i] -= 10;


                        if (zombiTamadoEreje[i] < 0)

                        {

                            zombiTamadoEreje[i] = 0;

                        }

                        Console.WriteLine(zombik[i] + " megtámadta " + lakossag[ember] + " embert.");

                    }

                }

            }

            Console.WriteLine("\nEmberek életereje:");

            KiirPopntok(lakossagEletereje);

            Console.WriteLine("\nZombik támadóereje:");

            KiirPopntok(zombiTamadoEreje);

            if (VanEEloLakos(lakossagEletereje))

            {

                Console.WriteLine("Az emberek győztek!");

            }

            else
            {

                Console.WriteLine("A zombik győztek!");

            }

        }

        static void Main(string[] args)
        {
            int lakossagSzama = 5;
            int zombikSzama = 3;
            string[] lakossag = NevekLetrehozasa(lakossagSzama);
            string[] zombik = NevekLetrehozasa(zombikSzama);
            Console.Write("Lakosság:");
            Kiir(lakossag);
            Console.Write("Zombik:");
            Kiir(zombik);
            int[] lakossagEletereje = EleteroBeallitasa(lakossagSzama);
            int[] zombikTamadoEreje = TamadoeroBeallitasa(zombikSzama);
            Console.Write("Lakosság eletereje:");
            KiirPopntok(lakossagEletereje);
            Console.Write("Zombik eletereje:");
            KiirPopntok(zombikTamadoEreje);
            Jatek(lakossagEletereje, zombikTamadoEreje, lakossag, zombik);
        }

    }
}
