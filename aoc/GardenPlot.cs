namespace aoc;

public class GardenPlot(char[,] input)
{
    private char [,] _plot = input;

    public static GardenPlot FromString(string input)
    {
        var lines = input.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.None
        );
        var plot = new char[lines.Length, lines[0].Length];
        for (var row = 0; row < lines.Length; row++)
        {
            for (var col = 0; col < lines.Length; col++)
            {
                plot[row, col] = lines[row][col];
            }
        }
        return new GardenPlot(plot);
    }

    public (int Area, int Perimeter, int Corners)[] GetPlots()
    {
        var area = new List<(int Area, int Perimeter, int Corners)>();
        var scanned = new bool[_plot.GetLength(0), _plot.GetLength(1)];
        for (var row = 0; row < _plot.GetLength(0); row++)
        {
            for (var col = 0; col < _plot.GetLength(1); col++)
            {
                 if (scanned[row, col])
                     continue;
                 area.Add(ScanPlot(row, col, scanned));
            }
        }
        return area.ToArray();
    }

    private (int Area, int Perimeter, int Corners) ScanPlot(int row, int col, bool[,] scanned)
    {
        var result = (Area: 0, Perimeter: 0, Corners: 0);
        var plotDesignator = _plot[row, col];
        ScanPlot2(row, col, scanned, plotDesignator, ref result);
        return result;
    }

    private void ScanPlot2(
        int row, 
        int col, 
        bool[,] scanned, 
        char plotDesignator, 
        ref (int Area, int Perimeter, int Corners) result)
    {
        try
        {
            if (scanned[row, col] || _plot[row, col] != plotDesignator)
                return;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }

        scanned[row, col] = true;
        result.Area++;
        result.Perimeter +=
            IsPerimeter(row , col + 1, plotDesignator) +
            IsPerimeter(row , col - 1, plotDesignator) +
            IsPerimeter(row + 1, col, plotDesignator) +
            IsPerimeter(row - 1, col, plotDesignator);
        result.Corners += HowManyCornersAt(row, col, plotDesignator);
        
        ScanPlot2(row, col + 1, scanned, plotDesignator, ref result);
        ScanPlot2(row, col - 1, scanned, plotDesignator, ref result);
        ScanPlot2(row + 1, col, scanned, plotDesignator, ref result);
        ScanPlot2(row - 1, col, scanned, plotDesignator, ref result);
    }

    private static readonly (int row, int col)[] SquareTl = [ (0, 0), (0, 1), (1, 0), (1, 1)];
    private static readonly (int row, int col)[] SquareTr = [ (0, 0), (0, -1), (1, 0), (1, -1) ];
    private static readonly (int row, int col)[] SquareBr = [ (0, 0), (-1, 0), (0, -1), (-1, -1) ];
    private static readonly (int row, int col)[] SquareBl = [ (0, 0),(-1, 0), (0, 1), (-1, 1)  ];
    private static readonly (int row, int col)[][] Squares =  [SquareTl, SquareTr, SquareBr, SquareBl];  
    // Count how many corners is represented by designator.
    private int HowManyCornersAt(int row, int col, char plotDesignator)
    {
        var corners = 0;
        foreach (var sq in Squares)
        {
            var surrounding = sq.Select(t => GetDesignator(row + t.row, col + t.col)).ToArray();
            var hasCorner  = surrounding[1..4].All(d => d != plotDesignator);  // Last 3 elements different
            var hasInverseCorner = 
                surrounding[..3].All(d => d == plotDesignator) && 
                surrounding[^1] != plotDesignator; // First 3 elements same and last/diagonal different
            var diagonalTouchCorner =
                surrounding[^1] == plotDesignator &&
                surrounding[1..3].All(d => d != plotDesignator); // Middle 2 elements different (other diagonal) two corners touching
            
            corners += (hasCorner || hasInverseCorner || diagonalTouchCorner) ? 1 : 0;
        }
        return corners;
    }

    private char GetDesignator(int row, int col)
    {
        try
        {
            return _plot[row, col];
        }
        catch (IndexOutOfRangeException e)
        {
            return '.';
        }
    }

    private int IsPerimeter(int row, int col, char plotDesignator)
    {
        try
        {
            return _plot[row, col] != plotDesignator ? 1 : 0;
        }
        catch (IndexOutOfRangeException)
        {
            return 1;
        }
    }


    public int Price
    {
        get
        {
            var r = GetPlots();
            return r.Sum(p => p.Perimeter * p.Area);
        }
    }
    
    public int DiscountedPrice
    {
        get
        {
            var r = GetPlots();
            return r.Sum(p => p.Area * p.Corners);
        }
    }
}