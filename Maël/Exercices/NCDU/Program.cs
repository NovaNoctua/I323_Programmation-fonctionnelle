using System;
using System.IO;

namespace NCDU
{
    class Program
    {
        static void Main()
        {
            string rootDirectory = @"D:\05-repertoires-ict-ssd (2022)";
            var entries = new List<FileSystemEntry>();

            // Get all files in root directory
            string[] filePaths = Directory.GetFiles(rootDirectory);
            foreach (string filePath in filePaths)
            {
                FileInfo fileDetails = new FileInfo(filePath);
                entries.Add(new FileSystemEntry() 
                { 
                    EntryPath = fileDetails.FullName, 
                    EntrySize = fileDetails.Length 
                });
            }

            // Get all directories in root directory
            string[] directoryPaths = Directory.GetDirectories(rootDirectory);
            foreach (string directoryPath in directoryPaths)
            {
                entries.Add(new FileSystemEntry() { EntryPath = directoryPath, EntrySize = GetDirectorySize(directoryPath) });
            }

            // Bubble sort entries by size descending
            for (int i = 0; i < entries.Count - 1; i++)
            {
                for (int j = 0; j < entries.Count - i - 1; j++)
                {
                    if (entries[j].EntrySize < entries[j + 1].EntrySize)
                    {
                        var temp = entries[j];
                        entries[j] = entries[j + 1];
                        entries[j + 1] = temp;
                    }
                }
            }

            PrintEntries(entries);
        }

        static long GetDirectorySize(string directoryPath)
        {
            long totalSize = 0;

            foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                totalSize += new FileInfo(filePath).Length;
            }

            foreach (string subDirectory in Directory.GetDirectories(directoryPath))
            {
                totalSize += GetDirectorySize(subDirectory);
            }

            return totalSize;
        }

        static void PrintEntries(List<FileSystemEntry> entries)
        {
            foreach (var entry in entries)
            {
                double size = entry.EntrySize;
                string[] units = { "B", "KiB", "MiB", "GiB" };
                int unitIndex = 0;

                while (size >= 1024 && unitIndex < units.Length - 1)
                {
                    size /= 1024;
                    unitIndex++;
                }

                Console.WriteLine($"{Math.Round(size, 1)} {units[unitIndex]}, {entry.EntryPath}");
            }
        }
    }

    public class FileSystemEntry
    {
        // full path
        public string EntryPath { get; set; }

        // size in bytes
        public float EntrySize { get; set; }
    }
}
