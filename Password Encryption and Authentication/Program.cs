using System;

namespace Password_Encryption_and_Authentication
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.WriteLine("\n Welcome! Please select what you would like to do...");
            Console.WriteLine("[1]-Create User");
            Console.WriteLine("[2]-Login");
            Console.WriteLine("[3]-Exit");
            string input = Console.ReadLine();
            bool loggedIn = false;

            if (input == "1" || input == "2" || input == "3")
            {
                switch (input)
                {
                    case "1":
                        Authentication.CreateNewUser();
                        Start();
                        break;

                    case "2":
                        bool check = Authentication.CheckUser(Authentication.GetCredentials());
                        if (check == true)
                        {
                            Console.WriteLine("\n Credentials match!");
                            loggedIn = true;
                        }
                        else
                        {
                            Console.WriteLine("\n Credentials do not exist in this system. Try again...");
                            Start();
                        }
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n Please enter a valid input [ 1, 2, or 3 ]!");
                Console.WriteLine("Press any key if you understand");
                Console.ReadLine();

                Start();
            }

            if (loggedIn == true)
            {
                LoggedIntoSWEED();
            }
        }

        public static void LoggedIntoSWEED()
        {
            Console.WriteLine("Welcome to SWEED-(Sunny's Word Encryption Engine Doc)");
            Console.WriteLine("\n What would you like to do?");
            Console.WriteLine("[1]-SWEED a word");
            Console.WriteLine("[2]-unSWEED a word");
            Console.WriteLine("[3]-Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter a word for me to SWEED!");
                string plainText = Console.ReadLine();
                string cipherString = StringCypher.Encrypt(plainText);

                Console.WriteLine($"\n Your word was {plainText}");
                Console.WriteLine($"\n Your SWEED is {cipherString}");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n Enter your SWEED");
                string cipherString = Console.ReadLine();
                string plainText = StringCypher.Decrypt(cipherString);

                Console.WriteLine($"\n Your SWEED was {cipherString}");
                Console.WriteLine($"\n Your word is {plainText}");
            }
            else if (choice == "3")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n Please enter a valid choice");
            }

            LoggedIntoSWEED();
        }
    }
}
