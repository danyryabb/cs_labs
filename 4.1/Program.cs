using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;


namespace CompInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("-------- OperatingSystem instance --------");
                Console.WriteLine("BuildNumber: {0}", queryObj["BuildNumber"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("FreePhysicalMemory: {0}", queryObj["FreePhysicalMemory"]);
                Console.WriteLine("FreeVirtualMemory: {0}", queryObj["FreeVirtualMemory"]);
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("OSType: {0}", queryObj["OSType"]);
                Console.WriteLine("RegisteredUser: {0}", queryObj["RegisteredUser"]);
                Console.WriteLine("SerialNumber: {0}", queryObj["SerialNumber"]);
                Console.WriteLine("Status: {0}", queryObj["Status"]);
                Console.WriteLine("SystemDevice: {0}", queryObj["SystemDevice"]);
                Console.WriteLine("SystemDrive: {0}", queryObj["SystemDrive"]);
                Console.WriteLine("Version: {0}", queryObj["Version"]);
            }

            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
            foreach (ManagementObject queryObj in searcher1.Get())
            {
                Console.WriteLine("----------- VideoController -----------");
                Console.WriteLine("AdapterRAM: {0}", queryObj["AdapterRAM"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("Description: {0}", queryObj["Description"]);
                Console.WriteLine("VideoProcessor: {0}", queryObj["VideoProcessor"]);
            }

            ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject queryObj in searcher2.Get())
            {
                Console.WriteLine("------------- Processor ---------------");
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("NumberOfCores: {0}", queryObj["NumberOfCores"]);
            }

            PerformanceCounter cpuCounter = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");
            Console.WriteLine("CPU: {0}%", cpuCounter.NextValue());
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine("RAM: {0} MBytes", ramCounter.NextValue());

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
