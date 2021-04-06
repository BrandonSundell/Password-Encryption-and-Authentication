using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Encryption_and_Authentication
{
    class Authentication
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Authentication()
        {
            Username = "Guest";
            Password = null;
        }
        public Authentication(string user, string password)
        {
            Username = user;
            Password = password;
        }

        public static List<Authentication> Users = new List<Authentication>();

        public static void CreateNewUser()
        {
            Console.WriteLine("Please enter your username...");
            string userName = Console.ReadLine();

            Console.WriteLine("Choose a new password(Must be at least 15 characters)...");
            string password = Console.ReadLine();
            while (password.Length < 15)
            {
                Console.WriteLine("Please enter a password that is at least 15 characters");
                password = Console.ReadLine();
            }           

            Authentication newUser = new Authentication(userName, password);

            Users.Add(newUser);

            Console.WriteLine("\n User has been created.");
        }

        public static Authentication GetCredentials()
        {
            Console.WriteLine("Enter your existing username...");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter your password...");
            string password = Console.ReadLine();

            Authentication credentials = new Authentication(userName, password);

            return credentials;
        }

        public static bool CheckUser(Authentication credentials)
        {
            bool userExists = false;

            for (int i = 0; i < Users.Count; i++)
            {
                if(credentials.Username == Users[i].Username && credentials.Password == Users[i].Password)
                {
                    userExists = true;
                }
            }

            return userExists;
        }
    }
}
