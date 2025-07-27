using Automat.Maps;
using System.Text;

namespace Automat
{
    public class Writer
    {
        private StringBuilder _stringBuilder = new StringBuilder();

        public Writer(Maps.Generator.MapRegenerator mapRegenerator)
        {
            mapRegenerator.OnGenerationProgress += LogGenerationProgress;
        }

        public void Write(Map map)
        {
            for (int i = 0; i < map.Cells.Count; i++)
            {
                for (int j = 0; j < map.Cells[i].Count; j++)
                {
                    _stringBuilder.Append(map.Cells[i][j].IsAlive ? "█" : " ");
                }
                _stringBuilder.AppendLine();
            }

            Console.WriteLine(_stringBuilder.ToString());
            _stringBuilder.Clear();
        }

        private void LogGenerationProgress(int currentGeneration, int totalGenerations)
        {
            Console.WriteLine($"Generation {currentGeneration}/{totalGenerations}");
        }
    }
}