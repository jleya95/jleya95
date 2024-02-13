using System.IO;
using System;
using System.Reflection.Metadata.Ecma335;
using Capstone.Models;

namespace Capstone.Services
{
    public class FileService : IFileService
    {
        public bool ReadFile()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("TextFile.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        MapLineToRecord(line);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public Record MapLineToRecord (string line)
        {
            Record record = new Record();
            string[] lineElements = line.Split(',');

            record.File = lineElements[0];
            record.Artist = lineElements[1];
            record.Title = lineElements[2];

            return record;
        }
    }
}
