using Automat.Maps;
using Automat.ExampleSystem;
using Automat.StandartRules;

namespace Automat.CustomRules
{
    public class CustomJsonRule : IRule
    {
        public string Name { get; set; }

        public List<string> WritedConditions { get; set; } = new List<string>();


        public void Apply(Cell cell)
        {
            foreach(var writedCondition in WritedConditions)
            {
                if(ExamplesFactory.Conditions.ContainsKey(writedCondition))
                {
                    if(ExamplesFactory.Conditions[writedCondition](cell)) cell.IsAlive = true;
                }
                else
                {
                    throw new Exception($"Condition is invalid ({writedCondition})");
                }
            }
        }
    }
}