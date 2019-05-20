using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class FuelEngine : Engine
    {
        private readonly eGasType r_GasType;
        public FuelEngine(eGasType i_GasType, float i_CurrentEnergy, float i_MaxEnergy) : base(i_CurrentEnergy, i_MaxEnergy)
        {
            r_GasType = i_GasType;

        }
        public void AddGas(float i_AmountToAdd, eGasType i_GasType)
        {
            if (i_GasType == r_GasType)
            {
                base.AddEnergy(i_AmountToAdd);
            }
            else
            {
                //throw exception
            }
        }
        public eGasType GasType
        {
            get
            {
                return r_GasType;
            }
        }

    }
}
