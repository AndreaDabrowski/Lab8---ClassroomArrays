using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static int userInputRow;
        static string response, studentHometown, studentName, studentFavoriteFood;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the C# .NET Class! ");
            do
            {
                //prompts user to enter student ID number
                Console.Write("Which student would you like to learn about? (enter a number 1-19): ");

                //the ID number correlates with the row of the 2D array, format and length verified via methods
                userInputRow = VerifyFormat(Console.ReadLine());

                //student ID and name displayed to user
                studentName = GetClassroomInformation(userInputRow, 1);
                Console.WriteLine("That student #{0} is {1}.", userInputRow, studentName);

                //method displays hometown and favorite food to user
                VerifyAndReturnDetails(userInputRow);

                //verifies if user would like to try again
                Console.Write("Would you like to learn about another student? (y/n): ");
                response = Console.ReadLine();

            }
            while (YesOrNo(response));
            Console.WriteLine("Goodbye!");
            Console.ReadLine();

        }
        //accesses each student's information with a 2D array
        public static string GetClassroomInformation(int row, int column)
        {
            string infoArray;

            string[,] classroomInformation = new string[19, 4]
            {
                    { "1", "Steve", "Royal Oak", "Goldfish" },
                    { "2","Sean O", "Flint", "Steak"},
                    { "3", "Evan", "Farm", "Juniper Berries"},
                    { "4","Heather", "East Point", "Cranberries"},
                    { "5","Tony","Georgia", "Potato salad"},
                    { "6","Johnathan","Warren", "Hot Tacos"},
                    { "7","Camille","Germany","Hot Pockets"},
                    { "8","Jacky","Rochester", "Cheetos"},
                    { "9","Rudy", "Detroit", "Water"},
                    { "10","Clayton","Indiana","Diet Coke"},
                    { "11","Mauricio","Grand Rapids", "Green Beans"},
                    { "12","Levi","Seattle", "Pizza"},
                    { "13","Nick","Washington D.C.", "Olive taco"},
                    { "14", "Katie","Ferndale", "Crock Pot Chili"},
                    { "15", "David","Bawston", "Planters peanut packs"},
                    { "16","Mace","New York", "Nothing made in other people's kitchens"},
                    { "17","Ty","Oxford","Green grapes, but not red grapes"},
                    { "18","Dan","Key west", "fried peas"},
                    { "19","Cheri","the UP","oranges"} };

            infoArray = classroomInformation[row - 1, column];
            return infoArray;
        }

        //determines action (bool) based on y/n reponse from user
        public static bool YesOrNo(string response)
        {
            while (true)
            {
                if (response == "y")
                {
                    return true;
                }
                else if (response == "n")
                {
                    Console.WriteLine("Okay...");
                    return false;
                }
                else
                {
                    Console.Write("Invalid input, try (y/n): ");
                    response = Console.ReadLine().ToLower();
                }
            }

        }
        //both verifies the format (handles the format exception) and that the user input integer is within the specified range
        public static int VerifyFormat(string input)
        {
            while (true)
            {
                try
                {
                    userInputRow = int.Parse(input);
                    if (VerifyRange(userInputRow))
                    {
                        
                        return userInputRow;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Range: Input Valid number: ");

                    }
                }
                catch (FormatException)
                {
                    if (input is string)
                    {
                        Console.Write("Invalid Format: Input valid number (1-19): ");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        return int.Parse(input);
                    }
                }
            }
        }
        public static bool VerifyRange(int input)
        {
            do
            {
                try
                {
                   if (input <= 19 && input > 0)
                   {
                    return true;
                   }
                   else
                    {
                        Console.Write("Number is not within the correct range, Try again (1-19): ");
                        input = int.Parse(Console.ReadLine());
                        return false;
                    }
                    
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("Number is not within the correct range, Try again (1-19): ");
                    return false;
                }

            }
            while (!VerifyRange(input));
        }

        //method verifies hometown or favorite food input, and displays this information to user
        public static void VerifyAndReturnDetails(int userInputRow)
        {
            string details;
            do
            {
                Console.WriteLine("What would you like to learn about {0}? (hometown or favorite food): ", GetClassroomInformation(userInputRow, 1));
                details = Console.ReadLine();
                if (details.ToLower() == "hometown")
                {
                    studentHometown = GetClassroomInformation(userInputRow, 2);
                    Console.WriteLine("{0}'s hometown is {1}", studentName, studentHometown);
                    Console.WriteLine("Would you like to learn something else about {0}? (y/n)", GetClassroomInformation(userInputRow, 1));
                    response = Console.ReadLine();
                }
                else if (details.ToLower() == "favorite food")
                {
                    studentFavoriteFood = GetClassroomInformation(userInputRow, 3);
                    Console.WriteLine("{0}'s favorite food is {1}", studentName, studentFavoriteFood);
                    Console.WriteLine("Would you like to learn something else about {0}? (y/n)", GetClassroomInformation(userInputRow, 1));
                    response = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("That data does not exist. Try again? (y/n): ");
                    details = Console.ReadLine();
                }
                
            }
            while (YesOrNo(response));
        }
    }
}
