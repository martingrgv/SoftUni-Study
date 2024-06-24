using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models;

public class CommandInterpreter : ICommandInterpreter
{
    private string command;
    
    public string Read(string args)
    {
        string command = args.Split()[0] + "Command";
        string[] commandArgs = args.Split().Skip(1).ToArray();

        Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == command);

        if (type == null)
        {
            throw new ArgumentException($"Invalid command!");
        }

        var commandInstance = (ICommand)Activator.CreateInstance(type);
        return commandInstance.Execute(commandArgs);
    }
}