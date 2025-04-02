namespace Wolfenstein.Domain;

public class Map
{
    public uint Height { get; }

    public uint Width { get; }
    public Cell[,] Cells { get; }

    public Map(uint width, uint height)
    {
        this.Width = width;
        this.Height = height;
        Cells = new Cell[Height, Width];
        RegenerateMap();
    }

    private void RegenerateMap()
    {
        for (uint y = 0; y < Height; y++)
        {
            for (uint x = 0; x < Width; x++)
            {
                Cells[y, x] = new Cell();
            }
        }
    }

    public static class Factory
    {
        public static Map CreateEmptyMap(uint width, uint height)
        {
            Map map = new Map(width, height);
            foreach (var cell in map.Cells)
            {
                cell.Type = CellType.Empty;
            }

            return map;
        }
        public static Map CreateWallMap(uint width, uint height)
        {
            Map map = new Map(width, height);
            foreach (var cell in map.Cells)
            {
                cell.Type = CellType.Wall;
            }

            return map;
        }
        
        public static Map CreateBoundsMap(uint width, uint height)
        {
            Map map = new Map(width, height);
            for (uint y = 0; y < height; y++)
            {
                for (uint x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
                    {
                        map.Cells[y, x].Type = CellType.Wall;
                    }
                    else
                    {
                        map.Cells[y, x].Type = CellType.Empty;
                    }
                }
            }

            return map;
        }
        
        
    }
}