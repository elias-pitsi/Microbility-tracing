namespace Tracing.Services.interfaces;

public interface IDateTimeProvider
{
   DateTime UtcNow { get;  }
}