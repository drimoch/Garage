using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Ex3.GarageLogic;
using Ex3.GarageLogic.Enums;

namespace Ex3.ConsoleUI
{
    public static class UIManager
    {
        private const bool v_LettersNumbersOnly = true;
        private const bool v_NumbersOnly = true;
        private const bool v_LettersOnly = true;
        private const int k_EnumDefault = 0;

        public static void StartMenu()
        {
            ConsoleUI.PrintMenu();
            string userInput = ConsoleUI.GetUserInput();
            parseUserInput(userInput);
        }

        private static void parseUserInput(string i_UserInput)
        {
            try
            {
                if(int.TryParse(i_UserInput, out int input))
                {
                    handleUserInput(input);
                }
                else
                {
                    ConsoleUI.PrintToScreen("ERROR: Failed to get user input, please choose a number from the menu");
                    StartMenu();
                }
            }
            catch (Exception)
            {
                ConsoleUI.PrintToScreen("ERROR: Something went wrong... Please try again");
                StartMenu();
            }
        }

        private static void handleUserInput(int i_Input)
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
                    ConsoleUI.PrintToScreen("Invalid input. Please choose an option from the menu");
                    StartMenu();
                    break;
            }

            StartMenu();
        }

        private static void changeVehicleStatus()
        {
            string licenseNumber = ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            ConsoleUI.CreateEnumArray<eVehicleStatus>();
            string newStatus = ConsoleUI.GetField("New Status: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eVehicleStatus statusEnum = ConsoleUI.ParseEnum<eVehicleStatus>(newStatus);
            try
            {
                Garage.ChangeVehicleStatus(licenseNumber, statusEnum);
                ConsoleUI.PrintToScreen(string.Format("SUCCESS: Vehicle status was changed successfully{0}", Environment.NewLine));
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                changeVehicleStatus();
            }
            catch
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, ConsoleUI.Quit));
                changeVehicleStatus();
            }
        }

        private static void inflateTiresToMax()
        {
            string licenseNumber = ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);

            try
            {
                Garage.InflateWheelsToMax(licenseNumber);
                ConsoleUI.PrintToScreen("SUCCESS: The wheels were successfully filled to maximum");
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                inflateTiresToMax();
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("{0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                inflateTiresToMax();
            }
            catch
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, ConsoleUI.Quit));
                inflateTiresToMax();
            }
        }

        private static void fillGasInVehicle()
        {
            string licenseNumber = ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            ConsoleUI.CreateEnumArray<eGasType>();
            string gasType = ConsoleUI.GetField("Gas Type: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eGasType gasTypeEnum = ConsoleUI.ParseEnum<eGasType>(gasType);
            float gasAmount = ConsoleUI.ConvertToFloat(ConsoleUI.GetUserInput("Amount: "));

            try
            {
                Garage.FuelVehicle(licenseNumber, gasTypeEnum, gasAmount);
                ConsoleUI.PrintToScreen("SUCCESS: Gas was filled successfully");
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                fillGasInVehicle();
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("{0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                fillGasInVehicle();
            }
            catch
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, ConsoleUI.Quit));
                fillGasInVehicle();
            }
        }

        private static void chargeElectricVehicle()
        {
            const float k_MinutesInHour = 60f;
            string licenseNumber = ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            float minutesFloat = ConsoleUI.ConvertToFloat(ConsoleUI.GetUserInput("Number of minutes to charge: "));

            try
            {
                Garage.ChargeElectricVehicle(licenseNumber, minutesFloat / k_MinutesInHour);
                ConsoleUI.PrintToScreen("SUCCESS: Vehicle was charged successfully");
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                chargeElectricVehicle();
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("{0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                chargeElectricVehicle();
            }
            catch
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, ConsoleUI.Quit));
                chargeElectricVehicle();
            }
        }

        private static void displayFullDetails()
        {
            string licenseNumber = ConsoleUI.GetField("Please enter license number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            string vehicleDetails;

            try
            {
                vehicleDetails = Garage.CreateStringVehicleDetails(licenseNumber);
                ConsoleUI.PrintToScreen(vehicleDetails);
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, ConsoleUI.Quit));
                displayFullDetails();
            }
            catch
            {
                ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, ConsoleUI.Quit));
                displayFullDetails();
            }
        }

        private static void displayCarLicenseNumbers()
        {
            const bool v_FilterByStatus = true;
            List<string> vehicleLicenses;

            ConsoleUI.PrintToScreen("Please choose vehicles status: ");
            ConsoleUI.PrintToScreen(string.Format("{0} - None", k_EnumDefault.ToString()));
            ConsoleUI.CreateEnumArray<eVehicleStatus>();
            string status = ConsoleUI.GetField(string.Empty, !v_LettersNumbersOnly, v_NumbersOnly);
            if (status == k_EnumDefault.ToString())
            {
                vehicleLicenses = Garage.GetVehiclesByStatus(k_EnumDefault, !v_FilterByStatus);
            }
            else
            {
                eVehicleStatus statusEnum = ConsoleUI.ParseEnum<eVehicleStatus>(status);
                vehicleLicenses = Garage.GetVehiclesByStatus(statusEnum);
            }

            if (vehicleLicenses.Count == 0)
            {
                ConsoleUI.PrintToScreen("NOT FOUND: There are no vehicles in this status");
            }
            else
            {
                StringBuilder licenseList = new StringBuilder("SUCCESS: Vehicle license numbers: ");
                foreach (string license in vehicleLicenses)
                {
                    licenseList.AppendFormat("{0}{1}", Environment.NewLine, license);
                }

                ConsoleUI.PrintToScreen(licenseList.ToString());
            }
        }

        private static void insertNewVehicleToGarage()
        {
            ConsoleUI.PrintToScreen(string.Format("Please enter the following details:{0}", Environment.NewLine));
            string licenseNumber = ConsoleUI.GetField("License number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            if (Garage.IsVehicleInGarage(licenseNumber))
            {
                Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
                ConsoleUI.PrintToScreen("STATUS UPDATE: Car already exists in the garage, changing its status to InRepair");
            }
            else
            {
                Vehicle vehicle = setBasicVehicleInfo(licenseNumber);
                setSpecificMembersPerVehicleType(vehicle);
                setVehicleOwnerInfo(out string o_Owner, out string o_Phone);
                if (Garage.AddVehicleToGarage(vehicle, o_Phone, o_Owner))
                {
                    ConsoleUI.PrintToScreen("SUCCESS: Car was successfully inserted to the garage");
                }
                else
                {
                    ConsoleUI.PrintToScreen("ERROR: An error occured while trying to insert the car to the garage");
                }
            }
        }

        private static void setVehicleOwnerInfo(out string o_Owner, out string o_Phone)
        {
            o_Owner = ConsoleUI.GetField("Owner's name: ", !v_LettersNumbersOnly, !v_NumbersOnly, v_LettersOnly);
            o_Phone = ConsoleUI.GetField("Phone number: ", !v_LettersNumbersOnly, v_NumbersOnly);
        }

        private static Vehicle setBasicVehicleInfo(string i_LicenseNumber)
        {
            ConsoleUI.CreateEnumArray<eVehicleType>();
            string type = ConsoleUI.GetField("Vehicle type: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eVehicleType vehicleType = ConsoleUI.ParseEnum<eVehicleType>(type);
            string model = ConsoleUI.GetField("Model's name: ", v_LettersNumbersOnly);
            Vehicle newVehicle = VehicleInitiator.CreateVehicle(i_LicenseNumber, vehicleType, model);
            setEngine(newVehicle, vehicleType);
            getWheelsInfo(vehicleType, newVehicle);

            return newVehicle;
        }

        private static void setEngine(Vehicle i_Vehicle, eVehicleType i_Type)
        {            
            float currentEnergy = ConsoleUI.ConvertToFloat(ConsoleUI.GetUserInput("Amount of energy left: "));

            try
            {
                VehicleInitiator.InitEngine(i_Type, currentEnergy, out Engine engine, i_Vehicle);
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.PrintToScreen(string.Format("{0}{1}{2}", ex.Message, Environment.NewLine, "Try again"));
                setEngine(i_Vehicle, i_Type);
            }
        }

        private static void getWheelsInfo(eVehicleType i_Type, Vehicle i_Vehicle)
        {
            string manufacturer = ConsoleUI.GetField("Manufacturer name: ", !v_LettersNumbersOnly, !v_NumbersOnly, v_LettersOnly);
            float airPressure = ConsoleUI.ConvertToFloat(ConsoleUI.GetUserInput("Current air pressure: "));

            setWheels(manufacturer, airPressure, i_Type, i_Vehicle);
        }

        private static void setWheels(string i_Manufacturer, float i_AirPressure, eVehicleType i_Type, Vehicle i_Vehicle)
        {
            try
            {
                VehicleInitiator.InitWheels(i_Manufacturer, i_AirPressure, i_Type, i_Vehicle);
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.PrintToScreen(ex.Message);
                i_AirPressure = ConsoleUI.ConvertToFloat(ConsoleUI.GetUserInput("Try again - Current air pressure: "));
                setWheels(i_Manufacturer, i_AirPressure, i_Type, i_Vehicle);
            }
            catch
            {
                ConsoleUI.PrintToScreen("Something went wrong... Try again");
                getWheelsInfo(i_Type, i_Vehicle);
            }
        }

        private static void setSpecificMembersPerVehicleType(Vehicle i_Vehicle)
        {
            const char k_Delimiter = '_';
            FieldInfo[] specificVehicleMembers = i_Vehicle.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo member in specificVehicleMembers)
            {
                int delimiterIndex = member.Name.IndexOf(k_Delimiter); // trim member's prefix
                string memberName = member.Name.Substring(delimiterIndex + 1, member.Name.Length - 2);
                setMember(member.FieldType, memberName, i_Vehicle);
            }
        }

        private static void setMember(Type i_MemberType, string i_MemberName, Vehicle i_Vehicle)
        {
            string input = string.Empty;

            ConsoleUI.PrintToScreen(string.Format("{0}: ", i_MemberName));
            if (i_MemberType.IsEnum)
            {
                input = ConsoleUI.FindEnumType(i_MemberType);
            }
            else if (i_MemberType == typeof(bool))
            {
                input = ConsoleUI.HandleBooleanType(i_MemberName);
            }
            else
            {
                input = ConsoleUI.GetUserInput();
            }

            if (input.Length > 0)
            {
                try
                {
                    VehicleInitiator.SetPropertiesForMember(i_MemberType, input, i_MemberName, i_Vehicle);
                }
                catch (InvalidCastException)
                {
                    ConsoleUI.PrintToScreen(string.Format("Failed to handle input, since it's not from type {0}. Try again...", i_MemberType));
                    setMember(i_MemberType, i_MemberName, i_Vehicle);
                }
                catch (Exception ex)
                {
                    ConsoleUI.PrintToScreen(string.Format("An error occured, please try again...{0}{1}", Environment.NewLine, ex.Message));
                    setMember(i_MemberType, i_MemberName, i_Vehicle);
                }
            }
        }
    }
}
