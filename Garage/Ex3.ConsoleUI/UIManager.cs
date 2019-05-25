using Ex3.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;
using System.Reflection;

namespace Ex3.ConsoleUI
{
    class UIManager
    {
        // Members
        private readonly ConsoleUI r_ConsoleUI;
        private const bool v_LettersNumbersOnly = true;
        private const bool v_NumbersOnly = true;
        private const bool v_LettersOnly = true;
        private const int k_EnumDefault = 0;
        // Methods
        public UIManager()
        {
            r_ConsoleUI = new ConsoleUI();
        }

        public void StartMenu()
        {
            r_ConsoleUI.PrintMenu();
            string userInput = r_ConsoleUI.GetUserInput();
            parseUserInput(userInput);
        }

        private void parseUserInput(string i_UserInput)
        {
            int input;

            try
            {
                input = int.Parse(i_UserInput);
                handleUserInput(input);
            }
            catch (Exception ex)
            {
                r_ConsoleUI.PrintToScreen("Failed to get user choice, please try again");
                Console.WriteLine(ex.Message);
                StartMenu();
            }
        }

        private void handleUserInput(int i_Input)
        {
            switch (i_Input)
            {
                case 1:
                    insertNewVehicleToGarage();
                    break;
                case 2:
                    displayCarLicenseNumbers();
                    break;
                case 3:
                     changeVehicleStatus();
                     break;
                 case 4:
                     inflateTiresToMax();
                     break;
                 case 5:
                     fillGasInVehicle();
                     break;
                 case 6:
                     chargeElectricVehicle();
                     break;
                case 7:
                    displayFullDetails();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose an option from the menu");
                    StartMenu();
                    break;
            }

            StartMenu();
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = getField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            createEnumArray<eVehicleStatus>();
            string newStatus = getField("New Status: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eVehicleStatus statusEnum = parseEnum<eVehicleStatus>(newStatus);
            try
            {
                Garage.ChangeVehicleStatus(licenseNumber, statusEnum);
                r_ConsoleUI.PrintToScreen("Vehicle status was changed successfully");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("An error occured...");
            }
        }

        private void inflateTiresToMax()
        {
            string licenseNumber = getField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            try
            {
                Garage.InflateWheelsToMax(licenseNumber);
                r_ConsoleUI.PrintToScreen("The wheels were successfully filled to maximum");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("An error occured...");
            }
        }

        private void fillGasInVehicle()
        {
            string licenseNumber = getField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            createEnumArray<eGasType>();
            string gasType = getField("Gas Type: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eGasType gasTypeEnum = parseEnum<eGasType>(gasType);
            string amount = getField("Amount: ", !v_LettersNumbersOnly, v_NumbersOnly);
            try
            {
                Garage.FuelVehicle(licenseNumber, gasTypeEnum, float.Parse(amount));
                r_ConsoleUI.PrintToScreen("Gas was filled successfully");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("An error occured...");
            }
        }
   
        private void chargeElectricVehicle()
        {
            string licenseNumber = getField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            string minutes = getField("Number of minutes to charge: ", !v_LettersNumbersOnly, v_NumbersOnly);
            try
            {
                Garage.ChargeElectricVehicle(licenseNumber, int.Parse(minutes));
                r_ConsoleUI.PrintToScreen("Vehicle was charged successfully");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("An error occured...");
            }
        }

        private void displayFullDetails()
        {
            string licenseNumber = getField("Please enter license number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            string vehicleDetails;
            try
            {
                vehicleDetails = Garage.CreateStringVehicleDetails(licenseNumber);
                r_ConsoleUI.PrintToScreen(vehicleDetails);
            }
            catch(ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("Could not print vehicle details since an error occured");
            }
        }

        private int convertToInt(string i_Value)
        {
            bool isInt = int.TryParse(i_Value, out int valueInt);
            while (!isInt)
            {
                i_Value = r_ConsoleUI.GetUserInput("Failed to handle the field, please choose a number from the available values: ");
                isInt = int.TryParse(i_Value, out valueInt);
            }

            return valueInt;
        }

        private TEnum parseEnum<TEnum>(string i_Value)
        {
            TEnum convertedEnum;
            int toInt = convertToInt(i_Value);
            while (!Enum.IsDefined(typeof(TEnum), toInt))
            {
                i_Value = r_ConsoleUI.GetUserInput("Invalid input, please choose a number in the displayed range: ");
                toInt = convertToInt(i_Value);
            }

            try
            {
                convertedEnum = (TEnum)Enum.ToObject(typeof(TEnum), toInt);
            }
            catch (Exception)
            {
                i_Value = r_ConsoleUI.GetUserInput("Failed to handle the field, please choose a number from the available values: ");
                convertedEnum = parseEnum<TEnum>(i_Value);
            }
            
            return convertedEnum;
        }

        /*private TEnum convertToEnum<TEnum>(string i_Value)
        {
            while (!Enum.IsDefined(typeof(TEnum), i_Value))
            {
                i_Value = r_ConsoleUI.GetUserInput("Invalid value, please try again: ");
            }

            return parseEnum<TEnum>(i_Value);
        }*/

        private void displayCarLicenseNumbers()
        {
            string status = getField("Please choose vehicles status: ", !v_LettersNumbersOnly, v_NumbersOnly);
            createEnumArray<eVehicleStatus>();
            eVehicleStatus statusEnum = parseEnum<eVehicleStatus>(status);
            List<string> vehicleLicenses = Garage.GetVehiclesByStatus(statusEnum);
            StringBuilder licenseList = new StringBuilder("Vehicle license numbers: ");
            foreach (string license in vehicleLicenses)
            {
                licenseList.Append(Environment.NewLine);
                licenseList.Append(license);
            }

            r_ConsoleUI.PrintToScreen(licenseList.ToString());
        }

        private void createEnumArray<TEbum>()
        {
            StringBuilder typeMenu = new StringBuilder("Please choose a type: ");
            Array enumTypes = Enum.GetValues(typeof(TEbum));
            int counter = 1;

            foreach (TEbum type in enumTypes)
            {
                typeMenu.Append(Environment.NewLine);
                typeMenu.AppendFormat("{0} - {1}", counter++, Enum.GetName(typeof(TEbum), type));
            }

            r_ConsoleUI.PrintToScreen(typeMenu.ToString());
        }

        private string getField(string i_Field, bool i_LettersNumbersOnly = false, bool i_NumbersOnly = false, bool i_LettersOnly = false)
        {
            string input = r_ConsoleUI.GetUserInput(i_Field);
            if (i_LettersNumbersOnly)
            {
                while (!isOnlyLettersNumbers(input))
                {
                    r_ConsoleUI.PrintToScreen("The field should contain only letters, numbers and spaces");
                    input = r_ConsoleUI.GetUserInput("Please try again: ");
                }
            }
            else if (i_NumbersOnly)
            {
                while (!isOnlyNumbers(input))
                {
                    r_ConsoleUI.PrintToScreen("The field should contain only numbers");
                    input = r_ConsoleUI.GetUserInput("Please try again: ");
                }
            }
            else if (i_LettersOnly)
            {
                while (!isOnlyLetters(input))
                {
                    r_ConsoleUI.PrintToScreen("The field should contain only letters and spaces");
                    input = r_ConsoleUI.GetUserInput("Please try again: ");
                }
            }

            return input;
        }

        private bool isOnlyLettersNumbers(string i_Input)
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

        private bool isOnlyLetters(string i_Input)
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

        private bool isOnlyNumbers(string i_Input)
        {
            bool isValid = true;

            foreach (char character in i_Input)
            {
                if (!char.IsDigit(character) && character != '.') // dot in case of float
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private void insertNewVehicleToGarage()
        {
            Vehicle vehicle = setBasicVehicleInfo();
            setSpecificMembersPerVehicleType(ref vehicle);
            setVehicleOwnerInfo(out string o_Owner, out string o_Phone);
            if (!VehicleInitiator.InsertVehicleToGarage(vehicle, o_Phone, o_Owner)) // this method will change the status to InRepair if vehicle is already in garage
            {
                r_ConsoleUI.PrintToScreen("Car was successfully inserted to the garage");
            }
            else
            {
                r_ConsoleUI.PrintToScreen("Car already exists in the garage, changing its status to InRepair");
            }
        }

        private void setVehicleOwnerInfo(out string o_Owner, out string o_Phone)
        {
            o_Owner = getField("Owner's name: ", !v_LettersNumbersOnly, !v_NumbersOnly, v_LettersOnly);
            o_Phone = getField("Phone number: ", !v_LettersNumbersOnly, v_NumbersOnly);
        }

        private Vehicle setBasicVehicleInfo()
        {
            r_ConsoleUI.PrintToScreen(string.Format("Please enter the following details:{0}", Environment.NewLine));
            string licenseNumber = getField("License number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            createEnumArray<eVehicleType>();
            string type = getField("Vehicle type: ", v_LettersNumbersOnly);
            eVehicleType vehicleType = parseEnum<eVehicleType>(type);
            string model = getField("Model's name: ", v_LettersNumbersOnly);
            Vehicle newVehicle = VehicleInitiator.CreateVehicle(licenseNumber, vehicleType, model);
            setEngine(ref newVehicle, vehicleType);
            getWheelsInfo(vehicleType, ref newVehicle);

            return newVehicle;
        }

        private void setEngine(ref Vehicle io_Vehicle, eVehicleType i_Type)
        {
            eGasType gasTypeEnum = k_EnumDefault;
            bool isElectric = i_Type == eVehicleType.ElectricCar || i_Type == eVehicleType.ElectricMotorcycle;
            string currentEnergy = getField("Amount of energy left: ", !v_LettersNumbersOnly, v_NumbersOnly);
            if (!isElectric)
            {
                createEnumArray<eGasType>();
                string gasType = getField("Gas type: ");
                gasTypeEnum = parseEnum<eGasType>(gasType);
            }

            try
            {
                VehicleInitiator.InitEngine(i_Type, float.Parse(currentEnergy), out Engine engine, ref io_Vehicle, gasTypeEnum);
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("{0}{1}{2}", ex.Message, Environment.NewLine, "Try again"));
                setEngine(ref io_Vehicle, i_Type);
            }
        }

        private void getWheelsInfo(eVehicleType i_Type, ref Vehicle o_Vehicle)
        {
            string manufacturer = getField("Manufacturer name: ", !v_LettersNumbersOnly, !v_NumbersOnly, v_LettersOnly);
            string airPressure = getField("Current air pressure: ", !v_LettersNumbersOnly, v_NumbersOnly);
            setWheels(manufacturer, float.Parse(airPressure), i_Type, ref o_Vehicle);
        }

        private void setWheels(string i_Manufacturer, float i_AirPressure, eVehicleType i_Type, ref Vehicle o_Vehicle)
        {
            try
            {
                VehicleInitiator.InitWheels(i_Manufacturer, i_AirPressure, i_Type, ref o_Vehicle);
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
                i_AirPressure = float.Parse(getField("Try again - Current air pressure: ", !v_LettersNumbersOnly, v_NumbersOnly));
                setWheels(i_Manufacturer, i_AirPressure, i_Type, ref o_Vehicle);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("Something went wrong... Try again");
                getWheelsInfo(i_Type, ref o_Vehicle);
            }
        }

        private void setSpecificMembersPerVehicleType(ref Vehicle io_Vehicle)
        {
            const char delimiter = '_';
            FieldInfo[] specificVehicleMembers = io_Vehicle.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo member in specificVehicleMembers)
            {
                int delimiterIndex = member.Name.IndexOf(delimiter); // trim member's prefix
                string memberName = member.Name.Substring(delimiterIndex + 1, member.Name.Length - 2);
                setMember(member.FieldType, memberName, ref io_Vehicle);
            }
        }

        private string findEnumType(Type i_Type)
        {
            string input;

            if(i_Type == typeof(eColor))
            {
                createEnumArray<eColor>();
                input = r_ConsoleUI.GetUserInput();
                parseEnum<eColor>(input);
            }
            else if (i_Type == typeof(eGasType))
            {
                createEnumArray<eGasType>();
                input = r_ConsoleUI.GetUserInput();
                parseEnum<eGasType>(input);
            }
            else if (i_Type == typeof(eLicenseType))
            {
                createEnumArray<eLicenseType>();
                input = r_ConsoleUI.GetUserInput();
                parseEnum<eLicenseType>(input);
            }
            else if (i_Type == typeof(eNumOfDoors))
            {
                createEnumArray<eNumOfDoors>();
                input = r_ConsoleUI.GetUserInput();
                parseEnum<eNumOfDoors>(input);
            }
            else if (i_Type == typeof(eVehicleStatus))
            {
                createEnumArray<eVehicleStatus>();
                input = r_ConsoleUI.GetUserInput();
                parseEnum<eVehicleStatus>(input);
            }
            else if (i_Type == typeof(eVehicleType))
            {
                createEnumArray<eVehicleType>();
                input = r_ConsoleUI.GetUserInput();
                parseEnum<eVehicleType>(input);
            }
            else
            {
                r_ConsoleUI.PrintToScreen("Member's type is invalid, moving on...");
                input = "";
            }

            return input;
        }

        private string handleBooleanType(string i_MemberName)
        {
            r_ConsoleUI.PrintToScreen(string.Format("1 - Yes{0}2 - No", Environment.NewLine));
            string input = r_ConsoleUI.GetUserInput("Your Choice: ");
            while (input != "1" && input != "2")
            {
                input = r_ConsoleUI.GetUserInput("The input is invalid, please choose 1 or 2: ");
            }

            input = input == "1" ? "true" : "false";

            return input;
        }

        private void setMember(Type i_MemberType, string i_MemberName, ref Vehicle io_Vehicle)
        {
            string input = "";

            r_ConsoleUI.PrintToScreen(string.Format("{0}: ", i_MemberName));
            if (i_MemberType.IsEnum)
            {             
                input = findEnumType(i_MemberType);
            }
            else if (i_MemberType == typeof(Boolean))
            {
                input = handleBooleanType(i_MemberName);     
            }
            else
            {
                input = r_ConsoleUI.GetUserInput();
            }

            if (input.Length > 0)
            {
                try
                {
                    VehicleInitiator.SetPropertiesForMember(i_MemberType, input, i_MemberName, ref io_Vehicle);
                }
                catch (InvalidCastException)
                {
                    r_ConsoleUI.PrintToScreen(string.Format("Failed to handle input, since it's not from type {0}. Try again...", i_MemberType));
                    setMember(i_MemberType, i_MemberName, ref io_Vehicle);
                }
                catch(Exception ex)
                {
                    r_ConsoleUI.PrintToScreen(string.Format("An error occured, please try again...{0}{1}", Environment.NewLine, ex.Message));
                    setMember(i_MemberType, i_MemberName, ref io_Vehicle);
                }
            }
        }
    }
}
