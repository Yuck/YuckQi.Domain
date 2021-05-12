/*
The MIT License (MIT)

Copyright (c) 2015 Clay Anderson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace YuckQi.Domain.ValueObjects
{
    [Serializable]
    public readonly struct Date : IComparable, IFormattable, ISerializable, IComparable<Date>, IEquatable<Date>
    {
        private readonly DateTime _value;

        public static readonly Date MaxValue = new Date(DateTime.MaxValue);
        public static readonly Date MinValue = new Date(DateTime.MinValue);

        public Date(Int32 year, Int32 month, Int32 day)
        {
            _value = new DateTime(year, month, day);
        }

        public Date(DateTime dateTime)
        {
            _value = dateTime.AddTicks(-dateTime.Ticks % TimeSpan.TicksPerDay);
        }

        public Date(DateTimeOffset dateTimeOffset) : this(dateTimeOffset.DateTime) { }

        private Date(SerializationInfo info, StreamingContext context)
        {
            _value = DateTime.FromFileTime(info.GetInt64("ticks"));
        }

        public static TimeSpan operator -(Date d1, Date d2) => d1._value - d2._value;

        public static Date operator -(Date d, TimeSpan t) => new Date(d._value - t);

        public static Boolean operator !=(Date d1, Date d2) => d1._value != d2._value;

        public static Date operator +(Date d, TimeSpan t) => new Date(d._value + t);

        public static Boolean operator <(Date d1, Date d2) => d1._value < d2._value;

        public static Boolean operator <=(Date d1, Date d2) => d1._value <= d2._value;

        public static Boolean operator ==(Date d1, Date d2) => d1._value == d2._value;

        public static Boolean operator >(Date d1, Date d2) => d1._value > d2._value;

        public static Boolean operator >=(Date d1, Date d2) => d1._value >= d2._value;

        public static implicit operator DateTime(Date d) => d._value;

        public static explicit operator Date(DateTime d) => new Date(d);

        public static implicit operator DateTimeOffset(Date d) => d._value;

        public static explicit operator Date(DateTimeOffset d) => new Date(d);

        public Int32 Day => _value.Day;

        public DayOfWeek DayOfWeek => _value.DayOfWeek;

        public Int32 DayOfYear => _value.DayOfYear;

        public Int32 Month => _value.Month;

        public static Date Today => new Date(DateTime.Today);

        public Int32 Year => _value.Year;

        public Int64 Ticks => _value.Ticks;

        public Date AddDays(Int32 value) => new Date(_value.AddDays(value));

        public Date AddMonths(Int32 value) => new Date(_value.AddMonths(value));

        public Date AddYears(Int32 value) => new Date(_value.AddYears(value));

        public static Int32 Compare(Date d1, Date d2) => d1.CompareTo(d2);

        public Int32 CompareTo(Date value) => _value.CompareTo(value._value);

        public Int32 CompareTo(Object value) => _value.CompareTo(value);

        public static Int32 DaysInMonth(Int32 year, Int32 month) => DateTime.DaysInMonth(year, month);

        public Boolean Equals(Date value) => _value.Equals(value._value);

        public override Boolean Equals(Object value) => value is Date date && _value.Equals(date._value);

        public override Int32 GetHashCode() => _value.GetHashCode();

        public static Boolean Equals(Date d1, Date d2) => d1._value.Equals(d2._value);

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ticks", _value.Ticks);
        }

        public static Boolean IsLeapYear(Int32 year) => DateTime.IsLeapYear(year);

        public static Date Parse(String s) => new Date(DateTime.Parse(s));

        public static Date Parse(String s, IFormatProvider provider) => new Date(DateTime.Parse(s, provider));

        public static Date Parse(String s, IFormatProvider provider, DateTimeStyles style) => new Date(DateTime.Parse(s, provider, style));

        public static Date ParseExact(String s, String format, IFormatProvider provider) => new Date(DateTime.ParseExact(s, format, provider));

        public static Date ParseExact(String s, String format, IFormatProvider provider, DateTimeStyles style) => new Date(DateTime.ParseExact(s, format, provider, style));

        public static Date ParseExact(String s, String[] formats, IFormatProvider provider, DateTimeStyles style) => new Date(DateTime.ParseExact(s, formats, provider, style));

        public TimeSpan Subtract(Date value) => this - value;

        public Date Subtract(TimeSpan value) => this - value;

        public static Date ToDate(DateTime dateTime) => new Date(dateTime);

        public static Date ToDate(DateTimeOffset dateTimeOffset) => new Date(dateTimeOffset);

        public String ToLongString() => _value.ToLongDateString();

        public String ToShortString() => _value.ToShortDateString();

        public override String ToString() => ToShortString();

        public String ToString(IFormatProvider provider) => _value.ToString(provider);

        public String ToString(String format)
        {
            if (format == "O" || format == "o" || format == "s")
                return ToString("yyyy-MM-dd");

            return _value.ToString(format);
        }

        public String ToString(String format, IFormatProvider provider) => _value.ToString(format, provider);

        public static Boolean TryParse(String s, out Date result)
        {
            var success = DateTime.TryParse(s, out var d);

            result = new Date(d);

            return success;
        }

        public static Boolean TryParse(String s, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            var success = DateTime.TryParse(s, provider, style, out var d);

            result = new Date(d);

            return success;
        }

        public static Boolean TryParseExact(String s, String format, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            var success = DateTime.TryParseExact(s, format, provider, style, out var d);

            result = new Date(d);

            return success;
        }

        public static Boolean TryParseExact(String s, String[] formats, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            var success = DateTime.TryParseExact(s, formats, provider, style, out var d);

            result = new Date(d);

            return success;
        }
    }
}