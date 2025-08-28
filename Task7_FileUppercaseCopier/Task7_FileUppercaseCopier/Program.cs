using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string sourceFile = "input.txt"; //Source File Path
        string destinationFile = "output.txt";
        try
        {
            //check if source File Exist or Not
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Source file not Found");
                return;
            }
            //Read all lines from source file
            string[] lines = File.ReadAllLines(sourceFile);
            //Convert each line to uppercase
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].ToUpper();
            }
            //Write the modified lines to destination file
            File.WriteAllLines(destinationFile, lines);
            Console.WriteLine($"File copied successfully to '{destinationFile}' with uppercase letter.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured: " + ex.Message);
        }
    }
}