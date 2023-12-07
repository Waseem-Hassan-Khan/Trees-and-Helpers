using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Delegates
{
    public delegate void TestDelegate();
    public class Delegates
    {
        public static TestDelegate testDelegateFunc;

        public Delegates()
        {
            testDelegateFunc = functionOne;
            testDelegateFunc += functionTwo;
        }

        public void functionOne()
        {
            Console.WriteLine("My first test delegate function");
        }

        public void functionTwo()
        {
            Console.WriteLine("My second test delegate function");
        }
    }
}
