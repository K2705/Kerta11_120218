using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Test
    {
        //define a delegate		
        public delegate int CalcHandler(int x, int y);

        //test using a delegate
        static void Main(string[] args)
        {
            MyMath math = new MyMath();
            //create a new instance of the delegate class
            CalcHandler sumHandler = new CalcHandler(math.Sum);
            //invoke the delegate
            int result = sumHandler(4, 2);
            Console.WriteLine("Result is: " + result);
            //change the method and invoke again
            sumHandler = new CalcHandler(math.FakeSum);
            Console.WriteLine("Result is now: " + sumHandler(4, 2));
        }
    }

    public class MyMath
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
        public int FakeSum(int x, int y)
        {
            return int.Parse(x.ToString() + y.ToString());
        }

    }
}
