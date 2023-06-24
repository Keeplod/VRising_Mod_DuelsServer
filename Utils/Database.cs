using System.Text.Json;

namespace DuelsServer.Utils
{
    internal class Database
    {
        public static JsonSerializerOptions JSON_options = new()
        {
            WriteIndented = false,
            IncludeFields = false
        };
    }
}
