using System;

namespace CyberSecurityAwarenessBot
{
    //chats 
    class Responses
    {
        public static string GetResponse(
            string input,
            string userName)
        {
            input = input.ToLower();

            if (input == "menu")
            {
                return ShowMenu();
            }

            else if (input.Contains("password"))
            {
                return $"{userName}, always use strong passwords with letters, numbers, and symbols.";
            }

            else if (input.Contains("phishing"))
            {
                return $"{userName}, phishing emails try to steal your information. Always verify links before clicking.";
            }

            else if (input.Contains("malware"))
            {
                return $"{userName}, malware is harmful software. Install antivirus protection.";
            }

            else if (input.Contains("browsing"))
            {
                return $"{userName}, always use secure websites (https) when browsing.";
            }

            else if (input.Contains("wifi"))
            {
                return $"{userName}, avoid using public Wi-Fi for sensitive information.";
            }

            else if (input == "exit")
            {
                return "Goodbye!";
            }

            else
            {
                return "I didn't understand that. Type 'menu' to see available topics.";
            }
        }
        //The main Menu 
        private static string ShowMenu()
        {
            return "\n========= CYBERSECURITY MENU =========\n" +
                   "• Password Safety\n" +
                   "• Phishing Awareness\n" +
                   "• Malware Protection\n" +
                   "• Safe Browsing\n" +
                   "• Public Wi-Fi Safety\n" +
                   "Type a topic name.";
        }
    }
}