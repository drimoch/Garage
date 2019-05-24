using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Wheel
    {
        private const float k_MinAirPressue = 0;
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;
        public Wheel(string i_Manufacturer, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            if (i_MaxAirPressure <= 0)
            {
                throw new ArgumentException("Air pressure value must be positive");
            }
            else
            {
                r_MaxAirPressure = i_MaxAirPressure;
            }
            CurrentAirPressure = i_CurrentAirPressure;

        }

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value > r_MaxAirPressure || value < 0)
                {
                    throw new ValueOutOfRangeException(k_MinAirPressue, r_MaxAirPressure);
                }
                else
                {
                    m_CurrentAirPressure = value;
                }
            }
        }
        public void AddAir(float i_AirToAdd)
        {
            CurrentAirPressure = CurrentAirPressure + i_AirToAdd;
        }

        public override string ToString()
        {
            StringBuilder wheelDetails = new StringBuilder();

            wheelDetails.AppendFormat("Wheel's Manufacturer: {0}{1}", r_Manufacturer, Environment.NewLine);
            wheelDetails.AppendFormat("Current Air Pressue: {0}{1}", m_CurrentAirPressure, Environment.NewLine);

            return wheelDetails.ToString();
        }


    }
}
