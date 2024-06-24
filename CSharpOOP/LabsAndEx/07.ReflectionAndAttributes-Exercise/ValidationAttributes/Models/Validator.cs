using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        var type = obj.GetType();
        var properties = type.GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit: true));

        foreach (var property in properties)
        {
            var validationAttributes = property.GetCustomAttributes(typeof(MyValidationAttribute), inherit: true)
                .Cast<MyValidationAttribute>();

            foreach (var attribute in validationAttributes)
            {
                object value = property.GetValue(obj);

                if (attribute.isValid(value) == false)
                {
                    return false;
                }
            }
        }

        return true;
    }
}