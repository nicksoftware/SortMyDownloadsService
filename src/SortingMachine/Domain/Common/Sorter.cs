using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace FileSortingMachine
{
    public abstract class Sorter
    {
        public virtual Dictionary<string,ISortBehavior> SortBehaviors { get; set; }
        public virtual Task DoSort(FileInfo file) => Task.CompletedTask;
    }
}