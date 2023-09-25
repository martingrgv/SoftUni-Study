using System;

namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char asciiValue;
            string output = String.Empty;

            // Input
            byte timesRead = byte.Parse(Console.ReadLine());

            // Logic
            for (int i = 0; i < timesRead; i++)
            {
                ushort currentDigit = ushort.Parse(Console.ReadLine());

                if (currentDigit == 0)
                {
                    asciiValue = AsciiToChar(32);
                }
                else
                {
                    byte mainDigit = (byte)(currentDigit % 10);
                    byte digitLength = 0;
                    while (currentDigit > 0)
                    {
                        digitLength++;
                        currentDigit = (byte)(currentDigit / 10);
                    }

                    byte offset = (byte)((mainDigit - 2) * 3);
                    if (mainDigit == 7 || mainDigit == 9)
                    {
                        offset++;
                    }

                    byte letterIndex = (byte)(offset + digitLength - 1);
                    asciiValue = AsciiToChar((byte)(97 + letterIndex));
                }
            
                output += asciiValue;
            }

            // Output
            Console.WriteLine(output);
        }
        
        private static char AsciiToChar(byte asciiIndex)
        {
            char ch = Convert.ToChar(asciiIndex);
            return ch;
        }
    }
}