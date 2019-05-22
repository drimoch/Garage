using System;
using System.Collections.Generic;
using System.Text;

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
                //    throw Exception invalid value
            }

            if (Enum.IsDefined(typeof(eLicenseType), i_LicenseType))
            {
                r_LicenseType = i_LicenseType;
            }
            else
            {
                //    throw Exception invalid value

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
    }
}
