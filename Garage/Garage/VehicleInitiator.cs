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
        private const float k_MaxTimeElectricMotorcycle = 1.4f;
        private const float k_MaxTimeElectricCar = 1.8f;
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
        private const eGasType k_TruckGas = eGasType.Soler;
        private const eGasType k_CarGas = eGasType.Octan96;
        private const eGasType k_MotorcycleGas = eGasType.Octan95;

        public static void InitEngine(eVehicleType i_Type, float i_CurrentEnergy, out Engine o_Engine, Vehicle i_Vehicle)
        {
            float maxEnergy;
            eGasType gasType = k_EnumDefault;

            switch (i_Type)
            {
                case eVehicleType.ElectricCar:
                    maxEnergy = k_MaxTimeElectricCar;
                    break;
                case eVehicleType.ElectricMotorcycle:
                    maxEnergy = k_MaxTimeElectricMotorcycle;
                    break;
                case eVehicleType.FuelCar:
                    maxEnergy = k_MaxFuelCar;
                    gasType = k_CarGas;
                    break;
                case eVehicleType.FuelMotorcycle:
                    maxEnergy = k_MaxFuelMotorcycle;
                    gasType = k_MotorcycleGas;
                    break;
                case eVehicleType.Truck:
                    maxEnergy = k_MaxFuelTruck;
                    gasType = k_TruckGas;
                    break;
                default:
                    throw new FormatException("Invalid Vehicle Type");
            }

            if (i_Type == eVehicleType.ElectricCar || i_Type == eVehicleType.ElectricMotorcycle)
            {
                o_Engine = new ElectricEngine(i_CurrentEnergy, maxEnergy);
            }
            else
            {
                o_Engine = new FuelEngine(gasType, i_CurrentEnergy, maxEnergy);
            }

            i_Vehicle.Engine = o_Engine;
        }

        public static void InitWheels(string i_Manufacturer, float i_CurrentAirPressure, eVehicleType i_Type, Vehicle i_Vehicle)
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
            i_Vehicle.Wheels = wheels;
        }

        public static void SetPropertiesForMember(Type i_MemberType, string i_UserInput, string i_MemberName, Vehicle i_Vehicle)
        {
            PropertyInfo propertyInfo = i_Vehicle.GetType().GetProperty(i_MemberName);
            if (i_MemberType.IsEnum)
            {
                propertyInfo.SetValue(i_Vehicle, Enum.Parse(propertyInfo.PropertyType, i_UserInput));
            }
            else
            {
                propertyInfo.SetValue(i_Vehicle, Convert.ChangeType(i_UserInput, propertyInfo.PropertyType), null);
            }
        }

        public static Vehicle CreateVehicle(string i_LicenseNumber, eVehicleType i_Type, string i_Model)
        {
            Vehicle newVehicle = null;
            switch (i_Type)
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
    }
}