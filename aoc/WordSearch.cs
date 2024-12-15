using System.Diagnostics;

namespace aoc;

public class WordSearch(char[,] input)
{
    private char [,] _grid = input;
    
    public static WordSearch FromString(string input)
    {
        var reader = new StringReader(input);
        var lines = input.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.None
        );
        var grid = new char[lines.Length, lines[0].Length];
        for (var row = 0; row < lines.Length; row++)
        {
            for (var col = 0; col < lines.Length; col++)
            {
                grid[row, col] = lines[row][col];
            }
        }
        return new WordSearch(grid);
    }

    public int CountWords(string word)
    {
        var count = CountWordsOneWay(word);
        return count;
    }
    
    public Dictionary<(int Row, int Col),int>[] CountWordsInXForm(string word)
    {
        var result = new Dictionary<(int Row, int Col), int>[word.Length];
        for (var i = 0; i < word.Length; i++)
            result[i] = new Dictionary<(int Row, int Col), int>();
    
        for (var row = 0; row < _grid.GetLength(0); row++)
        {
            for (var col = 0; col < _grid.GetLength(1); col++)
            {
                if (word[0] != _grid[row, col])
                    continue;
                
                if(HasWord(word, row, col, 1, 1) == 1) AddTrace(word, row, col, 1, 1, result); // Down/Right
                if(HasWord(word, row, col, -1, -1)  == 1) AddTrace(word, row, col, -1, -1, result); // Up/Left
                if(HasWord(word, row, col, -1, 1) == 1) AddTrace(word, row, col, -1, 1, result); // Up/Right
                if(HasWord(word, row, col, 1, -1) == 1) AddTrace(word, row, col, 1, -1, result); // Down/Left

            }
        }
        return result;
    }

    private void AddTrace(string word, int row, int col, int rowInc, int colInc, Dictionary<(int Row, int Col), int>[] result)
    {
        var wordIndex = 0;
        while (wordIndex < word.Length &&
               word[wordIndex] == _grid[row, col])
        {
            Debug.Assert(_grid[row, col] == word[wordIndex]);
            result[wordIndex].TryAdd((row, col), 0); 
            ++result[wordIndex][(row, col)];
            row += rowInc;
            col += colInc;
            ++wordIndex;
        }
    }

    public int CountWordsOneWay(string word)
    {
        var count = 0;
        for (var row = 0; row < _grid.GetLength(0); row++)
        {
            for (var col = 0; col < _grid.GetLength(1); col++)
            {
                if (word[0] != _grid[row, col])
                    continue;
                
                count += HasWord(word, row, col, 0, 1);     // Right
                count += HasWord(word, row, col, 0, -1);    // Left
                count += HasWord(word, row, col, 1, 0);     // Down
                count += HasWord(word, row, col, -1, 0);    // Up
                count += HasWord(word, row, col, 1, 1);     // Down/Right
                count += HasWord(word, row, col, -1, -1);   // Up/Left
                count += HasWord(word, row, col, -1, 1);    // Up/Right
                count += HasWord(word, row, col, 1, -1);    // Down/Left

            }
        }
        return count;
    }

    private int HasWord(string word, int row, int col, int rowInc, int colInc, int wordIndex = 0)
    {
        Debug.Assert(_grid[row, col] == word[wordIndex]);
        try
        {
            while (wordIndex < word.Length &&
                   word[wordIndex] == _grid[row, col])
            {
                row += rowInc;
                col += colInc;
                ++wordIndex;
            }
            return wordIndex == word.Length ? 1 : 0;
        }
        catch (IndexOutOfRangeException)
        {
            return 0;
        }

    }
}