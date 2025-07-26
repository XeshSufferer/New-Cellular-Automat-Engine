using Automat.Maps;
using Automat.ExampleSystem;
using Automat.StandartRules;

namespace Automat.StandartRules
{
    public class Rule30 : Rule
    {
        public override void Apply(Cell cell)
        {
            if
            (
                ExamplesFactory.UseExample(Examples.TrueFalseFalse, cell)
                || ExamplesFactory.UseExample(Examples.FalseTrueTrue, cell)
                || ExamplesFactory.UseExample(Examples.FalseFalseTrue, cell)
                || ExamplesFactory.UseExample(Examples.FalseTrueFalse, cell)
            )
            {
                cell.IsAlive = true;
            }
        }
    }
}