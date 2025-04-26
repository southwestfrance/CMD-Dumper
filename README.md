# CMD-Dumper
A command-line interface application used to view processes and create dumps for them, using [Spectre.Console](https://spectreconsole.net/) for the terminal UI.

## Features
- Lists all running processes with PID, name, and memory usage
- Interactive input to select a process
- Uses Windows API (`MiniDumpWriteDump`) to perform minidumps
- Clean terminal UI using Spectre.Console

## Technologies Used
- C# (.NET 9)
- Spectre.Console
- Windows API

## How to Run
1. Clone the repository
2. Restore packages: `dotnet restore`
3. Build the project: `dotnet build`
4. Run: `dotnet run`
