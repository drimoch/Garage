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
                    r_ConsoleUI.PrintToScreen("Invalid input. Please choose an option from the menu");
                    StartMenu();
                    break;
            }

            StartMenu();
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = r_ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            r_ConsoleUI.CreateEnumArray<eVehicleStatus>();
            string newStatus = r_ConsoleUI.GetField("New Status: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eVehicleStatus statusEnum = r_ConsoleUI.ParseEnum<eVehicleStatus>(newStatus);
            try
            {
                Garage.ChangeVehicleStatus(licenseNumber, statusEnum);
                r_ConsoleUI.PrintToScreen(string.Format("SUCCESS: Vehicle status was changed successfully{0}", Environment.NewLine));
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                changeVehicleStatus();
            }
            catch
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, r_ConsoleUI.Quit));
                changeVehicleStatus();
            }
        }

        private void inflateTiresToMax()
        {
            string licenseNumber = r_ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);

            try
            {
                Garage.InflateWheelsToMax(licenseNumber);
                r_ConsoleUI.PrintToScreen("SUCCESS: The wheels were successfully filled to maximum");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                inflateTiresToMax();
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
                r_ConsoleUI.PrintToScreen(string.Format("{0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                inflateTiresToMax();
            }
            catch
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, r_ConsoleUI.Quit));
                inflateTiresToMax();
            }
        }

        private void fillGasInVehicle()
        {
            string licenseNumber = r_ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            r_ConsoleUI.CreateEnumArray<eGasType>();
            string gasType = r_ConsoleUI.GetField("Gas Type: ", !v_LettersNumbersOnly, v_NumbersOnly);
            eGasType gasTypeEnum = r_ConsoleUI.ParseEnum<eGasType>(gasType);
            string amount = r_ConsoleUI.GetField("Amount: ", !v_LettersNumbersOnly, v_NumbersOnly);
            try
            {
                Garage.FuelVehicle(licenseNumber, gasTypeEnum, float.Parse(amount));
                r_ConsoleUI.PrintToScreen("SUCCESS: Gas was filled successfully");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                fillGasInVehicle();
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("{0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                fillGasInVehicle();
            }
            catch
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, r_ConsoleUI.Quit));
                fillGasInVehicle();
            }
        }
   
        private void chargeElectricVehicle()
        {
            string licenseNumber = r_ConsoleUI.GetField("License Number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            string minutes = r_ConsoleUI.GetField("Number of minutes to charge: ", !v_LettersNumbersOnly, v_NumbersOnly);
            try
            {
                Garage.ChargeElectricVehicle(licenseNumber, float.Parse(minutes));
                r_ConsoleUI.PrintToScreen("SUCCESS: Vehicle was charged successfully");
            }
            catch (ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                chargeElectricVehicle();
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("{0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                chargeElectricVehicle();
            }
            catch
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, r_ConsoleUI.Quit));
                chargeElectricVehicle();
            }
        }

        private void displayFullDetails()
        {
            string licenseNumber = r_ConsoleUI.GetField("Please enter license number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            string vehicleDetails;
            try
            {
                vehicleDetails = Garage.CreateStringVehicleDetails(licenseNumber);
                r_ConsoleUI.PrintToScreen(vehicleDetails);
            }
            catch(ArgumentException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: {0}{1}Try again or press {2} to go back to the menu", ex.Message, Environment.NewLine, r_ConsoleUI.Quit));
                displayFullDetails();
            }
            catch
            {
                r_ConsoleUI.PrintToScreen(string.Format("ERROR: An error occured...{0}Try again or press {1} to go back to the menu", Environment.NewLine, r_ConsoleUI.Quit));
                displayFullDetails();
            }
        }

        private void displayCarLicenseNumbers()
        {
            const bool v_isStatusValid = true;
            List<string> vehicleLicenses;

            r_ConsoleUI.PrintToScreen("Please choose vehicles status: ");
            r_ConsoleUI.PrintToScreen(string.Format("{0} - None", k_EnumDefault.ToString()));
            r_ConsoleUI.CreateEnumArray<eVehicleStatus>();
            string status = r_ConsoleUI.GetField("", !v_LettersNumbersOnly, v_NumbersOnly);
            if(status == k_EnumDefault.ToString())
            {
                vehicleLicenses = Garage.GetVehiclesByStatus(k_EnumDefault, !v_isStatusValid);
            }
            else
            {
                eVehicleStatus statusEnum = r_ConsoleUI.ParseEnum<eVehicleStatus>(status);
                vehicleLicenses = Garage.GetVehiclesByStatus(statusEnum);
            }

            if (vehicleLicenses.Count == 0)
            {
                r_ConsoleUI.PrintToScreen("NOT FOUND: There are no vehicles in this status");
            }
            else
            {
                StringBuilder licenseList = new StringBuilder("SUCCESS: Vehicle license numbers: ");
                foreach (string license in vehicleLicenses)
                {
                    licenseList.Append(Environment.NewLine);
                    licenseList.Append(license);
                }

                r_ConsoleUI.PrintToScreen(licenseList.ToString());
            }
        }

        private void insertNewVehicleToGarage()
        {
            r_ConsoleUI.PrintToScreen(string.Format("Please enter the following details:{0}", Environment.NewLine));
            string licenseNumber = r_ConsoleUI.GetField("License number: ", !v_LettersNumbersOnly, v_NumbersOnly);
            if (Garage.IsVehicleInGarage(licenseNumber))
            {
                Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
                r_ConsoleUI.PrintToScreen("STATUS UPDATE: Car already exists in the garage, changing its status to InRepair");
            }
            else
            {
                Vehicle vehicle = setBasicVehicleInfo(licenseNumber);
                setSpecificMembersPerVehicleType(vehicle);
                setVehicleOwnerInfo(out string o_Owner, out string o_Phone);
                if (Garage.AddVehicleToGarage(vehicle, o_Phone, o_Owner))
                {
                    r_ConsoleUI.PrintToScreen("SUCCESS: Car was successfully inserted to the garage");
                }
                else
                {
                    r_ConsoleUI.PrintToScreen("ERROR: An error occured while trying to insert the car to the garage");
                }
            }
        }

        private void setVehicleOwnerInfo(out string o_Owner, out string o_Phone)
        {
            o_Owner = r_ConsoleUI.GetField("Owner's name: ", !v_LettersNumbersOnly, !v_NumbersOnly, v_LettersOnly);
            o_Phone = r_ConsoleUI.GetField("Phone number: ", !v_LettersNumbersOnly, v_NumbersOnly);
        }

        private Vehicle setBasicVehicleInfo(string i_LicenseNumber)
        {
            r_ConsoleUI.CreateEnumArray<eVehicleType>();
            string type = r_ConsoleUI.GetField("Vehicle type: ", v_LettersNumbersOnly);
            eVehicleType vehicleType = r_ConsoleUI.ParseEnum<eVehicleType>(type);
            string model = r_ConsoleUI.GetField("Model's name: ", v_LettersNumbersOnly);
            Vehicle newVehicle = VehicleInitiator.CreateVehicle(i_LicenseNumber, vehicleType, model);
            setEngine(newVehicle, vehicleType);
            getWheelsInfo(vehicleType, newVehicle);

            return newVehicle;
        }

        private void setEngine(Vehicle i_Vehicle, eVehicleType i_Type)
        {
            string currentEnergy = r_ConsoleUI.GetField("Amount of energy left: ", !v_LettersNumbersOnly, v_NumbersOnly);
            try
            {
                VehicleInitiator.InitEngine(i_Type, float.Parse(currentEnergy), out Engine engine, i_Vehicle);
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(string.Format("{0}{1}{2}", ex.Message, Environment.NewLine, "Try again"));
                setEngine(i_Vehicle, i_Type);
            }
        }

        private void getWheelsInfo(eVehicleType i_Type, Vehicle i_Vehicle)
        {
            string manufacturer = r_ConsoleUI.GetField("Manufacturer name: ", !v_LettersNumbersOnly, !v_NumbersOnly, v_LettersOnly);
            string airPressure = r_ConsoleUI.GetField("Current air pressure: ", !v_LettersNumbersOnly, v_NumbersOnly);
            setWheels(manufacturer, float.Parse(airPressure), i_Type, i_Vehicle);
        }

        private void setWheels(string i_Manufacturer, float i_AirPressure, eVehicleType i_Type, Vehicle i_Vehicle)
        {
            try
            {
                VehicleInitiator.InitWheels(i_Manufacturer, i_AirPressure, i_Type, i_Vehicle);
            }
            catch (ValueOutOfRangeException ex)
            {
                r_ConsoleUI.PrintToScreen(ex.Message);
                i_AirPressure = float.Parse(r_ConsoleUI.GetField("Try again - Current air pressure: ", !v_LettersNumbersOnly, v_NumbersOnly));
                setWheels(i_Manufacturer, i_AirPressure, i_Type, i_Vehicle);
            }
            catch
            {
                r_ConsoleUI.PrintToScreen("Something went wrong... Try again");
                getWheelsInfo(i_Type, i_Vehicle);
            }
        }

        private void setSpecificMembersPerVehicleType(Vehicle i_Vehicle)
        {
            const char delimiter = '_';
            FieldInfo[] specificVehicleMembers = i_Vehicle.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo member in specificVehicleMembers)
            {
                int delimiterIndex = member.Name.IndexOf(delimiter); // trim member's prefix
                string memberName = member.Name.Substring(delimiterIndex + 1, member.Name.Length - 2);
                setMember(member.FieldType, memberName, i_Vehicle);
            }
        }

        private void setMember(Type i_MemberType, string i_MemberName, Vehicle i_Vehicle)
        {
            string input = "";

            r_ConsoleUI.PrintToScreen(string.Format("{0}: ", i_MemberName));
            if (i_MemberType.IsEnum)
            {             
                input = r_ConsoleUI.FindEnumType(i_MemberType);
            }
            else if (i_MemberType == typeof(Boolean))
            {
                input = r_ConsoleUI.HandleBooleanType(i_MemberName);     
            }
            else
            {
                input = r_ConsoleUI.GetUserInput();
            }

            if (input.Length > 0)
            {
                try
                {
                    VehicleInitiator.SetPropertiesForMember(i_MemberType, input, i_MemberName, i_Vehicle);
                }
                catch (InvalidCastException)
                {
                    r_ConsoleUI.PrintToScreen(string.Format("Failed to handle input, since it's not from type {0}. Try again...", i_MemberType));
                    setMember(i_MemberType, i_MemberName, i_Vehicle);
                }
                catch(Exception ex)
                {
                    r_ConsoleUI.PrintToScreen(string.Format("An error occured, please try again...{0}{1}", Environment.NewLine, ex.Message));
                    setMember(i_MemberType, i_MemberName, i_Vehicle);
                }
            }
        }
    }
}
