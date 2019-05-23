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
            foreach(VehicleInGarage vehicle in m_Vehicles)
            {
                if(vehicle.VehicleStatus == i_Status)
                {
                    carsInGarage.Add(vehicle.Vehicle.LicenseNumber);
                }
            }

            return carsInGarage;
        }

        private static bool isVehicleInGarage(string i_LienceNumber)
        {
            bool isFound = false;

            foreach(VehicleInGarage vehicle in m_Vehicles)
            {
                if(vehicle.Vehicle.LicenseNumber == i_LienceNumber)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        private static VehicleInGarage getVehicleByLicenseNumber(string i_LienceNumber)
        {
            VehicleInGarage vehicleFound = new VehicleInGarage();

            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LienceNumber)
                {
                    vehicleFound = vehicle;
                }
            }

            return vehicleFound;
        }

        public static string CreateStringVehicleDetails(string i_LicenseNumber)
        {
            string message;
            if (isVehicleInGarage(i_LicenseNumber))
            {
                try
                {
                    VehicleInGarage vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
                    StringBuilder carDetails = new StringBuilder();
                    carDetails.AppendFormat(vehicle.ToString());
                    message = carDetails.ToString();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                message = "The car is not in the garage";
            }

            return message;
        }
    }
}
