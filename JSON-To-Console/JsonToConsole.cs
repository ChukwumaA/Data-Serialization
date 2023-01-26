using System.Text.Json;

namespace JSON_To_Console;

public static class JsonToConsole
{
    public static T ReadAsJsonFormat<T>(string fileName) =>
        JsonSerializer.Deserialize<T>(File.ReadAllText(fileName))!;
}