namespace Automat.StandartRules
{
    public class RuleFactory
    {
        public static Rule CreateRule(Rules rule)
        {
            return rule switch
            {
                Rules.Rule22 => new Rule22(),
                Rules.Rule110 => new Rule110(),
                Rules.Rule30 => new Rule30(),
                _ => throw new Exception("Invalid rule")
            };
        }
}
}