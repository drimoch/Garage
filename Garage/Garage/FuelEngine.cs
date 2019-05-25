using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class FuelEngine : Engine
    {
        private readonly Enums.eGasType r_GasType;
        public FuelEngine(Enums.eGasType i_GasType, float i_CurrentEnergy, float i_MaxEnergy) : base(i_CurrentEnergy, i_MaxEnergy)
        {
            r_GasType = i_GasType;
        }

        public void FuelVehicle(float i_AmountToAdd, Enums.eGasType i_GasType)
        {
            if (i_GasType == r_GasType)
            {
                base.addEnergy(i_AmountToAdd);
            }
            else
            {
                throw new ArgumentException("The chosen gas type doesn't match the car's gas type");
            }
        }

        public Enums.eGasType GasType
        {
            get
            {
                return r_GasType;
            }
        }

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();
            engineDetails.AppendFormat("Gas Type: {0}{1}", r_GasType, Environment.NewLine);
            engineDetails.Append(base.ToString());

            return engineDetails.ToString();
        }
    }
}
