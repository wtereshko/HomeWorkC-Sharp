using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WebServiceTest
{
    public class ServiceHelper
    {
        private static string url = "http://localhost:8080";
        private static string reqType = "&reqtype=";

        /// <summary>
        /// Gets REST Requests from web service
        /// </summary>
        /// <returns></returns>
        public static ServiceRequests GetAllRestRequests()
        {
           return GetPosibleServiceRequests(GetBody(GetResponse("GET", url)));
        }

        /// <summary>
        /// Create request and return array strings with request url and HTTP Method
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static string[] RequestBuilder(string requestData)
        {
            string[] request = new string[2];
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(url);
            string[] parseStrings = requestData.Split(',');
            stringBuilder.Append(parseStrings[0].Replace("URL=", ""));
            request[0] = parseStrings[1].Split(' ')[1].Replace("method=", "");

            if (parseStrings.Length > 2)
            {
               stringBuilder.Append("?" + parseStrings[2].Replace("PARAMETERS= ", "") + "={0}");
                if (parseStrings.Length > 3)
                {
                    for (int i = 3; i < parseStrings.Length; i++)
                    {
                        int index = i - 2;
                        stringBuilder.Append("&" + parseStrings[i] + "={" + index + "}");
                    }
                }
            }
            request[1] = stringBuilder.Append(reqType + parseStrings[1].Split(' ')[2]).Replace(" ", "").ToString();

            return request;
        }

        /// <summary>
        /// Gets response from web service
        /// </summary>
        /// <param name="urlReqest"></param>
        /// <param name="typeMethod"></param>
        /// <returns></returns>
        public static HttpWebResponse GetResponse(string typeMethod, string urlReqest)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(urlReqest);
            webRequest.Method = typeMethod;
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
            return webResponse;
        }

        /// <summary>
        /// Get body from web service response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string GetBody(HttpWebResponse response)
        {
            string body = String.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        /// <summary>
        /// Get All Possible Service Request
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ServiceRequests GetPosibleServiceRequests(string body)
        {
            return JsonConvert.DeserializeObject<ServiceRequests>(body);
        }
        /// <summary>
        /// Get Service Response
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ServiceResponse GetServiceResponse(string body)
        {
            return JsonConvert.DeserializeObject<ServiceResponse>(body);
        }
    }

    public struct ServiceRequests
    {
        public string[] content;
    }

    public struct ServiceResponse
    {
        public string content;
    }
}
