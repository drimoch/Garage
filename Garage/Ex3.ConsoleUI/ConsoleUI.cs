﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic;
using Ex3.GarageLogic.Enums;

namespace Ex3.ConsoleUI
{
    public static class ConsoleUI
    {
        private const string k_Quit = "Q";
        private const string k_StringEmpty = "";

        public static string Quit
        {
            get
            {
                return k_Quit;
            }
        }

        public static void PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendFormat("======================================================================================================{0}", Environment.NewLine);
            menu.AppendFormat("Please choose an option from the menu (you can press {0} at any point in order to go back to the menu): {1}", k_Quit, Environment.NewLine);
            menu.AppendFormat("1. Insert new vehicle to the garage{0}", Environment.NewLine);
            menu.AppendFormat("2. Display the garage cars license numbers{0}", Environment.NewLine);
            menu.AppendFormat("3. Change vehicle's status in the garage{0}", Environment.NewLine);
            menu.AppendFormat("4. Fill air pressure to maximum for a vehicle{0}", Environment.NewLine);
            menu.AppendFormat("5. Fill gas in a vehicle{0}", Environment.NewLine);
            menu.AppendFormat("6. Charge an electric vehicle{0}", Environment.NewLine);
            menu.AppendFormat("7. Display full details on a vehicle{0}", Environment.NewLine);
            menu.AppendFormat("======================================================================================================{0}", Environment.NewLine);
            Console.WriteLine(menu);
        }

        public static void PrintToScreen(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public static string GetUserInput(string i_TextToDisplay = k_StringEmpty)
        {
            if (i_TextToDisplay.Length > 0)
            {
                Console.WriteLine(i_TextToDisplay);
            }

            string input = Console.ReadLine();
            if(input == k_Quit)
            {
                UIManager.StartMenu();
            }

            return input;
        }

        public static string GetField(string i_Field, bool i_LettersNumbersOnly = false, bool i_NumbersOnly = false, bool i_LettersOnly = false)
        {
            string input = GetUserInput(i_Field);

            if (i_LettersNumbersOnly)
            {
                while (!isOnlyLettersNumbers(input))
                {
                    PrintToScreen("The field should contain only letters, numbers and spaces");
                    input = GetUserInput("Please try again: ");
                }
            }
            else if (i_NumbersOnly)
            {
                while (!isOnlyNumbers(input))
                {
                    PrintToScreen("The field should contain only numbers");
                    input = GetUserInput("Please try again: ");
                }
            }
            else if (i_LettersOnly)
            {
                while (!isOnlyLetters(input))
                {
                    PrintToScreen("The field should contain only letters and spaces");
                    input = GetUserInput("Please try again: ");
                }
            }

            return input;
        }

        private static bool isOnlyLettersNumbers(string i_Input)
        {
            bool isValid = true;

            foreach (char character in i_Input)
            {
                if (!char.IsLetterOrDigit(character) && character != ' ')
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool isOnlyLetters(string i_Input)
        {
            bool isValid = true;

            foreach (char character in i_Input)
            {
                if (!char.IsLetter(character) && character != ' ')
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool isOnlyNumbers(string i_Input)
        {
            bool isValid = true;

            foreach (char character in i_Input)
            {
                if (!char.IsDigit(character)) 
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public static TEnum ParseEnum<TEnum>(string i_Value)
        {
            TEnum convertedEnum;
            int toInt = ConvertToInt(i_Value);

            while (!Enum.IsDefined(typeof(TEnum), toInt))
            {
                i_Value = GetUserInput("Invalid input, please choose a number in the displayed range: ");
                toInt = ConvertToInt(i_Value);
            }

            convertedEnum = (TEnum)Enum.ToObject(typeof(TEnum), toInt);

            return convertedEnum;
        }

        public static void CreateEnumArray<TEbum>()
        {
            StringBuilder typeMenu = new StringBuilder();
            string[] enumTypes = Enum.GetNames(typeof(TEbum));
            int counter = 1;

            foreach (string type in enumTypes)
            {
                typeMenu.AppendFormat("{0} - {1}", counter++, type);
                typeMenu.Append(Environment.NewLine);
            }

            PrintToScreen(typeMenu.ToString());
        }

        public static int ConvertToInt(string i_Value)
        {
            bool isInt = int.TryParse(i_Value, out int valueInt);

            while (!isInt)
            {
                i_Value = GetUserInput("ERROR: Field must be a number");
                isInt = int.TryParse(i_Value, out valueInt);
            }

            return valueInt;
        }

        public static float ConvertToFloat(string i_Value)
        {
            bool isFloat = float.TryParse(i_Value, out float valueFloat);

            while (!isFloat)
            {
                i_Value = GetUserInput("ERROR: Field must be a number");
                isFloat = float.TryParse(i_Value, out valueFloat);
            }

            return valueFloat;
        }

        public static string FindEnumType(Type i_Type)
        {
            string input;

            if (i_Type == typeof(eColor))
            {
                CreateEnumArray<eColor>();
                input = GetUserInput();
                input = ParseEnum<eColor>(input).ToString();
            }
            else if (i_Type == typeof(eGasType))
            {
                CreateEnumArray<eGasType>();
                input = GetUserInput();
                input = ParseEnum<eGasType>(input).ToString();
            }
            else if (i_Type == typeof(eLicenseType))
            {
                CreateEnumArray<eLicenseType>();
                input = GetUserInput();
                input = ParseEnum<eLicenseType>(input).ToString();
            }
            else if (i_Type == typeof(eNumOfDoors))
            {
                CreateEnumArray<eNumOfDoors>();
                input = GetUserInput();
                input = ParseEnum<eNumOfDoors>(input).ToString();
            }
            else if (i_Type == typeof(eVehicleStatus))
            {
                CreateEnumArray<eVehicleStatus>();
                input = GetUserInput();
                input = ParseEnum<eVehicleStatus>(input).ToString();
            }
            else if (i_Type == typeof(eVehicleType))
            {
                CreateEnumArray<eVehicleType>();
                input = GetUserInput();
                input = ParseEnum<eVehicleType>(input).ToString();
            }
            else
            {
                PrintToScreen("Member's type is invalid, moving on...");
                input = string.Empty;
            }

            return input;
        }

        public static string HandleBooleanType(string i_MemberName)
        {
            PrintToScreen(string.Format("1 - Yes{0}2 - No", Environment.NewLine));
            string input = GetUserInput("Your Choice: ");
            while (input != "1" && input != "2")
            {
                input = GetUserInput("The input is invalid, please choose 1 or 2: ");
            }

            input = input == "1" ? "true" : "false";

            return input;
        }
    }
}
