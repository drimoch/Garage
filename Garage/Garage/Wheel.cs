﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Wheel
    {
        public Wheel(string i_Manufacturer, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;

        }

        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;


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
                if (value > r_MaxAirPressure)
                {
                    //throw exception
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
    }
}
