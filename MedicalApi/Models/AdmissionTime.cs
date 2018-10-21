using System;

namespace MedicalApi.Models
{
    public class AdmissionTime : IComparable
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int CompareTo(object value)
        {
            if (!(value is AdmissionTime comparable))
            {
                throw new InvalidCastException();
            }

            if (StartTime > comparable.StartTime)
            {
                return -1;
            }

            return EndTime == comparable.EndTime ? 0 : 1;

        }
    }
}
