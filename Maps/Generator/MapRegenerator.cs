using Automat.Maps;
using Automat.StandartRules;
using Automat.Maps.Generator;
using Automat.CustomRules;

namespace Automat.Maps.Generator
{
    public class MapRegenerator
    {

        public Map Regenerate(Map map, Rule rule, GenerationType generationType)
        {
            return generationType switch
            {
                GenerationType.FullSeed => RegenerateWithFullSeed(map, rule),
                GenerationType.RandomSeed => RegenerateWithRandomSeed(map, rule),
                GenerationType.RandomDot => RegenerateWithRandomDot(map, rule),
                _ => Regenerate(map, rule),
            };
        }

        public Map Regenerate(Map map, CustomJsonRule rule, GenerationType generationType)
        {
            return generationType switch
            {
                GenerationType.FullSeed => RegenerateWithFullSeed(map, rule),
                GenerationType.RandomSeed => RegenerateWithRandomSeed(map, rule),
                GenerationType.RandomDot => RegenerateWithRandomDot(map, rule),
                _ => Regenerate(map, rule),
            };
        }
        public Map RegenerateWithRandomDot(Map map, Rule rule)
        {
            Map newMap = map.Clone();
            Random random = new Random();
            newMap.SetCellValue(random.Next(0, newMap.Width), 0, true);
            return Regenerate(newMap, rule);
        }

        public Map RegenerateWithRandomDot(Map map, CustomJsonRule rule)
        {
            Map newMap = map.Clone();
            Random random = new Random();
            newMap.SetCellValue(random.Next(0, newMap.Width), 0, true);
            return Regenerate(newMap, rule);
        }

        public Map Regenerate(Map map, Rule rule)
        {
            Map newMap = map.Clone();
            for (int i = 1; i < map.Cells.Count; i++)
            {
                for (int j = 0; j < map.Cells[i].Count; j++)
                {
                    rule.Apply(newMap.GetCell(j, i));
                }
            }
            return newMap;
        }

        public Map RegenerateWithRandomSeed(Map map, Rule rule)
        {
            Map newMap = map.Clone();
            Random random = new Random();
            for(int i = 0; i != newMap.Width; i++)
            {
                newMap.SetCellValue(i, 0, random.Next(0, 2) == 1);
            }
            
            
            return Regenerate(newMap, rule);
        }

        public Map RegenerateWithRandomSeed(Map map, CustomJsonRule rule)
        {
            Map newMap = map.Clone();
            Random random = new Random();
            for(int i = 0; i != newMap.Width; i++)
            {
                newMap.SetCellValue(i, 0, random.Next(0, 2) == 1);
            }
            
            
            return Regenerate(newMap, rule);
        }

        public Map RegenerateWithFullSeed(Map map, Rule rule)
        {
            Map newMap = map.Clone();

            newMap.FullSeed();

            for (int y = 1; y < newMap.Height; y++)
            {
                for (int x = 0; x < newMap.Width; x++)
                {
                    rule.Apply(newMap.GetCell(x, y));
                }
            }
            return newMap;
        }

        public Map RegenerateWithFullSeed(Map map, CustomJsonRule rule)
        {
            Map newMap = map.Clone();

            newMap.FullSeed();

            for (int y = 1; y < newMap.Height; y++)
            {
                for (int x = 0; x < newMap.Width; x++)
                {
                    rule.Apply(newMap.GetCell(x, y));
                }
            }
            return newMap;
        }


        public Map Regenerate(Map map, CustomJsonRule rule)
        {
            Map newMap = map.Clone();
            for (int i = 1; i < newMap.Cells.Count; i++)
            {
                for (int j = 0; j < newMap.Cells[i].Count; j++)
                {
                    rule.Apply(newMap.GetCell(j, i));
                }
            }
            return newMap;
        }

    }
}