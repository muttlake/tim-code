using System;
using Palindrome.Library;

namespace Palindrome.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithPalindrome();
        }

        static void PlayWithPalindrome()
        {
            Console.WriteLine("Enter string to test for palindrome.");
            string s = Console.ReadLine();
            var wh = new WordHandler(s);
            
            string wordNoSpace = wh.NoSpace();
            Console.WriteLine(wh.NoSpace());
            Console.WriteLine(wh.Reverse(wordNoSpace));

            wh.IsPalindrome();

        }
    }
}
