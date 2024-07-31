public interface IDisposableService : IDisposable, IAsyncDisposable { }

public class DisposableService : IDisposableService
{
    private static int globalId = 0;
    private int id;
    private readonly ILogger<DisposableService> logger;
    private readonly string type;

    public DisposableService(ILogger<DisposableService> logger, string type)
    {
        this.logger = logger;
        this.type = type;
        id = ++globalId;

        logger.LogInformation("{id}: {type} Service Instance Created", type, id);
    }

    public void Dispose() => logger.LogWarning("{id}: {type} Service Disposed!", type, id);
    public async ValueTask DisposeAsync() => logger.LogWarning("{id}: {type} Service Disposed Asynchronously!", type, id);
}