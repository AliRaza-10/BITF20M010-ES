#pragma warning disable CS8600 // Converting null literal or null value to non-nullable type
#pragma warning disable CS8603 
class Program
{
    //<------------Task1(a)-------------->
    static void Func1()
    {
        Greet();
        Greet("Hello", "Ali");
    }
    static void Greet(string greeting = "Hello", string name = "World")
    {
        Console.WriteLine($"{greeting}, {name}!");
    }
    //<------------Task1(b)-------------->
    static void Func2()
    {
        double defaultAreaOfRectangle = CalculateArea();
        Console.WriteLine($"Default Area Of Rectangle  is : {defaultAreaOfRectangle}");
        double areaOfRectangle = CalculateArea(10.5, 6.9);
        Console.WriteLine($"Area Of Rectangle is : {areaOfRectangle}");
    }
    static double CalculateArea(double length = 1.0, double width = 1.0)
    {
        return length * width;
    }
    //<------------Task1(c)-------------->
    static void Func3()
    {
        int sumOfTwoNumbers = AddNumbers(10, 10);
        Console.WriteLine($"Sum of two numbers are : {sumOfTwoNumbers}");

        int sumOfThreeNumbers = AddNumbers(10, 10, 10);
        Console.WriteLine($"Sum of three numbers are : {sumOfThreeNumbers}");
    }

    static int AddNumbers(int num1, int num2)
    {
        return num1 + num2;
    }

    static int AddNumbers(int num1, int num2, int num3 = 0)
    {
        return num1 + num2 + num3;
    }
    //<------------Task1(d)-------------->
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public Book(string title, string author = "Unknown")
        {
            Title = title;
            Author = author;
        }
    }
    static void Func4()
    {
        Book book1 = new Book("Web Development");
        Book book2 = new Book("Enterprise Systems", "Ali");
        Console.WriteLine($"Book 1: Title is {book1.Title} and  Author is {book1.Author}");
        Console.WriteLine($"Book 2: Title is {book2.Title} and Author is {book2.Author}");
    }
    //<------------Task2(a)-------------->
    class MyList<T>
    {
        private List<T> elements = new List<T>();
        public void Add(T item)
        {
            elements.Add(item);
        }
        public bool Remove(T item)
        {
            return elements.Remove(item);
        }
        public void Display()
        {
            foreach (T item in elements)
            {
                Console.WriteLine(item);
            }
        }
    }

    static void Func5()
    {
        // Create a MyList for integers
        MyList<int> intList = new MyList<int>();
        intList.Add(10);
        intList.Add(20);
        Console.WriteLine("Integer List:");
        intList.Display();
        Console.WriteLine("-----------------");
        // Create a MyList for strings
        MyList<string> stringList = new MyList<string>();
        stringList.Add("Peach");
        stringList.Add("Orange");
        Console.WriteLine("String List:");
        stringList.Display();
        Console.WriteLine("-----------------");
        // Create a MyList for doubles
        MyList<double> doubleList = new MyList<double>();
        doubleList.Add(3.35);
        doubleList.Add(3.40);
        Console.WriteLine("Double List:");
        doubleList.Display();
        Console.WriteLine("-----------------");
        // Create a MyList for floats
        MyList<float> floatList = new MyList<float>();
        floatList.Add(12.24f);
        floatList.Add(5.648f);
        Console.WriteLine("Float List:");
        floatList.Display();
        Console.WriteLine("-----------------");
        // Create a MyList for characters
        MyList<char> charList = new MyList<char>();
        charList.Add('A');
        charList.Add('L');
        Console.WriteLine("Character List:");
        charList.Display();
        Console.WriteLine("-----------------");
        // Remove an element from the Integer List
        intList.Remove(20);
        Console.WriteLine("\nInteger List after removing '20':");
        intList.Display();
        Console.WriteLine("-----------------");
        // Remove an element from the String List
        stringList.Remove("Peach");
        Console.WriteLine("String List after removing 'Peach':");
        stringList.Display();
        Console.WriteLine("-----------------");
        // Remove an element from the Double List
        doubleList.Remove(3.35);
        Console.WriteLine("Double List after removing '3.35':");
        doubleList.Display();
        Console.WriteLine("-----------------");
        // Remove an element from the Float List
        floatList.Remove(5.648f);
        Console.WriteLine("Float List after removing '5.648f':");
        floatList.Display();
        Console.WriteLine("-----------------");
        // Remove an element from the Character List
        charList.Remove('L');
        Console.WriteLine("Char List after removing 'L':");
        charList.Display();
    }
    //<------------Task2(b)-------------->
    static void Func6()
    {
        int num1 = 10;
        int num2 = 99;
        Console.WriteLine($"Before Swapping Values are  a = {num1} and  b = {num2}");
        Swap(ref num1, ref num2);
        Console.WriteLine($"After swapping Values are  a = {num1} and  b = {num2}\n");

        string str1 = "Ali";
        string str2 = "Raza";
        Console.WriteLine($"Before Swapping Values are str1 = {str1}, str2 = {str2}");
        Swap(ref str1, ref str2);
        Console.WriteLine($"After Swapping Values are str1 = {str1}, str2 = {str2}");
    }

    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    //<------------Task2(c)-------------->
