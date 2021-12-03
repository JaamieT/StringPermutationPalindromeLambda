using System.Collections.Generic;
using StringPermutationPalindrome.Enums;

namespace StringPermutationPalindrome.Factories
{
    public interface IDictionaryFactory
    {
        IDictionary<TKey, TValue> GetDictionary<TKey, TValue>(DictionaryTypes dictionaryType);
    }
}