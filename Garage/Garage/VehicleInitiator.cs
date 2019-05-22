using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Ex3.GarageLogic
{
   public static class VehicleInitiator
    {
        private const float m_MaxTimeElectricMotorcycle = 1.4f;
        private const float m_MaxAirPressureMotorcycle = 33;
        private const int m_NumOfWheelsInCar = 4;
        private const int m_NumOfWheelsInMotorcycle = 2;
        private const float m_MaxTimeElectricCar = 1.8f;
        private const float m_MaxAirPressureCar = 31f;
        private static void InitVehicleEssentials(float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, float i_MaxEnergy,float i_MaxPressure,out Engine i_Engine, out Wheel i_Wheel)
        {
            i_Engine = new ElectricEngine(i_CurrentEnergy, i_MaxEnergy);
            i_Wheel = new Wheel(i_WheelManufacturer, i_MaxPressure, i_CurrentAirPressure);
        }

        public static void AddNewElectricMotorcycle(eLicenseType i_LicenseType, string i_LicenseNumber, string i_ModelName, int i_EngineCapacity, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure,m_MaxTimeElectricMotorcycle,m_MaxAirPressureMotorcycle, out engine, out wheel);
            List<Wheel> motorcycleWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInMotorcycle).ToList();
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName, motorcycleWheels, engine);
            AddVehicleToGarage(motorcycle, i_PhoneNumber, i_Owner);

        }
        public static void AddNewElectricCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxTimeElectricCar,m_MaxAirPressureCar, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
            AddVehicleToGarage(car, i_PhoneNumber, i_Owner);

        }
        public static void AddNewFuelCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure,, m_MaxAirPressureCar, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
            AddVehicleToGarage(car, i_PhoneNumber, i_Owner);

        }


        public static void AddNewTruck(bool i_CarriesDangerousSubstances, float i_ContainerVolume, eGasType i_GasType, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure,m_MaxAirPressureMotorcycle,,, out engine, out wheel);
            List<Wheel> truckWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Truck truck = new Truck(i_GasType, i_ContainerVolume, i_CarriesDangerousSubstances, i_LicenseNumber, i_ModelName, truckWheels, engine);
            AddVehicleToGarage(truck, i_PhoneNumber, i_Owner);
        }
        private static void AddVehicleToGarage(Vehicle i_Vehicle, string i_PhoneNumber, string i_Owner)
        {
            foreach (VehicleInGarage vehicleInGarage in Garage.Vehicles)
            {
                if (vehicleInGarage.Vehicle.Equals(i_Vehicle))
                {
                    vehicleInGarage.VehicleStatus = eVehicleStatus.InRepair;
                    //throw exception car already in garage
                }
                else
                {
                    Garage.Vehicles.Add(new VehicleInGarage(i_Owner, i_PhoneNumber, i_Vehicle));
                }
            }
        }
    }
}
