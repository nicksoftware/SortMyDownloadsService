using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileSortingMachine;
using FileSortingMachine.Audio.Behaviors;

namespace FileSortingMachine.Audio
{
    public class AudioSorter: Sorter
    {
        public AudioSorter()
        {
            SortBehaviors = new Dictionary<string, ISortBehavior>();

            SortBehaviors.Add(SupportedFileExtensions.MP3, new Mp3Behavior());
            SortBehaviors.Add(SupportedFileExtensions.WMA, new WMABehavior());
            SortBehaviors.Add(SupportedFileExtensions.Wave, new WaveBehavior());
        }

        public override async Task DoSort(FileInfo file)
        {
            await SortBehaviors[file.Extension].SortAsync(file);

        }

    }
}