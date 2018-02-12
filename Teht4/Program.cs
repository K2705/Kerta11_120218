using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IFormattable> doubles = new List<IFormattable>();
            List<IFormattable> ints = new List<IFormattable>();
            while (true)
            {
                Console.Write("gib number   ");
                string input = Console.ReadLine();
                if (input == "") break;
                if (input.Contains(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    // it's a float
                    double d;
                    if (!double.TryParse(input, out d)) break;
                    doubles.Add(d);
                }
                else
                {
                    // it's an int
                    int i;
                    if (!int.TryParse(input, out i)) break;
                    ints.Add(i);
                }
            }


            Console.WriteLine("\nIntegers:");
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nFloats:");
            foreach (double d in doubles)
            {
                Console.WriteLine(d);
            }

            Save(ints, "integers.txt");
            Save(doubles, "floats.txt");

            

        }

        private static void Save(List<IFormattable> numbers, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (IFormattable line in numbers)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Path invalid:\n" + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Input/Output error:\n" + e.Message);
            }
            catch (SystemException e)
            {
                Console.WriteLine("Operation not permitted:\n" + e.Message);
            }
        }

    }
}
