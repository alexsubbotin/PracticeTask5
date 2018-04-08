using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask5
{
    class Program
    {
        // Task: n>=2, there is a matrix nxn of numbers. 
        //       Create a sequence b1,b2,b3... of 0s and 1s. bi = 1 only if numbers in i string of matrix create an increasing or decreasing sequence.
        // Student: Alexey Subbotin. Group: SE-17-1.
        static void Main(string[] args)
        {
            int n;

            // Getting the n.
            bool ok;
            do
            {
                Console.Write("Enter the n: ");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok || n < 2)
                    Console.WriteLine("Input error! Perhaps you didn't enter a natural number greater (or equal) than 2");
            } while (!ok || n < 2);

            // Creating the matrix.
            int[,] matrix = new int[n, n];

            // Creating the sequence.
            bool[] b = new bool[n];

            // Random number generator.
            Random rnd = new Random();

            Console.WriteLine("Created matrix:");
            // Filling the matrix with random values, checking for incresing or decreasing, printing.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Indicicates whether it's an increasing sequence or not.
                bool inc = true;
                // Indicicates whether it's a decreasing sequence or not.
                bool dec = true;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Assigning a random value.
                    matrix[i, j] = rnd.Next(-100, 101);
                    //matrix[i, j] = Convert.ToInt32(Console.ReadLine());

                    // If it's not the 1st element in a string.
                    if (j > 0)
                    {
                        // If current is greater than previous then it's not a decreasing one for sure.
                        if (matrix[i, j] > matrix[i, j - 1])
                            dec = false;

                        // If current is less than previous then it's not an increasing one for sure.
                        if (matrix[i, j] < matrix[i, j - 1])
                            inc = false;
                    }

                    // Printing a matrix element.
                    Console.Write(matrix[i, j] + " ");
                }

                // Assigning the value of 0 or 1.
                b[i] = inc ^ dec;

                Console.WriteLine();
            }

            // Printing the sequence.
            Console.Write("The sequence: ");
            for(int i = 0; i < b.Length; i++)
            {
                if (b[i])
                    Console.Write(1 + " ");
                else
                    Console.Write(0 + " ");
            }

            Console.ReadLine();
        }
    }
}
