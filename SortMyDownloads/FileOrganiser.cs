using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMyDownloads
{
    public class FileOrganiser
    {
        public static string GetFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private static string GetExtensionFolderName(FileInfo f)
        {
            var fileExtensionName = f.Extension.ToUpperInvariant();
            var trans = fileExtensionName.Skip(1).ToList();
            string newName = "";
            foreach (var x in trans)
            {
                newName += x;
            }

            return newName;

        }
        private static void Move(string fileDestination, FileInfo file)
        {

            if (fileDestination.Contains("MyDocuments"))
            {

                var datepublished = $"_{DateTime.Now.Day}_";
                if (!Directory.Exists(fileDestination))
                {
                    Directory.CreateDirectory(fileDestination);
                }
                Environment.CurrentDirectory = fileDestination;
           
                file.MoveTo(file.Name + datepublished + file.Extension);

            }
            else
            {
                Directory.CreateDirectory(fileDestination);
                Environment.CurrentDirectory = fileDestination;
                file.MoveTo(file.Name);
            }

        }
        public static void SortMyFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var f = new FileInfo(file);
                if(f.Extension == ".flp")
                {
                    //move to Fl Projects
                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Fl Projects/{DateTime.Now.ToString("y")}/";
                    Move(toDestination, f);

                }
                if (f.Extension == ".mp3" || f.Extension == ".wma" || f.Extension == ".wav")
                {
                    //move to Music Folder
                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)}/Downloaded/{DateTime.Now.ToString("y")}/";
                    Move(toDestination, f);
                }

                else if (f.Extension == ".jpg" || f.Extension == ".png")
                {
                    //move to pictures folder
                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}/Downloaded/{DateTime.Now.ToString("y")}/";
                    Move(toDestination,f);

                }
                else if (f.Extension == ".pdf" || f.Extension == ".docx" || f.Extension == ".doc")
                {
                    //Move to documents
                    if (f.Name.Contains("c++")|| f.Name.Contains("cplusplus")|| f.Name.Contains("cpp"))
                    {

                        var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C++/{DateTime.Now.ToString("y")}/";
                        Move(dest, f);
                    }
                    if (f.Name.Contains("csc") ||f.Name.Contains("c#") ||
                        f.Name.Contains(".net")|| f.Name.Contains("python")|| f.Name.Contains("javascript"))
                    {
                        //move to Computer Science/Documents
                        if (f.Name.Contains("CSC01A1"))
                        {
                            //Move to Computer Science Computer 1A
                            var destination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Computer Science 1A/{DateTime.Now.ToString("y")}/";
                            Move(destination, f);
                        }
                        else
                        {
                            if(f.Name.Contains("c#") || f.Name.Contains("csharp"))
                            {
                                var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C#/{DateTime.Now.ToString("y")}/";
                                Move(dest, f);
                            }
                            else if(f.Name.Contains("Aspnet"))
                            {

                                var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C#/Aspnet/{DateTime.Now.ToString("y")}/";
                                Move(dest, f);
                            }
                        
                            var destination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/{DateTime.Now.ToString("y")}/";
                            Move(destination, f);
                        }

                    }
                    //move to documents General Books
                    string newName = GetExtensionFolderName(f);
                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Documents/{newName}/{DateTime.Now.ToString("y")}/";
                    Move(toDestination, f);
                }
                else if (f.Extension == ".exe" || f.Extension == ".iso" || f.Extension == ".msi")
                {
                    //move to documents
                    string newName = GetExtensionFolderName(f);
                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Softwares/{newName}/{DateTime.Now.ToString("y")}/";
                    Move(toDestination,f);
                }
                else
                {
                    //Move to Other Downloads
                    if (files.Contains("Downloads"))
                    {
                        string newName = GetExtensionFolderName(f);
                        var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Other Downloaded/{newName}/{DateTime.Now.ToString("y")}/";
                        Move(toDestination, f);
                    }
                    else if(files.Contains("Desktop"))
                    {
                        string newName = GetExtensionFolderName(f);
                        var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Other Desktop Files/{newName}/{DateTime.Now.ToString("y")}/";
                        Move(toDestination, f);
                    }
                }
            }
        }

        public static async Task<int> SortMyFilesAsync(IEnumerable<string> files)
        {
            if(files == null)
            {
                //Logger no files were moved
                return 0;
            }
            else
            {
              
                    foreach (var file in files)
                    {
                        try
                        {
                            var f = new FileInfo(file);
                            if (f.Extension == ".flp")
                            {
                                //move to Fl Projects
                                var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Fl Projects/{DateTime.Now.ToString("y")}/";
                                Move(toDestination, f);

                            }
                            if (f.Extension == ".mp3" || f.Extension == ".wma" || f.Extension == ".wav")
                            {
                                //move to Music Folder
                                var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)}/Downloaded/{DateTime.Now.ToString("y")}/";
                                Move(toDestination, f);
                            }

                            else if (f.Extension == ".jpg" || f.Extension == ".png")
                            {
                                //move to pictures folder
                                var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}/Downloaded/{DateTime.Now.ToString("y")}/";
                                Move(toDestination, f);

                            }

                            else if (f.Extension == ".mp4" || f.Extension == ".avi")
                            {
                                //move to pictures folder
                                var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)}/Downloaded/{DateTime.Now.ToString("y")}/";
                                Move(toDestination, f);

                            }
                            else if (f.Extension == ".pdf" || f.Extension == ".docx" || f.Extension == ".doc")
                            {
                                //Move to documents
                                if (f.Name.Contains("c++") || f.Name.Contains("cplusplus") || f.Name.Contains("cpp"))
                                {

                                    var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C++/{DateTime.Now.ToString("y")}/";
                                    Move(dest, f);
                                }
                                if (f.Name.Contains("csc") || f.Name.Contains("c#") ||
                                    f.Name.Contains(".net") || f.Name.Contains("python") || f.Name.Contains("javascript"))
                                {
                                    //move to Computer Science/Documents
                                    if (f.Name.Contains("CSC01A1"))
                                    {
                                        //Move to Computer Science Computer 1A
                                        var destination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Computer Science 1A/{DateTime.Now.ToString("y")}/";
                                        Move(destination, f);
                                    }
                                    else
                                    {
                                        if (f.Name.Contains("c#") || f.Name.Contains("csharp"))
                                        {
                                            var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C#/{DateTime.Now.ToString("y")}/";
                                            Move(dest, f);
                                        }
                                        else if (f.Name.Contains("Aspnet"))
                                        {

                                            var dest = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/C#/Aspnet/{DateTime.Now.ToString("y")}/";
                                            Move(dest, f);
                                        }

                                        var destination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Computer Science/Books/{DateTime.Now.ToString("y")}/";
                                        Move(destination, f);
                                    }

                                }
                                //move to documents General Books
                                string newName = GetExtensionFolderName(f);
                                var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Documents/{newName}/{DateTime.Now.ToString("y")}/";
                                Move(toDestination, f);
                            }
                            else if (f.Extension == ".exe" || f.Extension == ".iso" || f.Extension == ".msi")
                            {
                                //move to documents
                                string newName = GetExtensionFolderName(f);
                                var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Softwares/{newName}/{DateTime.Now.ToString("y")}/";
                                Move(toDestination, f);
                            }
                            else
                            {
                                //Move to Other Downloads
                                if (files.Contains("downloads"))
                                {
                                    string newName = GetExtensionFolderName(f);
                                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Other Downloaded/{newName}/{DateTime.Now.ToString("y")}/";

                                    Move(toDestination, f);
                                }
                                else if (files.Contains("Desktop"))
                                {
                                    string newName = GetExtensionFolderName(f);
                                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Other Desktop Files/{newName}/{DateTime.Now.ToString("y")}/";
                                    Move(toDestination, f);
                                }
                                else
                                {
                                    string newName = GetExtensionFolderName(f);
                                    var toDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Other Files/{newName}/{DateTime.Now.ToString("y")}/";
                                    Move(toDestination, f);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            
                        }

                    }
                
                return files.Count();
            }
        }


    }
}
