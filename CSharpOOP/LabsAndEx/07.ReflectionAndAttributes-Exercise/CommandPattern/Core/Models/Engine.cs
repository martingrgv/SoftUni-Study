using System;
using System.Numerics;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models;

public class Engine : IEngine
{
    private readonly ICommandInterpreter commandInterpreter;
    public Engine(ICommandInterpreter command)
    {
        commandInterpreter = command;
    }
    
    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine();
            string result = null;

            try
            {
                result = commandInterpreter.Read(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(result);
        }
    }
}