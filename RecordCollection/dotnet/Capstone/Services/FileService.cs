using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Services
{
    public class FileService : IFileService
    {
        public List<Record> ReadFile()
        {
            int i = 0;
            List<Record> records = new List<Record>();
            Record newRecord = new Record();
            try
            {
                using (StreamReader sr = new StreamReader("TextFile.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null && i < 20)
                    {
                        if (line != "FILE,ARTIST,TITLE,RELEASE YEAR,LABEL,ISSUE YEAR,SERIAL #,PRESSING,DISC #,COLOR,NOTES,NEEDLE: 2.0 / 1.5")
                        {
                            newRecord = MapLineToRecord(line);
                            if (newRecord != null)
                            {
                                records.Add(newRecord);
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return records;
        }
        public Record MapLineToRecord(string line)
        {
            Record record = new Record();
            List<string[]> irregulars = new List<string[]>();
            string[] lineElements = line.Split(',');
            if (lineElements.Length == 12)
            {
                record.File = lineElements[0];
                record.Artist = lineElements[1];
                record.Title = lineElements[2];
                if (lineElements[3] != "")
                {
                    record.ReleaseYear = Int32.Parse(lineElements[3]);
                }
                record.Label = lineElements[4];
                if (lineElements[5] != "")
                {
                    record.IssueYear = Int32.Parse(lineElements[5]);
                }
                record.SerialNumber = lineElements[6];
                record.Pressing = lineElements[7];
                if (lineElements[8] != "")
                {
                    record.DiscNumber = Int32.Parse(lineElements[8]);
                }
                else
                {
                    record.DiscNumber = 1;
                }
                record.Color = lineElements[9];
                record.Notes = lineElements[10];
                record.NeedleInfo = lineElements[11];
                return record;
            }
            else
            {
                irregulars.Add(lineElements);
                return null;
            }
        }
    }
}
