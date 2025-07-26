using Automat.StandartRules;
using System.IO;
using System.Text.Json;

namespace Automat.CustomRules
{
    public static class CustomRulesReader
    {

        public static void GenerateExampleJsonRule()
        {
            if(File.Exists("CustomRules\\ExampleRule.json")) return;
            var rule = new CustomJsonRule
            {
                Name = "ExampleRule",
                WritedConditions = new List<string>{"001", "010", "100"},
            };
            Directory.CreateDirectory("CustomRules");
            File.WriteAllText("CustomRules\\ExampleRule.json", JsonSerializer.Serialize(rule));
        }

        public static List<CustomJsonRule> ReadRules()
        {   
            string path = Directory.GetCurrentDirectory() + "\\CustomRules";
            
            if(Directory.Exists(path))
            {
                return Directory.GetFiles(path, "*.json").Select(file => JsonSerializer.Deserialize<CustomJsonRule>(File.ReadAllText(file))).ToList() ?? new List<CustomJsonRule>();

            }
            else
            {
                throw new Exception("Custom rules directory not found");
            }
        }
    }
}