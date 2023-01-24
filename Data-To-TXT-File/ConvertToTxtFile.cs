using System.IO;

namespace Data_To_TXT_File
{
    public static class ConvertToTxtFile
    {
        public static void Create_TXT_File(string text, string fileName)
        {
            using (var writer = File.CreateText(fileName))
            {
                writer.Write(text);
                writer.Write(writer.NewLine);
            }
        }
    }
}