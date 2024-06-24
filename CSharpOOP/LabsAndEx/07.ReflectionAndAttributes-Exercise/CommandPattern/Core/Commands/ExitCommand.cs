using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models;

public class ExitCommand : ICommand
{
    private const int okExitCode = 0;
    
    public string Execute(string[] args)
    {
        Environment.Exit(okExitCode);
        return null;
    }
}