using System;


    class Program
    {
        // Function to check whether given text is a number
        static bool IsNumber(string input)
        {
            // TryParse checks if the string can be converted to a number (int in this case)
            int number;
            return int.TryParse(input, out number);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a value: ");
            string userInput = Console.ReadLine();  // take input as text

            // Call the IsNumber function
            if (IsNumber(userInput))
            {
                Console.WriteLine($"'{userInput}' is a valid number.");
            }
            else
            {
                Console.WriteLine($"'{userInput}' is NOT a number.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
