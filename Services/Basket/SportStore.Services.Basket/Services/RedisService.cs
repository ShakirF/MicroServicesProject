using StackExchange.Redis;

namespace SportStore.Services.Basket.Services;

public class RedisService
{
    private readonly string _host;
    private readonly string _port;
    private ConnectionMultiplexer _ConnectionMultiplexer;
    public RedisService(string host, string port)
    {
        this._host = host;
        this._port = port;

    }

    public void Connect() => _ConnectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    public IDatabase GetDB(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);
}

