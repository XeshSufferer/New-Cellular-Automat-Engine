using System.Text.Json;
using System.Text.Json.Serialization;
using Automat.Maps;
using Automat.StandartRules;
using Automat.Maps.Generator;

namespace Automat.StandartSettings
{
    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GenerationType GenerationType { get; set; }
        public int GenerationCount { get; set; }
        public int Delay { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Rules Rule { get; set; }

        public bool JsonMode { get; set; }
        public string JsonRule { get; set; }
    }
}