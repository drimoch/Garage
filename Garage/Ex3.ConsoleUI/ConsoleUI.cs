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
            string menu = string.Format(@"Welcome to the garage!
                                        Please choose an option from the menu: 
                                        1. Insert new vehicle to the garage    
                                        2. Display the garage cars license numbers  
                                        3. Change car's status in the garage
                                        4. Fill air pressure to maximum for a vehicle
                                        5. Fill gas in a vehicle
                                        6. Charge an electric vehicle
                                        7. Display full details on a vehicle");
            Console.WriteLine(menu);
            //string userInput = Console.ReadLine();
            //parseUserInput(userInput);
        }

        /*private void parseUserInput(string i_UserInput)
        {
            bool isInt = int.TryParse(i_UserInput, out int input);
            if(!isInt || input < 1 || input > 8)
            {
                throw new FormatException("The given value should be a number between 1 to 7");
            }

            handleUserInput(input);
        }*/

        public void PrintToScreen(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

    
        private void insertRelevantVehicle(string i_VehicleType, Array i_VehicleTypes)
        {
        }

        /*private void insertNewVehicleToGarage() // TODO: add try catch
        {            
            Console.WriteLine("Please enter the following details:{0}", Environment.NewLine);
            string model = getUserInput("Model's name:");
            string licenseNumber = getUserInput("License number:");
            string owner = getUserInput("Owner:");
            string phoneNumber = getUserInput("Phone number:");
            string currentEnergy = getUserInput("Percentage of energy left:");
            printEnumArray<eVehicleType>();
            string type = getUserInput("Vehicle type: ");
            Console.WriteLine("Please enter the following details for the wheels:{0}", Environment.NewLine);
            string manufacturer = getUserInput("Manufacturer name:");
            string airPressure = getUserInput("Current air pressure:");
            string maxAirPressure = getUserInput("Maximum air pressure:");
            if (eVehicleType.ElectricMotorcycle.ToString() == type)
            {
                string licenseType = getUserInput("License type:");
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
            }

            Console.WriteLine("Car was successfully inserted to the garage");
        }*/

        private bool convertInputToBoolean(string i_Input, string i_Val1, string i_Val2)
        {
            while(i_Input != i_Val1 && i_Input != i_Val2)
            {
                i_Input = GetUserInput("Wrong input, contains dangerous substances? (yes/no)");
            }

            bool isTrue = i_Input == i_Val1;

            return isTrue;
        }

    

        public string GetUserInput(string i_TextToDisplay="")
        {
            Console.WriteLine(i_TextToDisplay);
            return Console.ReadLine();
        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Please enter car license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter new vehicle status");
            string newStatus = Console.ReadLine();

        }

        private void fillAirPressureToMax()
        {
            Console.WriteLine("Please enter car license number");
            string licenseNumber = Console.ReadLine();
        }

        private void fillGasInVehicle()
        {
            Console.WriteLine("Please enter car license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter type of feul");
            string fuelType = Console.ReadLine();
            Console.WriteLine("Please enter amount of fuel to fill");
            string amountToFill = Console.ReadLine();

        }

        private void chargeElectricVehicle()
        {
            Console.WriteLine("Please enter car license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter number of minutes to charge");
            string numOfMinutesToCharge = Console.ReadLine();

        }

        private void displayFullDetails()
        {
            Console.WriteLine("Please enter car license number");
            string licenseNumber = Console.ReadLine();

        }
    }
}
