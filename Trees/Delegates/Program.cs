using HRAdministrationAPI;
using Trees.Abstraction;
using Trees.Delegates;
using Trees.HRAdministrationAPI;
using static System.Runtime.InteropServices.JavaScript.JSType;

class ProgramTemp
{
    static void MainTemp()
    {
        Delegates obj = new Delegates();
        Delegates.testDelegateFunc?.Invoke();
    }
}
