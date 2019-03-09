using System.Configuration;

namespace ApiTests
{
    public static class MethodsUrl
    {
        public static string AuthSignup =
            ConfigurationManager.AppSettings.Get("TargetUrl") + "/method/auth.signup";
    }
}
