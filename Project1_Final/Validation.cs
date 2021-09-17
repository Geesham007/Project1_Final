using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    public static class Validation
    {


        public static int verifyValue(List<string> ListOfValues)
        {
            int valueChosen;
            Console.WriteLine("\nChoose one choices:");
            for (int i = 0; i < ListOfValues.Count; i++)
                Console.WriteLine($"{i + 1}. {ListOfValues[i]}");
            Console.WriteLine("-1: Exit/Go Back");


            var boolValue = int.TryParse(Console.ReadLine(), out valueChosen);
            //Console.WriteLine($"Value is{ListOfValues.Count}");


            while (!boolValue || ((ListOfValues.Count) < valueChosen) || valueChosen < -1)
            {
                Console.WriteLine("\nWrong Output");

                Console.WriteLine("Choose 1 between the following;");
                for (int i = 0; i < ListOfValues.Count; i++)
                    Console.WriteLine($"{i + 1}. {ListOfValues[i]}");
                Console.WriteLine("-1: Exit/Go Back");

                boolValue = int.TryParse(Console.ReadLine(), out valueChosen);

            }
            return valueChosen;
        }

        public static string VerifyInteger(string x)
        {
            int valueChosen;
            bool boolValue = int.TryParse(x, out valueChosen);
            while (!boolValue)
            {
                Console.WriteLine("\nWrong Output");

                Console.WriteLine("Choose an integer value;");

                x = Console.ReadLine();
                boolValue = int.TryParse(x, out valueChosen);


            }

            return x;
        }

        public static int updateValidation(List<string> ListOfValues)
        {
            int valueChosen;
            Console.WriteLine("\nChoose one choices:");
            for (int i = 0; i < ListOfValues.Count; i++)
                Console.WriteLine($"{i}. {ListOfValues[i]}");


            var boolValue = int.TryParse(Console.ReadLine(), out valueChosen);
            //Console.WriteLine($"Value is{ListOfValues.Count}");


            while (!boolValue || ((ListOfValues.Count) <= valueChosen))
            {
                Console.WriteLine("\nWrong Output");

                Console.WriteLine("Choose 1 between the following;");
                for (int i = 0; i < ListOfValues.Count; i++)
                    Console.WriteLine($"{i}. {ListOfValues[i]}");

                boolValue = int.TryParse(Console.ReadLine(), out valueChosen);

            }
            return valueChosen;
        }

        public static string VerifyNullString(string x)
        {
            while (x.Length == 0)
            {
                Console.WriteLine("\nWrong Output");

                Console.WriteLine("Input a string;");

                x = Console.ReadLine();

            }

            return x;
        }

    }
}
