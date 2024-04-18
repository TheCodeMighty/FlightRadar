using System.Text.Json;

namespace FlightRadar
{
    public static class JsonDataWriter
    {
        public static void SerializeToJson<T>(T objects, string fileName)
        {
            string outputPath = FilePathFinder.FindFilePath(fileName);

            // Defining the JSON serialization options(so it puts a new line after each object)
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(objects, options);

            File.WriteAllText(outputPath, jsonString);
        }
    }
}