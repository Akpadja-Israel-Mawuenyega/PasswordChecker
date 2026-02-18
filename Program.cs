Console.Title = "PASSWORD_CHECKER_V1.0";
Console.OutputEncoding = System.Text.Encoding.UTF8;

const int minLength = 8;
const int maxLength = 16;
bool isValidPassword = false;

while (!isValidPassword)
{
    Console.Clear();

    Console.WriteLine($"--- Create a password ({minLength}-{maxLength} characters) ---");
    Console.WriteLine("Must include: 1 Uppercase letter, 1 Number, and 1 Special Character (#, ;, !, @, $,etc.).");

    Theme.Info("Enter your password: ");
    string password = ReadPassword(maxLength);

    Theme.Info("Confirm your password: ");
    string confirm_password = ReadPassword(maxLength);

    if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm_password))
    {
        Theme.Warning("Password cannot be empty.\n");
    }
    else if (password.Length < minLength)
    {
        Theme.Error($"Password is too short! Minimum is {minLength}.\n");
    }
    else if (!HasRequiredComplexity(password))
    {
        Theme.Error("Missing an uppercase letter, a number, or a special character.\n");
    }
    else if (!password.Equals(confirm_password, StringComparison.Ordinal))
    {
        Theme.Error("Passwords do not match. \n");
    }
    else
    {
        Theme.Success("Both passwords match.");
        isValidPassword = true;

        Thread.Sleep(1000);
        Console.Clear();

        Console.WriteLine(new string('━', 37));
        Console.WriteLine($"{Theme.Green}{Theme.Bold}      WELCOME TO THE MAIN SYSTEM     {Theme.Reset}");
        Console.WriteLine(new string('━', 37));
        Console.WriteLine("\nYou are now logged into your secure vault.");
    }

    if (!isValidPassword)
    {
        Console.WriteLine("\nPress any key to retry...");
        Console.ReadKey(true);
    }
}


Console.WriteLine("Press any key to continue...");
Console.ReadKey();

static string ReadPassword(int limit)
{
    var pass = new System.Text.StringBuilder();
    ConsoleKeyInfo key;

    do
    {
        key = Console.ReadKey(true);

        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
        {
            if (!char.IsControl(key.KeyChar) && pass.Length < limit)
            {
                pass.Append(key.KeyChar);
                Console.Write("*");
            }
        }
        else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
        {
            pass.Remove(pass.Length - 1, 1);
            Console.Write("\b \b");
        }
    } while (key.Key != ConsoleKey.Enter);

    Console.WriteLine();
    return pass.ToString();
}

static bool HasRequiredComplexity(string pass)
{
    bool hasUpper = false;
    bool hasDigit = false;
    bool hasSpecial = false;

    foreach (char c in pass)
    {
        if (char.IsUpper(c)) hasUpper = true;
        else if (char.IsDigit(c)) hasDigit = true;
        else if (char.IsPunctuation(c) || char.IsSymbol(c)) hasSpecial = true;

        if (hasUpper && hasDigit && hasSpecial) return true;
    }

    return hasUpper && hasDigit && hasSpecial;
}

public static class Theme
{
    public const string Bold = "\x1b[1m";
    public const string Red = "\x1b[31m";
    public const string Yellow = "\x1b[33m";
    public const string Green = "\x1b[32m";
    public const string Blue = "\x1b[34m";
    public const string Reset = "\x1b[0m";

    public static void Success(string msg) => Console.WriteLine($"{Green}{Bold}✅ SUCCESS: {msg}{Reset}");
    public static void Warning(string msg) => Console.WriteLine($"{Yellow}{Bold}⚠️  WARNING: {msg}{Reset}");
    public static void Error(string msg) => Console.WriteLine($"{Red}{Bold}❌ ERROR: {msg}{Reset}");
    public static void Info(string msg) => Console.Write($"{Blue}{Bold}ℹ️  INSTRUCTION: {msg}{Reset}");


}
