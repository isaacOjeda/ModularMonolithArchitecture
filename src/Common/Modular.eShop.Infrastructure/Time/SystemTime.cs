using Modular.eShop.Application.Time;

namespace Modular.eShop.Infrastructure.Time;
public class SystemTime : ISystemTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}
