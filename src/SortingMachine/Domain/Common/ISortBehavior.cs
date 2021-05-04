using System.IO;
using System.Threading.Tasks;

namespace FileSortingMachine
{
    public interface ISortBehavior
    {
        Task SortAsync(FileInfo file);
    }
}