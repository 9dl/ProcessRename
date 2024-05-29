## Overview
ProcessRename is a tool designed for pentesters to search for a running process by name, terminate it, rename its executable file, and then restart it. This can help in scenarios where processes need to be masked or manipulated during testing.

## Bypasses anti-debugging techniques that only check process names.
- Useless against anti-debugging techniques that check with `process.MainWindowTitle`
```
public static void AntiDebugger()
{
    for (;;)
    {
        var processes = Process.GetProcesses();
        foreach (var process in processes)
        {
            if (Blacklisted.Any(process.ProcessName.ToLower().Contains))
            {
                KillProcess(process.ProcessName);
                Environment.Exit(0);
            }
        }
        Thread.Sleep(1000);
    }
}

```

## Features
- Search for a running process by name
- Terminate the found process
- Rename the executable file of the terminated process
- Restart the renamed executable and hide it

## Prerequisites
- .NET Framework
- Administrative privileges (to terminate processes and rename files)

## Installation
1. Download the source code or executable.
2. Ensure all dependencies are installed.

## Usage
1. Run the executable `ProcessRename.exe`.
2. Input the name of the process you wish to rename when prompted.
3. The tool will search for the process, terminate it, rename the executable to `Sys64.exe`, and restart it.

### Example
1. Run `ProcessRename.exe`.
2. Enter the process name (e.g., `notepad`).
3. The tool will find and terminate the process, rename the executable to `Sys64.exe`, restart it, and hide the new executable.

## Error Handling
- If you attempt to use ProcessRename on a 32-bit program while running a 64-bit version of the tool (or vice versa), an error message will be displayed.
- Ensure you have the correct permissions and are targeting the appropriate process architecture.

## Disclaimer
This tool is intended for use in authorized penetration testing and security assessments only. Misuse of this tool can lead to system instability, data loss, or legal consequences. Use responsibly and ensure you have proper authorization before using this tool on any system.
