using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string message) : base(message)
        {
        }

        public ValueOutOfRangeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
