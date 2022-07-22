using Tracing.Services.interfaces;

namespace Tracing.Services.implementation;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}