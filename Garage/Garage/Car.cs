using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;

        public Car(string i_LicenseNumber, string i_Model) : base(i_LicenseNumber, i_Model)
        {
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                if (Enum.IsDefined(typeof(eColor), value))
                {
                    m_Color = value;
                }
                else
                {
                    throw new FormatException("Failed to format color input, please choose from the list");
                }
            }
        }

        public eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                if (Enum.IsDefined(typeof(eNumOfDoors), value))
                {
                    m_NumOfDoors = value;
                }
                else
                {
                    throw new FormatException("Failed to format number of doors input, please choose from the list");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder carDetails = new StringBuilder(string.Format("The car details are: {0}", Environment.NewLine));

            carDetails.Append(base.ToString());
            carDetails.AppendFormat("Color: {0}{1}", m_Color, Environment.NewLine);
            carDetails.AppendFormat("Number Of Doors: {0}{1}", m_NumOfDoors, Environment.NewLine);

            return carDetails.ToString();
        }
    }
}