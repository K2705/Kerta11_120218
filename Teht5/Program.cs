using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Teht5
{
    class Program
    {
        static void Main(string[] args)
        {

            List<TVProgram> programs = new List<TVProgram>();

            DateTime time = new DateTime(2017, 12, 25, 6, 0, 0);
            DateTime end = new DateTime(2017, 12, 25, 19, 45, 0);
            while (time < end)
            {
                programs.Add(new TVProgram("Teen Titans Go!", "Cartoon Network", time, time = time.AddMinutes(15), "Teen Titans Go!"));
            }

            //Save into a file
            try
            {
                using (Stream stream = File.Open("data.dat", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, programs);
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

            //Wipe the programs
            programs = null;

            //Load from file
            try
            {
                using (Stream stream = File.Open("data.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    programs = (List<TVProgram>)formatter.Deserialize(stream);
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


            foreach (TVProgram prog in programs)
            {
                Console.WriteLine(prog);
            }
        }

    }
}
