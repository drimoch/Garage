using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
   abstract class Vehicle
    {
        public Vehicle(string i_LicenseNumber, string i_ModelName, List<Wheel> i_Wheels,Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_ModelName;
            r_Wheels = i_Wheels;
            r_Engine = i_Engine;
        }

        // Members
        private readonly string r_LicenseNumber;
        private readonly string r_ModelName;
        private readonly float m_CurrentEnergyPercent;
        private readonly List<Wheel> r_Wheels;
        private readonly Engine r_Engine;
        public float CurrentEnergyPercent
        {
            //connect to electricity somehow
         //   set
         //   {
              //  m_CurrentEnergyPercent = (value / m_MaxEnergy) * 100;
            //}
            get
            {
                return m_CurrentEnergyPercent;
            }
        }
        public string LicenseNumber

        {
            get
            {
                return r_LicenseNumber;
            }
            
        }
        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }
        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public override bool Equals(object i_Obj1)
        {
            bool equals = false;
            Vehicle vehicleToCompare = i_Obj1 as Vehicle;
            if (this.r_LicenseNumber.Equals(vehicleToCompare.LicenseNumber))
            {
                equals = true;
            }
            return equals;
        }

        public static bool operator ==(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return i_Vehicle1.LicenseNumber == i_Vehicle1.LicenseNumber;
        }

        public static bool operator !=(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return !(i_Vehicle1.LicenseNumber == i_Vehicle2.LicenseNumber);
        }

        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder vehicleGeneralDetails = new StringBuilder(string.Format("Vehicle Details:{0}", Environment.NewLine));
            vehicleGeneralDetails.AppendFormat("License Number: {0}{1}", r_LicenseNumber, Environment.NewLine);
            vehicleGeneralDetails.AppendFormat("Model Name: {0}{1}", r_ModelName, Environment.NewLine);
            vehicleGeneralDetails.AppendFormat("Wheels Details {0}:", Environment.NewLine);
            int counter = 1;
            foreach (Wheel wheel in r_Wheels)
            {
                vehicleGeneralDetails.AppendFormat("Wheel Number {0}: {1}", counter++, Environment.NewLine);
                vehicleGeneralDetails.AppendFormat(wheel.ToString());
            }

            vehicleGeneralDetails.AppendFormat(r_Engine.ToString());

            return vehicleGeneralDetails.ToString();
        }

    }
}
