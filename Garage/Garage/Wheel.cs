using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirPressure = 0;
        private readonly string r_Manufacturer;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_Manufacturer, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxAirPressure = i_MaxAirPressure;
            if(i_CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(k_MinAirPressure, r_MaxAirPressure);
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
                if (value > r_MaxAirPressure || value < k_MinAirPressure)
                {
                    throw new ValueOutOfRangeException(k_MinAirPressure, r_MaxAirPressure);
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
            wheelDetails.AppendFormat("Current Air Pressure: {0}{1}", m_CurrentAirPressure, Environment.NewLine);

            return wheelDetails.ToString();
        }
    }
}
