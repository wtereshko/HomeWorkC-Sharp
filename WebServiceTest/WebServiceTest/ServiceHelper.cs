using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WebServiceTest
{
    public enum HttpMethod
    {
        DELETE,
        GET,
        POST,
        PUT
    }

    internal class ServiceHelper
    {
        #region REST Requests

        /*
       "URL=/reset, method=GET resetServiceToInitialState",
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
       "URL=/item/{index}, method=GET getItem, PARAMETERS= token, index"
        */

        #endregion

        #region Fields and Const

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
        public const string adminLogin = "admin";
        public const string adminPassword = "qwerty";

        private static ServiceRequests serviceRequests;
        private static ServiceResponse serviceResponse;
        private static string url = "http://localhost:8080";
        private static string reqType = "&reqtype=";

        #endregion

        #region Private Methods

        /// <summary>
        /// Find request in web service requests. Parameters should set in order, which they are in url.
        /// If url contains index, it's set after all parameters. 
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        private static string FindUrl(string searchParameter, HttpMethod httpMethod)
        {
            string[] strings = Array.FindAll(serviceRequests.content, s => s.Contains(searchParameter));
            return Array.Find(strings, s => s.Contains(httpMethod.ToString()));
        }

        /// <summary>
        /// Create url with parameters. Parameters should set in order  which they are set in url order.
        ///  </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        private static string UrlBuilder(string urlData, params string[] parameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(url);
            string[] parseStrings = urlData.Split(',');
            stringBuilder.Append(parseStrings[0].Replace("URL=", ""));

            if (parseStrings.Length > 2)
            {
                stringBuilder.Append("?" + parseStrings[2].ToLower().Replace("parameters= ", "") + $"={parameters[0]}");
                if (parseStrings.Length > 3)
                {
                    for (int i = 3; i < parseStrings.Length; i++)
                    {
                        int index = i - 2;
                        stringBuilder.Append("&" + parseStrings[i].ToLower() + $"={parameters[index]}");
                    }
                }
            }

            if (stringBuilder.ToString().Contains("removedname"))
            {
                stringBuilder.Replace("removedname", "name");
            }

            if (stringBuilder.ToString().Contains("new"))
            {
                stringBuilder.Replace("new", "");
            }

            if (stringBuilder.ToString().Contains("admintoken"))
            {
                stringBuilder.Replace("admintoken", "token");
            }

            if (stringBuilder.ToString().Contains("{index}"))
            {
                stringBuilder.Replace("{index}", parameters[parameters.Length - 1]);
            }

            return stringBuilder.Append(reqType + parseStrings[1].Split(' ')[2]).ToString().Replace(" ", "");
        }

        /// <summary>
        /// Gets response from web service
        /// </summary>
        /// <param name="urlReqest"></param>
        /// <param name="typeMethod"></param>
        /// <returns></returns>
        private static HttpWebResponse GetResponse(HttpMethod httpMethod, string urlReqest)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(urlReqest);
            webRequest.Method = httpMethod.ToString();
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
            return webResponse;
        }

        /// <summary>
        /// Get body from web service response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string GetBody(HttpWebResponse response)
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
        private static ServiceRequests GetPosibleServiceRequests(string body)
        {
            return JsonConvert.DeserializeObject<ServiceRequests>(body);
        }

        /// <summary>
        /// Get Service Response
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private static ServiceResponse GetServiceResponse(string body)
        {
            return JsonConvert.DeserializeObject<ServiceResponse>(body);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialization REST Requests from web service
        /// </summary>
        /// <returns></returns>
        public static void GetAllRestRequest()
        {
            serviceRequests = GetPosibleServiceRequests(GetBody(GetResponse(HttpMethod.GET, url)));
        }

        public static string GetRequest(string searchUrlByParameter, params string[] parameters)
        {
            try
            {
                string fullUrl = UrlBuilder(FindUrl(searchUrlByParameter, HttpMethod.GET), parameters);
                HttpWebResponse webResponse = GetResponse(HttpMethod.GET, fullUrl);
                serviceResponse = GetServiceResponse(GetBody(webResponse));
            }
            catch (JsonException jsonException)
            {
                ReportLog.WritingLogging(jsonException);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            return serviceResponse.content;
        }

        public static string PostRequest(string searchUrlByParameter, params string[] parameters)
        {
            try
            {
                string fullUrl = UrlBuilder(FindUrl(searchUrlByParameter, HttpMethod.POST), parameters);
                HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
                serviceResponse = GetServiceResponse(GetBody(webResponse));
            }
            catch (JsonException jsonException)
            {
                ReportLog.WritingLogging(jsonException);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            return serviceResponse.content;
        }

        public static string PutRequest(string searchUrlByParameter, params string[] parameters)
        {
            try
            {
                string fullUrl = UrlBuilder(FindUrl(searchUrlByParameter, HttpMethod.PUT), parameters);
                HttpWebResponse webResponse = GetResponse(HttpMethod.PUT, fullUrl);
                serviceResponse = GetServiceResponse(GetBody(webResponse));
            }
            catch (JsonException jsonException)
            {
                ReportLog.WritingLogging(jsonException);
            }
            catch (Exception exception)
            {
                ReportLog.WritingLogging(exception);
            }

            return serviceResponse.content;
        }

        public static string DeleteRequest(string searchUrlByParameter, params string[] parameters)
        {
            try
            {
                string fullUrl = UrlBuilder(FindUrl(searchUrlByParameter, HttpMethod.DELETE), parameters);
                HttpWebResponse webResponse = GetResponse(HttpMethod.DELETE, fullUrl);
                serviceResponse = GetServiceResponse(GetBody(webResponse));
            }
            catch (JsonException jsonException)
            {
                ReportLog.WritingLogging(jsonException);
            }
            catch (Exception exception)
            {
                ReportLog.WritingLogging(exception);
            }

            return serviceResponse.content;
        }

        #endregion
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
