using System;

namespace InterviewQuestions.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 16;
            Console.WriteLine("Fib Test {0}", n);
            Console.WriteLine(fib(n));

            Console.WriteLine("RecurFib Test {0}", n);
            var recurTest = new RecurTest();
            Console.WriteLine(recurTest.RecurFib(n));

            int numPrimes = 100;
            Console.WriteLine("Print first {0} Prime Numbers", numPrimes);
            printFirstNPrimes(numPrimes);

            int factTest = 10;
            Console.WriteLine("Get {0}!", factTest);
            Console.WriteLine(recurTest.RecurFact(factTest));

            string str = "ABC";
            Console.WriteLine("Get Permutations of {0}", str);
            GetPermuations(str);
        }

        static int fib(int n)
        {
            if(n == 0) { return 0; }
            if(n == 1) { return 1; }
            int fib_n_2 = 0;
            int fib_n_1 = 1;
            int currFib = 0;
            int currN = 2;
            while(currN <= n)
            {
                currFib = fib_n_1 + fib_n_2;
                fib_n_2 = fib_n_1;
                fib_n_1 = currFib;
                currN += 1;
            }

            return currFib;
        }

        static void printFirstNPrimes(int n)
        {
            int count = 1;
            int testNumber = 1;
            while(count <= n)
            {
                if (IsPrime(testNumber))
                {
                    Console.WriteLine("Prime Number {0} is {1}", count, testNumber);
                    count += 1;
                }
                testNumber += 1;
            }
        }


        static bool IsPrime(int n)
        {
            if(n <= 1) { return false; }
            if(n == 2 || n == 3) { return  true; }

            //a prime number is only divisible by 1 and itself
            for(int i = 2; i <= n/2; i ++)
            {
                if( n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void GetPermuations(string str)
        {
            if(str.Length == 0)  return;

            char[] list = str.ToCharArray();
            GetPermuations(list, 0, list.Length - 1);
        }


        private static void GetPermuations(char[] list, int start, int end)
        {
            if(start == end) { Console.Write( "\n" + Tabber(start) + "\tFinal Permutation: "); Console.Write(list); Console.Write("\n\n"); }

            else 
            {
                Console.WriteLine("\n" + Tabber(start) + "Begin For loop");
                for(int i = start; i <= end; i++)
                {
                    Console.Write("\n\t" + Tabber(start) + "Begin iteration {0} of For Loop: list: ", i);
                    Console.Write(list);
                    Console.WriteLine(" start: {0}, i: {1}, end: {1}", start, i, end);

                    SwapIt(ref list[start], ref list[i]);

                    Console.Write(Tabber(start) + "\tSwapped ");
                    Console.Write(list[start]);
                    Console.Write(" with ");
                    Console.Write(list[i]);
                    Console.Write("\n");
                    Console.Write(Tabber(start) + "\tSwapped: list: ");
                    Console.Write(list);
                    Console.WriteLine(" start: {0}, i: {1}", start, i, list);

                    Console.Write(Tabber(start) + "\tGetPermutations Called inside For Loop: list: ");
                    Console.Write(list);
                    Console.WriteLine(" start + 1: {0}, end: {1}", start + 1, end);
                    
                    GetPermuations(list, start + 1, end);

                    SwapIt(ref list[start], ref list [i]);

                    Console.Write(Tabber(start) + "\tSwapped ");
                    Console.Write(list[start]);
                    Console.Write(" with ");
                    Console.Write(list[i]);
                    Console.Write("\n");
                    Console.Write(Tabber(start) + "\tSwapped: list: ");
                    Console.Write(list);
                    Console.WriteLine(" start: {0}, i: {1}", start, i, list);

                    Console.Write(Tabber(start) + "\tEnd for Loop for one iteration");
                    Console.WriteLine(" start: {0}, i: {1}, end: {1}", start, i, end);
                    Console.WriteLine(Tabber(start) + "\t---------------------------------------------------");

                }
                Console.WriteLine(Tabber(start) + "End of for loop.\n");
            }
        }

        private static string Tabber(int n)
        {
            string tabber = "";
            for(int i = 0; i < n; i++) { tabber += "\t";}
            return tabber;
        }

        private static void SwapIt(ref char a, ref char b)
        {
            if (a == b) { return; }

            char temp = a;
            a = b;
            b = temp;
        }


    }

    public class RecurTest
    {
        public int RecurFib(int n)
        {
            if(n == 0) { return 0; }
            if(n == 1) { return 1; }
            return RecurFib(n - 1) + RecurFib(n - 2);
        }

        public int RecurFact(int n)
        {
            if(n == 0) { return  1; }
            if(n == 1) { return  1; }
            return n * RecurFact(n - 1);
        }
    }

}
