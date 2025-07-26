using Automat.Maps;

namespace Automat.ExampleSystem
{
    public static class ExamplesFactory
    {

        public static Dictionary<string, Func<Cell, bool>> Conditions { get; } = new Dictionary<string, Func<Cell, bool>>
        {
            {"001", cell => UseExample(Examples.FalseFalseTrue, cell)},
            {"010", cell => UseExample(Examples.FalseTrueFalse, cell)},
            {"100", cell => UseExample(Examples.TrueFalseFalse, cell)},
            {"110", cell => UseExample(Examples.TrueTrueFalse, cell)},
            {"111", cell => UseExample(Examples.TrueTrueTrue, cell)},
            {"011", cell => UseExample(Examples.FalseTrueTrue, cell)},
            {"101", cell => UseExample(Examples.TrueFalseTrue, cell)},
            {"000", cell => UseExample(Examples.FalseFalseFalse, cell)}
        };


        public static bool UseExample(Examples example, Cell cell)
        {
            return example switch
            {
                Examples.TrueTrueFalse => cell.GetTopLeftCellValue() && cell.GetTopRightCellValue() && !cell.GetTopCellValue(),
                Examples.TrueTrueTrue => cell.GetTopLeftCellValue() && cell.GetTopRightCellValue() && cell.GetTopCellValue(),
                Examples.TrueFalseFalse => cell.GetTopLeftCellValue() && !cell.GetTopRightCellValue() && !cell.GetTopCellValue(),
                Examples.TrueFalseTrue => cell.GetTopLeftCellValue() && !cell.GetTopRightCellValue() && cell.GetTopCellValue(),
                Examples.FalseTrueFalse => !cell.GetTopLeftCellValue() && cell.GetTopRightCellValue() && !cell.GetTopCellValue(),
                Examples.FalseTrueTrue => !cell.GetTopLeftCellValue() && cell.GetTopRightCellValue() && cell.GetTopCellValue(),
                Examples.FalseFalseFalse => !cell.GetTopLeftCellValue() && !cell.GetTopRightCellValue() && !cell.GetTopCellValue(),
                Examples.FalseFalseTrue => !cell.GetTopLeftCellValue() && !cell.GetTopRightCellValue() && cell.GetTopCellValue(),
                _ => throw new Exception("Invalid example"),
            };
        }
    }
}