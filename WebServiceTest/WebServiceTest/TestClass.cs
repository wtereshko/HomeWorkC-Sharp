using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using static WebServiceTest.ServiceHelper;

namespace WebServiceTest
{
    /*  
GET		http://localhost:8080/reset?reqtype=resetServiceToInitialState",   
GET       
GET     http://localhost:8080/cooldowntime?reqtype=getCoolDownTime    
GET     http://localhost:8080/tokenlifetime?reqtype=getTokenLifeTime
PUT		http://localhost:8080/cooldowntime?adminToken= &newCoolDownTime= &reqtype=setCoolDownTime	
PUT		http://localhost:8080/tokenlifetime?adminToken= &newTokenLifeTime= &reqtype=setTokenLifeTime	
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

    [TestFixture]
    public class TestClass
    {
        private string token;
        private Dictionary<string, string> usersToken;

        [OneTimeSetUp]
        public void StartTest()
        {
            LoggingLog.InitializationLogging();
            LoggingLog.WritingLogging("Beginning of tests", null);
            InitRestRequest();
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            LoggingLog.WritingLogging("Ends of tests", null);
            LoggingLog.Dispose();
        }


        // http://localhost:8080/login?name=admin&password=qwerty&reqtype=login
        [Test, Order(1)]
        public void Test_Admin_Login()
        {
            string fullUrl = UrlBuilder(FindRequest(login, HttpMethod.POST), adminLogin, adminPassword);
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            token = serviceResponse.content;
            LoggingLog.WritingLogging($"Test Login: token = {serviceResponse.content}", null);
            Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode);
        }

        //http://localhost:8080/logout?name= &token=&reqtype=logout,
        [Test]
        public void Test_Logout()
        {
            string fullUrl = UrlBuilder(FindRequest(logout, HttpMethod.POST), adminLogin, token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test logout: result = {serviceResponse.content}", null);
            Assert.AreEqual("true", webResponse.StatusCode);
        }


        // http://localhost:8080/user?token= &reqtype=getUserName, 
        [Test]
        public void Test_Get_User_Name()
        {
            string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.GET), token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.GET, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Get User Name: user name = {serviceResponse.content}", null);
            Assert.AreEqual(adminLogin, serviceResponse.content);
        }

        //http://localhost:8080/item/{index}?token= &item= &index =&reqtype=addItem

        [Test]
        public void Test_Add_Item()
        {
            string fullUrl = UrlBuilder(FindRequest(item, HttpMethod.POST), token, "Ball", "2", "1");
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Add Item: result = {serviceResponse.content}", null);
            Assert.AreEqual("true", serviceResponse.content);
        }

        #region Not work tests

        // http://localhost:8080/user?adminToken= &newName= &newPassword= &adminRights= &reqtype=createUser
        //[TestCase("Petro", "qazwsx")]
        //[TestCase("Oksana", "zxcasd")]
        //[TestCase("Viktoriya", "edcrfv")]
        //public void Test_Create_User(string userName, string userPassword)
        //{
        //    string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.POST), token, userName, userPassword, "true");
        //    HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
        //    LoggingLog.WriteWritingLogging($"{webResponse.StatusCode} {serviceResponse.content}", null);
        //    Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode, $"Message from service {serviceResponse.content}");
        //}

        //[TestCase("Petro", "qazwsx")]
        //[TestCase("Oksana", "zxcasd")]
        //[TestCase("Viktoriya", "edcrfv")]
        //public void Test_User_Login(string userName, string userPassword)
        //{
        //    string fullUrl = UrlBuilder(FindRequest(login, HttpMethod.POST), userName, userPassword);
        //    HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
        //    try
        //    { usersToken.Add(userName, serviceResponse.content); }
        //    catch (Exception exception)
        //    {
        //        LoggingLog.WriteWritingLogging("ex", exception);
        //    }

        //    Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode, serviceResponse.content);
        //}

        //http://localhost:8080/user?token= &oldPassword= &newPassword&reqtype=changePassword,
        //public void Test_Change_User_Paswword()
        //{
        //    string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.PUT), usersToken["Petro"], "qazwsx", "edcrfv");
        //    HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
        //    Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode, serviceResponse.content);
        //}
        #endregion
    }
}
