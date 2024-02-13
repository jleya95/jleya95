using Capstone.Models;
namespace Capstone.Services
{
    public interface IFileService
    {
        bool ReadFile();
        Record MapLineToRecord(string line);
    }
}
