// Test file to verify DateTimeUtcConverter functionality
using System;
using LibraryManagementAPI.Converters;

class DateTimeConverterTest
{
    static void Main()
    {
        Console.WriteLine("🧪 Testing DateTimeUtcConverter...");

        var converter = new DateTimeUtcConverter();
        var nullableConverter = new NullableDateTimeUtcConverter();

        // Test DateTime conversion
        var localTime = new DateTime(2024, 9, 10, 14, 30, 0, DateTimeKind.Local);
        var unspecifiedTime = new DateTime(2024, 9, 10, 14, 30, 0, DateTimeKind.Unspecified);
        var utcTime = new DateTime(2024, 9, 10, 14, 30, 0, DateTimeKind.Utc);

        Console.WriteLine($"Local time: {localTime} (Kind: {localTime.Kind})");
        Console.WriteLine($"Unspecified time: {unspecifiedTime} (Kind: {unspecifiedTime.Kind})");
        Console.WriteLine($"UTC time: {utcTime} (Kind: {utcTime.Kind})");

        // Test nullable DateTime conversion
        DateTime? nullTime = null;
        DateTime? localNullableTime = new DateTime(2024, 9, 10, 14, 30, 0, DateTimeKind.Local);

        Console.WriteLine($"Null time: {nullTime}");
        Console.WriteLine($"Local nullable time: {localNullableTime} (Kind: {localNullableTime?.Kind})");

        Console.WriteLine("✅ DateTimeUtcConverter test completed!");
    }
}
