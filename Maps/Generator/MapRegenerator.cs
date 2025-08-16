using Automat.Maps;
using Automat.StandartRules;
using Automat.Maps.Generator;
using Automat.CustomRules;

namespace Automat.Maps.Generator
{
    public class MapRegenerator : IMapRegenerator
    {

        private Random _globalRandom = new Random();

        public event Action<int, int> OnGenerationProgress;

        private Map _cleanMap;
        private Map _bufferMap;

        public MapRegenerator(Map injectedMap)
        {
            _cleanMap = injectedMap.Clone();
            _bufferMap = injectedMap.Clone();
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
            newMap.SetCellValue(_globalRandom.Next(0, newMap.Width), 0, true);
            return Regenerate(newMap, rule);
        }

        public Map Regenerate(Map map, IRule rule)
        {
            Map cleanMap = _cleanMap;
            Map bufferMap = _bufferMap;
            
            Map.CopyMap(map, cleanMap);
            
            for (int y = 1; y < cleanMap.Height; y++)
            {
                for (int x = 0; x < cleanMap.Width; x++)
                {
                    Cell cell = bufferMap.GetCell(x, y);
                    rule.Apply(cell);
                }

                if(y % 200 == 0)
                {
                    OnGenerationProgress?.Invoke(y, cleanMap.Height);
                }
            }
            
            var temp = _cleanMap;
            _cleanMap = _bufferMap;
            _bufferMap = temp;
            
            return _cleanMap;
        }

        public Map RegenerateWithRandomSeed(Map map, IRule rule)
        {
            Map newMap = map.Clone();
            for(int i = 0; i != newMap.Width; i++)
            {
                newMap.SetCellValue(i, 0, _globalRandom.Next(0, 2) == 1);
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