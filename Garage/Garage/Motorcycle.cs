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
        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, string i_ModelName,  List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_Engine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
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
