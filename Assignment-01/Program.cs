using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BITF20M010_Assignment_1
{
    internal class Program
    {
        static void display()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("\t\t\tWELCOME TO MYRIDE");
            Console.WriteLine("------------------------------------------------------------------------");
        }

        static void mainMenu()
        {
            Console.WriteLine("1: Book a Ride");
            Console.WriteLine("2: Enter as Driver");
            Console.WriteLine("3: Enter as Admin");
            Console.WriteLine("4: Close App");
            Console.WriteLine("Enter your choice 1-4 : ");
        }

        static void driverMenu()
        {
            Console.WriteLine("1: Change Availability");
            Console.WriteLine("2: Change Location");
            Console.WriteLine("3: Exit as Driver");
        }

        static void adminMenu()
        {
            Console.WriteLine("1: Add Driver");
            Console.WriteLine("2: Remove Driver");
            Console.WriteLine("3: Update Admin");
            Console.WriteLine("4: Search Driver");
            Console.WriteLine("5: Exit as Admin");
        }
        static void Main(string[] args)
        {
            display();

            int choice = 0;

            Admin admin = new Admin();

            while (choice != 4)
            {
                mainMenu();

                while (choice < 1 || choice > 4)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        string val = Console.ReadLine();
                        Console.ResetColor();
                        choice = Convert.ToInt32(val);
                        if (choice < 1|| choice > 4)
                        Console.WriteLine("Please enter a number 1-4 ");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }

                if (choice == 1)
                {
                    choice = 0;    
                    Console.WriteLine("Enter name : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string passengerName = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    bool flag = true; 
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Enter Phone Number : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string passengerPhoneNumber = Console.ReadLine();
                    Console.ResetColor();
                    while (flag)
                    {
                        flag = false;
                        try
                        {
                            int phoneNumberLength = passengerPhoneNumber.Length;
                            if (phoneNumberLength != 11)
                            {
                                throw new Exception("Phone number length must be 11 digits.");
                            }

                            for (int i = 0; i < phoneNumberLength; i++)
                            {
                                if (passengerPhoneNumber[i] < '0' || passengerPhoneNumber[i] > '9')
                                {
                                    throw new Exception("Invalid character in phone number.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: " + ex.Message);
                            Console.ResetColor();

                            Console.WriteLine("Enter valid Number : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            passengerPhoneNumber = Console.ReadLine();
                            Console.ResetColor();
                        }

                        if (flag)
                        {
                            Console.WriteLine("Enter valid Number : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            passengerPhoneNumber = Console.ReadLine();
                            Console.ResetColor();
                        }
                    }

                    Passenger passenger = new Passenger(passengerName, passengerPhoneNumber);

                    
                    Console.WriteLine("Enter Start Location : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string startLoc = Console.ReadLine();
                    Console.ResetColor();

                    string[] dimensions = startLoc.Split(',');

                    Location startLocation = new Location(float.Parse(dimensions[0]), float.Parse(dimensions[1]));

                    Console.WriteLine("Enter End Location : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string endLoc = Console.ReadLine();
                    Console.ResetColor();

                    dimensions = endLoc.Split(',');

                    Location endLocation = new Location(float.Parse(dimensions[0]), float.Parse(dimensions[1]));
                    Console.WriteLine("Enter Ride Type : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string type = Console.ReadLine();
                    Console.ResetColor();

                    Ride ride = new Ride();
                    bool rideFlag = ride.bookRide(startLocation, endLocation, passenger, type);
                    if (rideFlag)
                    {
                        Console.WriteLine("\n--------------- THANK YOU ----------------\n");

                        Console.WriteLine("Total cost of ride is " + ride.calculatePrice(type));

                        
                        Console.WriteLine("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation: ");

                        Console.ForegroundColor = ConsoleColor.Green;
                        string choice2 = Console.ReadLine();
                        Console.ResetColor();

                        if (choice2 == "y" || choice2 == "Y")
                        {
                            Console.WriteLine("\nHappy Travel…!\n");

                            Console.WriteLine("\nGive rating out of 5: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string val = Console.ReadLine();
                            Console.ResetColor();
                            int rating = Convert.ToInt32(val);

                            while (rating < 1 || rating > 5)
                            {
                                Console.WriteLine("\nRating should be from 1 to 5: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                val = Console.ReadLine();
                                Console.ResetColor();
                                rating = Convert.ToInt32(val);
                            }

                            ride.addDriversRating(rating);
                        }
                        else
                        {
                            Console.WriteLine("Try another driver");
                        }
                    }

                }

                else if (choice == 2)
                {
                    choice = 0;

                    Console.WriteLine("Enter ID : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string val = Console.ReadLine();
                    Console.ResetColor();
                    int id = Convert.ToInt32(val);
                    Console.WriteLine("Enter name : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();

                    Driver driver = admin.searchDriverById(id);

                    if (driver != null)
                    {
                        Console.WriteLine("Hello " + driver.getName());
                        Console.WriteLine("Please enter your current location:");

                        Console.ForegroundColor = ConsoleColor.Green;
                        string startLoc = Console.ReadLine();
                        Console.ResetColor();

                        string[] dimensions = startLoc.Split(',');

                        driver.updateLocation(float.Parse(dimensions[0]), float.Parse(dimensions[1]));

                        int choice2 = 0;

                        while (choice2 != 3)
                        {
                            driverMenu();
                            while (choice2 < 1 || choice2 > 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                string value = Console.ReadLine();
                                Console.ResetColor();
                                choice2 = Convert.ToInt32(value);
                            }

                            if (choice2 == 1)
                            {
                                choice2 = 0;

                                driver.updateAvailability();
                            }

                            else if (choice2 == 2)
                            {
                                choice2 = 0;

                                Console.WriteLine("Enter Location : ");

                                Console.ForegroundColor = ConsoleColor.Green;
                                string loc = Console.ReadLine();
                                Console.ResetColor();

                                dimensions = startLoc.Split(',');

                                driver.updateLocation(float.Parse(dimensions[0]), float.Parse(dimensions[1]));
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("\n*** Driver not exists ***\n");
                    }
                }

                else if (choice == 3)
                {
                    choice = 0;

                    int choice2 = 0;

                    while (choice2 != 5)
                    {
                        adminMenu();
                        while (choice2 < 1 || choice2 > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            string val = Console.ReadLine();
                            Console.ResetColor();
                            choice2 = Convert.ToInt32(val);
                        }

                        if (choice2 == 1)
                        {
                            choice2 = 0;

                            Console.WriteLine("Enter Name : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string name = Console.ReadLine();
                            Console.ResetColor();

                            int age = 0;
                            bool validAgeInput = false;

                            while (!validAgeInput)
                            {
                                try
                                {
                                    Console.WriteLine("Enter Age : ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    string ageInput = Console.ReadLine();
                                    Console.ResetColor();

                                    age = Convert.ToInt32(ageInput);

                                    if (age >= 0) 
                                    {
                                        validAgeInput = true; 
                                    }
                                    else
                                    {
                                        Console.WriteLine("Age cannot be negative. Please enter a valid age.");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid age.");
                                }
                            }

                            string gender = "";

                            while (true)
                            {
                                Console.WriteLine("Enter Gender (M/F/S): ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                gender = Console.ReadLine().Trim().ToUpper();
                                Console.ResetColor();

                                try
                                {
                                    if (gender == "M" || gender == "F" || gender == "S")
                                    {
                                        break; 
                                    }
                                    else
                                    {
                                        throw new FormatException(); 
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter 'M' for Male, 'F' for Female, or 'S' for Other.");
                                }
                            }


                            Console.WriteLine("Enter Address : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string address = Console.ReadLine();
                            Console.ResetColor();

                            bool flag = true;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Enter Phone Number : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string phoneNumber = Console.ReadLine();
                            Console.ResetColor();
                            while (flag)
                            {
                                flag = false;
                                try
                                {
                                    int phoneNumberLength = phoneNumber.Length;
                                    if (phoneNumberLength != 11)
                                    {
                                        throw new Exception("Phone number length must be 11 digits.");
                                    }

                                    for (int i = 0; i < phoneNumberLength; i++)
                                    {
                                        if (phoneNumber[i] < '0' || phoneNumber[i] > '9')
                                        {
                                            throw new Exception("Invalid character in phone number.");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: " + ex.Message);
                                    Console.ResetColor();

                                    Console.WriteLine("Enter valid Number : ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    phoneNumber = Console.ReadLine();
                                    Console.ResetColor();
                                }

                                if (flag)
                                {
                                    Console.WriteLine("Enter valid Number : ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    phoneNumber = Console.ReadLine();
                                    Console.ResetColor();
                                }
                            }
                            Console.WriteLine("Enter Location : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string loc = Console.ReadLine();
                            Console.ResetColor();
                            string[] dimensions = loc.Split(',');
                            float latitude = float.Parse(dimensions[0]);
                            float longitude = float.Parse(dimensions[1]);

                            Location currentLocation = new Location(latitude, longitude);
                            string type = "";
                            while (true)
                            {
                                Console.WriteLine("Enter Vehicle Type (Rickshaw/Car/Bike): ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                type = Console.ReadLine().Trim();
                                Console.ResetColor();

                                try
                                {
                                    if (type.Equals("Rickshaw", StringComparison.OrdinalIgnoreCase) ||
                                        type.Equals("Car", StringComparison.OrdinalIgnoreCase) ||
                                        type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        throw new FormatException(); 
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter 'Rickshaw', 'Car', or 'Bike'.");
                                }
                            }

                            Console.WriteLine("Enter Model : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string model = Console.ReadLine();
                            Console.ResetColor();
                            Console.WriteLine("Enter Licence Plate : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string plate = Console.ReadLine();
                            Console.ResetColor();

                            Vehicle vehicle = new Vehicle(type, model, plate);

                            Driver driver = new Driver(name, age, gender, address, phoneNumber, currentLocation, vehicle, true);

                            Console.WriteLine("Driver Registered. ID : " + admin.addDriver(driver));
                        }

                        else if (choice2 == 2)
                        {
                            choice2 = 0;


                            Console.WriteLine("Enter ID : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string val = Console.ReadLine();
                            Console.ResetColor();
                            int id = Convert.ToInt32(val);

                            admin.removeDriver(id);
                        }

                        else if (choice2 == 3)
                        {
                            choice2 = 0;

                            Console.WriteLine("Enter ID : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string val = Console.ReadLine();
                            Console.ResetColor();
                            int id = Convert.ToInt32(val);

                            if (admin.searchDriverById(id) == null)
                            {
                                Console.WriteLine("------------Driver with ID " + id + " not exist-------------");
                            }

                            else
                            {
                                Console.WriteLine("------------Driver with ID " + id + " exists-------------");

                                Console.WriteLine("Enter Age : ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                val = Console.ReadLine();
                                Console.ResetColor();
                                int age = Convert.ToInt32(val);

                                string type = "";

                                while (true)
                                {
                                    Console.WriteLine("Enter Vehicle Type (Rikshaw/Car/Bike): ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    type = Console.ReadLine().Trim();
                                    Console.ResetColor();

                                    try
                                    {
                                        if (type.Equals("Rikshaw", StringComparison.OrdinalIgnoreCase) ||
                                            type.Equals("Car", StringComparison.OrdinalIgnoreCase) ||
                                            type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
                                        {
                                            break; 
                                        }
                                        else
                                        {
                                            throw new FormatException(); 
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid input. Please enter 'Rikshaw', 'Car', or 'Bike'.");
                                    }
                                }

                                Console.WriteLine("Enter Model : ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                string model = Console.ReadLine();
                                Console.ResetColor();

                                Console.WriteLine("Enter Licence Plate : ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                string plate = Console.ReadLine();
                                Console.ResetColor();

                                admin.updateDriver(id, age, type, model, plate);

                                Console.WriteLine("------------ Driver Updated -------------");

                            }
                        }
                        else if (choice2 == 4)
                        {
                            choice2 = 0;

                            Console.WriteLine("Enter ID : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string val = Console.ReadLine();
                            Console.ResetColor();
                            int id = Convert.ToInt32(val);

                            Driver driver = admin.searchDriver(id);

                            if (driver == null)
                            {
                                Console.WriteLine("------------Driver with ID " + id + " not exist-------------");
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------");
                                Console.WriteLine("Name        Age        Gender        V.Type        V.Model        V.Licence");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,-12}{1,-11}{2,-14}{3,-14}{4,-15}{5,-17}", driver.getName(), driver.getAge(), driver.getGender(), driver.getVehicleType(), driver.getModel(), driver.getLicence()));
                                Console.WriteLine("---------------------------------------------------------------------------");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Thanks for visiting :)");
        }
    }
}
