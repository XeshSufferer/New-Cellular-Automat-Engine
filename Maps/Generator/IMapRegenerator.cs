using Automat.StandartRules;


namespace Automat.Maps.Generator
{
    public interface IMapRegenerator
    {
        Map RegenerateWithFullSeed(Map map, IRule rule);
        Map RegenerateWithRandomSeed(Map map, IRule rule);
        Map Regenerate(Map map, IRule rule);
        Map RegenerateWithRandomDot(Map map, IRule rule);
        Map Regenerate(Map map, IRule rule, GenerationType generationType);
        public event Action<int, int> OnGenerationProgress;
    }
}