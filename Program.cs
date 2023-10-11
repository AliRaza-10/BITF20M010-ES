using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace AssignmentFiveConsoleApp
    {
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\A.H Computer\\Desktop\\assignment-5\\ConsoleApp3\\AssignmentFive.mdf\";Integrated Security=True";
            while (true)
            {
                Console.WriteLine("1 - Insert Employee Record");
                Console.WriteLine("2 - Display All Records");
                Console.WriteLine("3 - Update Record by ID");
                Console.WriteLine("4 - Display Specific Record by ID");
                Console.WriteLine("5 - Delete Record by ID");
                Console.WriteLine("6 - Exit");
                Console.Write("Enter your choice (1-6): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InsertEmployee(connectionString);
                            break;
                        case 2:
                            DisplayAllEmployeeRecords(connectionString);
                            break;
                        case 3:
                            int id;
                            Console.Write("Enter the ID of the employee to update: ");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                UpdateEmployeeRecords(connectionString, id);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid ID.");
                            }
                            break;
                        case 4:
                            int ID;
                            Console.Write("Enter the ID of the employee which you want to get Record: ");
                            if (int.TryParse(Console.ReadLine(), out ID))
                            {
                                SelectEmployeeById(connectionString, ID);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid  ID.");
                            }
                            break;
                        case 5:
                            int userInput;
                            Console.Write("Enter the ID of the employee which you want to Delete: ");
                            if (int.TryParse(Console.ReadLine(), out userInput))
                            {
                                DeleteEmployeeById(connectionString, userInput);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Exiting the program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid  choice.");
                }
            }
        }
        static void DisplayAllEmployeeRecords(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}");
                        Console.WriteLine($"FirstName: {reader["FirstName"]}");
                        Console.WriteLine($"LastName: {reader["LastName"]}");
                        Console.WriteLine($"Email: {reader["Email"]}");
                        Console.WriteLine($"PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                        Console.WriteLine($"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                        Console.WriteLine($"CreatedBy: {reader["CreatedBy"]}");
                        Console.WriteLine($"CreatedOn: {reader["CreatedOn"]}");
                        Console.WriteLine($"ModifiedBy: {reader["ModifiedBy"]}");
                        Console.WriteLine($"ModifiedOn: {reader["ModifiedOn"]}");
                        Console.WriteLine();
                    }
                }
            }
        }
        static void InsertEmployee(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter First name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Primary Phone Number: ");
                string primaryPhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Secondary Phone Number (press enter if none): ");
                string secondaryPhoneNumber = Console.ReadLine();
                Console.Write("Employee Record Created by: ");
                string createdBy = Console.ReadLine();
                string insertQuery = @"INSERT INTO Employees (firstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn)
                VALUES (@firstName, @lastName, @email, @primaryPhoneNumber, @secondaryPhoneNumber, @createdBy, GETDATE())";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                insertCommand.Parameters.AddWithValue("@LastName", lastName);
                insertCommand.Parameters.AddWithValue("@Email", email);
                insertCommand.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                insertCommand.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? (object)DBNull.Value : secondaryPhoneNumber);
                insertCommand.Parameters.AddWithValue("@CreatedBy", createdBy);
                int rowsAffected = insertCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record inserted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to insert a record.");
                }
            }
        }
        static void DeleteEmployeeById(string connectionString, int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Employees WHERE ID = @EmployeeId";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@EmployeeId", employeeId);

                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record with ID " + employeeId + " deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No record found for the specified ID or failed to delete.");
                }
            }
        }
        static void SelectEmployeeById(string connectionString, int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees WHERE ID = @EmployeeId";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);

                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}");
                        Console.WriteLine($"FirstName: {reader["FirstName"]}");
                        Console.WriteLine($"LastName: {reader["LastName"]}");
                        Console.WriteLine($"Email: {reader["Email"]}");
                        Console.WriteLine($"PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                        Console.WriteLine($"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                        Console.WriteLine($"CreatedBy: {reader["CreatedBy"]}");
                        Console.WriteLine($"CreatedOn: {reader["CreatedOn"]}");
                        Console.WriteLine($"ModifiedBy: {reader["ModifiedBy"]}");
                        Console.WriteLine($"ModifiedOn: {reader["ModifiedOn"]}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No record found for the specified ID.");
                }
            }
        }


        static void UpdateEmployeeRecords(string connectionString, int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Employees WHERE ID = @EmployeeId";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                int recordCount = (int)checkCommand.ExecuteScalar();
                if (recordCount > 0)
                {
                    Console.Write("Enter new First Name: ");
                    string newFirstName = Console.ReadLine();

                    Console.Write("Enter new Last Name: ");
                    string newLastName = Console.ReadLine();

                    Console.Write("Enter new Email: ");
                    string newEmail = Console.ReadLine();

                    Console.Write("Enter new Primary Phone Number: ");
                    string newPrimaryPhoneNumber = Console.ReadLine();

                    Console.Write("Enter new Secondary Phone Number (press Enter if none): ");
                    string newSecondaryPhoneNumber = Console.ReadLine();

                    Console.Write("Enter Updated By : ");
                    string NewModifiedBy = Console.ReadLine();

              
                    string updateQuery = @" UPDATE Employees
                            SET FirstName = @NewFirstName,
                            LastName = @NewLastName,
                            Email = @NewEmail,
                            PrimaryPhoneNumber = @NewPrimaryPhoneNumber,
                            SecondaryPhoneNumber = @NewSecondaryPhoneNumber,
                            ModifiedBy = @NewModifiedBy,
                            ModifiedOn = GETDATE()
                            WHERE ID = @EmployeeId";

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    updateCommand.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    updateCommand.Parameters.AddWithValue("@NewLastName", newLastName);
                    updateCommand.Parameters.AddWithValue("@NewEmail", newEmail);
                    updateCommand.Parameters.AddWithValue("@NewPrimaryPhoneNumber", newPrimaryPhoneNumber);
                    updateCommand.Parameters.AddWithValue("@NewSecondaryPhoneNumber", string.IsNullOrEmpty(newSecondaryPhoneNumber) ? (object)DBNull.Value : newSecondaryPhoneNumber);
                    updateCommand.Parameters.AddWithValue("@NewModifiedBy", NewModifiedBy);
                   

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update the record.");
                    }
                }
                else
                {
                    Console.WriteLine("No record found for the specified ID.");
                }
            }
        }
    }
}


