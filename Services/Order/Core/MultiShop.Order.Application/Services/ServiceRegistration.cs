using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiShop.Order.Application.Services;

public static class ServiceRegistration
{
    public static void ApplicationService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}

//Bu yapı, ilgili kütüphanenin servis kayıtlarını merkezi olarak tamamlar; Program.cs dosyasında ayrıca çağırmaya gerek kalmaz.