﻿using Capstone.Exceptions;
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
            List<string> irregulars = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader("TextFile.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null && i < 734)
                    {
                        if (line != "FILE,ARTIST,TITLE,RELEASE YEAR,LABEL,ISSUE YEAR,SERIAL #,PRESSING,DISC #,COLOR,NOTES,NEEDLE: 2.0 / 1.5")
                        {
                            string[] lineElements = line.Split(',');
                            if (lineElements.Length == 12)
                            {
                                newRecord = MapLineToRecord(lineElements);
                                if (newRecord != null)
                                {
                                    records.Add(newRecord);
                                    i++;
                                }
                            }
                            else
                            {
                                irregulars.Add(line);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DaoException("Error reading file", e);
            }

            if (irregulars.Count > 0)
            {
                for (int j = 0; j < irregulars.Count; j++)
                {
                    records.Add(MapIrregularLineToRecord(irregulars[j]));
                }
            }

            return records;
        }
        private Record MapLineToRecord(string[] lineElements)
        {
            Record record = new Record();

            record.File = lineElements[0];
            record.Artist = lineElements[1];
            record.Title = lineElements[2];
            if (lineElements[3] != "" && lineElements[3].Length == 4)
            {
                record.ReleaseYear = Int32.Parse(lineElements[3]);
            }
            record.Label = lineElements[4];
            if (lineElements[5] != "" && lineElements[5].Length == 4)
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

        private Record MapIrregularLineToRecord(string irregularLine)
        {
            Record record = new Record();
            string[] lineElements = new string[12];

            string[] initialLineSplit = irregularLine.Split("\",");
            for(int i = 0; i < initialLineSplit.Length; i++)
            {
                if (initialLineSplit[i].Contains("\""))
                {
                    string splitSubstring = initialLineSplit[i].Remove(0,1);
                    lineElements[i] = splitSubstring;
                } else
                {
                    string[] nextLineSplit = initialLineSplit[i].Split(',');
                }
            }


            return record;
        }
    }

}