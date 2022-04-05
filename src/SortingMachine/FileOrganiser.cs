using FileSortingMachine.Audio;
using FileSortingMachine.Sorters;
using src.Domain.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSortingMachine
{
    public class FileOrganiser
    {
        public static string DownloadsFolder = @"Downloads\SortFilesInHere\";

        public static  int SortMyFiles(IEnumerable<string> filePaths)
        {
            //Register File Sorters
            var sorters = new List<Sorter>
            {
                new ImageSorter(),
                new AudioSorter(),
                new DocSorter()
            };

            if(filePaths.Count()  == 0) return 0;

            foreach (var f in filePaths)
            {
                var file = new FileInfo(f);

                foreach (var sorter in sorters)
                {
                    if (!sorter.SortBehaviors.ContainsKey(file.Extension))
                        continue;
                    sorter.DoSort(file);
                }
            }
            return filePaths.Count();
        }

        public static string GetFolderPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),DownloadsFolder);
        }
    }
}
