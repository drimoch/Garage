using System;
using System.Collections.Generic;
using System.Text;

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

        private void insertNewVehicleToGarage()
        {

        }

        private void displayCarLicenseNumbers()
        {

        }

        private void changeVehicleStatus()
        {

        }

        private void fillAirPressureToMax()
        {

        }

        private void fillGasInVehicle()
        {

        }

        private void chargeElectricVehicle()
        {

        }

        private void displayFullDetails()
        {

        }
    }
}
