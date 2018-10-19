using WebServiceTest;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHelper.GetAllRestRequests();
            string some = ServiceHelper.FindRequest(string.Concat(ServiceHelper.login, ServiceHelper.tockens), ServiceHelper.HttpMethod.POST);
        }
    }
}
