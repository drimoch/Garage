using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    class Motorcycle : Vehicle
    {
        //Members
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        public Motorcycle(string i_LicenseNumber, string i_Model) : base(i_LicenseNumber, i_Model)
        {

        }
        /*public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, string i_ModelName, List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_Engine)
        {
            if (i_EngineCapacity > 0)
            {
                m_EngineCapacity = i_EngineCapacity;
            }
            else
            {
                throw new ArgumentException("Enigne capacity must be positive value");
            }

            if (Enum.IsDefined(typeof(eLicenseType), i_LicenseType))
            {
                m_LicenseType = i_LicenseType;
            }
            else
            {
                throw new FormatException("Invalid license type");
            }
        }*/

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                if (Enum.IsDefined(typeof(eLicenseType), value))
                {
                    m_LicenseType = value;
                }
                else
                {
                    throw new FormatException("Invalid license type");
                }
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if (value > 0)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Enigne capacity must be positive value");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleDetails = new StringBuilder(string.Format("The motorcycle details are: {0}", Environment.NewLine));

            motorcycleDetails.Append(base.ToString());
            motorcycleDetails.AppendFormat("License Type: {0}{1}", Enum.GetName(typeof(eLicenseType), m_LicenseType), Environment.NewLine);
            motorcycleDetails.AppendFormat("Engine Capacity: {0}{1}", m_EngineCapacity, Environment.NewLine);

            return motorcycleDetails.ToString();
        }
    }
}
