using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic;

namespace Ex3.ConsoleUI
{
    public class ConsoleUI
    {
        public void PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendFormat("Welcome to the garage!{0}", Environment.NewLine);
            menu.AppendFormat("Please choose an option from the menu: {0}", Environment.NewLine);
            menu.AppendFormat("1. Insert new vehicle to the garage{0}", Environment.NewLine);
            menu.AppendFormat("2. Display the garage cars license numbers{0}", Environment.NewLine);
            menu.AppendFormat("3. Change car's status in the garage{0}", Environment.NewLine);
            menu.AppendFormat("4. Fill air pressure to maximum for a vehicle{0}", Environment.NewLine);
            menu.AppendFormat("5. Fill gas in a vehicle{0}", Environment.NewLine);
            menu.AppendFormat("6. Charge an electric vehicle{0}", Environment.NewLine);
            menu.AppendFormat("7. Display full details on a vehicle{0}", Environment.NewLine);
            Console.WriteLine(menu);
        }

        public void PrintToScreen(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public string GetUserInput(string i_TextToDisplay="")
        {
            if (i_TextToDisplay.Length > 0)
            {
                Console.WriteLine(i_TextToDisplay);
            }

            return Console.ReadLine();
        }
    }
}
