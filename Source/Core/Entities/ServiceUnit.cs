using System;

namespace Core.Entities
{
    public class ServiceUnit
    {
        public decimal Price { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration
        {
            get
            {
                if (StartTime != default(DateTime) && EndTime != default(DateTime))
                {
                    if (DateTime.Compare(StartTime, EndTime) < 0)
                    {
                        return new TimeSpan(EndTime.Ticks-StartTime.Ticks);
                    }
                }

                throw new ArgumentException($"Dates conversion to duration error {StartTime} - {EndTime}");
            } 
        }
    }
}