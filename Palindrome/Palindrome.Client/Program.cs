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
            
            // string wordNoSpace = wh.NoSpace();
            // Console.WriteLine(wh.NoSpace());
            // Console.WriteLine(wh.Reverse(wordNoSpace));

            if(wh.IsPalindrome())
                Console.WriteLine("Yes this is a palindrome.");
            else
                Console.WriteLine("No this is not a palindrome.");

        }
    }
}
