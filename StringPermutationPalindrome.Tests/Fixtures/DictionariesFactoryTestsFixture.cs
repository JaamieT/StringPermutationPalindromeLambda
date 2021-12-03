using StringPermutationPalindrome.Factories;

namespace StringPermutationPalindrome.Tests.Fixtures
{
    public class DictionariesFactoryTestsFixture
    {
        public readonly IDictionaryFactory DictionariesFactory;
        public readonly char[] AlphabetCharArray;

        public DictionariesFactoryTestsFixture()
        {
            DictionariesFactory = new DictionaryFactory();
            AlphabetCharArray = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }
    }
}
