﻿namespace Stealer;

public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        spy.AnalyzeAccessModifiers("Stealer.Hacker");
    }
}