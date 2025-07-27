using Automat.Maps;
using System.Text;

namespace Automat
{
    public class Writer
    {
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
    }
}