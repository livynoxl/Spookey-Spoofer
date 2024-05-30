using System;
using System.IO;

public class SpookyCleaner
{
    public static void Gpu()
    {
        string tempPath = Path.GetTempPath();

        DeleteFiles(tempPath);

        string[] tempDirectories = Directory.GetDirectories(tempPath);
        foreach (string directory in tempDirectories)
        {
            DeleteFiles(directory);
            Directory.Delete(directory, true);
        }
    }

    private static void DeleteFiles(string directoryPath) // u can add any shit to boost ur pc
    {
        DirectoryInfo directory = new DirectoryInfo(directoryPath);
        foreach (FileInfo file in directory.GetFiles())
        {
            try
            {
                file.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete file: {file.FullName} - {ex.Message}");
            }
        }
    }
}