using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public abstract class Engine
    {
        private const float k_MinEnergy = 0;
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;
        private  float m_CurrentEnergyPercent;

        public Engine(float i_CurrentEnergy, float i_MaxEnergy)
        {
            if (i_MaxEnergy <= k_MinEnergy)
            {
                throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy);
            }
            else
            {
                r_MaxEnergy = i_MaxEnergy;
            }

            if (i_CurrentEnergy > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy);
            }
            else
            {
                CurrentEnergy = i_CurrentEnergy;
            }
        }
        public float CurrentEnergyPercent
        {            
            get
            {
                return m_CurrentEnergyPercent;
            }
        }

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
                if (value > r_MaxEnergy || value < k_MinEnergy)
                {
                    throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy);
                }
                else
                {
                    m_CurrentEnergy = value;
                    m_CurrentEnergyPercent = (value / r_MaxEnergy) * 100;
                }
            }
        }

        protected void addEnergy(float i_EnergyToAdd)
        {
            if(CurrentEnergy + i_EnergyToAdd > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy - CurrentEnergy);
            }

            CurrentEnergy = CurrentEnergy + i_EnergyToAdd;
        }

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();
            engineDetails.AppendFormat("Current Gas/Energy: {0}{1}", m_CurrentEnergy, Environment.NewLine);
            engineDetails.AppendFormat("Energy Left: {0}%{1}", m_CurrentEnergyPercent, Environment.NewLine);

            return engineDetails.ToString();
        }
    }
}
