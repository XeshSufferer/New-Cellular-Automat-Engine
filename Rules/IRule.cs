using Automat.Maps;

namespace Automat.StandartRules
{
    public interface IRule
    {
        void Apply(Cell cell);
    }
}