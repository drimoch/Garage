using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage g = new Garage();
            List<VehicleInGarage> l = new List<VehicleInGarage>();
            l.Add(new VehicleInGarage("yosi", "0548306906", new Car(eColor.black, eNumOfDoors.two, "2392312", "GTR", null, null)));
            l.Add(new VehicleInGarage("momo", "0548301234", new Car(eColor.black, eNumOfDoors.two, "2312", "axa", null, null)));
            g.Vehicles = l;
           
        }
    }
}
