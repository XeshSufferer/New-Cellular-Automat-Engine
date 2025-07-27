using Automat.Maps;
using System.Text;

namespace Automat
{
    public class Writer
    {

        public Writer(Maps.Generator.MapRegenerator mapRegenerator)
        {
            mapRegenerator.OnGenerationProgress += LogGenerationProgress;
        }

        public void Write(Map map)
        {


            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < map.Cells.Count; i++)
            {
                for (int j = 0; j < map.Cells[i].Count; j++)
                {
                    stringBuilder.Append(map.Cells[i][j].IsAlive ? "█" : " ");
                }
                stringBuilder.AppendLine();
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private void LogGenerationProgress(int currentGeneration, int totalGenerations)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Generation {currentGeneration}/{totalGenerations}");
        }
    }
}