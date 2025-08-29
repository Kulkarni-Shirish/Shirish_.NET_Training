using System;
namespace MultiplicationWithoutOperator
{
    //Program multiplies two integers  without using the * Operator.
    class ConsecutiveSumMultiplication
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first Integer1:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter the second Integer2:");
            int secondNumber = int.Parse(Console.ReadLine());   
            int product = MultiplyUsingAddition(firstNumber, secondNumber); 
            Console.WriteLine($"The multiplication of {firstNumber} and {secondNumber} is: {product}");
        }
        //Multiplies two integers by performing consecutive addition.
        static int MultiplyUsingAddition(int multiplicand, int multiplier)
        {
            int result = 0;
            bool isNegative = false; 
            //Handle Negative Values
            if (multiplicand < 0 && multiplier >=0)
            {
                multiplicand = -multiplicand;
                isNegative = true;
            }
            else if (multiplicand < 0 && multiplier >= 0)
            {
                multiplier = -multiplier;
                isNegative = true;
            }
            else if ( multiplicand < 0 && multiplier < 0)
            {
                multiplicand = -multiplicand;
                multiplier = -multiplier;
            }
            //Perform Multiplication through repeated addition
            for (int i = 0; i < multiplier; i++)
            {
                result += multiplicand;
            }
            return isNegative ? -result : result;
        }
    }
}