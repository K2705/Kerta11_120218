using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Teht2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\K2705\nimet.txt";
            if (File.Exists(path))
            {

                try
                {
                    // get the list of names
                    string[] lines = File.ReadAllLines(path);
                    
                    // use it to make a dictionary of every unique name and its count in the list
                    Dictionary<string, int> names = new Dictionary<string, int>();
                    foreach (string name in lines)
                    {
                        if (!names.ContainsKey(name))
                        {
                            names.Add(name, 1);
                        }
                        else
                        {
                            names[name]++;
                        }
                    }

                    // print, ordered by name
                    foreach (KeyValuePair<string, int> name in names.OrderBy(name => name.Key))
                    {
                        Console.WriteLine("Name {0} was found {1} times.", name.Key, name.Value);
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
            } else
            {
                //the file doesn't exist
                Console.WriteLine("File " + path + " not found");
            }
        }
    }
}
