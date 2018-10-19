using WebServiceTest;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHelper.GetAllRestRequests();
            string some = ServiceHelper.FindRequest(
                ServiceHelper.login, HttpMethod.POST);
        }
    }
}
