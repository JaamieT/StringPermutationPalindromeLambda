using StringPermutationPalindrome.Tests.Fixtures;
using StringPermutationPalindrome.Extensions;
using Xunit;
using FluentAssertions;

namespace StringPermutationPalindrome.Tests.ExtensionTests
{
    public class AlphabetDictionaryExtensionTests : IClassFixture<AlphabetDictionaryExtensionTestsFixture>
    {
        private readonly AlphabetDictionaryExtensionTestsFixture _classFixture;

        public AlphabetDictionaryExtensionTests(AlphabetDictionaryExtensionTestsFixture classFixture)
        {
            _classFixture = classFixture;
        }

        [Fact]
        public void TryPopulateAlphabetDictionaryWithString_ShouldPopulateCorrectly_WithValidInput()
        {
            //Act
            var isSuccessful = _classFixture.AlphabetDictionary.TryPopulateAlphabetDictionaryWithString(_classFixture.OneOfEachLetter);

            //Assert
            isSuccessful.Should().BeTrue();
            foreach(char letter in _classFixture.OneOfEachLetter)
            {
                _classFixture.AlphabetDictionary.Should().ContainKey(letter).WhoseValue.Equals(1);
            }
        }

        [Fact]
        public void TryPopulateAlphabetDictionaryWithString_ShouldReturnValue_WithInvalidInput()
        {
            //Act
            var isSuccessful = _classFixture.AlphabetDictionary.TryPopulateAlphabetDictionaryWithString(_classFixture.InvalidAlphabetInput);

            //Assert
            isSuccessful.Should().BeFalse();
        }
    }
}
