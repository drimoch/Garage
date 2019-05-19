using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Vehicle
    {
        // Members
        private string m_LicenseNumber;
        private string m_ModelName;
        private float m_CurrentEnergy;
        private float m_MaxEnergy;
        private float m_CurrentEnergyPercent;
        public float CurrentEnergy
        {
            set
            {
                if (value + m_CurrentEnergy > m_MaxEnergy)
                {
                    //throw exception
                }
            }
        }
        public float CurrentEnergyPercent
        {
            get
            {
                return (m_CurrentEnergy / m_MaxEnergy) * 100;
            }
        }

        public string LicenseNumber

        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }
    }
}
