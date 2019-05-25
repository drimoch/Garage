using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ex3.GarageLogic.Enums;
using System.Reflection;

namespace Ex3.GarageLogic
{
    public static class VehicleInitiator
    {
        private const float k_MaxTimeElectricMotorcycle = 3.5f;
        private const float k_MaxTimeElectricCar = 12f;

        private const float k_MaxFuelMotorcycle = 8f;
        private const float k_MaxFuelCar = 55f;
        private const float k_MaxFuelTruck = 110f;

        private const float k_MaxAirPressureCar = 31f;
        private const float k_MaxAirPressureMotorcycle = 33f;
        private const float k_MaxAirPressureTruck = 26f;

        private const int k_NumOfWheelsInCar = 4;
        private const int k_NumOfWheelsInMotorcycle = 2;
        private const int k_NumOfWheelsInTruck = 12;

        private const int k_EnumDefault = 0;

        /*private static void initVehicleEssentials(float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, float i_MaxEnergy, float i_MaxPressure, out Engine i_Engine, out Wheel i_Wheel)
        {
            i_Engine = new ElectricEngine(i_CurrentEnergy, i_MaxEnergy);
            i_Wheel = new Wheel(i_WheelManufacturer, i_MaxPressure, i_CurrentAirPressure);
        }*/

        public static void InitEngine(eVehicleType i_Type, float i_CurrentEnergy, out Engine o_Engine, ref Vehicle io_Vehicle, eGasType i_GasType = k_EnumDefault)
        {
            float maxEnergy;
            switch(i_Type)
            {
                case eVehicleType.ElectricCar:
                    maxEnergy = k_MaxTimeElectricCar;
                    break;
                case eVehicleType.ElectricMotorcycle:
                    maxEnergy = k_MaxTimeElectricMotorcycle;
                    break;
                case eVehicleType.FuelCar:
                    maxEnergy = k_MaxFuelCar;
                    break;
                case eVehicleType.FuelMotorcycle:
                    maxEnergy = k_MaxFuelMotorcycle;
                    break;
                case eVehicleType.Truck:
                    maxEnergy = k_MaxFuelTruck;
                    break;
                default:
                    throw new FormatException("Invalid Vehicle Type");
            }

            if(i_Type == eVehicleType.ElectricCar || i_Type == eVehicleType.ElectricMotorcycle)
            {
                o_Engine = new ElectricEngine(i_CurrentEnergy, maxEnergy);
            }
            else
            {
                o_Engine = new FuelEngine(i_GasType, i_CurrentEnergy, maxEnergy);
            }

            io_Vehicle.Engine = o_Engine;
        }

        public static void InitWheels(string i_Manufacturer, float i_CurrentAirPressure, eVehicleType i_Type, ref Vehicle o_Vehicle)
        {
            int numOfWheels;
            float maxAirPressure;

            switch (i_Type)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelCar:
                    numOfWheels = k_NumOfWheelsInCar;
                    maxAirPressure = k_MaxAirPressureCar;
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelMotorcycle:
                    numOfWheels = k_NumOfWheelsInMotorcycle;
                    maxAirPressure = k_MaxAirPressureMotorcycle;
                    break;
                case eVehicleType.Truck:
                    numOfWheels = k_NumOfWheelsInTruck;
                    maxAirPressure = k_MaxAirPressureTruck;
                    break;
                default:
                    throw new FormatException("Invalid Vehicle Type");
            }
            
            Wheel wheel = new Wheel(i_Manufacturer, maxAirPressure, i_CurrentAirPressure);
            List<Wheel> wheels = Enumerable.Repeat(wheel, numOfWheels).ToList();
            o_Vehicle.Wheels = wheels;
        }

        public static void SetPropertiesForMember(Type i_MemberType, string i_UserInput, string i_MemberName, ref Vehicle io_Vehicle)
        {
            PropertyInfo propertyInfo = io_Vehicle.GetType().GetProperty(i_MemberName);
            if (i_MemberType.IsEnum)
            {
                propertyInfo.SetValue(io_Vehicle, Enum.Parse(propertyInfo.PropertyType, i_UserInput));
            }
            else
            {
                propertyInfo.SetValue(io_Vehicle, Convert.ChangeType(i_UserInput, propertyInfo.PropertyType), null);
            }
        }

        public static Vehicle CreateVehicle(string i_LicenseNumber, eVehicleType i_Type, string i_Model)
        {
            Vehicle newVehicle = null;
            switch(i_Type)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelCar:
                    newVehicle = new Car(i_LicenseNumber, i_Model);
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelMotorcycle:
                    newVehicle = new Motorcycle(i_LicenseNumber, i_Model);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(i_LicenseNumber, i_Model);
                    break;
                default:
                    throw new FormatException("Invalid Vehicle Type");
            }

            return newVehicle;
        }

        public static bool InsertVehicleToGarage(Vehicle i_Vehicle, string i_PhoneNumber, string i_Owner)
        {
            return Garage.AddVehicleToGarage(i_Vehicle, i_PhoneNumber, i_Owner);
        }

        /*public static void AddNewElectricMotorcycle(eLicenseType i_LicenseType, string i_LicenseNumber, string i_ModelName, int i_EngineCapacity, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            initVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxTimeElectricMotorcycle, m_MaxAirPressureMotorcycle, out engine, out wheel);
            List<Wheel> motorcycleWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInMotorcycle).ToList();
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName, motorcycleWheels, engine);
            AddVehicleToGarage(motorcycle, i_PhoneNumber, i_Owner);

        }
        public static void AddNewElectricCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            initVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxTimeElectricCar, m_MaxAirPressureCar, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
            AddVehicleToGarage(car, i_PhoneNumber, i_Owner);

        }
        public static void AddNewFuelCar(eNumOfDoors i_NumOfDoors, eColor i_Color, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            initVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxFuelCar, m_MaxAirPressureCar, out engine, out wheel);
            List<Wheel> carWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInCar).ToList();
            Car car = new Car(i_Color, i_NumOfDoors, i_LicenseNumber, i_ModelName, carWheels, engine);
            AddVehicleToGarage(car, i_PhoneNumber, i_Owner);

        }
        public static void AddNewFuelMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            initVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxFuelMotorcycle, m_MaxAirPressureMotorcycle, out engine, out wheel);
            List<Wheel> motorcycleWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInMotorcycle).ToList();
            Motorcycle motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_ModelName, motorcycleWheels, engine);
            AddVehicleToGarage(motorcycle, i_PhoneNumber, i_Owner);

        }
        public static void AddNewTruck(bool i_CarriesDangerousSubstances, float i_ContainerVolume, eGasType i_GasType, string i_LicenseNumber, string i_ModelName, float i_CurrentEnergy, string i_WheelManufacturer, float i_CurrentAirPressure, string i_PhoneNumber, string i_Owner)
        {
            //there should be try&catch from consoleUI side when using this function
            Engine engine;
            Wheel wheel;
            initVehicleEssentials(i_CurrentEnergy, i_WheelManufacturer, i_CurrentAirPressure, m_MaxFuelTruck, m_MaxAirPressureTruck, out engine, out wheel);
            List<Wheel> truckWheels = Enumerable.Repeat(wheel, m_NumOfWheelsInTruck).ToList();
            Truck truck = new Truck(i_GasType, i_ContainerVolume, i_CarriesDangerousSubstances, i_LicenseNumber, i_ModelName, truckWheels, engine);
            AddVehicleToGarage(truck, i_PhoneNumber, i_Owner);
        }*/

    }
}
