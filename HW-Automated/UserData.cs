using System;
using System.IO;
using Newtonsoft.Json;


public class UserData
{
    public static User GetUserData()
    {
        string userData;
        string path = "D:\\GitRepository\\HomeWorkC-Sharp\\HW-Automated\\Users.json";
        using (StreamReader reader = new StreamReader(path))
        {
            userData = reader.ReadAllLines();
        }

        User user = JsonConvert.DeserializeObject<User>(userData);
    }

    public struct User
    {
        public string firstName;
        public string lastName;
        public string email;
        public string telephone;
        public string fax;

        public string company;
        public string address_1;
        public string address_2;
        public string city;
        public string postCode;
        public string country;
        public string region;
        public string password;

    }

}
