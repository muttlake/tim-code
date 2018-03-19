

using System;

namespace Palindrome.Library
{
    public class WordHandler
    {
        public string Word { get; set; }

        public WordHandler()
        {
            Word = "";
        }

        public WordHandler(string w)
        {
            Word = w;
        }

        public string NoSpace()
        {
            string noSpaceWord = "";

            foreach (char c in Word)
            {
                if(c != ' ')
                    noSpaceWord += c;
            }
            return noSpaceWord;
        }

        public string Reverse(string w)
        {
            string reverseWord = "";

            foreach (char c in w)
                reverseWord = c + reverseWord;

            return reverseWord;
        }

        public bool IsPalindrome()
        {
            string noSpaceWord = NoSpace();
            string reversedNoSpaceWord = Reverse(noSpaceWord);

            if(noSpaceWord.Equals(reversedNoSpaceWord))
            {
                return true;
            }

            return false;
        }
    }
}