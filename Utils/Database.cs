using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuelsServer.Utils
{
    internal class Database
    {
        public static JsonSerializerOptions JSON_options = new()
        {
            WriteIndented = false,
            IncludeFields = false
        };
        public static JsonSerializerOptions Pretty_JSON_options = new()
        {
            WriteIndented = true,
            IncludeFields = true
        };

        public static Dictionary<string, TeleportsData> teleports { get; set; }
    }
}
