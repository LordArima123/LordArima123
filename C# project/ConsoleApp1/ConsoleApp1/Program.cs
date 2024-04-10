using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.ComponentModel;
using System.Transactions;


namespace ConsoleApp1
{
    internal class Program
    {
        static List<string> color = new List<string>() { "Red", "Green", "Blue" };
        static List<string> gender = new List<string>() { "Male", "Female" };
        static List<string> musicgen = new List<string>() { "Pop", "Rock", "Rap", "Ballad" };
        static string nameColor = "Color List";
        static string nameGender = "Gender List";
        static string namemusicgen = "Music Genre List";
        static string filePath = "data.txt";
        struct dataInfo // Data Structure
        {
            public string name;
            public int age;
            public string gender;
            public string country;
            public string color;
            public string hobby;
            public string job;
            public string music;
            public string book;
            public string movie;
            
        } 

        static dataInfo MakeNewData()
        {
            bool test = false;
            dataInfo newdataInfo = new dataInfo();
            Console.WriteLine("What is your name? ");
            newdataInfo.name = Console.ReadLine();
            Console.WriteLine("----------------------");

            do
            {
                Console.WriteLine("How old are you? ");
                test = int.TryParse(Console.ReadLine(), out newdataInfo.age);
                if (newdataInfo.age <= 0 || newdataInfo.age > 200)
                {
                    Console.WriteLine("Please enter your real age!");
                    test = false;
                }
            } while (test == false); // Check user input for age
            Console.WriteLine("----------------------");

            Console.WriteLine("What is your gender? ");
            newdataInfo.gender = ChooseOption(gender, nameGender);

            Console.WriteLine("What country are you from? ");
            newdataInfo.country = Console.ReadLine();
            Console.WriteLine("----------------------");

            Console.WriteLine("What is your favorite color? ");
            newdataInfo.color = ChooseOption(color, nameColor);
            

            Console.WriteLine("What is your hobby? ");
            newdataInfo.hobby = Console.ReadLine();
            Console.WriteLine("----------------------");

            Console.WriteLine("What do you do? ");
            newdataInfo.job = Console.ReadLine();
            Console.WriteLine("----------------------");

            Console.WriteLine("What is your favorite music genre? ");
            newdataInfo.music = ChooseOption(musicgen,namemusicgen);

            Console.WriteLine("What is your favorite book? ");
            newdataInfo.book = Console.ReadLine();
            Console.WriteLine("----------------------");

            Console.WriteLine("What is your favorite movie? ");
            newdataInfo.movie = Console.ReadLine();
            Console.WriteLine("----------------------");

            return newdataInfo;
        } 

        // Function to choose option
        static string ChooseOption(List<string> list, string listName)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show option list");
                Console.WriteLine("2. Choose an option from option list");
                Console.WriteLine("3. Add new option to the option list");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ShowList(list, listName);
                        break;
                    case 2:
                        string chosenOption = ChooseFromList(list, listName);
                        Console.WriteLine($"Selected option: {chosenOption}");
                        Console.WriteLine("----------------------");
                        return chosenOption;
                        
