using Automat.Maps;
using Automat.ExampleSystem;
using Automat.StandartRules;

namespace Automat.StandartRules
{
    public class Rule110 : Rule
    {
        public override void Apply(Cell cell)
        {
            if
            (
                ExamplesFactory.UseExample(Examples.TrueTrueFalse, cell)
                || ExamplesFactory.UseExample(Examples.TrueFalseTrue, cell)
                || ExamplesFactory.UseExample(Examples.FalseTrueTrue, cell)
                || ExamplesFactory.UseExample(Examples.FalseTrueFalse, cell)
                || ExamplesFactory.UseExample(Examples.FalseFalseTrue, cell)
            )
            {
                cell.IsAlive = true;
            }
        }
    }
}