using CommonDomain.Model;
using System;

namespace CommonDomain.ValueObjects
{
    public class DateTimeRange : ValueObject<DateTimeRange>
    {
        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public DateTimeRange(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start date could not be greather or equal to end date");
            }

            Start = start;
            End = end;
        }

        public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
        {
        }
        
        public TimeSpan Duration => (End - Start);

        public static DateTimeRange Yesterday = CreateOneDayRange(DateTime.Now.Date.AddDays(-1));
        public static DateTimeRange Today = CreateOneDayRange(DateTime.Now.Date);
        public static DateTimeRange Tomorow = CreateOneDayRange(DateTime.Now.Date.AddDays(1));
        
        public static DateTimeRange LastWeek = CreateOneWeekRange(StartOfWeek(DateTime.Now.AddDays(-7)));
        public static DateTimeRange ThisWeek = CreateOneWeekRange(StartOfWeek(DateTime.Now));
        public static DateTimeRange NextWeek = CreateOneWeekRange(StartOfWeek(DateTime.Now.AddDays(7)));

        private static DateTime StartOfWeek(DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public DateTimeRange NewStart(DateTime newStart)
        {
            return new DateTimeRange(newStart, this.End);
        }
        public DateTimeRange NewEnd(DateTime newEnd)
        {
            return new DateTimeRange(this.Start, newEnd);
        }
        public DateTimeRange NewDuration(TimeSpan newDuration)
        {
            return new DateTimeRange(this.Start, newDuration);
        }

        public static DateTimeRange CreateOneDayRange(DateTime day)
        {
            return new DateTimeRange(day, day.AddDays(1));
        }

        public static DateTimeRange CreateOneWeekRange(DateTime startDay)
        {
            return new DateTimeRange(startDay, startDay.AddDays(7));
        }

        public bool Overlaps(DateTimeRange dateTimeRange)
        {
            return this.Start < dateTimeRange.End &&
                this.End > dateTimeRange.Start;
        }
    }
}
