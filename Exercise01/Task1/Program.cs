using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            string strNum1, strNum2;
            int num1 = 0, num2 = 0;

            int intResult = 0;
            double dblResult = 0;

            bool inputsValid = false;

            while (!inputsValid)
            {
                Console.Write("Enter first number (between {0} and {1}) : ", int.MinValue, int.MaxValue);
                strNum1 = Console.ReadLine();
                Console.Write("Enter second number (between {0} and {1}) : ", int.MinValue, int.MaxValue);
                strNum2 = Console.ReadLine();

                try
                {
                    num1 = int.Parse(strNum1);
                    num2 = int.Parse(strNum2);

                    intResult = num1 / num2;
                    dblResult = (double)num1 / num2;

                    inputsValid = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("String can't be null.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad format.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow.");
                } 
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Can't divide with zero");
                }
            }


            Console.WriteLine("Currency:\t {0} / {1} = {2:c}", num1, num2, dblResult);
            Console.WriteLine("Integer:\t {0} / {1} = {2}", num1, num2, intResult);
            Console.WriteLine("Scientific:\t {0} / {1} = {2:e}", num1, num2, dblResult);
            Console.WriteLine("Fixed-point:\t {0} / {1} = {2:f}", num1, num2, dblResult);
            Console.WriteLine("General:\t {0} / {1} = {2:g}", num1, num2, dblResult);
            Console.WriteLine("Number:\t\t {0} / {1} = {2:n}", num1, num2, dblResult);
            Console.WriteLine("Hexadecimal:\t {0} / {1} = {2:x}", num1, num2, intResult);

            Console.WriteLine("\nPress any key to exit...");
            Console.Read();
        }
    }
}
