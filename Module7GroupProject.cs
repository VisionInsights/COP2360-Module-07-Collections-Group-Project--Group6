using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace VSCODE;
class Program
{

  // Switch Statement and Algorithm to collect user data done collectively by group.
    static void Main(string[] args)
    {
      // Starter variables that has a standard List and an instance of a Dictionary as well as a control variable for the while loop
      List<string> listOfItems = new List<string>();
      Dictionary<int, string> dict = new Dictionary<int, string>();
      bool exit = false;

      // While Loop to allow user to iterate through all the options of the Dicitionary
      while (!exit)
        {
            // Presents options for the user with all the functions and takes account to their choice.
            Console.WriteLine("Choose an option:");
            Console.WriteLine("a. Populate the Dictionary");
            Console.WriteLine("b. Display Dictionary Contents");
            Console.WriteLine("c. Remove a Key");
            Console.WriteLine("d. Add a New Key and Value");
            Console.WriteLine("e. Add a Value to an Existing Key");
            Console.WriteLine("f. Sort the Keys");
            Console.WriteLine("g. Exit");
            string choice = Console.ReadLine();

            // Switch Statement for each option the user inputs.
            switch (choice)
            {
                // Case A allows the user to populate the Dictionary with a nested while loop that allows the user to put as many items as he or she wishes
                // Once The user inputs all the choices, it adds to the List then calls the PopulateDictionary Method at the end with the list inputted.
                case "a":
                    int popCount = 0;
                    if (popCount == 0) {
                      bool anotherExit = false;
                      while (!anotherExit) {
                        Console.WriteLine("Write a list item or type the letter 'exit' to quit adding items");
                        string choiceOne = Console.ReadLine();
                        if (choiceOne != "exit") {
                          listOfItems.Add(choiceOne);
                       }
                        else {
                          anotherExit = true;
                        }
                      }
                      dict = PopulateDictionary(listOfItems);
                      popCount++;
                    }
                    else {
                      Console.WriteLine("Dictionary has already been populated.");
                    }
                    break;

                // Case B simply calls the method of the DisplayDicitionaryContents with the Dictionary instance as a parameter. 
                // See Documentation below for more details.    
                case "b":
                    DisplayDictionaryContents(dict);
                    break;

                // Case C asks for the users input as an integer for a key and then sets the Dicitionary equal to the RemoveKey function.
                case "c":
                    Console.WriteLine("Which key do you want to remove?");
                    if (int.TryParse(Console.ReadLine(), out int choiceTwo)) {
                        dict = RemoveKey(dict, choiceTwo);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please enter a valid integer key.");
                    }
                    break;

                // Asks user for an input of a key then asks user for a value then sets Dictionary instance equal to the AddKeyAndValue method.
                case "d":
                    Console.WriteLine("Please input a key that you would .");
                    if (int.TryParse(Console.ReadLine(), out int choiceThree)) {
                      Console.WriteLine("Please input a value.");
                      string valueToAddOne = Console.ReadLine();
                      dict = AddKeyAndValue(dict, choiceThree, valueToAddOne);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please enter a valid integer key.");
                    }
                    break;
                // Asks user for input of key then value and then sets sets Dictionary instance equal to the AppendDictionary method.
                case "e":
                    Console.WriteLine("Please input a key to the value you want to append.");
                    if(int.TryParse(Console.ReadLine(), out int choiceFour)) {
                      Console.WriteLine("Please input a value.");
                      string valueToAddTwo = Console.ReadLine();
                      dict = AppendDictionary(dict,choiceFour,valueToAddTwo);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please enter a valid integer key.");
                    }
                    break;
                // Sets Dictionary equal to the SortDictionaryByKeys to sort keys in the Dictionary.
                case "f":
                    dict = SortDictionaryByKeys(dict);
                    break;
                // Case g is set to exit the loop using the boolean value exit as true. Exits the program
                case "g":
                    exit = true;
                    break;
                // In the case the user inputs an invalid choice.
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Part A completed by Emmanuel Padron
    // Populates the Dicitionary using the list the user provides in the Switch Statement above. Returns a Dictionary
    public static Dictionary<int,string> PopulateDictionary(List<string> list) {
      // Creates a new Dictionary to return and an int variable to assign key value numbers.
      Dictionary<int, string> diction = new Dictionary<int, string>();
      int i = 0;

      // Iterates through all the items of the List and adds them to the dictionary.
      foreach (string item in list)
      {
        diction.Add(i,item);
        i++;
      }

      return diction;
    }

    // Part B Completed by Ederson Noel.
    // Displays all Dictionary contents in an organized fashion. No return value
    static void DisplayDictionaryContents(Dictionary<int, string> dictionary)
    {
        // Iterates through the Dicitionary and prints them out in a ordered fashion.
        Console.WriteLine("Displaying dictionary contents:");
        foreach (KeyValuePair<int, string> kvp in dictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    // Part C completed by Emmanuel Padron
    // Removes a key and its value selected by the user from the Switch statement. Returns a Dictionary
    public static Dictionary<int,string> RemoveKey(Dictionary<int,string> originalList, int keyToBeRemoved) {
      // Creates a new Dictionary to be returned
      Dictionary<int,string> newList = originalList;

      // Checks if the key the user inputted exists then removes it and prints out the key removed. Else, it simply prints the key has not been found.
      if (newList.Remove(keyToBeRemoved)) {
        Console.WriteLine("Key {0} has been succesfully removed!",keyToBeRemoved);
      }
      else {
        Console.WriteLine("Key {0} has not been found", keyToBeRemoved);
      }

      return newList;
    }

    // Part D done by Jacob Rosenthal
    // Adds a new key and value selected by the user and adds it to the Dictionary. Returns a Dictionary.
    public static Dictionary<int,string> AddKeyAndValue(Dictionary<int,string> originalList, int key, string value) {
      // Creates a new Dictionary to be returned and set equal to the original dicitionary.
      Dictionary<int, string> newList = originalList;

      // Checks if key inputted by user does not exist and then adds the key with value. Else, it reminds user the key already exists.
      if (!newList.ContainsKey(key)) {
        newList.Add(key,value);
        Console.WriteLine("New key and value have been added!");
      }
      else {
        Console.WriteLine("Sorry that key already exists!");
      }
      return newList;
    }

    // Part E done by Andrew Redmond
    // Changes a value from an existing key in which the value is inputted by the user. Returns a Dictionary
    public static Dictionary<int,string> AppendDictionary(Dictionary<int,string> originalList, int key, string value) {
      // Creates a new Dictionary to be returned.
      Dictionary<int,string> newList = originalList;

      // Checks if Dictionary key inputted by user already exists then appends the value from the key to what the user inputted.
      // Else, it reminds the user that the key they inputted does not exists.
      if (newList.ContainsKey(key)) {
        newList[key] = value;
        Console.WriteLine("Value has been appended with repsect to the key.");
      }
      else {
        Console.WriteLine("Sorry that key doesn't exist!");
      }
      return newList;
    }

    // Part F done by Dhamyr Panier
    // Sorts the keys in order. Returns a Dictionary.
    public static Dictionary<int, string> SortDictionaryByKeys(Dictionary<int, string> dict)
    {
      Console.WriteLine("Keys are now sorted!");
      return dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}