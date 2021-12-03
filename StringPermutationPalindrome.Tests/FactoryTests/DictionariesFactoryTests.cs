using StringPermutationPalindrome.Tests.Fixtures;
using Xunit;
using FluentAssertions;
using System;
using StringPermutationPalindrome.Enums;

namespace StringPermutationPalindrome.Tests.FactoryTests
{
    public class DictionariesFactoryTests : IClassFixture<DictionariesFactoryTestsFixture>
    {
        private readonly DictionariesFactoryTestsFixture _classFixture;

        public DictionariesFactoryTests(DictionariesFactoryTestsFixture classFixture)
        {
            _classFixture = classFixture;
        }

        [Fact]
        public void Alphabet_Dictionary_Should_Include_All_Letters()
        {
            // Arrange
            var alphabetDict = _classFixture.DictionariesFactory.GetDictionary<char,int>(DictionaryTypes.AlphabetDictionary);

            //Act
            //...

            // Assert
            alphabetDict.Should().ContainKeys(_classFixture.AlphabetCharArray);
        }

        [Fact]
        public void AlphabetDictionary_ShouldThrowException_WithInvalidTypes()
        {
            //Arrange
            Action getAlphabetDictionary = () => _classFixture.DictionariesFactory.GetDictionary<string, string>(DictionaryTypes.AlphabetDictionary);

            //Act
            //...

            //Assert
            getAlphabetDictionary.Should().Throw<InvalidCastException>();
        }
    }
}
