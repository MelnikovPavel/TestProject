using RestSharp;

namespace ApiTests.Helpers
{
    public class RestHelper
    {
        private static string _uri;
        public RestHelper(string uri)
        {
            _uri = uri;
        }

        public IRestResponse GetResponse(object body, Method method)
        {
            var client = new RestSharp.RestClient(_uri);
            var request = new RestRequest(method) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(body);
            var response = client.Execute(request);
            return response;
        }
    }
}
