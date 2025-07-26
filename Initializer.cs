using Automat.StandartSettings;
using Automat.Maps;
using Automat.StandartRules;
using Automat.Maps.Generator;
using Automat.CustomRules;

namespace Automat
{
    public class Initializer
    {
        public static void Main()
        {
            Initializer initializer = new Initializer();
            initializer.Initialize();
        }


        public void Initialize()
        {
            Settings settings = SettingsReader.ReadSettings("settings.json");
            CustomRulesReader.GenerateExampleJsonRule();
            var jsonRules = CustomRulesReader.ReadRules();
            Map map = new Map(settings.Width, settings.Height);
            Rule rule = RuleFactory.CreateRule(settings.Rule);

            switch(settings.JsonMode)
            {
                case true:
                    {
                        for(int i = 0; i != jsonRules.Count; i++)
                        {
                            if(jsonRules[i].Name == settings.JsonRule)
                            {
                                WorkWithJsonMode(map, jsonRules[i], settings.GenerationCount, settings.Delay, settings);
                                break;
                            }
                        }
                        throw new Exception("Rule not found by name " + settings.JsonRule);
                        break;
                    }
                case false:
                    {
                        Work(map, rule, settings.GenerationCount, settings.Delay, settings);
                        break;
                    }
            }
        }

        private void Work(Map map, Rule rule, int generationCount, int delay, Settings settings)
        {
            Writer writer = new Writer();
            MapRegenerator mapRegenerator = new MapRegenerator();

            for(int i = 0; i != generationCount; i++)
            {
                Map newMap = map.Clone();
                Map usableMap = mapRegenerator.Regenerate(newMap, rule, settings.GenerationType);
                writer.Write(usableMap);
                if(delay > 0)
                {
                    Thread.Sleep(delay);
                }
                else
                {
                    Console.ReadKey();
                }

                Console.Clear();
            }
            Console.ReadKey();
        }

        private void WorkWithJsonMode(Map map, CustomJsonRule jsonRule, int generationCount, int delay, Settings settings)
        {
            Writer writer = new Writer();
            MapRegenerator mapRegenerator = new MapRegenerator();

            for(int i = 0; i != generationCount; i++)
            {
                Map newMap = map.Clone();
                Map usableMap = mapRegenerator.Regenerate(newMap, jsonRule, settings.GenerationType);
                writer.Write(usableMap);
                if(delay > 0)
                {
                    Thread.Sleep(delay);
                }
                else
                {
                    Console.ReadKey();
                }

                Console.Clear();
            }
            Console.ReadKey();
        }   
    }
}