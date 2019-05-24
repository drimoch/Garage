using Ex3.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

namespace Ex3.ConsoleUI
{
    class UIManager
    {
        private readonly ConsoleUI r_ConsoleUI;
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
               /* case 3:
                    changeVehicleStatus();
                    break;
                case 4:
                    fillAirPressureToMax();
                    break;
                case 5:
                    fillGasInVehicle();
                    break;
                case 6:
                    chargeElectricVehicle();
                    break;*/
                case 7:
                    displayFullDetails();
                    break;
                default:
                    Console.WriteLine("Please choose an option from the menu");
                    StartMenu();
                    break;
            }

            StartMenu();
        }

        private void displayFullDetails()
        {
            string licenseNumber = getField("Please enter license number", false, true);
            string vehicleDetails;
            try
            {
                vehicleDetails = Garage.CreateStringVehicleDetails(licenseNumber);
                r_ConsoleUI.PrintToScreen(vehicleDetails);
            }
            catch(Exception ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
            }
        }

        private TEnum convertToEnum<TEnum>(string i_Value)
        {
            while (!Enum.IsDefined(typeof(TEnum), i_Value))
            {
                i_Value = r_ConsoleUI.GetUserInput("Invalid value, please try again: ");
            }

            TEnum convertedEnum = (TEnum)Enum.Parse(typeof(TEnum), i_Value);

            return convertedEnum;
        }

        private void displayCarLicenseNumbers()
        {
            string status = getField("Please choose vehicles status", true);
            createEnumArray<eVehicleStatus>();
            eVehicleStatus statusEnum = convertToEnum<eVehicleStatus>(status);
            List<string> vehicleLicenses = Garage.GetVehiclesLicenseNumbers(statusEnum);
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
            foreach (TEbum type in enumTypes)
            {
                typeMenu.Append(Environment.NewLine);
                typeMenu.Append(Enum.GetName(typeof(TEbum), type));
            }

            r_ConsoleUI.PrintToScreen(typeMenu.ToString());
        }

        private string getField(string i_Field, bool i_LettersNumbersOnly = false, bool i_NumbersOnly = false)
        {
            string input = r_ConsoleUI.GetUserInput(i_Field);
            if (i_LettersNumbersOnly)
            {
                while (!isOnlyLettersNumbers(input))
                {
                    r_ConsoleUI.PrintToScreen("The field should contain only letters, numbers and spaces");
                    input = r_ConsoleUI.GetUserInput("Please try again:");
                }
            }
            else if(i_NumbersOnly)
            {
                while (!isOnlyNumbers(input))
                {
                    r_ConsoleUI.PrintToScreen("The field should contain only numbers");
                    input = r_ConsoleUI.GetUserInput("Please try again:");
                }
            }

            return input;
        }

        private bool isOnlyLettersNumbers(string i_Input)
        {
            bool isValid = true;

            foreach(char character in i_Input)
            {
                if(!char.IsLetterOrDigit(character) && character != ' ')
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
                if (!char.IsDigit(character))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private void insertNewVehicleToGarage() // TODO: add try catch
        {
            r_ConsoleUI.PrintToScreen(string.Format("Please enter the following details:{0}", Environment.NewLine));
            string model = getField("Model's name:", true);
            string licenseNumber = getField("License number:", false, true);
            string owner = getField("Owner:", true);
            string phoneNumber = getField("Phone number:", false, true);

            string currentEnergy = getField("Percentage of energy left:", false, true);
            createEnumArray<eVehicleType>();
            string type = getField("Vehicle type: ", true);
            r_ConsoleUI.PrintToScreen(string.Format("Please enter the following details for the wheels:{0}", Environment.NewLine));
            string manufacturer = getField("Manufacturer name:", true);
            string airPressure = getField("Current air pressure:", false, true);
            string maxAirPressure = getField("Maximum air pressure:", false, true);
           /* if (eVehicleType.ElectricMotorcycle.ToString() == type)
            {
                string licenseType = getField("License type:");
                eLicenseType licenseTypeEnum = convertToEnum<eLicenseType>(licenseType);
                string engineCapacity = getUserInput("Engine capacity:");
                try
                {
                    VehicleInitiator.AddNewElectricMotorcycle(licenseTypeEnum, licenseNumber, model, int.Parse(engineCapacity), float.Parse(currentEnergy), manufacturer, float.Parse(airPressure), phoneNumber, owner);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ERROR! Failed to add vehicle: {0}", ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("ERROR! Failed to add vehicle: {0}", ex.Message);
                }
            }
            else if (eVehicleType.ElectricCar.ToString() == type)
            {
                string carColor = getUserInput("Color:");
                eColor carColorEnum = convertToEnum<eColor>(carColor);
                string numOfDoors = getUserInput("Number of doors:");
                eNumOfDoors numOfDoorsEnum = convertToEnum<eNumOfDoors>(numOfDoors);
                try
                {
                    VehicleInitiator.AddNewElectricCar(numOfDoorsEnum, carColorEnum, licenseNumber, model, float.Parse(currentEnergy), manufacturer, float.Parse(airPressure), phoneNumber, owner);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ERROR! Failed to add vehicle: {0}", ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("ERROR! Failed to add vehicle: {0}", ex.Message);
                }
            }
            else if (eVehicleType.Truck.ToString() == type)
            {
                string dangerousSubstances = getUserInput("Contains dangerous substances? (yes/no)");
                bool isDangerous = convertInputToBoolean(dangerousSubstances, "yes", "no");
                string containerVolume = getUserInput("Container volume:");
                printEnumArray<eGasType>();
                string gasType = getUserInput("Gas type:");
                eGasType gasTypeEnum = convertToEnum<eGasType>(gasType);
                try
                {
                    VehicleInitiator.AddNewTruck(isDangerous, float.Parse(containerVolume), gasTypeEnum, licenseNumber, model, float.Parse(currentEnergy), manufacturer, float.Parse(airPressure), phoneNumber, owner);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ERROR! Failed to add vehicle: {0}", ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("ERROR! Failed to add vehicle: {0}", ex.Message);
                }
            }*/

            r_ConsoleUI.PrintToScreen("Car was successfully inserted to the garage");
        }
    }
}
