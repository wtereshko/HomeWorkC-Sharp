using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebServiceTest
{
    [TestFixture]
    public class UserTests : BaseTestClass
    {
        private string actualResponse;
        private Dictionary<string, string> tokens = new Dictionary<string, string>();

        // http://localhost:8080/login?name=admin&password=qwerty&reqtype=login
        [TestCase("Viktor", "zxcasd")]
        [TestCase("Petro", "qazwsx")]
        public void TestLogin(string userName, string userPassword)
        {
            actualResponse = ServiceHelper.PostRequest(ServiceHelper.login, userName, userPassword);
            tokens.Add(userName, actualResponse);
            Log($"Test Login: user name: {userName}" +"\n" + $"token = {actualResponse}");
            Assert.AreEqual(32, actualResponse.Length);
        }

        // http://localhost:8080/user?adminToken= &newName= &newPassword= &adminRights= &reqtype=createUser
        [TestCase("Petro", "qazwsx", "true")]
        [TestCase("Viktor", "zxcasd", "false")]
        public void TestCreateUser(string userName, string userPassword, string adminRights)
        {
            actualResponse = ServiceHelper.PostRequest(ServiceHelper.user, Token, userName, userPassword, adminRights);
            Log($"Test Create User: user name: {userName} \n user right: {adminRights} \n result: {actualResponse}");
            Assert.AreEqual("true", actualResponse);
        }


        // http://localhost:8080/user?token= &reqtype=getUserName, 
        [TestCase("Viktor")]
        public void TestTakeUserName(string name)
        {
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.user, tokens[name]);
            Log($"Test Get User Name: user name = {actualResponse}");
            Assert.AreEqual(name, actualResponse);
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

        //http://localhost:8080/user?adminToken= &removedName= &reqtype=removeUser
        [TestCase("Oksana", "qazwsx", "true")]
        public void TestRemoveUser(string userName, string userPassword, string adminRights)
        {
            string addUserResult =
                        ServiceHelper.PostRequest(ServiceHelper.user, Token, userName, userPassword, adminRights);
            string removeResult = ServiceHelper.DeleteRequest(ServiceHelper.user, Token, userName);
            actualResponse = ServiceHelper.GetRequest(ServiceHelper.users, Token);

            Log("Test Remove User:" + "\n" + $"result add user: {addUserResult} " + "\n" +
                $"result remove user: {removeResult}" + "\n" +
                $"users in data base: {actualResponse}");

            StringAssert.DoesNotContain(userName, actualResponse);
        }
    }
}
