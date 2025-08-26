using System;
class Task5_EvenNumbersArray
{
    static void Main()
    {
        //Declare Array to store 10 Integers
        int[] numbers = new int[10];
        Console.WriteLine("Enter 10 Integers:");
        //Loop to take 10 integer inputs from user
        for(int i = 0; i < 10; i++)
        {
            Console.Write($"Number {i + 1}:"); //Ask user for each number
            numbers[i] = Convert.ToInt32(Console.ReadLine()); //Store input in array
        }
        Console.WriteLine("\n Even numbers are:");
        //Loop through the array and check each number
        foreach(int num in numbers)
        {
            //If the number is divisible by 2,its even
            if(num %2 ==0)
            {
                Console.WriteLine(num);
            }
        }
    }
}