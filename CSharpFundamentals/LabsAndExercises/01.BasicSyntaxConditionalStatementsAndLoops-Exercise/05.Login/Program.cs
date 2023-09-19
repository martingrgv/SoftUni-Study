using System.Security.Cryptography.X509Certificates;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loggedIn = false;
            bool blockedUser = false;
            int attempts = 0;
            string usernameInput = Console.ReadLine();
            string correctPassword = String.Empty;

            // Reverse username as password
            for (int i = usernameInput.Length; i > 0; i--)
            {
                correctPassword += usernameInput[i - 1];
            }

            while (!loggedIn && !blockedUser)
            {
                string passwordInput = Console.ReadLine();

                if (passwordInput == correctPassword) // if password correct print login
                {
                    Console.WriteLine("User {0} logged in.", usernameInput);
                    loggedIn = true;
                    break;
                }
                else
                {
                    if (attempts < 3) // cup attempts
                    {
                        attempts++;
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                    else // block user
                    {
                        blockedUser = true;
                        Console.WriteLine("User {0} blocked!", usernameInput);
                    }
                }
            }
        }
    }
}