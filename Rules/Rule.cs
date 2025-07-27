using Automat.Maps;

namespace Automat.StandartRules
{
    public abstract class Rule : IRule
    {
        public abstract void Apply(Cell cell);
    }
}