using WebServiceTest;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHelper.InitRestRequest();
            string some = ServiceHelper.FindRequest(ServiceHelper.login, HttpMethod.POST);
            ServiceHelper.UrlBuilder(some, "admin", "qwerty");
        }
    }
}
