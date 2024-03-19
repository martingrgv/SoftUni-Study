using System;

namespace CommandPattern.Core.Models;

public class MyRangeAttribute : MyValidationAttribute
{
    private int minValue;
    private int maxValue;
    
    public MyRangeAttribute(int minValue, int maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }
    
    public override bool isValid(object obj)
    {
        throw new NotImplementedException();
    }
}