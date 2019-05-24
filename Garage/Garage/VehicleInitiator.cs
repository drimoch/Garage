using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    public static class VehicleInitiator
    {
        private const float m_MaxTimeElectricMotorcycle = 1.4f;
        private const float m_MaxTimeElectricCar = 1.8f;

        private const float m_MaxFuelMotorcycle = 8f;
        private const float m_MaxFuelCar = 55f;
        private const float m_MaxFuelTruck = 110f;

        private const float m_MaxAirPressureCar = 31f;
        private const float m_MaxAirPressureMotorcycle = 33f;
        private const float m_MaxAirPressureTruck = 26f;

        private const int m_NumOfWheelsInCar = 4;
        private const int m_NumOfWheelsInMotorcycle = 2;
        private const int m_NumOfWheelsInTruck = 12;

        private static void InitVehicleEssentials(float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, float i_MaxEnergy, float i_MaxPressure, out Engine i_Engine, out Wheel i_Wheel)
        {
            i_Engine = new ElectricEngine(i_CurrentEnergy, i_MaxEnergy);
            i_Wheel = new Wheel(i_WheelManufacturer, i_MaxPressure, i_CurrentAirPressure);
        }

        public static void AddNewElectricMotorcycle(eLicenseType i_LicenseType, string i_LicenseNumber, string i_ModelName, int i_EngineCapacity, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxTimeElectricMotorcycle, m_MaxAirPressureMotorcycle, out engine, out wheel);
            List<Wheel> motorcycleWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInMotorcycle).ToList();
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName, motorcycleWheels, engine);
            AddVehicleToGarage(motorcycle, i_PhoneNumber, i_Owner);

        }
        public static void AddNewElectricCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxTimeElectricCar, m_MaxAirPressureCar, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
            AddVehicleToGarage(car, i_PhoneNumber, i_Owner);

        }
        public static void AddNewFuelCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxFuelCar, m_MaxAirPressureCar, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
            AddVehicleToGarage(car, i_PhoneNumber, i_Owner);

        }
        public static void AddNewFuelMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxFuelMotorcycle, m_MaxAirPressureMotorcycle, out engine, out wheel);
            List<Wheel> motorcycleWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInMotorcycle).ToList();
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName, motorcycleWheels, engine);
            AddVehicleToGarage(motorcycle, i_PhoneNumber, i_Owner);

        }
        public static void AddNewTruck(bool i_CarriesDangerousSubstances, float i_ContainerVolume, eGasType i_GasType, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            InitVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxFuelTruck, m_MaxAirPressureTruck, out engine, out wheel);
            List<Wheel> truckWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInTruck).ToList();
            Truck truck = new Truck(i_GasType, i_ContainerVolume, i_CarriesDangerousSubstances, i_LicenseNumber, i_ModelName, truckWheels, engine);
            AddVehicleToGarage(truck, i_PhoneNumber, i_Owner);
        }
        private static void AddVehicleToGarage(Vehicle i_Vehicle, string i_PhoneNumber, string i_Owner)//maybe move logic to garage class and make Garage.Vehicles private
        {
            bool vehicleExist = false;
            foreach (VehicleInGarage vehicleInGarage in Garage.Vehicles)
            {
                if (vehicleInGarage.Vehicle.Equals(i_Vehicle))
                {
                    vehicleInGarage.VehicleStatus = eVehicleStatus.InRepair;
                    vehicleExist = true;
                    //throw exception car already in garage
                }
            }
            if (vehicleExist == false)//just to be sure, boolean is not necessary 
            {
                Garage.Vehicles.Add(new VehicleInGarage(i_Owner, i_PhoneNumber, i_Vehicle));
            }
        }
    }
}
