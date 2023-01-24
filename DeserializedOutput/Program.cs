using AttributeContent.Model;
using TXT_T0_Console;
using static JSON_To_Console.JsonToConsole;

TxtToConsole.PrintToConsole();


const string fileLocation = "C:\\Users\\Chikosolu Akunyili\\RiderProjects\\Data Serialization\\SerializedOutput\\Outputs\\GetDocs.json";
ReadAsJsonFormat<CustomData>(fileLocation);