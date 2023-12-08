using HRAdministrationAPI;
using Trees.Abstraction;
using Trees.Delegates;
using Trees.HRAdministrationAPI;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program3
{

    /*
     * Explaining Covariance
     * 
     * Imagine you have a fruit basket (a method or delegate) that is supposed to give you some
     * fruits (return a value). You know that it always gives you fruits, but you don't know exactly
     * which type of fruit you'll get.

     * Now, let's introduce covariance. Covariance is like saying, "Even though the basket always gives
     * fruits, I'll accept a basket that gives a more specific type of fruit without any problem."
     * 
     */

    //Covariance delegate examples
    delegate Car CarFactoryDelegate(int Id, string Name);

    //Contravariance delegate examples
    delegate void LogEVCarDetails(Car car);
    delegate void LogICECarDetails(Car car);
    static void Main3()
    {
        CarFactoryDelegate carfactory = CarFactory.returnICECar;
        Car iceCar = carfactory(1, "Ferrari");

        carfactory = CarFactory.returnEVCar;
        Car evCar = carfactory(2, "Tesla");


        // Used for Contravariance
        LogEVCarDetails EVCar = LogCarDetails;
        EVCar(evCar as EVCar);

        LogICECarDetails ICECar = LogCarDetails;
        ICECar(iceCar as ICECar);


        // Used for CoVariance
        //Console.WriteLine($"Object Type: {iceCar.GetType()}");
        //Console.WriteLine($"Car Details: {iceCar.getCarDetails()} \n");


        //Console.WriteLine($"Object Type: {evCar.GetType()}");
        //Console.WriteLine($"Car Details: {evCar.getCarDetails()}");
    }

    static void LogCarDetails(Car car)
    {
        if (car is ICECar)
        {
            using (StreamWriter sw = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDetail.txt"), true))
            {
                sw.WriteLine($"Object Type: {car.GetType()}");
                sw.WriteLine($"Car Details: {car.getCarDetails()} \n");
            }
        }
        else if (car is EVCar)
        {
            Console.WriteLine($"Object Type: {car.GetType()}");
            Console.WriteLine($"Car Details: {car.getCarDetails()}");
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string getCarDetails()
        {
            return $"{Id} : {Name}";
        }
    }

    public class ICECar : Car
    {
        public override string getCarDetails()
        {
            return $"{base.getCarDetails()} - Internal combustion engine.";
        }
    }

    public class EVCar : Car
    {
        public override string getCarDetails()
        {
            return $"{base.getCarDetails()} - Electric.";
        }
    }


    public static class CarFactory
    {
        public static ICECar returnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }

        public static EVCar returnEVCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }
}
