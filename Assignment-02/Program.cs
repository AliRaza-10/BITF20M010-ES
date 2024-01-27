using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class Program
    {
        //<----------------------------TASK-1-------------------->
        static void func1()
        {
            string firstName = GetValidName("Enter your first name: ");
            string lastName = GetValidName("Enter your last name: ");

            string fullName = ConcatenateNames(firstName, lastName);

            Console.WriteLine($"Your full name is: {fullName}");
        }

        static string GetValidName(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                else if (ContainsDigits(input))
                {
                    Console.WriteLine("Name cannot contain digits.");
                }
                else
                {
                    return input;
                }

            } while (true);
        }

        static bool ContainsDigits(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        static string ConcatenateNames(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
        //<----------------------------TASK-2-------------------->
        static void func2()
        {
            try
            {
                string sentence = GetInput("Enter a sentence: ");
                DisplayLastFiveCharacters(sentence);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void DisplayLastFiveCharacters(string input)
        {
            try
            {
                if (input.Length >= 5)
                {
                    string last5Characters = input.Substring(input.Length - 5);
                    Console.WriteLine("Last 5 characters of your sentence are : " + last5Characters);
                }
                else
                {
                    throw new Exception("The input is too short to extract 5 characters.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while processing input: " + ex.Message);
            }
        }
        //<----------------------------TASK-3-------------------->
        static void func3()
        {
            try
            {
                double temperature = GetTemperature("Enter the current temperature in Celsius: ");
                string city = GetCity("Enter the name of your city: ");

                DisplayWeatherInfo(city, temperature);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static double GetTemperature(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double temperature))
                {
                    return temperature;
                }
                else
                {
                    Console.WriteLine("Invalid temperature input. Please enter a valid number.");
                }
            }
        }

        static string GetCity(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && !ContainsDigits(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid city name. Please enter a valid name without digits or empty spaces.");
                }
            }
        }
        static void DisplayWeatherInfo(string city, double temperature)
        {
            Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
        }
        //<----------------------------TASK-4-------------------->
        static void func4()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Elements of the array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        //<----------------------------TASK-5(a)-------------------->
        static void func5()
        {
            string[] fruits = { "Apple", "Banana", "Orange", "Grape", "Mango" };
            Console.WriteLine("---- TASK-5(a)------- ");
            PrintFruits(fruits);
        }

        static void PrintFruits(string[] fruits)
        {
            Console.WriteLine("List of fruits are :");

            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine(fruits[i]);
            }
            Console.WriteLine();
        }
        //<----------------------------TASK-5(b)-------------------->
        static void func6()
        {
            string[] colors = { "Red", "Blue", "Green", "Yellow" };
            Console.WriteLine("---- TASK-5(b)------- ");
            DisplayColors(colors);
        }
        static void DisplayColors(string[] colors)
        {
            Console.WriteLine("Names of colors are :");

            for (int i = 0; i < colors.Length; i++)
            {
                Console.Write(colors[i]);

                // Add a comma and space if not the last element
                if (i < colors.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }

        //<----------------------------TASK-6-------------------->
        static void func7()
        {
            int[] scores = { 8, 9, 1, 3, 5, 7, 2, 4, 6, 10 };

            Console.WriteLine("Test Scores:");
            DisplayScores(scores);

            int sum = CalculateSum(scores);
            Console.WriteLine($"Sum of test scores: {sum}");
        }

        static void DisplayScores(int[] scores)
        {
            foreach (int score in scores)
            {
                Console.Write(score + " ");
            }
            Console.WriteLine();
        }

        static int CalculateSum(int[] scores)
        {
            int sum = 0;
            int index = 0;

            do
            {
                sum += scores[index];
                index++;
            } while (index < scores.Length);

            return sum;
        }
        //<----------------------------TASK-7-------------------->
        static void func8()
        {
            int[] values = { 9, -1, 7, 5, 96, 66, 92, 99, 54 };

            int maxValue = FindMaxValue(values);

            Console.WriteLine($"The maximum value in the array is: {maxValue}");
        }

        static int FindMaxValue(int[] values)
        {
            if (values.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            int max = values[0];
            int index = 1;

            while (index < values.Length)
            {
                if (values[index] > max)
                {
                    max = values[index];
                }
                index++;
            }

            return max;
        }
        //<----------------------------TASK-8-------------------->
        static void func9()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            ReverseArray(numbers);
            Console.WriteLine("Reversed Array:");
            PrintArray(numbers);
        }

        static void ReverseArray(int[] numbers)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int temp = numbers[left];
                numbers[left] = numbers[right];
                numbers[right] = temp;

                left++;
                right--;
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        //<----------------------------TASK-9(a)-------------------->

        static void func10()
        {
            Console.WriteLine("---- TASK-9(a)------- ");
            int x = 42;
            object boxedValue = x;
            int y = (int)boxedValue;
            Console.WriteLine("Value of y is : " + y);
        }
        //<----------------------------TASK-9(b)-------------------->
        static void func11()
        {
            Console.WriteLine("---- TASK-9(b)------- ");
            double doubleValue = 3.14159;
            object boxedValue = doubleValue;
            double unboxedValue = (double)boxedValue;
            Console.WriteLine("UnboxedValue is : " + unboxedValue);
        }
        //<----------------------------TASK-10(a)-------------------->
        static void func12()
        {
            Console.WriteLine("---- TASK-10(a)------- ");
            int[] numbers = { 2, 5, 7, 10, 3 };
            Console.WriteLine("Orig Int\tSquared Value");
            foreach (int num in numbers)
            {
                object boxedValue = num;
                int unboxedValue = (int)boxedValue;
                int squaredValue = unboxedValue * unboxedValue;
                Console.WriteLine($"{unboxedValue}\t\t\t{squaredValue}");
            }
        }
        //<----------------------------TASK-10(b)-------------------->
        static void func13()
        {
            Console.WriteLine("---- TASK-10(b)------- ");
            List<object> mixedList = new List<object>();
            mixedList.Add(10);            // int
            mixedList.Add(3.14159);       // double
            mixedList.Add('A');           // char
            mixedList.Add("ALI");       // string
            mixedList.Add(true);          // bool
            Console.WriteLine("Elements in the List and their types:");
            Console.WriteLine("Values \t DataTypes");
            foreach (object item in mixedList)
            {
                Type itemType = item.GetType();
                Console.WriteLine($"{item}\t {itemType}");
            }
        }
        //<----------------------------TASK-11(a)-------------------->
        static void func14()
        {
            Console.WriteLine("---- TASK-11(a)------- ");
            dynamic myVariable = 42;
            Console.WriteLine($"myVariable (integer) is : {myVariable}");
            myVariable = "Hello, Dynamic!";
            Console.WriteLine($"myVariable (string) is : {myVariable}");
        }
        //<----------------------------TASK-11(b)-------------------->
        static void func15()
        {
            Console.WriteLine("---- TASK-11(b)------- ");
            dynamic myVariable2 = 42;
            Console.WriteLine($"Type of myVariable2 (integer) is : {myVariable2.GetType()}");
            myVariable2 = 3.14159;
            Console.WriteLine($"Type of myVariable2 (double) is : {myVariable2.GetType()}");
            myVariable2 = DateTime.Now;
            Console.WriteLine($"Type of myVariable2 (DateTime) is : {myVariable2.GetType()}");
            myVariable2 = "Hello, Dynamic!";
            Console.WriteLine($"Type of myVariable2 (string) is : {myVariable2.GetType()}");
        }

        static void Main()
        {
            int choice;

            do
            {
                Console.Write("Which Task do you want to run (1-11): ");
                choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= 11)
                {
                    switch (choice)
                    {
                        case 1:
                            func1();
                            break;
                        case 2:
                            func2();
                            break;
                        case 3:
                            func3();
                            break;
                        case 4:
                            func4();
                            break;
                        case 5:
                            func5();
                            func6();
                            break;
                        case 6:
                            func7();
                            break;
                        case 7:
                            func8();
                            break;
                        case 8:
                            func9();
                            break;
                        case 9:
                            func10();
                            func11();
                            break;
                        case 10:
                            func12();
                            func13();
                            break;
                        case 11:
                            func14();
                            func15();
                            break;
                        default:
                            Console.WriteLine("--------bye-----------");
                            break;
                    }
                }
                else if (choice < 1 || choice > 11)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 11.");
                }
            } while (choice >= 1 && choice <= 11);
        }
    }
}