using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace LibraryManagementAPI.Converters
{
    /// <summary>
    /// Converts DateTime values to UTC for PostgreSQL compatibility
    /// </summary>
    public class DateTimeUtcConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeUtcConverter()
            : base(
                v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {
        }
    }

    /// <summary>
    /// Converts nullable DateTime values to UTC for PostgreSQL compatibility
    /// </summary>
    public class NullableDateTimeUtcConverter : ValueConverter<DateTime?, DateTime?>
    {
        public NullableDateTimeUtcConverter()
            : base(
                v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v : v.Value.ToUniversalTime()) : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v)
        {
        }
    }
}
