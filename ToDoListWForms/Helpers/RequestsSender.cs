using Newtonsoft.Json;
using RestSharp;

namespace ToDoListWForms.Helpers
{
    /// <summary>
    /// Статический класс для работы по отправке запросов
    /// </summary>
    public static class RequestsSender
    {
        /// <summary>
        /// Выполнение запроса клиентом
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodCode">целочисленное представление метода из <see cref="Method"/></param>
        /// <param name="url">Путь</param>
        /// <param name="obj">Объект для отправки запроса</param>
        /// <returns>Возаращает объект <see cref="IRestResponse"/></returns>
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

        /// <summary>
        /// /// Выполнение запроса клиентом
        /// </summary>
        /// <param name="methodCode">целочисленное представление метода из <see cref="Method"/></param>
        /// <param name="url">Путь</param>
        /// <returns>Возаращает объект <see cref="IRestResponse"/></returns>
        public static IRestResponse ClientExecuter(int methodCode, string url)
        {
            return ClientExecuter(methodCode, url, string.Empty);
        }

        /// <summary>
        /// Получает десериализованный json объект
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Объект для определения типа объекта </param>
        /// <param name="json">Строка json</param>
        /// <returns>Десериализованный объект Т типа</returns>
        public static T GetDeserializedObject<T>(T obj , string json)
        {
           return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
