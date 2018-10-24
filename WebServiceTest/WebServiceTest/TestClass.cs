using System;
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
GET		http://localhost:8080/login/tockens?adminToken= &reqtype=getAliveTockens
GET		http://localhost:8080/locked/users?adminToken= &reqtype=getLockedUsers
POST	http://localhost:8080/locked/user/{name}?adminToken= &name= &reqtype=lockUser
PUT		http://localhost:8080/locked/user/{name}?adminToken= &name= &reqtype=unlockUser
PUT		http://localhost:8080/locked/reset?adminToken= &reqtype=unlockAllUsers

GET		http://localhost:8080/item/user/{name}?adminToken = &name= &reqtype=getUserItems
GET		http://localhost:8080/item/{index}/user/{name}?adminToken= &name= &index= &reqtype=getUserItem
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
        private string allItems = string.Empty;
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

        #region Tests User Data
                    
        // http://localhost:8080/login?name=admin&password=qwerty&reqtype=login
        [Test, Order(1)]
        public void TestAdminLogin()
        {
            string fullUrl = UrlBuilder(FindRequest(login, HttpMethod.POST), adminLogin, adminPassword);
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            token = serviceResponse.content;
            LoggingLog.WritingLogging($"Test Login: token = {serviceResponse.content}", null);
            Assert.AreEqual(32, serviceResponse.content.Length);
        }

        // http://localhost:8080/user?token= &reqtype=getUserName, 
        [Test]
        public void TestGetUserName()
        {
            string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.GET), token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.GET, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Get User Name: user name = {serviceResponse.content}", null);
            Assert.AreEqual(adminLogin, serviceResponse.content);
        }

        // http://localhost:8080/user?adminToken= &newName= &newPassword= &adminRights= &reqtype=createUser
        [TestCase("Petro", "qazwsx", "true")]
        [TestCase(testUserName, testUserPassword, "false")]
        public void TestCreateUser(string userName, string userPassword, string adminRights)
        {
            string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.POST), token, userName, userPassword, adminRights);
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Create User: {userName} - {serviceResponse.content}", null);
            Assert.AreEqual("true", serviceResponse.content);
        }

        //http://localhost:8080/login/users?adminToken= &reqtype=getLoginedUsers
        [Test]
        public void TestGetLogginedUser()
        {
            string fullUrl = UrlBuilder(FindRequest(String.Concat(login, users), HttpMethod.GET), token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.GET, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Get Loggined User: result = {serviceResponse.content}", null);
            StringAssert.Contains(adminLogin, serviceResponse.content);
        }
        
        //http://localhost:8080/users?adminToken= &reqtype=getAllUsers
        [Test]
        public void TestGetAllUser()
        {
            string fullUrl = UrlBuilder(FindRequest(users, HttpMethod.GET), token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.GET, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Get All User: result = \n {serviceResponse.content}", null);
            StringAssert.Contains(testUserName, serviceResponse.content);
        }

        ////http://localhost:8080/user?token= &oldPassword= &newPassword&reqtype=changePassword,
        //public void TestChangeUserPaswword()
        //{
        //    string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.PUT), usersToken["Petro"], "qazwsx", "edcrfv");
        //    HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
        //    Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode);
        //}


        ////DELETE http://localhost:8080/user?adminToken= &removedName= &reqtype=removeUser
        //public void TestRemoveUser()
        //{
        //    string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.DELETE), token);
        //    HttpWebResponse webResponse = GetResponse(HttpMethod.DELETE, fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
        //    Assert.AreEqual("true", webResponse.StatusCode);
        //}

        //http://localhost:8080/logout?name= &token=&reqtype=logout,
        [Test]
        public void TestUserLogout()
        {
            string fullUrl = UrlBuilder(FindRequest(logout, HttpMethod.POST), adminLogin, token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test logout: result = {serviceResponse.content}", null);
            Assert.AreEqual("true", serviceResponse.content);
        }

        #endregion

        #region Tests Items
        
        //http://localhost:8080/item/{index}?token= &item= &index =&reqtype=addItem  "1 \tSquare\n2 \tCircle\n3 \tRegtangle\n"
        [TestCase("Square", "1")]
        [TestCase(testItem, testIndex)]
        public void TestAddItem(string itemName, string index)
        {
            allItems += string.Format(index + " " + "\t" + itemName + "\n");
            string fullUrl = UrlBuilder(FindRequest(item, HttpMethod.POST), token, itemName, index);
            HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Add Item: result = {serviceResponse.content}", null);
            Assert.AreEqual("true", serviceResponse.content);
        }
 
        //http://localhost:8080/items?token= &reqtype=getAllItems  
        [Test]
        public void TestGetAllItems() {
            string fullUrl = UrlBuilder(FindRequest(items, HttpMethod.GET), token);
            HttpWebResponse webResponse = GetResponse(HttpMethod.GET, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Get All Items: result = {serviceResponse.content}", null);
           // Assert.AreEqual(allItems, serviceResponse.content);
            StringAssert.Contains(testItem, serviceResponse.content);
        }

        //http://localhost:8080/item/{index}?token= &index= &reqtype=deleteItem
        [Test]
        public void TestRemoveItem()
        {
            string fullUrl = UrlBuilder(FindRequest(item, HttpMethod.DELETE), token, testIndex);
            HttpWebResponse webResponse = GetResponse(HttpMethod.DELETE, fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            LoggingLog.WritingLogging($"Test Remove Item: result = {serviceResponse.content}", null);
            Assert.AreEqual("true", serviceResponse.content);
        }
       
        #endregion

    }
}
