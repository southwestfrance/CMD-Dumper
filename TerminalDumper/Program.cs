using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        var table = new Table();
        table.Border(TableBorder.AsciiDoubleHead);
        // Table columns  [PID, Name, Memory]
        table.AddColumn("[bold yellow]PID[/]");
        table.AddColumn("[bold green]Process Name[/]");
        table.AddColumn("[bold blue]Memory (MB)[/]");

        Process[] processList = Process.GetProcesses();

        foreach (Process proc in processList)
        {
            //Console.WriteLine("PID {0} - {1}", proc.Id, proc.ProcessName);

            table.AddRow(proc.Id.ToString(), proc.ProcessName, (proc.WorkingSet64/1024/1024).ToString());
        }


        AnsiConsole.Write(table);

        var input = AnsiConsole.Prompt(new TextPrompt<string>("[green]Enter a process ID to dump or 'q' to quit:[/]").PromptStyle("cyan").AllowEmpty());

        if (input == "exit")
        {
            return;
        }

        else {
            int pId;
            bool success = int.TryParse(input, out pId);

            if (success)
            {
                Process targetProcess = Process.GetProcessById(pId);

                ProcessDumper dumper = new ProcessDumper();
                
                dumper.DumpProcess(targetProcess);

                Console.WriteLine("Dump created for process {0}. Press any button to exit.", targetProcess.ProcessName);
                Console.ReadLine();
                return;
            }

            else
            {
                Console.WriteLine("Unable to dump file. Press any button to exit.");
                Console.ReadLine();
                return;
            }
        }
    }
} 