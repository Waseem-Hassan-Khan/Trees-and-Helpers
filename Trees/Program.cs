using Trees.Abstraction;
using Trees.Delegates;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        Delegates obj = new Delegates();
        Delegates.testDelegateFunc?.Invoke();
    }

}
