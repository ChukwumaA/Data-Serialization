using System.Text.Json;

namespace Data_To_JSON;

public static class ConvertToJson
{
    public static void SaveAsJsonFormat<T>(T typeToSerialize, string fileName)
    {
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
            WriteIndented = true
        };
        File.WriteAllText(fileName, JsonSerializer.Serialize(typeToSerialize, options));
    }
    
    

    
}