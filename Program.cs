using System;
using System.Collections.Generic;

namespace CheckTheEmail
{
    class Data
    {
        public static string StringOfEmail = "mrfraycop@mail.ru";

        public static List<string> PartOfTheEmail = new List<string>();

        public static bool TrueAnswer;
    }
    class Program
    {
        static void Main(string[] args)
        {
            do 
            {
                Console.WriteLine("Ввведите мыло");

                Data.StringOfEmail = Console.ReadLine();

                CheckingForErrors.PresenceOfMainCharacters();

            } while (Data.TrueAnswer != true);

        }
    }
    public class CheckingForErrors
    {
        public static void PresenceOfMainCharacters()
        {
            if(Data.StringOfEmail.Contains('@') == false || Data.StringOfEmail.Contains('.') == false)
                Console.WriteLine("Некоректный ввод");
            else
            {
                Data.PartOfTheEmail.AddRange(Data.StringOfEmail.Split(new char[] { '@', '.' }));

                Console.WriteLine(Data.PartOfTheEmail.Count);

                CheckingForErrors.AvailabilityOfAllMainParts();
            }
        }
        private static void AvailabilityOfAllMainParts()
        {
            int ChanceFalse = 0;

            if (Data.PartOfTheEmail.Count!=3)
                Console.WriteLine("Невверный вод");
            else
            {
                foreach (var i in Data.PartOfTheEmail)
                {
                    if (CheckingForErrors.SearchForExtraCharacters(i.ToLower()) == false)
                    {
                        Console.WriteLine("Неверный ввод");

                        ChanceFalse++;

                        break;
                    }
                    
                }

            }

            if (ChanceFalse == 0 )
            {
                Console.WriteLine("Ввод верный");

                Data.TrueAnswer = true;
            }

        }
        private static bool SearchForExtraCharacters(string part)
        {
            foreach(var i in part)
            {
                if (i < 'a' || i > 'z')
                {
                    if (i < '0' || i > '9')
                    {
                        Console.WriteLine("Неверный ввод");
                        return false;
                    }
                }
                
            }
            return true;
        }
    }
}
