using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebServiceTest
{
    public class ServiceHelper
    {
        public enum HttpMethod
        {
            DELETE,
            GET,
            POST,
            PUT
        }
        /*
     URL=/reset, method=GET resetServiceToInitialState",
     "URL=/login, method=POST login, PARAMETERS= name, password",
     "URL=/logout, method=POST logout, PARAMETERS= name, token",
     "URL=/user, method=PUT changePassword, PARAMETERS= token, oldPassword, newPassword",
     "URL=/user, method=GET getUserName, PARAMETERS= token",
     "URL=/cooldowntime, method=GET getCoolDownTime",
     "URL=/tokenlifetime, method=GET getTokenLifeTime",
     "URL=/cooldowntime, method=PUT setCoolDownTime, PARAMETERS= adminToken, newCoolDownTime",
     "URL=/tokenlifetime, method=PUT setTokenLifeTime, PARAMETERS= adminToken, newTokenLifeTime",
     "URL=/user, method=POST createUser, PARAMETERS= adminToken, newName, newPassword, adminRights",
     "URL=/user, method=DELETE removeUser, PARAMETERS= adminToken, removedName",
     "URL=/admins, method=GET getAllAdmins, PARAMETERS= adminToken",
     "URL=/login/admins, method=GET getLoginedAdmins, PARAMETERS= adminToken",
     "URL=/locked/admins, method=GET getLockedAdmins, PARAMETERS= adminToken",
     "URL=/users, method=GET getAllUsers, PARAMETERS= adminToken",
     "URL=/login/users, method=GET getLoginedUsers, PARAMETERS= adminToken",
     "URL=/login/tockens, method=GET getAliveTockens, PARAMETERS= adminToken",
     "URL=/locked/users, method=GET getLockedUsers, PARAMETERS= adminToken",
     "URL=/locked/user/{name}, method=POST lockUser, PARAMETERS= adminToken, name",
     "URL=/locked/user/{name}, method=PUT unlockUser, PARAMETERS= adminToken, name",
     "URL=/locked/reset, method=PUT unlockAllUsers, PARAMETERS= adminToken",
     "URL=/item/user/{name}, method=GET getUserItems, PARAMETERS= adminToken, name",
     "URL=/item/{index}/user/{name}, method=GET getUserItem, PARAMETERS= adminToken, name, index",
     "URL=/item/{index}, method=POST addItem, PARAMETERS= token, item, index",
     "URL=/item/{index}, method=DELETE deleteItem, PARAMETERS= token, index",
     "URL=/item/{index}, method=PUT updateItem, PARAMETERS= token, index, item",
     "URL=/items, method=GET getAllItems, PARAMETERS= token",
     "URL=/itemindexes, method=GET getAllItemsIndexes, PARAMETERS= token",
     "URL=/item/{index}, method=GET getItem, PARAMETERS= token, index"]}
     */
        public const string login = "/login";
        public const string logout = "/logout";
        public const string user = "/user";
        public const string cooldowntime = "/cooldowntime";
        public const string tokenlifetime = "/tokenlifetime";
        public const string admins = "/admins";
        public const string users = "/users";
        public const string tockens = "/tockens";
        public const string locked = "/locked";
        public const string item = "/item";
        public const string items = "/items";

        private static ServiceRequests serviceRequests;
        private static string url = "http://localhost:8080";
        private static string reqType = "&reqtype=";

        /// <summary>
        /// Gets REST Requests from web service
        /// </summary>
        /// <returns></returns>
        public static ServiceRequests GetAllRestRequests()
        {

           serviceRequests = GetPosibleServiceRequests(GetBody(GetResponse(HttpMethod.GET, url)));
            return serviceRequests;
        }

        public static string FindRequest(string findParameter, HttpMethod httpMethod)
        {
            string[] strings = Array.FindAll(serviceRequests.content, s => s.Contains(findParameter));
            return Array.Find(strings, s => s.Contains(httpMethod));
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
        public static HttpWebResponse GetResponse(HttpMethod httpMethod, string urlReqest)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(urlReqest);
            webRequest.Method = httpMethod;
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
