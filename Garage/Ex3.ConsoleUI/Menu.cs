using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic;

namespace Ex3.ConsoleUI
{
    public class Menu
    {
        public void ShowMenu()
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
            string userInput = Console.ReadLine();
            parseUserInput(userInput);
        }

        private void parseUserInput(string i_UserInput)
        {
            bool isInt = int.TryParse(i_UserInput, out int input);
            if(!isInt || input < 1 || input > 8)
            {
                throw new FormatException("The given value should be a number between 1 to 7");
            }

            handleUserInput(input);
        }

        private void handleUserInput(int i_Input)
        {
            switch(i_Input)
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
                    fillAirPressureToMax();
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
                    Console.WriteLine("Please choose an option from the menu");
                    ShowMenu();
                    break;
            }
        }

        private void insertRelevantVehicle(string i_VehicleType, Array i_VehicleTypes)
        {
        }

        private string getVehicleType()
        {
            StringBuilder typeMenu = new StringBuilder("Please enter vehicle type:");
            Array vehicleTypes = Enum.GetValues(typeof(eVehicleType));
            foreach (eVehicleType type in vehicleTypes)
            {
                typeMenu.Append(Environment.NewLine);
                typeMenu.Append(Enum.GetName(typeof(eVehicleType), type));
            }

            Console.WriteLine(typeMenu);
            string input = Console.ReadLine();
            return input;
        }

        private void insertNewVehicleToGarage()
        {
            Garage garage = new Garage();
            Console.WriteLine("Please enter the following details:{0}", Environment.NewLine);
            string model = getUserInput("Model's name:");
            string licenseNumber = getUserInput("License number:");
            string currentEnergy = getUserInput("Percentage of energy left:");
            string type = getVehicleType();
            Console.WriteLine("Please enter the following details for the wheels:{0}", Environment.NewLine);
            string manufacturer = getUserInput("Manufacturer name:");
            string airPressure = getUserInput("Current air pressure:");
            string maxAirPressure = getUserInput("Maximum air pressure:");
            if (eVehicleType.ElectricMotorcycle.ToString() == type)
            {
                string licenseType = getUserInput("License type:");
                eLicenseType licenseTypeEnum = convertToEnum<eLicenseType>(licenseType);
                string engineCapacity = getUserInput("Engine capacity:");
                garage.AddNewElectricMotorcycle(licenseTypeEnum, licenseNumber, model, int.Parse(engineCapacity), float.Parse(currentEnergy), manufacturer, float.Parse(airPressure));
            }
            else if(eVehicleType.ElectricCar.ToString() == type)
            {
                string carColor = getUserInput("Color:");
                eColor carColorEnum = convertToEnum<eColor>(carColor);
                string numOfDoors = getUserInput("Number of doors:");
                eNumOfDoors numOfDoorsEnum = convertToEnum<eNumOfDoors>(numOfDoors);
                garage.AddNewElectricCar(numOfDoorsEnum, carColorEnum, licenseNumber, model, float.Parse(currentEnergy), manufacturer, float.Parse(airPressure));
            }
            else if(eVehicleType.Truck.ToString() == type)
            {
                string dangerousSubstances = getUserInput("Contains dangerous substances? (yes/no)");
                bool isDangerous = convertInputToBoolean(dangerousSubstances, "yes", "no");
                string containerVolume = getUserInput("Container volume:");
                string gasType = getUserInput("Gas type:");
                eGasType gasTypeEnum = convertToEnum<eGasType>(gasType);
                garage.AddNewTruck(isDangerous, gasTypeEnum, licenseNumber, model, float.Parse(currentEnergy), manufacturer, float.Parse(airPressure));
            }

            Console.WriteLine("Car was inserted to the garage");
        }

        private bool convertInputToBoolean(string i_Input, string i_Val1, string i_Val2)
        {
            while(i_Input != i_Val1 && i_Input != i_Val2)
            {
                i_Input = getUserInput("Wrong input, contains dangerous substances? (yes/no)");
            }

            bool isTrue = i_Input == i_Val1;

            return isTrue;
        }

        private TEnum convertToEnum<TEnum>(string i_Value)
        {
            while(!Enum.IsDefined(typeof(TEnum), i_Value))
            {
                i_Value = getUserInput("Invalid value, please try again: ");
            }

            TEnum convertedEnum = (TEnum)Enum.Parse(typeof(TEnum), i_Value);
                
            return convertedEnum;
        }

        private string getUserInput(string i_TextToDisplay)
        {
            Console.WriteLine(i_TextToDisplay);
            return Console.ReadLine();
        }

        private void displayCarLicenseNumbers()
        {
            Console.WriteLine("Please choose vehicles status");
            string input = Console.ReadLine();
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
