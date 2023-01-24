namespace TXT_T0_Console;

public static class TxtToConsole
{
    public static void PrintToConsole()
    {
        const string fileLocation = "C:\\Users\\Chikosolu Akunyili\\RiderProjects\\Data Serialization\\SerializedOutput\\Outputs\\GetDocs.txt";
        
        foreach (var items in File.ReadAllLines(fileLocation))
        {
            Console.WriteLine(items);
        }
    }
}