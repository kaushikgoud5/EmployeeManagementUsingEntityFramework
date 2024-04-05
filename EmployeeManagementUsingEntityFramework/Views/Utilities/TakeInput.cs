using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUsingEntityFramework.Views.Utilities
{
    public class TakeInput
    {
        public static string ValidateInput(string prompt, Func<string, bool> isValidPattern)
        {
            Console.Write($"Enter {prompt}:");
            string input = Console.ReadLine();
            while (!isValidPattern(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid {prompt}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Enter {prompt}:");
                input = Console.ReadLine();
            }
            return input;

        }
        public static DateTime? ValidateDateInput(string prompt)
        {
            while (true) {

                DateTime date;
            Console.Write($"Enter {prompt}:");
           string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { return null; }
                while (!DateTime.TryParseExact(input, "d/M/yyyy", null, System.Globalization.DateTimeStyles.None, out  date))
                {
                    if (string.IsNullOrWhiteSpace(input)) { return null; }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid {prompt}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Enter {prompt}:");
                    input = Console.ReadLine();
                }

            return date;
            }
            
        }
        public static DateTime? ValidateJoinDateInput(string prompt)
        {
            while (true)
            {
                DateTime date;
                Console.Write($"Enter {prompt}:");
                string input = Console.ReadLine();
              
                while (!DateTime.TryParseExact(input, "d/M/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid {prompt}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Enter {prompt}:");
                    input = Console.ReadLine();
                }

                return date;
            }

        }
        public static long? ValidateMobileInput(string prompt)
        {
            while(true)
            {
            long mobile;
            Console.Write($"{prompt}:");
            string input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input)) { return null; }
            while (!long.TryParse(input, out mobile) || mobile.ToString().Length != 10)
            {
                    if (string.IsNullOrWhiteSpace(input)) { return null; }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid {prompt}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{prompt}:");
                    input = Console.ReadLine();
            }

            return mobile;
            }
           
        }
        public static string SelectFromMenu(string prompt, List<string> options)
        {
            int choice = 0;
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.Write("Choose an option:");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > options.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please choose an option from the menu.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Choose an option:");
            }

            return options[choice - 1];
        }
    }
}
