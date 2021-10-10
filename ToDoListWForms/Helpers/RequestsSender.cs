using Newtonsoft.Json;
using RestSharp;

namespace ToDoListWForms.Helpers
{
    public static class RequestsSender
    {
        public static IRestResponse ClientExecuter<T>(int methodCode, string url, T obj) where T : class
        {
            var json = obj.ToString() == string.Empty ? null : JsonConvert.SerializeObject(obj);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest((Method)methodCode);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            return client.Execute(request);
        }

        public static IRestResponse ClientExecuter(int methodCode, string url)
        {
            return ClientExecuter(methodCode, url, string.Empty);
        }

        internal static T GetDeserializedObject<T>(T obj, string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
