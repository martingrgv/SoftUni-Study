using System;

namespace Person
{
    public class Child : Person
    {
        private int age;

        public Child(string name, int age) : base(name, age)
        {
            Age = age; 
        }

        public new int Age
        {
            get { return age; }
            set
            {
                if (value > 15)
                    throw new ArgumentException("Child cannot be over 15 years of old.");
                else
                    age = value;
            }
        }
    }
}
