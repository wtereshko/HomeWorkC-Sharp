using System.IO;
using System.Reflection;
using Newtonsoft.Json;


public class UserData
{
    public static ListUsers GetUsersData()
    {
        string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "");
        string path = Path.Combine(folderPath, "Users.json");
        string userData;

        using (StreamReader reader = new StreamReader(path))
        {
            userData = reader.ReadToEnd();
        }

        ListUsers users = JsonConvert.DeserializeObject<ListUsers>(userData);
        return users;
    }
}

public struct User
{
    private string firstName;
    private string lastName;
    private string email;
    private string telephone;
    private string fax;

    private string company;
    private string address_1;
    private string address_2;
    private string city;
    private string postCode;
    private string country;
    private string region;
    private string password;

}

public struct ListUsers
    {
        public User[] Users { get; set; }
    }

