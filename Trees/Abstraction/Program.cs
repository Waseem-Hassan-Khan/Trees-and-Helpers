//using Trees;
//using Trees.Abstraction;
//using Trees.BinaryTree;

//class Program
//{
//    static void Main()
//    {
//        UserAuth user = new UserAuth();
//        string message;
//        string token;


//        while (true)
//        {
//            Console.WriteLine("1. Register");
//            Console.WriteLine("2. Login");
//            Console.WriteLine("3. Exit");

//            string choice = Console.ReadLine();

//            switch (choice)
//            {
//                case "1":

//                    Console.Write("Enter your name: ");
//                    string userName = Console.ReadLine();

//                    Console.Write("Enter your age: ");
//                    string age = Console.ReadLine();
//                    if (string.IsNullOrWhiteSpace(age))
//                    {
//                        age = "0";
//                    }
//                    int convertedAge = Convert.ToInt32(age);

//                    Console.Write("Enter your password: ");
//                    string password = Console.ReadLine();

//                    user.register(userName, convertedAge, password, out message);
//                    Console.WriteLine(message);
//                    break;
//                case "2":
//                    Console.Write("Enter your name: ");
//                    string name = Console.ReadLine();

//                    Console.Write("Enter your password: ");
//                    string pswd = Console.ReadLine();

//                    user.authenticate(name,pswd,out token,out message);
//                    Console.WriteLine($"{token}\n{message}");
//                    break;
//                case "3":
//                    Environment.Exit(0);
//                    break;
//                default:
//                    Console.WriteLine("Invalid choice. Please try again.");
//                    break;
//            }
//        }
//    }

//}
