using Amazon.Lambda.APIGatewayEvents;
using StringPermutationPalindrome;

namespace StringPermutationPalindrome.Tests.Fixtures
{
    public class FunctionTestsFixture
    {
        public readonly Function Function;
        public readonly APIGatewayProxyRequest ValidInputHasPalindromeEvenCharacters;
        public readonly APIGatewayProxyRequest ValidInputHasPalindromeOddCharacters;
        public readonly APIGatewayProxyRequest ValidInputNoPalindrome;
        public readonly APIGatewayProxyRequest InvalidInput;
        public readonly string TrueString = "True";
        public readonly string FalseString = "False";

        public FunctionTestsFixture()
        {
            Function = new Function();

            ValidInputHasPalindromeEvenCharacters = new APIGatewayProxyRequest
            {
                Body = "Noon"
            };

            ValidInputHasPalindromeOddCharacters = new APIGatewayProxyRequest
            {
                Body = "Racecar"
            };

            ValidInputNoPalindrome = new APIGatewayProxyRequest
            {
                Body = "Hello"
            };

            InvalidInput = new APIGatewayProxyRequest 
            {
                Body = "@@"
            };
        }
    }
}
