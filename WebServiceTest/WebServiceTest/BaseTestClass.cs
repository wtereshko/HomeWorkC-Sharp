using NUnit.Framework;

namespace WebServiceTest
{
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
            ServiceHelper.GetAllRestRequest();
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
            token = ServiceHelper.PostRequest(ServiceHelper.login, 
                        ServiceHelper.adminLogin, 
                        ServiceHelper.adminPassword);
        }
    }
}
