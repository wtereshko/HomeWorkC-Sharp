using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static WebServiceTest.ServiceHelper;

namespace WebServiceTest
{
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


    [TestFixture]
    public class TestClass
    {
        private ServiceRequests serviceRequests;
        private string token;

        [OneTimeSetUp]
        public void Start()
        {
            serviceRequests = GetAllRestRequests();
        }

        //[Test, Order(1)]
        //public void Test_Login()
        //{
        //    string [] request = RequestBuilder(serviceRequests.content[1]);
        //    string fullUrl = String.Format(request[1], "admin", "qwerty");
        //    HttpClient httpClient = new HttpClient();
        //   // httpClient.GetStringAsync(fullUrl);
        //    HttpWebResponse webResponse = GetResponse(request[0], fullUrl);
        //    Task <string> s = await httpClient.GetStringAsync(fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(s);
        //    token = serviceResponse.content;
        //    Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode);
        //}
    }
}
