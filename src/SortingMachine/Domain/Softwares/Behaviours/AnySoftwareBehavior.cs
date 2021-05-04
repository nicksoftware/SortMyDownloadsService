using System;
using System.IO;
using System.Threading.Tasks;
using FileSortingMachine;

namespace src.Domain.Softwares
{
    internal class AnySoftwareBehavior : Behavior,ISortBehavior
    {
        private readonly string _imagesDestination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/Softwares";

        public async Task SortAsync(FileInfo file)
        {
            string newName = GetExtensionFolderName(file);
            var toDestination = $"{_imagesDestination}/{DateTime.Now.ToString("y")}/";
            Move(toDestination, file);

            await Task.CompletedTask;
        }
    }
}