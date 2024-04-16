using Consul;

namespace OrderAPI;

public class ConsulRegistrationService:IHostedService
{
    private readonly IConsulClient _consulClient;
    private readonly IConfiguration _configuration;
    private string _serviceId = string.Empty;
    public ConsulRegistrationService(IConsulClient consulClient, IConfiguration configuration)
    {
        _consulClient = consulClient;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var serviceName = _configuration.GetValue<string>("ServiceConfiguration:ServiceName");
        var host =_configuration.GetValue<string>("ServiceConfiguration:Host");
        var port =_configuration.GetValue<string>("ServiceConfiguration:Port");
        _serviceId = $"{serviceName}-{Guid.NewGuid()}";
        var tagList = new string[] { serviceName };
        
        var register = new AgentServiceRegistration()
        {
            ID = _serviceId,
            Name = serviceName,
            Port = Convert.ToInt32(port),
            Address = host,
            Tags = tagList
        };

        await _consulClient.Agent.ServiceRegister(register, cancellationToken);

    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _consulClient.Agent.ServiceDeregister(_serviceId, cancellationToken);
    }
}