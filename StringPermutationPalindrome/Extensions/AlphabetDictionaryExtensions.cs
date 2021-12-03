using System;
using System.Collections.Generic;
using System.Text;

namespace StringPermutationPalindrome.Extensions
{
    public static class AlphabetDictionaryExtensions
    {
        public static bool TryPopulateAlphabetDictionaryWithString(this IDictionary<char, int> alphabetDictionary, string input)
        {
            try
            {
                foreach (char c in input)
                {
                    alphabetDictionary[c]++;
                }

                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
