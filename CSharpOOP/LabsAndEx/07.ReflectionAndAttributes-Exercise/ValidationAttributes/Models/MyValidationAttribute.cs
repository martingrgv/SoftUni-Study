using System;

namespace CommandPattern.Core.Models;

public abstract class MyValidationAttribute : Attribute
{
    public abstract bool isValid(object obj);
}