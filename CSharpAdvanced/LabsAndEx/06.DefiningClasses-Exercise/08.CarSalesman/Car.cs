using System.Text;

namespace DefiningClasses;

public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = 0;
        this.Color = null;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Model}:");
        sb.AppendLine($" {this.Engine.Model}:");
        sb.AppendLine($"   Power: {this.Engine.Power}");

        if (this.Engine.Displacement != 0)
            sb.AppendLine($"   Displacement: {this.Engine.Displacement}");
        else
            sb.AppendLine($"   Displacement: n/a");

        if (this.Engine.Efficiency != null)
            sb.AppendLine($"   Efficiency: {this.Engine.Efficiency}");
        else
            sb.AppendLine($"   Efficiency: n/a");


        if (this.Weight != 0)
            sb.AppendLine($" Weight: {this.Weight}");
        else
            sb.AppendLine($" Weight: n/a");

        if (this.Color != null)
            sb.AppendLine($" Color: {this.Color}");
        else
            sb.AppendLine($" Color: n/a");

        return sb.ToString().TrimEnd();
    }
}