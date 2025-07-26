namespace Automat.Maps
{
    public class Cell
    {

        public Map ParentMap;
        public int X;
        public int Y;
        public bool IsAlive;

        public Cell(Map parentMap, int x, int y)
        {
            this.ParentMap = parentMap;
            this.X = x;
            this.Y = y;
            this.IsAlive = false;
        }

        public Cell(Map parentMap, int x, int y, bool isAlive)
        {
            this.ParentMap = parentMap;
            this.X = x;
            this.Y = y;
            this.IsAlive = isAlive;
        }

        public bool GetSelfCellValue()
        {
            return this.ParentMap.GetCellValue(this.X, this.Y);
        }

        public bool GetTopRightCellValue()
        {
            return this.ParentMap.GetCellValue(this.X + 1, this.Y - 1);
        }

        public bool GetTopCellValue()
        {
            return this.ParentMap.GetCellValue(this.X, this.Y - 1);
        }

        public bool GetTopLeftCellValue()
        {
            return this.ParentMap.GetCellValue(this.X - 1, this.Y - 1);
        }

        
        
        }
}