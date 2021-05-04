using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileSortingMachine;

namespace src.Domain.Images
{
    public class ImageSorter : Sorter
    {
        public ImageSorter()
        {
            SortBehaviors = new Dictionary<string, ISortBehavior>();

            SortBehaviors.Add(SupportedFileExtensions.JPG, new AnyImageBehavior());
            SortBehaviors.Add(SupportedFileExtensions.PNG, new AnyImageBehavior());
        }
        public override async Task DoSort(FileInfo file)
        {
            if (!SortBehaviors.ContainsKey(file.Extension))
                return;

            await SortBehaviors[file.Extension].SortAsync(file);
        }
    }
}