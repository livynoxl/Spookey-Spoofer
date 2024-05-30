using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class SpookyOptimizer
{
    public static void SetProcessorAffinity()
    {
        Process currentProcess = Process.GetCurrentProcess();
        IntPtr processHandle = currentProcess.Handle;
        IntPtr processorAffinityMask = new IntPtr(1);

        if (currentProcess.ProcessorAffinity != processorAffinityMask)
        {
            currentProcess.ProcessorAffinity = processorAffinityMask;
        }
    }

    public static void SetProcessPriority()
    {
        Process currentProcess = Process.GetCurrentProcess();
        currentProcess.PriorityClass = ProcessPriorityClass.High;
    }

    public static void ClearFileSystemCache()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            bool success = Win32.FlushFileBuffers(IntPtr.Zero);
            if (!success)
            {
                int error = Marshal.GetLastWin32Error();
                Console.WriteLine($"Failed to clear file system cache. Error code: {error}");
            }
        }
        else
        {
            Console.WriteLine("Clearing file system cache is not supported on this platform.");
        }
    }

    private static class Win32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushFileBuffers(IntPtr hFile);
    }
}