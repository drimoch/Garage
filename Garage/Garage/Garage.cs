using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex3.GarageLogic
{
    public static class Garage
    {
        //Members
        private static List<VehicleInGarage> m_Vehicles;



        internal static List<VehicleInGarage> Vehicles
        {
            get
            {
                return m_Vehicles;
            }
            set
            {
                if (IsVehicleListValid(value))
                {
                    m_Vehicles = value;

                }
                else
                {
                    throw new Exception();
                    //throw exception to vehicles with same license
                }
            }
        }
        private static bool IsVehicleListValid(List<VehicleInGarage> i_vehiclesInGarage)
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
        public static List<string> GetVehiclesLicenseNumbers(eVehicleStatus i_Status)
        {
            List<string> carsInGarage = new List<string>();
            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (vehicle.VehicleStatus == i_Status)
                {
                    carsInGarage.Add(vehicle.Vehicle.LicenseNumber);
                }
            }

            return carsInGarage;
        }

        private static bool isVehicleInGarage(string i_LienceNumber)
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
            VehicleInGarage vehicleFound;

            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LienseNumber)
                {
                    return vehicleFound = vehicle;
                }
            }

            throw new Exception();//todo: throw exception vehicle not found
        }

        public static string CreateStringVehicleDetails(string i_LicenseNumber)
        {
            VehicleInGarage vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
            StringBuilder carDetails = new StringBuilder();
            carDetails.AppendFormat(vehicle.ToString());
            return carDetails.ToString();
        }

        public static void ChangeVehicleStatus(string i_LicsenseNumber, eVehicleStatus i_NewStatus)
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

        public static void fuelVehicle(string i_LicsenseNumber,eGasType i_GasType,float i_GasToFuel)
        {

        }
    }
}
