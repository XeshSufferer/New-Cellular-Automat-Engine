using Automat.StandartRules;
using System.IO;
using System.Text.Json;
using Automat.Debug;

namespace Automat.CustomRules
{
    public static class CustomRulesReader
    {
        private static ILogger _logger;

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static CustomJsonRule FindRuleByName(string name)
        {
            List<CustomJsonRule> rules = ReadRules();
            for(int i = 0; i != rules.Count; i++)
            {
                if(rules[i].Name == name)
                {
                    return rules[i];
                }
            }
            _logger.Log("Rule not found by name: " + name);
            throw new Exception("Rule not found by name: " + name);
        }

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
                _logger.Log("Custom rules directory not found");
                throw new Exception("Custom rules directory not found");
            }
        }
    }
}