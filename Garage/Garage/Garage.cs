using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex3.GarageLogic
{
    public static class Garage
    {
        //Members
        private static List<VehicleInGarage> m_Vehicles = new List<VehicleInGarage>();
        internal static List<VehicleInGarage> Vehicles
        {
            get
            {
                return m_Vehicles;
            }
            set
            {
                if (isVehicleListValid(value))
                {
                    m_Vehicles = value;

                }
                else
                {
                    throw new ArgumentException("A vehicle with the same license number already exists");
                }
            }
        }

        private static bool isVehicleListValid(List<VehicleInGarage> i_vehiclesInGarage)
        {
            int sameVehicleCounter = 0;
            bool listIsValid = false;
            foreach (VehicleInGarage vehicleInGarage in i_vehiclesInGarage)
            {
                foreach (VehicleInGarage vehicleToCompare in i_vehiclesInGarage)
                {
                    if (vehicleInGarage.Vehicle.Equals(vehicleToCompare.Vehicle))
                    {
                        sameVehicleCounter++;
                    }
                }
            }

            if (sameVehicleCounter == i_vehiclesInGarage.Count)
            {
                listIsValid = true;
            }

            return listIsValid;
        }

        public static List<string> GetVehiclesByStatus(Enums.eVehicleStatus i_Status, bool i_IsStatusValid = true)
        {
            List<string> carsInGarage = new List<string>();
            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (!i_IsStatusValid)
                {
                    carsInGarage.Add(vehicle.Vehicle.LicenseNumber);
                }
                else if(vehicle.VehicleStatus == i_Status)
                {
                    carsInGarage.Add(vehicle.Vehicle.LicenseNumber);
                }
            }

            return carsInGarage;
        }

        public static bool IsVehicleInGarage(string i_LienceNumber)
        {
            bool isFound = false;

            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LienceNumber)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        private static VehicleInGarage getVehicleByLicenseNumber(string i_LienseNumber)
        {
            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LienseNumber)
                {
                    return vehicle;
                }
            }

            throw new ArgumentException("Vehicle was not found");
        }

        public static string CreateStringVehicleDetails(string i_LicenseNumber)
        {
            VehicleInGarage vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
            StringBuilder vehicleDetails = new StringBuilder("SUCCESS: Vehicle Details:");
            vehicleDetails.AppendFormat("{0}----------------------{1}", Environment.NewLine, Environment.NewLine);
            vehicleDetails.AppendFormat(vehicle.ToString());

            return vehicleDetails.ToString();
        }

        public static void ChangeVehicleStatus(string i_LicsenseNumber, Enums.eVehicleStatus i_NewStatus)
        {
            getVehicleByLicenseNumber(i_LicsenseNumber).VehicleStatus = i_NewStatus;
        }

        public static void InflateWheelsToMax(string i_LicsenseNumber)
        {
            List<Wheel> wheelsToInflate = getVehicleByLicenseNumber(i_LicsenseNumber).Vehicle.Wheels;
            foreach (Wheel wheel in wheelsToInflate)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }

        public static void FuelVehicle(string i_LicsenseNumber, Enums.eGasType i_GasType, float i_GasToFuel)
        {
            Engine engine = getVehicleByLicenseNumber(i_LicsenseNumber).Vehicle.Engine;
            FuelEngine fuelEngine = engine as FuelEngine;

            if (fuelEngine != null)
            {
                fuelEngine.FuelVehicle(i_GasToFuel, i_GasType);
            }
            else
            {
                throw new ArgumentException("Vehicle has electric engine");
            }
        }

        public static void ChargeElectricVehicle(string i_LicsenseNumber, float i_NumOfMinutesToCharge)
        {
            Engine engine = getVehicleByLicenseNumber(i_LicsenseNumber).Vehicle.Engine;
            ElectricEngine electricEngine = engine as ElectricEngine;

            if (electricEngine != null)
            {
                electricEngine.Charge(i_NumOfMinutesToCharge);
            }
            else
            {
                throw new ArgumentException("Vehicle has fuel engine");
            }

        }

        public static bool AddVehicleToGarage(Vehicle i_Vehicle, string i_PhoneNumber, string i_Owner)
        {
            bool isInGarage = IsVehicleInGarage(i_Vehicle.LicenseNumber);
            bool success = false;

            if (!isInGarage)
            {
                m_Vehicles.Add(new VehicleInGarage(i_Owner, i_PhoneNumber, i_Vehicle));
                success = true;
            }

            return success;
        }
    }
}
