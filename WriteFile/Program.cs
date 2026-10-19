using System.Data;
using System.Globalization;

Console.Title = "WriteFile text editor v1.0";

Console.WriteLine("""
    WELCOME TO WRITEFILE!
    Enter the file path. If if such a file does not exist, it will
    automaticly created.

    to save changes on a new line type $save and press ENTER
    to save and exit - type $exit
    To delete last line - type $del
    To erese all text in a file - type $erese

    """);
pathInput:
Console.Write("File path (e.g. C:\\users\\user\\desktop\\file.txt): ");
string path = Console.ReadLine();
fileSearch:
if (File.Exists(path))
{
    Console.WriteLine();
    List<string> fileContents = ReadFile(path).ToList(); ;
    Show(fileContents);
textInput:
    string line = Console.ReadLine();
    if (line == "$exit")
    {
        WriteFile(fileContents.ToArray(), path);
        goto pathInput;
    }
    else if (line == "$del")
    {
        fileContents.RemoveAt(fileContents.Count - 1);
        Show(fileContents);
        goto textInput;
    }
    else if (line == "$save")
    {
        WriteFile(fileContents.ToArray(), path);
        goto textInput;
    }
    else if (line == "$erese")
    {
        fileContents.Clear();
        goto textInput;
    }
    else
    {
        fileContents.Add(line);
        goto textInput;
    }
}
else
{
    File.Create(path).Close();
    goto fileSearch;
}
static string[] ReadFile(string path)
{
    string[] lines = File.ReadAllLines(path);
    return lines;
}

static void WriteFile(string[] text, string path)
{
    File.WriteAllLines(path, text);
}

static void Show(List<string> list)
{
    Console.Clear();
    for (int i = 0; i < list.Count(); i++)
    {
        Console.WriteLine(list[i]);
    }
}