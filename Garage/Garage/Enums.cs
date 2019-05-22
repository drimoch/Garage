namespace Ex3.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum eGasType
    {
        Soler = 0,
        Octan95 = 1,
        Octan96 = 2,
        Octan98 = 3
    }
    public enum eColor
    {
        Red = 0,
        Blue = 1,
        Black = 2,
        Grey = 3
    }
    public enum eNumOfDoors
    {
        Two = 0,
        Three = 1,
        Four = 2,
        Five = 3
    }
    public enum eLicenseType
    {
        A = 0,
        A1 = 1,
        A2 = 2,
        B = 3
    }
    public enum eVehicleStatus
    {
        InRepair = 0,
        Repaired = 1,
        Paid = 2
    }
    public enum eVehicleType
    {
        ElectricCar = 0,
        FuelCar = 1,
        ElectricMotorcycle = 2,
        FuelMotorcycle = 3,
        Truck = 4
    }
}