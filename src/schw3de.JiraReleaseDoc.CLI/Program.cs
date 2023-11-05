// See https://aka.ms/new-console-template for more information
using Atlassian.Jira;


Console.Write("Please enter your username: ");
var userName = Console.ReadLine();
Console.Write("Please enter your password: ");
var password = ReadPassword();
// Nun enthält die Variable "password" das eingegebene Passwort
Console.WriteLine("\nPasswort eingegeben.");

var jira = Jira.CreateRestClient("http://", userName, password);

static string ReadPassword()
{
    string password = "";
    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            break;
        }
        if (keyInfo.Key == ConsoleKey.Backspace)
        {
            if (password.Length > 0)
            {
                password = password[0..^1];
                Console.Write("\b \b");  // Zeichen im Terminal löschen
            }
        }
        else
        {
            password += keyInfo.KeyChar;
            Console.Write("*");
        }
    }
    return password;
}