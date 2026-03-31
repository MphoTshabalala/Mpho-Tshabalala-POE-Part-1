using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBot
{
    using System;

    public class UserInterface
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
                      
            Console.WriteLine(@"
        [ 🔒 CYBER SAFE 🔒 ]

           _________
          |  _____  |
          | |     | |
          | | 🔒 | |
          | |_____| |
          |_________|

        Stay Safe Online!
        ");

            Console.ResetColor();
        }
    }
}
