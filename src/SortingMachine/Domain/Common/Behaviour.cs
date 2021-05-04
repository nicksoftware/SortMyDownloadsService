using System;
using System.IO;
using System.Linq;

namespace FileSortingMachine
{
    public class Behavior
    {
        protected virtual string GetExtensionFolderName(FileInfo f)
        {
            var fileExtensionName = f.Extension.ToUpperInvariant();
            var trans = fileExtensionName.Skip(1).ToList();
            string newName = string.Empty;

            foreach (var x in trans)
            {
                newName += x;
            }
            return newName;
        }
        protected virtual void Move(string fileDestination, FileInfo file)
        {
            Directory.CreateDirectory(fileDestination);

            Environment.CurrentDirectory = fileDestination;

            file.MoveTo(file.Name);

        }
    }
}