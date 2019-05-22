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
        private const float m_MaxTimeElectricMotorcycle = 1.4f;
        private const float m_MaxAirPressureMotorcycle = 33;
        private const int m_NumOfWheelsInCar = 4;
        private const int m_NumOfWheelsInMotorcycle = 2;
        private const float m_MaxTimeElectricCar = 1.8f;
        private const float m_MaxAirPressureCar = 31f;


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

        public void AddNewElectricMotorcycle(eLicenseType i_LicenseType, string i_LicenseNumber, string i_ModelName, int i_EngineCapacity, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, out engine, out wheel);
            List<Wheel> motorcycleWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInMotorcycle).ToList();
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName, motorcycleWheels, engine);
        }
        public void AddNewElectricCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
        }

        private void InitVehicleEssentials(float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, out Engine i_Engine, out Wheel i_Wheel)
        {
            i_Engine = new ElectricEngine(i_CurrentEnergy, m_MaxTimeElectricCar);
            i_Wheel = new Wheel(i_WheelManufacturer, m_MaxAirPressureCar, i_CurrentAirPressure);
        }

        public void AddNewTruck(bool i_CarriesDangerousSubstances, eGasType i_GasType, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure)
        {
            //there should be try&catch from consoleUI side when using this function
            /*Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Truck truck = new Truck(i_GasType,i_ContainerVolume,i_CarriesDangerousSubstances, i_LicenseNumber, i_ModelName, carWheels, engine);*/
        }
    }
}
