// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Kemfon Bassey-BU/22C/IT/7848
using System;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;


        //  Prompt the user to input their name and birthdate.
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        string birthdateInput;
        DateTime birthdate;
        
        //  Validate the birthdate format using a regular expression (MM/dd/yyyy).
        Regex regex = new Regex(@"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$");
        do
        {
            Console.Write("Enter your birthdate (MM/dd/yyyy): ");
            birthdateInput = Console.ReadLine();
            
            if (!regex.IsMatch(birthdateInput) || !DateTime.TryParseExact(birthdateInput, "MM/dd/yyyy", null, DateTimeStyles.None, out birthdate))
            {
                Console.WriteLine("Error: Invalid birthdate format. Please try again.");
            }
            else
            {
                break;
            }
        } while (true);

        // Calculate and display the user’s age.
        int age = DateTime.Now.Year - birthdate.Year;
        if (DateTime.Now.DayOfYear < birthdate.DayOfYear) // Adjust age if birthday hasn't occurred yet this year.
        {
            age--;
        }
        Console.WriteLine($"You are {age} years old.");

        //  Save the user's information to a file named "user_info.txt".
        string filePath = "user_info.txt";
        File.WriteAllText(filePath, $"Name: {name}\nBirthdate: {birthdate:MM/dd/yyyy}\nAge: {age}");

        //  Read and display the contents of the "user_info.txt" file.
        Console.WriteLine("\nContents of 'user_info.txt':");
        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine(fileContent);

        //  Prompt the user to enter a directory path.
        Console.Write("\nEnter a directory path to list all files: ");
        string directoryPath = Console.ReadLine();

        //  List all files within the specified directory.
        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("\nFiles in the specified directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine("The directory does not exist.");
        }

        //  Prompt the user to input a string.
        Console.Write("\nEnter a string: ");
        string inputString = Console.ReadLine();

        //  Format the string to title case.
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string titleCaseString = textInfo.ToTitleCase(inputString.ToLower());
        Console.WriteLine("Formatted String (Title Case): " + titleCaseString);

        //  Explicitly trigger garbage collection.
        Console.WriteLine("\nTriggering garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage collection complete.");

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    


