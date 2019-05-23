using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex3.GarageLogic
{
    public class Garage
    {
        //Members
        private List<VehicleInGarage> m_Vehicles;



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
        private bool IsVehicleListValid(List<VehicleInGarage> i_vehiclesInGarage)
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
        public List<string> GetVehiclesLicenseNumbers(eVehicleStatus i_Status)
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
    }
}
