using System;
using System.Collections;

namespace GUI_04
{
    internal class Program
    {
        public static int ReadNum()
        {
            int? x = null;
            do
            {
                try
                {
                    Console.Write("Kerek egy szamot: ");
                    x = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                }
            } while (x == null);

            return (int) x;
        }

        static void CheckDiv(int x)
        {
            String msg = "Nem oszthato 3-mal, 4-gyel vagy 9-cel";

            if ((x % 3 == 0) || (x % 4 == 0) || (x % 9 == 0))
            {
                msg = x + " osztoi:";

                if (x % 3 == 0) msg += " 3";
                if (x % 4 == 0) msg += " 4";
                if (x % 9 == 0) msg += " 9";
            }

            Console.WriteLine(msg);
        }

        static void RandomsInRange(int a, int b)
        {
            Console.WriteLine(a + "-" + b + " kozotti random ertekek:");
            Random r = new Random();
            int randValue;
            ArrayList randomValues = new ArrayList();
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    randValue = r.Next(a, b + 1);
                } while (randomValues.Contains(randValue));

                randomValues.Add(randValue);

                Console.WriteLine(randValue);
            }
        }

        static bool CheckPrime(int x)
        {
            if (x % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(x); i += 2)
            {
                if (x % i == 0) return false;
            }

            return true;
        }
        
        static bool CheckPrime(int x, ArrayList primes)
        {
            if (x % 2 == 0) return false;
            /*
            for (int i = 3; i <= Math.Sqrt(x); i += 2)
            {
                if (x % i == 0) return false;
            }
            */
            
            // optimizalt, csak az elotte levo primszamokkal kell mar ellenorizni, egeszen a szam gyokeig
            foreach (int prime in primes)
            {
                if (x % prime == 0) return false;
                if (prime > Math.Sqrt(x)) return true;
            }

            return true;
        }

        static ArrayList PrimeNumbers(int max)
        {
            ArrayList primes = new ArrayList();

            if (max >= 2) primes.Add(2);

            for (int i = 3; i < max; i += 2)
            {
                if (primes.Contains(Math.Sqrt(i)) == false)
                    if (CheckPrime(i, primes))
                        primes.Add(i);
            }

            return primes;
        }

        static void PrintPrimes(int max)
        {
            ArrayList primes = PrimeNumbers(max);

            foreach (var prime in primes)
            {
                Console.Write(prime + " ");
            }
            Console.WriteLine();
        }

        static int[] MergeSort(int[] a)
        {
            int i = 0;
            int j;
            int x;
            while (i < a.Length)
            {
                x = a[i];
                j = i - 1;
                while (j >= 0 && a[j] > x)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = x;
                i++;
            }

            return a;
        }

        static void PrintArray(int[] a)
        {
            foreach (var x in a)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            /*
            int x = ReadNum();
            Console.WriteLine("x = " + x);
            CheckDiv(x);

            Console.WriteLine("Kerek 2 szamot:");
            int a = ReadNum();
            int b;
            do
            {
                b = ReadNum();
            } while (b - a < 2);

            RandomsInRange(a, b);

            Console.WriteLine("Kerek egy binaris szamot:");
            String binary;
            binary = Console.ReadLine();
            Console.WriteLine(" 2-es szamrendszerben x = " + binary);
            Console.WriteLine("10-es szamrendszerben x = " + Convert.ToInt32(binary, 2));
            */

            // EXTRA:
            int x = ReadNum();
            if (CheckPrime(x)) Console.WriteLine(x + " primszam.");
            else Console.WriteLine(x + " nem primszam.");
            PrintPrimes(x);

            int[] a = {6, 2, 5, 4, 9, 21};
            PrintArray(a);
            a = MergeSort(a);
            PrintArray(a);
        }
    }
}