namespace _06.StoreBoxes;
internal class Program
{
    public static void Main(string[] args)
    {
        List<Box> boxes = new List<Box>();
        string[] input = Console.ReadLine().Split(" ");

        AddBox(boxes, input);
        PrintBoxes(boxes);
    }

    static void AddBox(List<Box> boxes, string[] input)
    {
        while (input[0] != "end")
        {
            Box box = CreateBox(input);
            boxes.Add(box);

            input = Console.ReadLine().Split(" ");
        }
    }

    static Item CreateItem(string[] input)
    {
        string itemName = input[1];
        int itemQuality = int.Parse(input[2]);
        double itemPrice = double.Parse(input[3]);


        Item item = new Item()
        {
            Name = itemName,
            Quality = itemQuality,
            Price = itemPrice
        };

        return item;
    }

    static Box CreateBox(string[] input)
    {
        int boxSerialNumber = int.Parse(input[0]);
        Item item = CreateItem(input);
        double boxPrice = item.Quality * item.Price;

        Box box = new Box()
        {
            SerialNumber = boxSerialNumber,
            Item = item,
            Price = boxPrice
        };

        return box;
    }

    static void PrintBoxes(List<Box> boxes)
    {
        List<Box> sortedList = boxes.OrderBy(b => b.Price).ToList();
        sortedList.Reverse();

        foreach (Box box in sortedList)
        {
            System.Console.WriteLine(box.SerialNumber);
            System.Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Item.Quality}");
            System.Console.WriteLine($"-- ${box.Price:f2}");
        }
    }
}
