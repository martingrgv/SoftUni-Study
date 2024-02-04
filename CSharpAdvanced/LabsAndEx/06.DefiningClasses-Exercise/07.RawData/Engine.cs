namespace DefiningClasses;

public class Engine
{
    private int power;
    private int speed;

    public Engine(int power, int speed)
    {
        this.Power = power;
        this.Speed = speed;
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public int Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }
}