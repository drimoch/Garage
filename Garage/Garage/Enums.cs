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
        red = 0,
        blue = 1,
        black = 2,
        grey = 3
    }
    public enum eNumOfDoors
    {
        two = 0,
        three = 1,
        four = 2,
        five = 3
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
        inRepair = 0,
        repaired = 1,
        paid = 2
    }
    public enum eVehicleType
    {
        electricCar = 0,
        fuelCar = 1,
        electricMotorcycle = 2,
        fuelMotorcycle = 3,
        truck = 4
    }
}