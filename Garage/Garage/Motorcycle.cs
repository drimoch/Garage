using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    class Motorcycle : Vehicle
    {
        //Members
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;
        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, string i_ModelName, List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_Engine)
        {
            if (i_EngineCapacity > 0)
            {
                r_EngineCapacity = i_EngineCapacity;
            }
            else
            {
                throw new ArgumentException("Enigne capacity must be positive value");
            }

            if (Enum.IsDefined(typeof(eLicenseType), i_LicenseType))
            {
                r_LicenseType = i_LicenseType;
            }
            else
            {
                throw new FormatException("Invalid license type");
            }
        }
        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleDetails = new StringBuilder(string.Format("The motorcycle details are: {0})", Environment.NewLine));

            motorcycleDetails.Append(base.ToString());
            motorcycleDetails.AppendFormat("License Type: {0}{1}", Enum.GetName(typeof(eLicenseType), r_LicenseType), Environment.NewLine);
            motorcycleDetails.AppendFormat("Engine Capacity: {0}{1}", r_EngineCapacity, Environment.NewLine);

            return motorcycleDetails.ToString();
        }
    }
}
