using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

public class ProcessDumper
{
    

    public void DumpProcess(Process process)
    {
        try
        {
            System.UInt32 pId = (uint)process.Id;
            IntPtr pHandle = process.Handle;
            string current_path = Directory.GetCurrentDirectory();
            MiniDumpType DumpType = MiniDumpType.MiniDumpWithFullMemory;
            string pName = process.ProcessName;
            string time = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string dump_path = Path.Combine(current_path, pName + "_" + pId.ToString() + time + ".dmp");
            FileStream dumpStream = File.Create(dump_path);

            bool dump = NativeMethods.MiniDumpWriteDump(pHandle, pId, dumpStream.SafeFileHandle.DangerousGetHandle(), DumpType, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

        }

        catch (Exception e)
        {
            Console.WriteLine("Exception message: {0}", e.Message);
        }
    }
}