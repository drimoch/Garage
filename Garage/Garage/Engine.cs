using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    abstract class Engine
    {
        public Engine(float i_CurrentEnergy, float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }
        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                if (value > r_MaxEnergy)
                {
                    //throw exception
                }
                else
                {
                    m_CurrentEnergy = value;
                    //  CurrentEnergyPercent = value; todo: take care of this later
                }
            }
        }

        protected void AddEnergy(float i_EnergyToAdd)
        {
            CurrentEnergy = CurrentEnergy + i_EnergyToAdd;
        }
    }
}
