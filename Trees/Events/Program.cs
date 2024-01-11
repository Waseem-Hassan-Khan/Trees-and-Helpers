using System;

  
/* 
 * Events in C#
 * A mechanism for communication between objects
 * Used to build loosley coupled application.
 * Helps extending application.
 */
class ProgramEvents
{
    private event EventHandler onSpacePressed;

    private void EventSubscribers()
    {
        onSpacePressed += subscriberOne;
        onSpacePressed += subscriberTwo;
        onSpacePressed += subscriberThree;
    }

    public void InvokeEvent()
    {
        EventSubscribers();
        onSpacePressed?.Invoke(this, EventArgs.Empty);
    }

    private void subscriberOne(object sender, EventArgs args)
    {
        Console.WriteLine("First Subscriber");
    }

    private void subscriberTwo(object sender, EventArgs args)
    {
        Console.WriteLine("Second Subscriber");
    }

    private void subscriberThree(object sender, EventArgs args)
    {
        Console.WriteLine("Third Subscriber");
    }

    static void Main()
    {
        Program obj = new Program();
        obj.InvokeEvent();
        Console.ReadLine();
    }
}