static void Func7()
    {
        int[] integerArray = { 1, 3, 10, 12, 5 };
        long[] longArray = { 100L, 200L, 300L };
        double[] doubleArray = { 1.523, 2.512, 3.153 };
        //string [] stringArray = {"ali", "raza"};

        int intSum = calculateSum.Sum(integerArray);
        long longSum = calculateSum.Sum(longArray);
        double doubleSum = calculateSum.Sum(doubleArray);
        //string stringSum = calculateSum.Sum(stringArray); //Compilation error bcz string does not support addition

        Console.WriteLine($"Sum of integer Array: {intSum}");
        Console.WriteLine($"Sum of long Array: {longSum}");
        Console.WriteLine($"Sum of double Array: {doubleSum}");
        //Console.WriteLine($"Sum of string Array: {stringSum}");
    }
public class calculateSum
{
    public static T Sum<T>(T[] array) where T : struct
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length == 0)
        {
            throw new ArgumentException("Array must not be empty.");
        }

        dynamic sum = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            sum += array[i];
        }
        
        return sum;
    }
}

    //<------------Task2(d)-------------->
    static void AddStudent(Dictionary<int, string> student)
    {
        int id = 1;

        while (true)
        {
            Console.WriteLine("Enter Student Name : ");
            string? name = Console.ReadLine();
            string? choice;
            try
            {
                if (name == "")
                {
                    throw new Exception("Name cannot be null");
                }
                student.Add(id, name!); // Use ! to assert non-null

                Console.WriteLine("Do you want to add more names? (y/n)");
                choice = Console.ReadLine();

                if (choice != "y")
                {
                    break;
                }

                id++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    static void DisplayStudent(Dictionary<int, string> Student)
    {
        foreach (var student in Student)
        {
            Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value}");
        }
    }
    static void SearchStudentById(Dictionary<int, string> Student)
    {
        Console.Write("Enter Student ID : ");
        int studentId = Convert.ToInt32(Console.ReadLine());
        if (Student.ContainsKey(studentId!))
        {
            Console.WriteLine($"Student ID: {studentId}, Name: {Student[studentId!]}");
        }
        else
        {
            Console.WriteLine("Student ID not found");
        }
    }

    static void UpdateStudentById(Dictionary<int, string> Student)
    {
        Console.Write("Enter Student ID : ");
        int studentId = Convert.ToInt32(Console.ReadLine());
        if (Student.ContainsKey(studentId!))
        {
            Console.WriteLine($"Student ID: {studentId}, Name: {Student[studentId!]}");
            Console.Write("Enter Student Name : ");
            string? name = Console.ReadLine();
            Student[studentId!] = name!;
        }
        else
        {
            Console.WriteLine("Student ID not found");
        }
    }
    static void Main()
    {
        Func1();
        Func2();
        Func3();
        Func4();
        Func5();
        Func6();
        Func7();
        Dictionary<int, string> Student = new Dictionary<int, string>();
        while (true)
        {
            Console.WriteLine("1. Add Student Record");
            Console.WriteLine("2. View the Student Database");
            Console.WriteLine("3. Search for a Student by ID");
            Console.WriteLine("4. Update a Student's Name");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddStudent(Student);
                        break;
                    case 2:
                        DisplayStudent(Student); 
                        break;
                    case 3:
                        SearchStudentById(Student);
                        break;
                    case 4:
                        UpdateStudentById(Student);
                        break;
                    case 5:
                        Environment.Exit(0);; 
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice (1-5).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }

        }
    }
}