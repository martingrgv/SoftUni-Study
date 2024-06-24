using BorderControl.Interfaces;

namespace BorderControl.Models;
public class Robot : IIdentifiable
{
    private string model;
    private string id;

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model
    {
        get { return model; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be empty!");
            }

            model = value;
        }
    }

    public string Id
    {
        get { return id; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Id cannot be empty!");
            }

            id = value;
        }
    }
}