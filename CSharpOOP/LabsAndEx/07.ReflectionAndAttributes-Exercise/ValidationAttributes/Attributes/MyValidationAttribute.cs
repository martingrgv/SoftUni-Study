using System;

namespace ValidationAttributes.Attributes;

public abstract class MyValidationAttribute : Attribute
{
    public abstract bool isValid(object obj);
}