using System;
using NUnit.Framework;

namespace WebServiceTest
{
    [TestFixture]
    public class UserTests : BaseTestClass
    {
        private string actualResponse;
        private string addedUsers = string.Empty;
        

        // http://localhost:8080/login?name=admin&password=qwerty&reqtype=login
        [TestCase("Viktor", "zxcasd")]
        public void TestLogin(string userName, string userPassword)
        {
            actualResponse = ServiceHelper.PostRequest(ServiceHelper.login, userName, userPassword);
            Log($"Test Login: token = {actualResponse}");
            Assert.AreEqual(32, actualResponse.Length);
        }

        // http://localhost:8080/user?adminToken= &newName= &newPassword= &adminRights= &reqtype=createUser
        [TestCase("Petro", "qazwsx", "true")]
        [TestCase("Viktor", "zxcasd", "false")]
        public void TestCreateUser(string userName, string userPassword, string adminRights)
        {
            addedUsers += string.Format($"%{userName}%");
            actualResponse = ServiceHelper.PostRequest(ServiceHelper.user, Token, userName, userPassword, adminRights);
            Log($"Test Create User: user name: {userName} \n user right: {adminRights} \n result: {actualResponse}");
            Assert.AreEqual("true", actualResponse);
        }


        // http://localhost:8080/user?token= &reqtype=getUserName, 
        [Test]
        public void TestGetUserName()
        {
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.user, Token);
            Log($"Test Get User Name: user name = {actualResponse}");
            Assert.AreEqual(ServiceHelper.adminLogin, actualResponse);
        }

        //http://localhost:8080/login/users?adminToken= &reqtype=getLoginedUsers
        [Test]
        public void TestGetLogginedUser()
        {
            actualResponse = ServiceHelper.GetRequest(String.Concat(ServiceHelper.login, ServiceHelper.users), Token);
            Log($"Test Get Loggined User: result = {actualResponse}");
            StringAssert.Contains(ServiceHelper.adminLogin, actualResponse);
        }

        //http://localhost:8080/users?adminToken= &reqtype=getAllUsers
        [Test]
        public void TestGetAllUser()
        {
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.users, Token);
            ReportLog.WritingLogging(null, $"Test Get All User: result = \n {actualResponse}");
            Assert.AreEqual(124, actualResponse.Length);
        }

        ////http://localhost:8080/user?token= &oldPassword= &newPassword&reqtype=changePassword,
        //public void TestChangeUserPaswword()
        //{
        //    string fullUrl = UrlBuilder(FindRequest(user, HttpMethod.PUT), usersToken["Petro"], "qazwsx", "edcrfv");
        //    HttpWebResponse webResponse = GetResponse(HttpMethod.POST, fullUrl);
        //    ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
        //    Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode);
        //}


        //http://localhost:8080/user?adminToken= &removedName= &reqtype=removeUser
        [TestCase("Oksana", "qazwsx", "true")]
        public void TestRemoveUser(string userName, string userPassword, string adminRights)
        {
            string addUserResult =
                        ServiceHelper.PostRequest(ServiceHelper.user, Token, userName, userPassword, adminRights);
            string removeResult = ServiceHelper.DeleteRequest(ServiceHelper.user, Token, userName);
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.users, Token);

            Log("Test Remove User:" + "\n" + $"result add user = {addUserResult} " + "\n" +
                $"result remove user= {removeResult}" + "\n" +
                $"users in data base = {actualResponse}");

            StringAssert.DoesNotContain(userName, actualResponse);
        }

        //http://localhost:8080/logout?name= &token=&reqtype=logout,
        //[Test]
        //public void TestLogout()
        //{
        //    ServiceResponse serviceResponse = Post(logout, adminLogin, Token);
        //    LoggingLog.WritingLogging($"Test logout: result = {serviceResponse.content}", null);
        //    Assert.AreEqual("true", serviceResponse.content);
        //}

    }
}
