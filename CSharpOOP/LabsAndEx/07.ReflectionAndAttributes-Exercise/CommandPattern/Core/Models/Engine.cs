using System.Numerics;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models;

public class Engine : IEngine
{
    public Engine(ICommandInterpreter command)
    {
        
    }
    
    public void Run()
    {
        throw new System.NotImplementedException();
    }
}