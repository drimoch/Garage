using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Garage
    {
        //Members
        private List<VehicleInGarage> m_Vehicles;
        private const float m_MaxTimeElectricMotorcycle = 1.4f;
        private const float m_MaxAirPressureElectricMotorcycle = 33;

        internal List<VehicleInGarage> Vehicles
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

        public void AddNewElectricMotorcycle( eLicenseType i_LicenseType, string i_LicenseNumber, string i_ModelName, int i_EngineCapacity, float i_CurrentEnergy)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine = new ElectricEngine(i_CurrentEnergy, m_MaxTimeElectricMotorcycle);
            Wheel wheel = new Wheel(i_Manufacturer, m_MaxAirPressureElectricMotorcycle, i_MaxAirPressure);
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName,/*list of wheel*/, engine);
           
        }
        public void AddNewElectricCar()
        {
            //there should be try&catch from consoleUI side when using this function

        }
        public void AddNewTruck()
        {
            //there should be try&catch from consoleUI side when using this function

        }
    }
}
