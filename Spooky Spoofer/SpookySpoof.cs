using System;
using System.Management;

public class SpookyHWID
{
    public static void SpoofHWID()
    {
        try
        {
            string spoofedHWID = GenerateSpoofedHWID();
            ModifySystemHWID(spoofedHWID);
            Console.WriteLine("Spoofed HWID: " + spoofedHWID);
        }
        catch (Exception ex)
        {
      
            Console.WriteLine("An error occurred during HWID spoofing: " + ex.Message);
        }
    }

    private static string GenerateSpoofedHWID()
    {
        DateTime now = DateTime.Now;
        string spoofedHWID = now.ToString("yyyyMMddHHmmss");
        return spoofedHWID;
    }

    private static void ModifySystemHWID(string newHWID)
    {
        Console.WriteLine("Modifying system HWID...");
        Console.WriteLine("New HWID: " + newHWID);
    }
}