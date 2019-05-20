using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Car : Vehicle
    {

        //Members
        private readonly eColor r_Color;
        private readonly eNumOfDoors r_NumOfDoors;
        public Car(eColor i_Color, eNumOfDoors i_NumOfDoors, string i_LicenseNumber, string i_ModelName, List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_Engine)
        {
            r_Color = i_Color;
            r_NumOfDoors = i_NumOfDoors;

        }

        public eColor Color
        {
            get
            {
                return r_Color;
            }
        }
        public eNumOfDoors NumOfDoors
        {
            get
            {
                return r_NumOfDoors;
            }
        }
    }
}