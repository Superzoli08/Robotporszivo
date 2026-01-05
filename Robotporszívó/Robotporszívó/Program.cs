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

<<<<<<< HEAD
                valasztas = Convert.ToChar(Console.ReadLine());
=======
            }
            else if (beallitas == 'G' || beallitas == 'g')
            {
                Console.Clear();
                terkep = Ujrageneralas(terkep);
            }
            else if (beallitas == 'S' || beallitas == 's')
            {
                Console.WriteLine("A program leállt.");
            }
>>>>>>> cc1bcb0f669b3fbbbef808d1f6bf1c0808eec6ee

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
            Random rnd = new Random();

            int szabad = 0;
            int koszos = 0;

            while (szabad == 0 || koszos == 0)
            {
                szabad = 0;
                koszos = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int r = rnd.Next(100);

                        if (r < 50)
                        {
                            terkep[i, j] = '-';
                            szabad++;
                        }
                        else if (r < 70)
                        {
                            terkep[i, j] = 'b';
                        }
                        else
                        {
                            terkep[i, j] = 'k';
                            koszos++;
                        }
                    }
                }
            }

            bool robotLetett = false;
            int rx = 0;
            int ry = 0;

            while (!robotLetett)
            {
                rx = rnd.Next(n);
                ry = rnd.Next(m);

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
            int lepesek = 0;
            int feltakaritott = 0;

            int rx = 0, ry = 0;
            int n = terkep.GetLength(0);
            int m = terkep.GetLength(1);

            // Robot pozíciójának keresése
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

            // Logikus takarítás: sor és oszlop szerint végig minden koszos cellán
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (terkep[i, j] == 'k')
                    {
                        // először sor szerint közelít
                        while (rx != i)
                        {
                            terkep[rx, ry] = '-';
                            if (rx < i) rx++; else rx--;
                            if (terkep[rx, ry] == 'k') feltakaritott++;
                            terkep[rx, ry] = 'r';
                            lepesek++;
                            Console.Clear();
                            TerkepKirajzol(terkep);
                            Thread.Sleep(100);
                        }

                        // majd oszlop szerint
                        while (ry != j)
                        {
                            terkep[rx, ry] = '-';
                            if (ry < j) ry++; else ry--;
                            if (terkep[rx, ry] == 'k') feltakaritott++;
                            terkep[rx, ry] = 'r';
                            lepesek++;
                            Console.Clear();
                            TerkepKirajzol(terkep);
                            Thread.Sleep(100);
                        }

                        // takarítva
                        terkep[rx, ry] = 'r';
                    }
                }
            }
            return terkep;
        }

            static void TerkepKirajzol(int[,] terkep)
        {
            for (int i = 0; i < terkep.GetLength(0); i++)
            {
                for (int j = 0; j < terkep.GetLength(1); j++)
                {
<<<<<<< HEAD
                    Console.Write((char)terkep[i, j] + " ");
                }
                Console.WriteLine();
            }
=======
                    Console.Write($"K ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }
        static int[,] Ujrageneralas(int[,] terkep)
        {
            Console.WriteLine("A robot újragenerálja a térképet...");
            terkep = Generalas();
            return terkep;
>>>>>>> cc1bcb0f669b3fbbbef808d1f6bf1c0808eec6ee
        }
    }
}
