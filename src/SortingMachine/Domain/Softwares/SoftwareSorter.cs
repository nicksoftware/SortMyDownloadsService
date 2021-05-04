using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileSortingMachine;

namespace src.Domain.Softwares
{
    public class SoftwareSorter : Sorter
    {
        public SoftwareSorter()
        {
            SortBehaviors = new Dictionary<string, ISortBehavior>();

            SortBehaviors.Add(SupportedFileExtensions.MSI, new AnySoftwareBehavior());
            SortBehaviors.Add(SupportedFileExtensions.EXE, new AnySoftwareBehavior());
        }
        public override async Task DoSort(FileInfo file)
        {
            if (!SortBehaviors.ContainsKey(file.Extension))
                return;
            await SortBehaviors[file.Extension].SortAsync(file);
        }


    }
}