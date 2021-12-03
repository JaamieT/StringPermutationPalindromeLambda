using FluentAssertions;
using StringPermutationPalindrome.Tests.Fixtures;
using Xunit;

namespace StringPermutationPalindrome.Tests.IntegrationTests
{
    public class FunctionTests : IClassFixture<FunctionTestsFixture>
    {
        //These could be unit tests if we faked the return value of the call
        //to DictionaryFactory but I think they make more sense as integration tests

        private readonly FunctionTestsFixture _classFixture;

        public FunctionTests(FunctionTestsFixture classFixture)
        {
            _classFixture = classFixture;
        }

        [Fact]
        public void FunctionHandler_ValidEvenInputWithPalindrome_ShouldReturnTrue()
        {
            //Act
            var result = _classFixture.Function.FunctionHandler(_classFixture.ValidInputHasPalindromeEvenCharacters);

            //Assert
            result.Body.Should().Be(_classFixture.TrueString);
        }

        [Fact]
        public void FunctionHandler_ValidOddInputWithPalindrome_ShouldReturnTrue()
        {
            //Act
            var result = _classFixture.Function.FunctionHandler(_classFixture.ValidInputHasPalindromeOddCharacters);

            //Assert
            result.Body.Should().Be(_classFixture.TrueString);
        }

        [Fact]
        public void FunctionHandler_ValidInputNoPalindrome_ShouldReturnFalse()
        {
            //Act
            var result = _classFixture.Function.FunctionHandler(_classFixture.ValidInputNoPalindrome);

            //Assert
            result.Body.Should().Be(_classFixture.FalseString);
        }

        [Fact]
        public void FunctionHandler_InvalidInput_ShouldReturnFalse()
        {
            //Act
            var result = _classFixture.Function.FunctionHandler(_classFixture.InvalidInput);

            //Assert
            result.Body.Should().Be(_classFixture.FalseString);
        }
    }
}
