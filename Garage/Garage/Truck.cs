using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    class Truck : Vehicle
    {
        // Members
        private readonly float r_ContainerVolume;
        private readonly bool r_CarriesDangerousSubstances;

        public Truck(eGasType i_GasType, float i_ContainerVolume, bool i_CarriesDangerousSubstances,
            string i_LicenseNumber, string i_ModelName,  List<Wheel> i_Wheels, Engine i_Engine)
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

        public override string ToString()
        {
            const string k_Yes = "yes";
            const string k_No = "no";
            string carriesDangerous = r_CarriesDangerousSubstances ? k_Yes : k_No;
            StringBuilder truckDetails = new StringBuilder(string.Format("The truck details are: {0})", Environment.NewLine));

            truckDetails.Append(base.ToString());
            truckDetails.AppendFormat("Carries Dangerous Substances: {0}{1}", carriesDangerous, Environment.NewLine);
            truckDetails.AppendFormat("Container Volume: {0}{1}", r_ContainerVolume, Environment.NewLine);

            return truckDetails.ToString();
        }
    }
}
