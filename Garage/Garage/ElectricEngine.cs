using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class ElectricEngine : Engine
    {

        public ElectricEngine(float i_CurrentEnergy, float i_MaxEnergy) : base(i_CurrentEnergy, i_MaxEnergy)
        {
        }

        public void Charge(float i_EnergyToAdd)
        {
            base.AddEnergy(i_EnergyToAdd);
        }

    }
}
