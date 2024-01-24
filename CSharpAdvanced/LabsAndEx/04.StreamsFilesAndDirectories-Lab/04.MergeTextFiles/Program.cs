namespace MergeFiles 
{ 
    public class MergeFiles 
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath) 
        {
            string[] file1 = File.ReadAllLines(firstInputFilePath);
            string[] file2 = File.ReadAllLines(secondInputFilePath);

            int longestLines = Math.Max(file1.Length, file2.Length);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < longestLines; i++)
                {
                    if (i < file1.Length)
                        writer.WriteLine(file1[i]);

                    if (i < file2.Length)
                        writer.WriteLine(file2[i]);
                }
            }
        }
    }
}
