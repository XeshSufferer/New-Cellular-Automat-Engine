using Automat.StandartSettings;
using Automat.Maps;
using Automat.StandartRules;
using Automat.Maps.Generator;
using Automat.CustomRules;
using Automat.Debug;
using System;
using Automat.ExampleSystem;

namespace Automat
{
    public class Initializer : IDisposable
    {

        private ILogger _logger;
        public static void Main()
        {
            ILogger logger = new BaseLogger();
            Initializer initializer = new Initializer(logger);

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                initializer.Dispose();
                Environment.Exit(0);
            };
            
            AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
            {
                initializer.Dispose(); 
            };


            initializer.Initialize();
        }

        public Initializer(ILogger logger)
        {
            _logger = logger;
            _logger.Log("[PROGRAM STARTING]");
        }

        public void Dispose()
        {
            _logger.Log("[PROGRAM ENDING]");
            _logger.SaveAllLogs();
        }


        public void Initialize()
        {
            Settings settings = SettingsReader.ReadSettings("settings.json");
            CustomRulesReader.GenerateExampleJsonRule();
            Map map = new Map(settings.Width, settings.Height);

            ExamplesFactory.SetLogger(_logger);
            CustomRulesReader.SetLogger(_logger);

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

            Map clearMap = map.Clone();
            Map newMap = clearMap.Clone();

            for(int i = 0; i != generationCount; i++)
            {

                Map.CopyMap(clearMap, newMap);

                writer.Write(mapRegenerator.Regenerate(newMap, rule, settings.GenerationType));
                
                if(delay > 0)
                {
                    Thread.Sleep(delay);
                }
                else
                {
                    Console.ReadKey();
                }

                Console.SetCursorPosition(0, 0);
            }
            Console.ReadKey();
        }
    }
}