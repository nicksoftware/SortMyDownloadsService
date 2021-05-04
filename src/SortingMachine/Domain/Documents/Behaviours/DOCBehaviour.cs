using System;
using System.IO;
using System.Threading.Tasks;


namespace FileSortingMachine.Documents.Behaviors
{
    internal class DOCBehaviour :Behavior,ISortBehavior
    {
        private readonly string _docsDestination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public async Task SortAsync(FileInfo file)
        {
            string newName = GetExtensionFolderName(file);
            var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Documents/{newName}/{DateTime.Now.ToString("y")}/";
            Move(toDestination, file);

            await Task.CompletedTask;
        }
    }
}