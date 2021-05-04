using System;
using System.IO;
using System.Threading.Tasks;
using FileSortingMachine;

namespace FileSortingMachine.Documents.Behaviors
{
    internal class PDFBehavior :Behavior, ISortBehavior
    {
        private readonly string _docsDestination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public async Task SortAsync(FileInfo file)
        {

            if (file.Name.Contains("c#") ||
                file.Name.Contains(".net")||
                file.Name.Contains("python")||
                file.Name.Contains("javascript"))
            {
                //move to Computer Science/Documents

                if (file.Name.Contains("c#") || file.Name.Contains("csharp"))
                {
                    var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C#/{DateTime.Now.ToString("y")}/";
                    Move(dest, file);
                }
                else if (file.Name.Contains("Aspnet"))
                {
                    var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C#/Aspnet/{DateTime.Now.ToString("y")}/";
                    Move(dest, file);
                }
                var destination = $"{_docsDestination}/Computer Science/Books/{DateTime.Now.ToString("y")}/";
                Move(destination, file);

                await Task.CompletedTask;
                return;
            }

            //move to documents General Books
            string newName = GetExtensionFolderName(file);
            var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Documents/{newName}/{DateTime.Now.ToString("y")}/";
            Move(toDestination, file);

            await Task.CompletedTask;
        }
    }
}

