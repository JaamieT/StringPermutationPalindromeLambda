using System.Collections.Generic;
using System.Text.RegularExpressions;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using StringPermutationPalindrome.Enums;
using StringPermutationPalindrome.Extensions;
using StringPermutationPalindrome.Factories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace StringPermutationPalindrome
{
    public class Function
    {
        private readonly IDictionaryFactory _characterDictionaryFactory;
        public Function()
        {
            _characterDictionaryFactory = new DictionaryFactory();
        }
        /// <summary>
        /// Takes in a string and checks if any permutations of it
        /// are a palindrome
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest eventInfo, ILambdaContext context = null)
        {
            //Set up response now so we only have to set body
            var response = new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Headers = new Dictionary<string, string> { { "Access-Control-Allow-Origin", "*" } }
            };

            var input = eventInfo.Body.ToLower().Replace(" ", "");

            //Ensure string only contains alphabetical characters
            if (Regex.IsMatch(input, @"^[a-z]+$"))
            {

                response.Body = DoesStringPermutationHavePalindrome(input).ToString();

                return response;
            }

            response.Body = false.ToString();
            return response;
        }

        protected bool DoesStringPermutationHavePalindrome(string input)
        {
            var length = input.Length;
            var alphabetDict = _characterDictionaryFactory.GetDictionary<char, int>(DictionaryTypes.AlphabetDictionary);

            var success = alphabetDict.TryPopulateAlphabetDictionaryWithString(input);

            if (!success)
            {
                return false;
            }

            //If string length even, has to have an even number
            //of each character to have palindromes
            if (length % 2 == 0)
            {
                foreach(var key in alphabetDict.Keys)
                {
                    if(alphabetDict[key] % 2 != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            //If string length odd, only 1 character can have
            //odd value for any valid palindromes to exist
            else
            {
                int oddCount = 0;

                foreach(var key in alphabetDict.Keys)
                {
                    if (alphabetDict[key] % 2 != 0)
                    {
                        oddCount++;
                    }

                    //If  > 1 odd, exit early,
                    //No need to continue
                    if (oddCount > 1)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
