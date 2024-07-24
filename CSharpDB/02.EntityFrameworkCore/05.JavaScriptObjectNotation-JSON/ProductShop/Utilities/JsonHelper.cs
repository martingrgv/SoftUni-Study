namespace ProductShop.Utilities;

public static class JsonHelper
{
    public static string GetJson(string filePath, string filename)
    {
        string fullPath = $"{filePath}{filename}.json";

        if (File.Exists(fullPath))
        {
            return File.ReadAllText($"{filePath}{filename}.json");
        }

        throw new FileNotFoundException("JSON file could not be found in the provided directory: " + filePath);
    }
}
