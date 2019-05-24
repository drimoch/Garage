using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    abstract class Engine
    {
        private const float k_MinEnergy = 0;
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;
        public Engine(float i_CurrentEnergy, float i_MaxEnergy)
        {
            if (i_MaxEnergy <= 0)
            {
                throw new ArgumentException("Energy value must be positive");
            }
            else
            {
                r_MaxEnergy = i_MaxEnergy;
            }
            CurrentEnergy = i_CurrentEnergy;
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
                if (value > r_MaxEnergy || value < 0)
                {
                    throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy);
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

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();
            engineDetails.AppendFormat("Current Gas/Energy: {0}{1}", m_CurrentEnergy, Environment.NewLine);

            return engineDetails.ToString();
        }
    }
}
