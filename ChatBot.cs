using System;
using System.Media;
using System.IO;
using System.Threading;

namespace CyberSecurityAwarenessBot
{
    class Chatbot
    {
        private string userName;

        public void Start()
        {
            PlayVoiceGreeting();
            ShowLogo();
            ShowLoading();
            GetUserName();
            RunChat();
        }

        // Voice Greeting
        private void PlayVoiceGreeting()
        {
            try
            {
                string path =
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Greeting.wav"
                    );

                if (File.Exists(path))
                {
                    SoundPlayer player =
                        new SoundPlayer(path);

                    player.PlaySync();
                }
            }
            catch
            {
                Console.WriteLine("Audio could not be played.");
            }
        }

        // ASCII logo
        private void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
   _____       _                 _____                      
  / ____|     | |               / ____|                     
 | |     _   _| |__   ___ _ __ | (___   ___  ___ _   _ ___ 
 | |    | | | | '_ \ / _ \ '__| \___ \ / _ \/ __| | | / __|
 | |____| |_| | |_) |  __/ |    ____) |  __/ (__| |_| \__ \
  \_____|\__, |_.__/ \___|_|   |_____/ \___|\___|\__,_|___/
          __/ |                                            
         |___/                                             
        CYBER SECURITY AWARENESS BOT 🛡️
");

            Console.ResetColor();
        }

        // Loading Animation
        private void ShowLoading()
        {
            Console.Write("\nStarting chatbot");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(400);
                Console.Write(".");
            }

            Console.WriteLine("\n");
        }

        // Name Input with Validation
        private void GetUserName()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter your name: ");
                Console.ResetColor();

                userName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name. Please try again.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nHello {userName}! 👋");
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("Type 'menu' to view topics.");
            Console.WriteLine("Type 'exit' to quit.");

            Console.ResetColor();
        }

        // Chat Loop
        private void RunChat()
        {
            string input = "";

            while (input.ToLower() != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid message.");
                    continue;
                }

                string response =
                    Responses.GetResponse(input, userName);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Bot: " + response);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(
                $"\nGoodbye {userName}! Stay safe online 🛡️"
            );

            Console.ResetColor();
        }
    }
}