using CommandsServices.Models;

namespace CommandsServices.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();


        // Platforms
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExist(int platformId);

        //Commands
        IEnumerable<Command> GetAllCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);




    }
}
