using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergy, float i_MaxEnergy) : base((i_CurrentEnergy/60f), i_MaxEnergy)
        {
        }

        public void Charge(float i_EnergyToAdd)
        {
            addEnergy(i_EnergyToAdd);
        }

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();
            engineDetails.AppendFormat("Engine Type: Electric{0}", Environment.NewLine);
            engineDetails.Append(base.ToString());

            return engineDetails.ToString();
        }
    }
}
