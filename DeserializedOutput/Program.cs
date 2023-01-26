
using AttributeContent.Implementation;
using AttributeContent.Model;
using TXT_T0_Console;
using static JSON_To_Console.JsonToConsole;


TxtToConsole.PrintToConsole();


const string fileLocation = "C:\\Users\\Chikosolu Akunyili\\RiderProjects\\Data Serialization\\SerializedOutput\\Outputs\\GetDocs.json";

var readJson = ReadAsJsonFormat<List<CustomData>>(fileLocation);

foreach (var data in readJson)
{
    Console.WriteLine($"{data.Name}, \n{data.Description}, {data.Input}, {data.Output}");
    Console.WriteLine();
}
