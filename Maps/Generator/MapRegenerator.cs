using Automat.Maps;
using Automat.StandartRules;
using Automat.Maps.Generator;
using Automat.CustomRules;

namespace Automat.Maps.Generator
{
    public class MapRegenerator
    {

        private Random globalRandom = new Random();

        public event Action<int, int> OnGenerationProgress;

        private Map buffer1;
        private Map buffer2;

        public MapRegenerator(Map injectedMap)
        {
            buffer1 = injectedMap.Clone();
            buffer2 = injectedMap.Clone();
        }

        public Map Regenerate(Map map, IRule rule, GenerationType generationType)
        {
            return generationType switch
            {
                GenerationType.FullSeed => RegenerateWithFullSeed(map, rule),
                GenerationType.RandomSeed => RegenerateWithRandomSeed(map, rule),
                GenerationType.RandomDot => RegenerateWithRandomDot(map, rule),
                _ => Regenerate(map, rule),
            };
        }

        public Map RegenerateWithRandomDot(Map map, IRule rule)
        {
            Map newMap = map.Clone();
            newMap.SetCellValue(globalRandom.Next(0, newMap.Width), 0, true);
            return Regenerate(newMap, rule);
        }

        public Map Regenerate(Map map, IRule rule)
        {
            Map source = buffer1;
            Map target = buffer2;
            
            Map.CopyMap(map, source);
            
            for (int y = 1; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Cell cell = target.GetCell(x, y);
                    cell.IsAlive = source.GetCellValue(x, y);
                    rule.Apply(cell);
                }

                if(y % 200 == 0)
                {
                    OnGenerationProgress?.Invoke(y, source.Height);
                }
            }
            
            var temp = buffer1;
            buffer1 = buffer2;
            buffer2 = temp;
            
            return buffer1;
        }

        public Map RegenerateWithRandomSeed(Map map, IRule rule)
        {
            Map newMap = map.Clone();
            for(int i = 0; i != newMap.Width; i++)
            {
                newMap.SetCellValue(i, 0, globalRandom.Next(0, 2) == 1);
            }
            
            
            return Regenerate(newMap, rule);
        }

        public Map RegenerateWithFullSeed(Map map, IRule rule)
        {
            Map newMap = map.Clone();

            newMap.FullSeed();

            return Regenerate(newMap, rule);
        }


        

    }
}