public class Guest
{
    public string Name { get; set; }
    public List<string> likedMeals { get; set; }
    public int unlikedMealsCount { get; set; }

    public Guest()
    {
        likedMeals = new List<string>();
    }
}
