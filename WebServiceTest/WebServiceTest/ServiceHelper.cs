using System;
using System.IO;
using System.Net;
using System.Net.Http;
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

    public class ServiceHelper
    {
        /*  
	GET		http://localhost:8080/reset?reqtype=resetServiceToInitialState",   
	POST	http://localhost:8080/login?name=admin&password=qwerty&reqtype=login,
    POST    http://localhost:8080/logout?name= &token=&reqtype=logout,
	PUT     http://localhost:8080/user?token= &oldPassword= &newPassword&reqtype=changePassword,    
	GET     http://localhost:8080/user?token= &getUserName,    
	GET     http://localhost:8080/cooldowntime?reqtype=getCoolDownTime,    
	GET     http://localhost:8080/tokenlifetime?reqtype=getTokenLifeTime",	
	PUT		http://localhost:8080/cooldowntime?adminToken= &newCoolDownTime= &reqtype=setCoolDownTime	
	PUT		http://localhost:8080/tokenlifetime?adminToken= &newTokenLifeTime= &reqtype=setTokenLifeTime	
	POST	http://localhost:8080/user?adminToken= &newName= &newPassword= &adminRights= &reqtype=
	DELETE	http://localhost:8080/user?adminToken= &removedName= &reqtype=removeUser
	GET		http://localhost:8080/admins?adminToken= &reqtype=getAllAdmins
	GET		http://localhost:8080/login/admins?adminToken= &reqtype=getLoginedAdmins
	GET		http://localhost:8080/locked/admins?adminToken= &reqtype=getLockedAdmins
	GET		http://localhost:8080/users?adminToken= &reqtype=getAllUsers
	GET		http://localhost:8080/login/users?adminToken= &reqtype=getLoginedUsers
	GET		http://localhost:8080/login/tockens?adminToken= &reqtype=getAliveTockens
	GET		http://localhost:8080/locked/users?adminToken= &reqtype=getLockedUsers
	POST	http://localhost:8080/locked/user/{name}?adminToken= &name= &reqtype=lockUser
	PUT		http://localhost:8080/locked/user/{name}?adminToken= &name= &reqtype=unlockUser
	PUT		http://localhost:8080/locked/reset?adminToken= &reqtype=unlockAllUsers
	GET		http://localhost:8080/item/user/{name}?adminToken = &name= &reqtype=getUserItems
	GET		http://localhost:8080/item/{index}/user/{name}?adminToken= &name= &index= &reqtype=getUserItem
	POST	http://localhost:8080/item/{index}?token= &item= &index =&reqtype=addItem
	DELETE	http://localhost:8080/item/{index}?token= &index= &reqtype=deleteItem
	PUT		http://localhost:8080/item/{index}?token= &index= &item= &reqtype=updateItem
	GET		http://localhost:8080/items?token= &reqtype=getAllItems
	GET		http://localhost:8080/itemindexes?token= &reqtype=getAllItemsIndexes
	GET		http://localhost:8080/item/{index}?token= &index= &reqtype=getItem
     */
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
        private static string url = "http://localhost:8080";
        private static string reqType = "&reqtype=";
        #endregion

        #region Methods

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Initialization REST Requests from web service
        /// </summary>
        /// <returns></returns>
        public static void InitRestRequest()
        {
            serviceRequests = GetPosibleServiceRequests(GetBody(GetResponse(HttpMethod.GET, url)));
        }

        /// <summary>
        /// Find request in web service requests
        /// </summary>
        /// <param name="findParameter"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        public static string FindRequest(string findParameter, HttpMethod httpMethod)
        {
            string[] strings = Array.FindAll(serviceRequests.content, s => s.Contains(findParameter));
            return Array.Find(strings, s => s.Contains(httpMethod.ToString()));
        }

        /// <summary>
        /// Create url with parameters. Parameters should set in order  which they are set in url order.
        ///  </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static string UrlBuilder(string requestData, params string[] parameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(url);
            string[] parseStrings = requestData.Split(',');
            stringBuilder.Append(parseStrings[0].Replace("URL=", ""));
            
            if (parseStrings.Length > 2)
            {
               stringBuilder.Append("?" + parseStrings[2].Replace("PARAMETERS= ", "") + $"={parameters[0]}");
                if (parseStrings.Length > 3)
                {
                    for (int i = 3; i < parseStrings.Length; i++)
                    {
                        int index = i - 2;
                        stringBuilder.Append("&" + parseStrings[i] + $"={parameters[index]}");
                    }
                }
            }
            return stringBuilder.Append(reqType + parseStrings[1].Split(' ')[2]).Replace(" ", "").ToString();
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
            webRequest.Method = httpMethod.ToString();
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
