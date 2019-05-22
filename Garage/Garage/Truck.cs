using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class Truck : Vehicle
    {
        // Members
        private readonly float r_ContainerVolume;
        private readonly bool r_CarriesDangerousSubstances;

        public Truck(eGasType i_GasType, float i_ContainerVolume, bool i_CarriesDangerousSubstances,
            string i_LicenseNumber, string i_ModelName, float i_MaxEnergy, float i_CurrentEnergy, List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_Engine)
        {
            r_CarriesDangerousSubstances = i_CarriesDangerousSubstances;
            r_ContainerVolume = i_ContainerVolume;
        }

        public float ContainerVolume
        {
            get
            {
                return r_ContainerVolume;
            }
        }

        public bool R_CarriesDangerousSubstances
        {
            get
            {
                return r_CarriesDangerousSubstances;
            }
        }
    }
}
