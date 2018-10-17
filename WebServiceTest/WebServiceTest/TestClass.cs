using NUnit.Framework;
using System;
using System.Net;
using static WebServiceTest.ServiceHelper;

namespace WebServiceTest
{
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

        [Test, Order(1)]
        public void Test_Login()
        {
            string [] request = RequestBuilder(serviceRequests.content[1]);
            string fullUrl = String.Format(request[1], "admin", "qwerty");
            HttpWebResponse webResponse = GetResponse(request[0], fullUrl);
            ServiceResponse serviceResponse = GetServiceResponse(GetBody(webResponse));
            token = serviceResponse.content;
            Assert.AreEqual(HttpStatusCode.OK, webResponse.StatusCode);
        }
    }
}
