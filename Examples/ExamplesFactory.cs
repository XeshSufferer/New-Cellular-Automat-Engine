using Automat.Maps;

namespace Automat.ExampleSystem
{
    public static class ExamplesFactory
    {

        private static Random random = new Random();


        public static Dictionary<string, Func<Cell, bool>> Conditions { get; } = new Dictionary<string, Func<Cell, bool>>
        {
            {"001", cell => UseExample(Examples.FalseFalseTrue, cell)},
            {"010", cell => UseExample(Examples.FalseTrueFalse, cell)},
            {"100", cell => UseExample(Examples.TrueFalseFalse, cell)},
            {"110", cell => UseExample(Examples.TrueTrueFalse, cell)},
            {"111", cell => UseExample(Examples.TrueTrueTrue, cell)},
            {"011", cell => UseExample(Examples.FalseTrueTrue, cell)},
            {"101", cell => UseExample(Examples.TrueFalseTrue, cell)},
            {"000", cell => UseExample(Examples.FalseFalseFalse, cell)},


            {"001_p50", cell => UseExample(Examples.FalseFalseTrue, cell) && random.Next(0, 100) < 50},
            {"010_p50", cell => UseExample(Examples.FalseTrueFalse, cell) && random.Next(0, 100) < 50},
            {"100_p50", cell => UseExample(Examples.TrueFalseFalse, cell) && random.Next(0, 100) < 50},
            {"110_p50", cell => UseExample(Examples.TrueTrueFalse, cell) && random.Next(0, 100) < 50},
            {"111_p50", cell => UseExample(Examples.TrueTrueTrue, cell) && random.Next(0, 100) < 50},
            {"011_p50", cell => UseExample(Examples.FalseTrueTrue, cell) && random.Next(0, 100) < 50},
            {"101_p50", cell => UseExample(Examples.TrueFalseTrue, cell) && random.Next(0, 100) < 50},
            {"000_p50", cell => UseExample(Examples.FalseFalseFalse, cell) && random.Next(0, 100) < 50},


            {"001_p25", cell => UseExample(Examples.FalseFalseTrue, cell) && random.Next(0, 100) < 25},
            {"010_p25", cell => UseExample(Examples.FalseTrueFalse, cell) && random.Next(0, 100) < 25},
            {"100_p25", cell => UseExample(Examples.TrueFalseFalse, cell) && random.Next(0, 100) < 25},
            {"110_p25", cell => UseExample(Examples.TrueTrueFalse, cell) && random.Next(0, 100) < 25},
            {"111_p25", cell => UseExample(Examples.TrueTrueTrue, cell) && random.Next(0, 100) < 25},
            {"011_p25", cell => UseExample(Examples.FalseTrueTrue, cell) && random.Next(0, 100) < 25},
            {"101_p25", cell => UseExample(Examples.TrueFalseTrue, cell) && random.Next(0, 100) < 25},
            {"000_p25", cell => UseExample(Examples.FalseFalseFalse, cell) && random.Next(0, 100) < 25},


            {"001_p10", cell => UseExample(Examples.FalseFalseTrue, cell) && random.Next(0, 100) < 10},
            {"010_p10", cell => UseExample(Examples.FalseTrueFalse, cell) && random.Next(0, 100) < 10},
            {"100_p10", cell => UseExample(Examples.TrueFalseFalse, cell) && random.Next(0, 100) < 10},
            {"110_p10", cell => UseExample(Examples.TrueTrueFalse, cell) && random.Next(0, 100) < 10},
            {"111_p10", cell => UseExample(Examples.TrueTrueTrue, cell) && random.Next(0, 100) < 10},
            {"011_p10", cell => UseExample(Examples.FalseTrueTrue, cell) && random.Next(0, 100) < 10},
            {"101_p10", cell => UseExample(Examples.TrueFalseTrue, cell) && random.Next(0, 100) < 10},
            {"000_p10", cell => UseExample(Examples.FalseFalseFalse, cell) && random.Next(0, 100) < 10},


            {"001_p75", cell => UseExample(Examples.FalseFalseTrue, cell) && random.Next(0, 100) < 75},
            {"010_p75", cell => UseExample(Examples.FalseTrueFalse, cell) && random.Next(0, 100) < 75},
            {"100_p75", cell => UseExample(Examples.TrueFalseFalse, cell) && random.Next(0, 100) < 75},
            {"110_p75", cell => UseExample(Examples.TrueTrueFalse, cell) && random.Next(0, 100) < 75},
            {"111_p75", cell => UseExample(Examples.TrueTrueTrue, cell) && random.Next(0, 100) < 75},
            {"011_p75", cell => UseExample(Examples.FalseTrueTrue, cell) && random.Next(0, 100) < 75},
            {"101_p75", cell => UseExample(Examples.TrueFalseTrue, cell) && random.Next(0, 100) < 75},
            {"000_p75", cell => UseExample(Examples.FalseFalseFalse, cell) && random.Next(0, 100) < 75}
        };


        public static bool UseExample(Examples example, Cell cell)
        {
            return example switch
            {
                Examples.TrueTrueFalse => cell.GetTopLeftCellValue() && cell.GetTopCellValue() && !cell.GetTopRightCellValue(),
                Examples.TrueTrueTrue => cell.GetTopLeftCellValue() && cell.GetTopCellValue() && cell.GetTopRightCellValue(),
                Examples.TrueFalseFalse => cell.GetTopLeftCellValue() && !cell.GetTopCellValue() && !cell.GetTopRightCellValue(),
                Examples.TrueFalseTrue => cell.GetTopLeftCellValue() && !cell.GetTopCellValue() && cell.GetTopRightCellValue(),
                Examples.FalseTrueFalse => !cell.GetTopLeftCellValue() && cell.GetTopCellValue() && !cell.GetTopRightCellValue(),
                Examples.FalseTrueTrue => !cell.GetTopLeftCellValue() && cell.GetTopCellValue() && cell.GetTopRightCellValue(),
                Examples.FalseFalseFalse => !cell.GetTopLeftCellValue() && !cell.GetTopCellValue() && !cell.GetTopRightCellValue(),
                Examples.FalseFalseTrue => !cell.GetTopLeftCellValue() && !cell.GetTopCellValue() && cell.GetTopRightCellValue(),
                _ => throw new Exception("Invalid example"),
            };
        }
    }
}