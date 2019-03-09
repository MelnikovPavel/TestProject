using ApiTests.Helpers;
using ApiTests.Models;
using ApiTests.Models.Auth.AuthSignup;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace ApiTests.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class AuthSignupTests
    {
        private static readonly object[] PositiveTestCases =
        {
            new object[] {"01.01.2000"
                , "Иван"
                , "Иванов"
                , "8" + GenerateData.GeneratePhoneNumber(10)
                , Sex.Men
                ,  TestMode.Yes
                ,  6890062
                ,  "Z27ibfbSBC29DY2MDu5h"
                , "123123Aa"
            }
        };

        private static readonly object[] NegativeTestCases =
        {
            new object[] {"01.01.2000"
                , "Иван"
                , "Иванов"
                , ""
                , Sex.Men
                ,  TestMode.Yes
                ,  6890062
                ,  "Z27ibfbSBC29DY2MDu5h"
                , "123123Aa"
                , 100
                , ErrorMessages.PhoneIsUndefinedError
            }
        };

        [Test]
        [TestCaseSource(nameof(PositiveTestCases))]
        public void AuthSignupPositiveTest(string birthday, string firstName, string lastName, string phone
            ,Sex sex, TestMode testMode, int clientId, string clientSecret, string password)
        {
            var restHelper = new RestHelper(MethodsUrl.AuthSignup);
            var body = new Signup()
            {
                birthday = birthday,
                test_mode = testMode,
                client_id = clientId,
                password = password,
                client_secret = clientSecret,
                phone = phone,
                last_name = lastName,
                first_name = firstName,
                sex = sex
            };
            var response = restHelper.GetResponse(body, Method.POST);
            var content = JsonConvert.DeserializeObject<ResponseSignup>(response.Content);
            Assert.IsNotEmpty(content.response.sid);
        }

        [Test]
        [TestCaseSource(nameof(NegativeTestCases))]
        public void AuthSignupNegativeTest(string birthday, string firstName, string lastName, string phone
            , Sex sex, TestMode testMode, int clientId, string clientSecret, string password, int errorCode, string errorMsg)
        {
            var restHelper = new RestHelper(MethodsUrl.AuthSignup);
            var body = new Signup()
            {
                birthday = birthday,
                test_mode = testMode,
                client_id = clientId,
                password = password,
                client_secret = clientSecret,
                phone = phone,
                last_name = lastName,
                first_name = firstName,
                sex = sex
            };
            var response = restHelper.GetResponse(body, Method.POST);
            var content = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(errorCode, content.error_code);
                Assert.AreEqual(errorMsg, content.error_message);
            });
        }
    }
}
