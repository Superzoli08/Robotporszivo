using System;
using System.Threading;

namespace Robotporszívó
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[,] terkep = Generalas();
            char valasztas = ' ';

            while (valasztas != 'S' && valasztas != 's')
            {
                Console.Clear();
                Console.WriteLine("Robot - Beállítások:");
                Console.WriteLine("Takarítás (C), Térkép (T), Újragenerálás (G), Kilépés (S)");
                Console.Write("---------> ");
                valasztas = Convert.ToChar(Console.ReadLine());

                while (valasztas != 'C' && valasztas != 'c' &&
                       valasztas != 'T' && valasztas != 't' &&
                       valasztas != 'G' && valasztas != 'g' &&
                       valasztas != 'S' && valasztas != 's')
                {
                    Console.Write("Hibás választás! Újra: ");
                    valasztas = Convert.ToChar(Console.ReadLine());
                }

                if (valasztas == 'C' || valasztas == 'c')
                {
                    terkep = Takaritas(terkep);
                }
                else if (valasztas == 'T' || valasztas == 't')
                {
                    Console.Clear();
                    TerkepKirajzol(terkep);
                    Console.ReadKey();
                }
                else if (valasztas == 'G' || valasztas == 'g')
                {
                    terkep = Generalas();
                }
            }
        }

        static int[,] Generalas()
        {
            int n = 0;
            int m = 0;
            Random rnd = new Random();

            while (n < 20 || n > 30)
            {
                Console.Write("Sorok száma [20-30]: ");
                n = Convert.ToInt32(Console.ReadLine());
            }

            while (m < 20 || m > 30 || m == n)
            {
                Console.Write("Oszlopok száma [20-30], nem lehet egyenlő: ");
                m = Convert.ToInt32(Console.ReadLine());
            }

            int[,] terkep = new int[n, m];

            bool valid = false;
            while (!valid)
            {
                valid = true;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        int r = rnd.Next(100);
                        if (r < 50) terkep[i, j] = '-';
                        else if (r < 70) terkep[i, j] = 'b';
                        else terkep[i, j] = 'k';
                    }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (terkep[i, j] == 'k')
                        {
                            bool elerheto = false;
                            if (i > 0 && terkep[i - 1, j] == '-') elerheto = true;
                            if (i < n - 1 && terkep[i + 1, j] == '-') elerheto = true;
                            if (j > 0 && terkep[i, j - 1] == '-') elerheto = true;
                            if (j < m - 1 && terkep[i, j + 1] == '-') elerheto = true;
                            if (!elerheto) valid = false;
                        }
                    }
                }
            }

            bool robotLetett = false;
            while (!robotLetett)
            {
                int rx = rnd.Next(n);
                int ry = rnd.Next(m);
                if (terkep[rx, ry] == '-')
                {
                    terkep[rx, ry] = 'r';
                    robotLetett = true;
                }
            }

            Console.Clear();
            TerkepKirajzol(terkep);
            Console.ReadKey();
            return terkep;
        }



        static int[,] Takaritas(int[,] terkep)
        {
            int n = terkep.GetLength(0);
            int m = terkep.GetLength(1);
            Random rnd = new Random();

            int lepesek = 0;
            int feltakaritott = 0;

            int rx = 0, ry = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (terkep[i, j] == 'r')
                    {
                        rx = i;
                        ry = j;
                    }
                }
            }

            bool vanKosz = true;
            while (vanKosz)
            {
                vanKosz = false;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (terkep[i, j] == 'k')
                        {
                            vanKosz = true;
                            break;
                        }
                    }
                    if (vanKosz) break;
                }

                if (!vanKosz) break;

                int irany = rnd.Next(4);
                int ujx = rx;
                int ujy = ry;

                if (irany == 0 && rx > 0) ujx = rx - 1;
                if (irany == 1 && rx < n - 1) ujx = rx + 1;
                if (irany == 2 && ry > 0) ujy = ry - 1;
                if (irany == 3 && ry < m - 1) ujy = ry + 1;

                if (terkep[ujx, ujy] != 'b')
                {
                    terkep[rx, ry] = '-';
                    rx = ujx;
                    ry = ujy;

                    if (terkep[rx, ry] == 'k') feltakaritott++;

                    terkep[rx, ry] = 'r';
                    lepesek++;

                    Console.Clear();
                    TerkepKirajzol(terkep);
                    Thread.Sleep(10);
                }
            }

            Console.Clear();
            TerkepKirajzol(terkep);
            Console.WriteLine();
            Console.WriteLine($"Takarítás vége!");
            Console.WriteLine($"Lépések száma: {lepesek}");
            Console.WriteLine($"Feltakarított koszos mezők: {feltakaritott}");
            Console.ReadKey();
            return terkep;
        }



        static void TerkepKirajzol(int[,] terkep)
        {
            for (int i = 0; i < terkep.GetLength(0); i++)
            {
                for (int j = 0; j < terkep.GetLength(1); j++)
                {
                    Console.Write((char)terkep[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
