using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FolderOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {

            string folderPath;
            int numberOfFiles; //number of files in the directory
            int directoryCheck; //if the directory path is not correct, the cycle do-while restarts.

            do
            {                
                Console.Write("Folder Path: ");
                folderPath = Console.ReadLine();

                if (Directory.Exists(folderPath))
                {
                    string[] filePaths = Directory.GetFiles(folderPath);
                    numberOfFiles = Directory.GetFiles(folderPath).Length;

                    for (int i = 0; i < numberOfFiles; i++)
                    {
                        #region Extension Control
                        if (filePaths[i].EndsWith(".pdf") || filePaths[i].EndsWith(".docx") || filePaths[i].EndsWith(".doc") || filePaths[i].EndsWith(".txt"))
                        {
                            Directory.CreateDirectory(folderPath + @"\Documents");
                            File.Move(filePaths[i], folderPath + @"\Documents\" + Path.GetFileName(filePaths[i]));
                        }
                        else if (filePaths[i].EndsWith(".jpeg") || filePaths[i].EndsWith(".png") || filePaths[i].EndsWith(".gif"))
                        {
                            Directory.CreateDirectory(folderPath + @"\Images");
                            File.Move(filePaths[i], folderPath + @"\Images\" + Path.GetFileName(filePaths[i]));
                        }
                        else if (filePaths[i].EndsWith(".exe") || filePaths[i].EndsWith(".ini"))
                        {
                            Directory.CreateDirectory(folderPath + @"\Programs");
                            File.Move(filePaths[i], folderPath + @"\Programs\" + Path.GetFileName(filePaths[i]));
                        }
                        else if (filePaths[i].EndsWith(".mp3") || filePaths[i].EndsWith(".wav"))
                        {
                            Directory.CreateDirectory(folderPath + @"\Audio");
                            File.Move(filePaths[i], folderPath + @"\Audio\" + Path.GetFileName(filePaths[i]));
                        }
                        else if (filePaths[i].EndsWith(".mp4") || filePaths[i].EndsWith(".mkv"))
                        {
                            Directory.CreateDirectory(folderPath + @"\Video");
                            File.Move(filePaths[i], folderPath + @"\Video\" + Path.GetFileName(filePaths[i]));
                        }
                        else
                        {
                            Directory.CreateDirectory(folderPath + @"\Other");
                            File.Move(filePaths[i], folderPath + @"\Other\" + Path.GetFileName(filePaths[i]));
                        }
                        #endregion
                    }
                    Console.WriteLine("All file have been organized with success.");
                    Console.ReadKey();

                    directoryCheck = 0;
                }
                else
                {
                    Console.WriteLine("The directory does not exist.");
                    directoryCheck = 1;
                }

            } while (directoryCheck == 1);

            
        }
    }
}
