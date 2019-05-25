﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
   public abstract class Vehicle
   {
        public Vehicle(string i_LicenseNumber, string i_Model)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_Model;
        }

        /*public Vehicle(string i_LicenseNumber, string i_ModelName, List<Wheel> i_Wheels, Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_ModelName;
            r_Wheels = i_Wheels;
            m_Engine = i_Engine;
        }*/

        // Members
        private readonly string r_LicenseNumber;
        private readonly string r_ModelName;
        private readonly float m_CurrentEnergyPercent;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;
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

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
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
            vehicleGeneralDetails.AppendFormat("Wheels Details: {0}", Environment.NewLine);
            vehicleGeneralDetails.AppendFormat("Number of Wheels: {0}{1}", m_Wheels.Count, Environment.NewLine);
            vehicleGeneralDetails.AppendFormat(m_Wheels[0].ToString());
            vehicleGeneralDetails.AppendFormat(m_Engine.ToString());

            return vehicleGeneralDetails.ToString();
        }

    }
}
