using System.Text.Json;
using Automat.StandartSettings;
using Automat.Maps.Generator;
using Automat.StandartRules;

namespace Automat.StandartSettings
{
    public static class SettingsReader
    {
        public static Settings ReadSettings(string path)
        {
            if (File.Exists(path))
            {
                return JsonSerializer.Deserialize<Settings>(File.ReadAllText(path)) ?? AutoGenerateSettings();
            }
            else
            {
                return AutoGenerateSettings();
            }
        }

        public static Settings AutoGenerateSettings()
        {
            Settings settings = new Settings();
                settings.Width = 1200;
                settings.Height = 600;
                settings.GenerationType = GenerationType.RandomDot;
                settings.GenerationCount = 100;
                settings.Delay = 100;
                settings.Rule = Rules.Rule22;
                settings.JsonMode = false;
                settings.JsonRule = "ExampleRule";

                if (!File.Exists("settings.json"))
                {
                    File.WriteAllText("settings.json", JsonSerializer.Serialize(settings));
                }

                return settings;
        }
    }
}