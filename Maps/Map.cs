namespace Automat.Maps
{
    public class Map
    {
        public List<List<Cell>> Cells;
        public int Width;
        public int Height;

        public static void CopyMap(Map source, Map target)
        {
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    target.SetCellValue(x, y, source.GetCellValue(x, y));
                }
            }
        }

        public Map(int width, int height)
        {
            this.Cells = new List<List<Cell>>(height);
            for (int i = 0; i < height; i++)
            {
                this.Cells.Add(new List<Cell>(width));
                for (int j = 0; j < width; j++)
                {
                    this.Cells[i].Add(new Cell(this, j, i));
                }
            }
            this.Width = width;
            this.Height = height;
        }

        public Map Clone()
        {   
            Map newMap = new Map(this.Cells[0].Count, this.Cells.Count);
            for (int i = 0; i < this.Cells.Count; i++)
            {
                for (int j = 0; j < this.Cells[i].Count; j++)
                {
                    newMap.Cells[i][j] = new Cell(newMap, j, i, this.Cells[i][j].IsAlive);
                }
            }
            return newMap;
        }

        public void FullSeed()
        {
            for(int i = 0; i < this.Width; i++)
            {
                this.SetCellValue(i, 0, true);
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= this.Width || y < 0 || y >= this.Height) return null;
            return this.Cells[y][x];
        }

        public bool GetCellValue(int x, int y)
        {
            if (x < 0 || x >= this.Width || y < 0 || y >= this.Height) return false;
            return this.Cells[y][x].IsAlive;
        }

        public void SetCellValue(int x, int y, bool value)
        {
            if (x < 0 || x >= this.Width || y < 0 || y >= this.Height) return;
            this.Cells[y][x].IsAlive = value;
        }
    }
}