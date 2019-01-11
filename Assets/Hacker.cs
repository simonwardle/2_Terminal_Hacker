using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    string[] levelOnePasswords = {"books", "shelf", "aisle", "membership", "fiction", "borrow"};
    string[] levelTwoPasswords = { "panda", "uniform", "arrest", "prisoner", "handcuffs", "truncheon"};
    string[] levelThreePasswords = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    string menuMessage = "Enter menu at any time.";

    //Game State
    int level;
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };
    Screen currentScreen = Screen.MainMenu;

    string password;
 
    
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for NASA.");
        Terminal.WriteLine("Enter your selection:");
        currentScreen = Screen.MainMenu;
    }

    
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            ValidatePassword(input);
        }
        
    }


    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please choose a valid level Mr Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
                break;
            case 2:
                password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
                break;
            case 3:
                password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number!");
                break;
        }

    }

    void ValidatePassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Well done!");
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;

        }
    }
}