                    case 3:
                        AddToList(list, listName);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        continue;
                }
            }
        }

        

        // Show option
        static void ShowList<T>(List<T> list, string listName)
        {
            Console.WriteLine($"--- {listName} ---");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i]}");
            }
            Console.WriteLine("----------------------");
        }

        //Choose from list
        static T ChooseFromList<T>(List<T> list, string listName)
        {
            Console.WriteLine($"Choose an option from the {listName}:");
            ShowList(list, listName);

            int choice;
            while (true)
            {
                Console.Write("Enter the number of your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= list.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }

            return list[choice - 1];
        }
         
        //Function add new option
        static void AddToList<T>(List<T> list, string listName)
        {
            Console.WriteLine($"Enter the new option to add to the {listName}:");
            T newOption = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            list.Add(newOption);
            Console.WriteLine($"Option '{newOption}' added to {listName} successfully.");
        }

        //Write to file function
        static void WriteToFile(string filePath, dataInfo data)
        {
            
            // Convert data object to a string representation
            string dataString = $"{data.name}, {data.age}, {data.gender}, {data.country}, {data.color}, {data.hobby}, {data.job}, {data.music}, {data.book}, {data.movie}";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Append data to the existing file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(dataString);
                }
            }
            else
            {
                // Create a new file and write data to it
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(dataString);
                }
            }
        }
        static void FindData(string filePath, string searchText)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            // Read data from the file and search for the line
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                dataInfo data = new dataInfo();
                bool found = false;
                while ((line = reader.ReadLine()) != null)
                {
                    // Check if the line starts with the specified text
                    if (line.StartsWith(searchText))
                    {
                        // Split the line into its components
                        string[] parts = line.Split(',');

                        // Assuming the format is "Name,Age,Occupation"
                        data.name = parts[0].Trim();
                        data.age = int.Parse(parts[1].Trim());
                        data.gender = parts[2].Trim();
                        data.country = parts[3].Trim();
                        data.color = parts[4].Trim();
                        data.hobby = parts[5].Trim();
                        data.job = parts[6].Trim();
                        data.music = parts[7].Trim();
                        data.book = parts[8].Trim();
                        data.movie = parts[9].Trim();
                        // Create and return a Data instance
                        
                        Console.WriteLine($"Found {searchText}");
                        Console.WriteLine($"Name: {data.name}");
                        Console.WriteLine($"Age: {data.age}");
                        Console.WriteLine($"Gender: {data.gender}");
                        Console.WriteLine($"Country: {data.country}");
                        Console.WriteLine($"Favorite Color: {data.color}");
                        Console.WriteLine($"Hobby: {data.hobby}");
                        Console.WriteLine($"Job: {data.job}");
                        Console.WriteLine($"Favorite Music: {data.music}");
                        Console.WriteLine($"Favorite Book: {data.book}");
                        Console.WriteLine($"Favorite Movie: {data.movie}");
                        Console.WriteLine("----------------------");
                        found = true;
                    }

                }
                if ( !found )
                {
                    Console.WriteLine($"{searchText} Not Found");
                }
            }
        }

        //Read Data from File to do statistic
        static List<dataInfo> ReadDataFromFile(string filePath)
        {
            List<dataInfo> dataList = new List<dataInfo>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(','); 

                        dataInfo data = new dataInfo
                        {
                            name = fields[0].Trim(),
                            age = int.Parse(fields[1].Trim()),
                            gender = fields[2].Trim(),
                            country = fields[3].Trim(),
                            color = fields[4].Trim(),
                            hobby = fields[5].Trim(),
                            job = fields[6].Trim(),
                            music = fields[7].Trim(),
                            book = fields[8].Trim(),
                            movie = fields[9].Trim()
                        };

                        dataList.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            return dataList;
        }

        //Calculate avarage age
        static double CalculateAverageAge(List<dataInfo> dataList)
        {
            if (dataList.Count == 0)
            {
                return 0; // Return 0 if the list is empty to avoid division by zero
            }

            int totalAge = 0;
            foreach (var data in dataList)
            {
                totalAge += data.age;
            }

            return (double)totalAge / dataList.Count;
        }

        //Calculate most entered answer
        static string FindMostCommon(List<string> dataList)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            // Count occurrences of each item
            foreach (var item in dataList)
            {
                if (counts.ContainsKey(item))
                {
                    counts[item]++;
                }
                else
                {
                    counts[item] = 1;
                }
            }

            // Find the item with the maximum count
            var mostCommon = counts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return mostCommon;
        }

        //Function statistic
        static void statistic(List<dataInfo> dataList)
        {
            int sta_choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Please choose option statistic to do:");
                Console.WriteLine("1 - Avarage Age");
                Console.WriteLine("2 - The most favorite color");
                Console.WriteLine("3 - The most common job");
                Console.WriteLine("4 - The most entered gender");
                Console.WriteLine("5 - The most favorite music genre");
                Console.WriteLine("6 - The most favorite book");
                Console.WriteLine("7 - The most favorite movie");
                Console.WriteLine("10 - Exit");
                int.TryParse(Console.ReadLine(), out sta_choice);
                switch (sta_choice)
                {
                    case 1: //Avarage Age
                        double res = CalculateAverageAge(dataList);
                        Console.WriteLine($"Average Age entered is: {res}");
                        break;
                    case 2: //Color
                        List<string> colors = dataList.Select(data => data.color).ToList();
                        string s = FindMostCommon(colors);
                        Console.WriteLine($"The most favorite color is: {s}");
                        break;
                    case 3: //Job
                        List<string> jobs = dataList.Select(data => data.job).ToList();
                        string j = FindMostCommon(jobs);
                        Console.WriteLine($"The most favorite color is: {j}");
                        break;
                    case 4: //Gender
                        List<string> genders = dataList.Select(data => data.gender).ToList();
                        string g = FindMostCommon(genders);
                        Console.WriteLine($"The most favorite color is: {g}");
                        break;
                    case 5: //Music
                        List<string> musics = dataList.Select(data => data.music).ToList();
                        string m = FindMostCommon(musics);
                        Console.WriteLine($"The most favorite color is: {m}");
                        break;
                    case 6: //Book
                        List<string> books = dataList.Select(data => data.book).ToList();
                        string b = FindMostCommon(books);
                        Console.WriteLine($"The most favorite color is: {b}");
                        break;
                    case 7: //Movie
                        List<string> movies = dataList.Select(data => data.movie).ToList();
                        string M = FindMostCommon(movies);
                        Console.WriteLine($"The most favorite color is: {M}");
                        break;
                    

                }
                if (sta_choice != 10)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadKey();
                }


            } while (sta_choice != 10);
        }
        static void Main(string[] args)
        {
            int choice = 0;
            Console.WriteLine("Filling out questionares");
            dataInfo entry = MakeNewData();
            WriteToFile(filePath, entry);
            Console.WriteLine("Thank you!");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.WriteLine("Please choose option:");
                Console.WriteLine("1 - Fill out questionares");
                Console.WriteLine("2 - Finding answers of a person");
                Console.WriteLine("3 - Statistic");     
                Console.WriteLine("4 - Exit");
                int.TryParse(Console.ReadLine(),out choice);
                switch (choice)
                {
                    case 1:
                        dataInfo newdata = MakeNewData();
                        WriteToFile(filePath, newdata);
                        break;
                    case 2:
                        Console.Write("Enter the person's name: ");
                        string find_name = Console.ReadLine();
                        FindData(filePath, find_name);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadKey();
                        break;
                    case 3:
                        List<dataInfo> dataList = ReadDataFromFile(filePath);
                        statistic(dataList);

                        break;

                }

            } while ( choice != 4);
            

            
            
        }
    }
}
  

