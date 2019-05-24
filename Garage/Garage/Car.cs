using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

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

        public override string ToString()
        {
            StringBuilder carDetails = new StringBuilder(string.Format("The car details are: {0})", Environment.NewLine));

            carDetails.Append(base.ToString());
            carDetails.AppendFormat("Color: {0}{1}", r_Color, Environment.NewLine);
            carDetails.AppendFormat("Number Of Doors: {0}{1}", r_NumOfDoors, Environment.NewLine);

            return carDetails.ToString();
        }
    }
}