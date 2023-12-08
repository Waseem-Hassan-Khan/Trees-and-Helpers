using HRAdministrationAPI;
using Trees.Abstraction;
using Trees.Delegates;
using Trees.HRAdministrationAPI;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Change Program2 to Program to make it run
class Program2
{
    public delegate void logDel(string message);
    static void Main2()
    {
        Log obj = new Log();
        logDel instanceMethod, staticMethod;

        //static method in delegate
        staticMethod = new logDel(Log.logtextToFile);

        // for instacne method we can create an instance of the class to call a method to assign it to delegate
        instanceMethod = new logDel(obj.logMessage);

        logDel multiLogDel = staticMethod + instanceMethod;
        Console.WriteLine("Enter a message.");
        var name = Console.ReadLine();

        Log.logDelegate(multiLogDel, name); //Passing delegate as a parameter in a function

        Console.ReadKey();
    }

    public class Log
    {
        public static void logDelegate(logDel logDel, string name)
        {
            logDel(name);
        }

        public void logMessage(string message)
        {
            Console.WriteLine($"{DateTime.Now.Date}: {message}");
        }

        public static void logtextToFile(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now.Date}: {message}");
            }
        }
    }


    /* 
     * Delegates:
     * Delegate is a type safe function() pointer.
     * A delegate is a refrence type variable that holds a refrence to a method.
     * In order to enable delegate to refrence a function  it must fullfill few requirments.
     * ---- It must have the same return type as the function (or a compatible return type).
     * ---- The delegate must have the same parameter types and the same number of parameters as the function it is referencing.
     *
     * When a delegate is instanciated it can be associated to any function which fullfills the above mentioned requirments.
     * The delegate can be instanciated by creating its instance.
     * A delegate can also refer to static methods
     * 
     * A delegate can be passed as a parameter to the method and called with in that method.
     * Delegates can be used for asynchronus callbacks and event handling in C#.
     */

}
