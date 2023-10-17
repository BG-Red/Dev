using PowerShellHandler;
using System;

string process = PowerShellHandler.PowerShellHandler.Command("Get-Process");

Console.WriteLine(process);