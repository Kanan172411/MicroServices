using CommandsServices.Models;

namespace CommandsServices.SyncDataService.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}
