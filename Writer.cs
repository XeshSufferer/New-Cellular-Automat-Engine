using Automat.Maps;

namespace Automat
{
    public class Writer
    {
        public void Write(Map map)
        {
            for (int i = 0; i < map.Cells.Count; i++)
            {
                for (int j = 0; j < map.Cells[i].Count; j++)
                {
                    Console.Write(map.Cells[i][j].IsAlive ? "█" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}