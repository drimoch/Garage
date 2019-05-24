using System;
using System.Collections.Generic;
using System.Text;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    class VehicleInGarage
    {
        private eVehicleStatus m_VehicleStatus;
        private string m_Owner;
        private string m_PhoneNumber;
        private readonly Vehicle r_Vehicle;
        public VehicleInGarage(string i_Owner, string i_PhoneNumber, Vehicle i_vehicle)
        {
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Owner = i_Owner;
            m_PhoneNumber = i_PhoneNumber;
            r_Vehicle = i_vehicle;
        }

        public VehicleInGarage()
        {

        }

        internal eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        internal string Owner
        {
            get
            {
                return m_Owner;
            }
            set
            {
                m_Owner = value;
            }
        }

        internal Vehicle Vehicle { get {return r_Vehicle; } }

        public override string ToString()
        {
            StringBuilder garageDetails = new StringBuilder();

            garageDetails.AppendFormat("Owner's Name: {0}{1}", m_Owner, Environment.NewLine);
            garageDetails.AppendFormat("Owner's Phone Number: {0}{1}", m_PhoneNumber, Environment.NewLine);
            garageDetails.AppendFormat("Vehicle Status: {0}{1}", Enum.GetName(typeof(eVehicleStatus), m_VehicleStatus), Environment.NewLine);
            garageDetails.AppendFormat(r_Vehicle.ToString());

            return garageDetails.ToString();
        }
    }
}
