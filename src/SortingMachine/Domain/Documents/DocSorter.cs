using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using FileSortingMachine.Documents.Behaviors;

namespace FileSortingMachine.Sorters
{
    public class DocSorter : Sorter
    {
        public DocSorter()
        {
            SortBehaviors = new Dictionary<string, ISortBehavior>();
            SortBehaviors.Add(SupportedFileExtensions.PDF, new PDFBehavior());
            SortBehaviors.Add(SupportedFileExtensions.DOC, new DOCBehaviour());
            SortBehaviors.Add(SupportedFileExtensions.DOCX, new DOCXBehaviour());
        }

        public override async Task DoSort(FileInfo file)
        {
            if (!SortBehaviors.ContainsKey(file.Extension))
                return;

            await SortBehaviors[file.Extension].SortAsync(file);
        }
    }
}