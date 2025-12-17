using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotporszívó
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[,] terkep = Generalas();

            char beallitas = ' ';
            while (beallitas != 'S' && beallitas != 's')
            {
                beallitas = Beallitasok(terkep);
            }
        }
        static char Beallitasok(int[,] terkep)
        {
            Console.WriteLine("Robot - Beállítások:");
            Console.WriteLine("Takarítás (C), Térkép (T), Újragenerálás (G), Program leállítása (S)");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("---------> ");
            char beallitas = Convert.ToChar(Console.ReadLine());
            while (beallitas != 'C' && beallitas != 'T' && beallitas != 'G' && beallitas != 'S' && beallitas != 'c' && beallitas != 't' && beallitas != 'g' && beallitas != 's')
            {
                Console.Clear();
                Console.WriteLine("Robot - Beállítások:");
                Console.WriteLine("Takarítás (C), Térkép (T), Újragenerálás (G), Program leállítása (S)");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("---------> ");
                beallitas = Convert.ToChar(Console.ReadLine());
            }
            Console.WriteLine();
            if (beallitas == 'C' || beallitas == 'c')
            {
                Console.Clear();
                Takaritas(terkep);
            }
            else if (beallitas == 'T' || beallitas == 't')
            {
                Console.Clear();
                Terkep(terkep);

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

            return beallitas;
        }
        static int[,] Generalas() 
        {
            int[,] terkep = new int[0, 0];
            int szabad = 0;
            int koszos = 0;
            while (szabad < 1 || koszos < 1)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("ROBOTPORSZÍVÓ TÉRKÉPGENERÁLÁS");
                Console.WriteLine("-----------------------------------------------");

                int n = 0;
                int m = 0;

                Console.WriteLine("Adj meg a szélét a térképnek [20; 30] intervallum között: ");
                n = Convert.ToInt32(Console.ReadLine());
                while (n < 20 || n > 30)
                {
                    Console.WriteLine("Hiba: Add meg a paraméteren belül: [20; 30]");
                    Console.WriteLine("Adj meg a szélét a térképnek [20; 30] intervallum között: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }


                Console.WriteLine("Adj meg a magasságát a térképnek [20; 30] intervallum között: ");
                m = Convert.ToInt32(Console.ReadLine());
                while (m < 20 || m > 30)
                {
                    Console.WriteLine("Hiba: Add meg a paraméteren belül: [20; 30]");
                    Console.WriteLine("Adj meg a magasságát a térképnek [20; 30] intervallum között: ");
                    m = Convert.ToInt32(Console.ReadLine());
                }


                while (n == m)
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("HIBA: A SZÉLESSÉG ÉS MAGASSÁG NEM LEHET EGYENLŐ!");
                    Console.WriteLine("------------------------------------------------");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine("Adj meg a szélét a térképnek [20; 30] intervallum között: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    while (n < 20 || n > 30)
                    {
                        Console.WriteLine("Hiba: Add meg a paraméteren belül: [20; 30]");
                        Console.WriteLine("Adj meg a szélét a térképnek [20; 30] intervallum között: ");
                        n = Convert.ToInt32(Console.ReadLine());
                    }


                    Console.WriteLine("Adj meg a magasságát a térképnek [20; 30] intervallum között: ");
                    m = Convert.ToInt32(Console.ReadLine());
                    while (m < 20 || m > 30)
                    {
                        Console.WriteLine("Hiba: Add meg a paraméteren belül: [20; 30]");
                        Console.WriteLine("Adj meg a magasságát a térképnek [20; 30] intervallum között: ");
                        m = Convert.ToInt32(Console.ReadLine());
                    }
                }

                terkep = new int[n, m];
                szabad = (n * m) / 100 * 50;
                int akadaly = (n * m) / 100 * 20;
                koszos = (n * m) / 100 * 30;
            }
            Console.WriteLine();
            Console.Write("┏");
            for (int i = 0; i < terkep.GetLength(1)*2; i++)
            {
                Console.Write("━");
            }

            Console.Write("┓");
            Console.WriteLine();
            for (int i = 0; i < terkep.GetLength(0); i++)
            {
                Console.Write("┃");
                for (int j = 0; j < terkep.GetLength(1); j++)
                {
                    terkep[i, j] = 'p';
                    Console.Write($"p ");
                }
                Console.Write("┃");
                Console.WriteLine();
            }
            Console.Write("┗");
            for (int i = 0; i < terkep.GetLength(1) * 2; i++)
            {
                Console.Write("━");
            }

            Console.Write("┛");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
            return terkep;
        }

        static void Takaritas(int[,] terkep)
        {
            Console.WriteLine("A robot elkezdi a takarítást...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Terkep(int[,] terkep)
        {
            Console.WriteLine("A robot térképet jelenít meg...");
            for (int i = 0; i < terkep.GetLength(0); i++)
            {
                for (int j = 0; j < terkep.GetLength(1); j++)
                {
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
        }
    }
}
