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
    public struct Date : IComparable, IFormattable, ISerializable, IComparable<Date>, IEquatable<Date>
    {
        private DateTime _dt;

        public static readonly Date MaxValue = new Date(DateTime.MaxValue);
        public static readonly Date MinValue = new Date(DateTime.MinValue);

        public Date(Int32 year, Int32 month, Int32 day)
        {
            _dt = new DateTime(year, month, day);
        }

        public Date(DateTime dateTime)
        {
            _dt = dateTime.AddTicks(-dateTime.Ticks % TimeSpan.TicksPerDay);
        }

        public Date(DateTimeOffset dateTimeOffset) : this(dateTimeOffset.DateTime) { }

        private Date(SerializationInfo info, StreamingContext context)
        {
            _dt = DateTime.FromFileTime(info.GetInt64("ticks"));
        }

        public static TimeSpan operator -(Date d1, Date d2) => d1._dt - d2._dt;

        public static Date operator -(Date d, TimeSpan t) => new Date(d._dt - t);

        public static Boolean operator !=(Date d1, Date d2) => d1._dt != d2._dt;

        public static Date operator +(Date d, TimeSpan t) => new Date(d._dt + t);

        public static Boolean operator <(Date d1, Date d2) => d1._dt < d2._dt;

        public static Boolean operator <=(Date d1, Date d2) => d1._dt <= d2._dt;

        public static Boolean operator ==(Date d1, Date d2) => d1._dt == d2._dt;

        public static Boolean operator >(Date d1, Date d2) => d1._dt > d2._dt;

        public static Boolean operator >=(Date d1, Date d2) => d1._dt >= d2._dt;

        public static implicit operator DateTime(Date d) => d._dt;

        public static explicit operator Date(DateTime d) => new Date(d);

        public static implicit operator DateTimeOffset(Date d) => d._dt;

        public static explicit operator Date(DateTimeOffset d) => new Date(d);

        public Int32 Day => _dt.Day;

        public DayOfWeek DayOfWeek => _dt.DayOfWeek;

        public Int32 DayOfYear => _dt.DayOfYear;

        public Int32 Month => _dt.Month;

        public static Date Today => new Date(DateTime.Today);

        public Int32 Year => _dt.Year;

        public Int64 Ticks => _dt.Ticks;

        public Date AddDays(Int32 value) => new Date(_dt.AddDays(value));

        public Date AddMonths(Int32 value) => new Date(_dt.AddMonths(value));

        public Date AddYears(Int32 value) => new Date(_dt.AddYears(value));

        public static Int32 Compare(Date d1, Date d2) => d1.CompareTo(d2);

        public Int32 CompareTo(Date value) => _dt.CompareTo(value._dt);

        public Int32 CompareTo(Object value) => _dt.CompareTo(value);

        public static Int32 DaysInMonth(Int32 year, Int32 month) => DateTime.DaysInMonth(year, month);

        public Boolean Equals(Date value) => _dt.Equals(value._dt);

        public override Boolean Equals(Object value) => value is Date date && _dt.Equals(date._dt);

        public override Int32 GetHashCode() => _dt.GetHashCode();

        public static Boolean Equals(Date d1, Date d2) => d1._dt.Equals(d2._dt);

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ticks", _dt.Ticks);
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

        public static Date ToDate(DateTime dt) => new Date(dt);

        public static Date ToDate(DateTimeOffset dto) => new Date(dto);

        public String ToLongString() => _dt.ToLongDateString();

        public String ToShortString() => _dt.ToShortDateString();

        public override String ToString() => ToShortString();

        public String ToString(IFormatProvider provider) => _dt.ToString(provider);

        public String ToString(String format)
        {
            if (format == "O" || format == "o" || format == "s")
                return ToString("yyyy-MM-dd");

            return _dt.ToString(format);
        }

        public String ToString(String format, IFormatProvider provider) => _dt.ToString(format, provider);

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