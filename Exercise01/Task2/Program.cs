using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer;
            long maxLong = long.MaxValue;

            try
            {
                integer = checked((int)maxLong);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow Exception: {0}", e);
            }

            Console.Read();
        }
    }
}
