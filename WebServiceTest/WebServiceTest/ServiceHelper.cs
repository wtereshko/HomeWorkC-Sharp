using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WebServiceTest
{
    public class ServiceHelper
    {
        public const string url = "http://localhost:8080";
        private static string reqType = "&reqtype=";

        /// <summary>
        /// Create request and return array strings with request url and HTTP Method
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static string[] BuildRequest(string requestData)
        {
            string[] request = new string[2];
            string parametrs = String.Empty;
            string[] parseStrings = requestData.Split(',');
            string method = parseStrings[0].Replace("URL=", "");
            request[0] = parseStrings[1].Split(' ')[1].Replace("method=", "");
            string reqTypeMethod = reqType + parseStrings[1].Split(' ')[2];
            if (parseStrings.Length > 2)
            {
                parametrs = "?" + parseStrings[2].Replace("PARAMETERS= ", "") + "={0}";
                if (parseStrings.Length > 3)
                {
                    for (int i = 3; i < parseStrings.Length; i++)
                    {
                        int index = i - 2;
                        parametrs += "&" + parseStrings[i] + "={" + index + "}";
                    }
                }
            }

            if (!String.IsNullOrEmpty(parametrs))
            {
                request[1] = String.Concat(url, method, parametrs, reqTypeMethod).Replace(" ", "");
            }
            else
            {
                request[1] = String.Concat(url, method, reqTypeMethod).Replace(" ", "");
            }

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
