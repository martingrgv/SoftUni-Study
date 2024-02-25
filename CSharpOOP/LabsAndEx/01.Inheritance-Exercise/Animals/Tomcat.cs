namespace Animals
{
    public class Tomcat : Animal
    {
        private const string gender = "Male";

        public Tomcat(string name, int age) : base(name, age, gender)
        {
            
        }

        public override string ProduceSound() => "MEOW";
    }
}
