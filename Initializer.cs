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
            Map map = new Map(settings.Width, settings.Height);

            AutoFindAndWork(map, settings);
        }

        private void AutoFindAndWork(Map map, Settings settings)
        {
            switch(settings.JsonMode)
            {
                case true:
                    {
                        Work(map, CustomRulesReader.FindRuleByName(settings.JsonRule), settings.GenerationCount, settings.Delay, settings);
                        break;
                    }
                case false:
                    {
                        Work(map, RuleFactory.CreateRule(settings.Rule), settings.GenerationCount, settings.Delay, settings);
                        break;
                    }
            }
        }

        private void Work(Map map, IRule rule, int generationCount, int delay, Settings settings)
        {
            MapRegenerator mapRegenerator = new MapRegenerator(map);
            Writer writer = new Writer(mapRegenerator);

            for(int i = 0; i != generationCount; i++)
            {
                Map newMap = map.Clone();
                
                writer.Write(mapRegenerator.Regenerate(newMap, rule, settings.GenerationType));
                
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