using System;
using NUnit.Framework;
using System.Collections.Generic;
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

PUT		http://localhost:8080/item/{index}?token= &index= &item= &reqtype=updateItem
GET		http://localhost:8080/items?token= &reqtype=getAllItems
GET		http://localhost:8080/itemindexes?token= &reqtype=getAllItemsIndexes
GET		http://localhost:8080/item/{index}?token= &index= &reqtype=getItem
 */

    [TestFixture]
    public class BaseTestClass
    {
        private string token;

        public string Token
        {
            get { return token; }
        }

        [OneTimeSetUp]
        public void StartTest()
        {
            ReportLog.InitializationLogging(this.GetType().Name);
            ReportLog.WritingLogging(null, "Beginning of tests");
            GetAllRestRequest();
            GetToken();
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            ReportLog.WritingLogging(null, "Ends of tests");
            ReportLog.Dispose();

        }

        public void Log(string message)
        {
            ReportLog.WritingLogging(null, message);
        }

        private void GetToken()
        {
            token = PostRequest(login, adminLogin, adminPassword);
        }
    }
}
