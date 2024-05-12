using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class CrosswordGenerator
{
    public CrosswordGenerator(WordsData data)
    {
        m_words = data.Words;
    }

    private char[,] m_grid;
    private List<WordData> m_words;

    private System.Random m_random;

    private List<WordData> PickWordsOfLength(List<WordData> words, int maxLength)
    {
        return words.FindAll(x => x.Word.Length <= maxLength).ToList();
    }

    private List<WordData> PickRandomWords(List<WordData> words, int wordsAmount)
    {
        HashSet<WordData> result = new();

        while (result.Count < wordsAmount)
        {
            result.Add(words[Random.Range(0, words.Count)]);
        }

        return result.ToList();
    }

    public async Task<(List<Word>, char[,])> Generate(int gridSize = 30, int wordsAmount = 10)
    {
        m_words = PickRandomWords(PickWordsOfLength(m_words, 5), wordsAmount)
        .OrderByDescending(w => w.Word.Length)
        .ToList();

        m_random = new();

        List<Word> result = new();

        m_grid = new char[gridSize, gridSize];

        var firstWord = await PlaceFirstWord(m_words[0]);

        result.Add(firstWord);

        int wordsPlaced = 1;
        for (int i = 1; i < m_words.Count; i++)
        {
            bool placed = false;
            int attempt = 0;
            while (!placed && attempt < 200)
            {
                int x = m_random.Next(gridSize);
                int y = m_random.Next(gridSize);
                Direction dir = GetRandomDirection();
                Word newWord = new Word(m_words[i].Word, m_words[i].Description, x, y, dir);
                if (TryPlaceWord(newWord))
                {
                    placed = true;

                    result.Add(newWord);

                    wordsPlaced++;
                }
                else
                {
                    attempt++;
                }
                await Task.Yield();
            }
        }

        return (result, m_grid);
    }

    private async Task<Word> PlaceFirstWord(WordData word)
    {
        Direction direction = GetRandomDirection();

        int x = m_grid.GetLength(0) / 2;
        int y = m_grid.GetLength(1) / 2;

        if (direction == Direction.Horizontal)
        {
            while (x < 0 || x + word.Word.Length > m_grid.GetLength(0))
            {
                x = m_random.Next(m_grid.GetLength(0));

                await Task.Yield();
            }
        }

        if (direction == Direction.Vertical)
        {
            while (y < 0 || y + word.Word.Length > m_grid.GetLength(1))
            {
                y = m_random.Next(m_grid.GetLength(1));

                await Task.Yield();
            }
        }

        Debug.Log($"PLACED FIRST WORD {x},{y},{word.Word.Length},{direction}, {m_grid.GetLength(0)},{m_grid.GetLength(1)}");

        var firstWord = new Word(word.Word, word.Description, x, y, direction);

        PlaceWord(firstWord);

        return firstWord;
    }

    private bool TryPlaceWord(Word word)
    {
        if ((word.Dir == Direction.Horizontal && word.StartX + word.Text.Length > m_grid.GetLength(0)) ||
            (word.Dir == Direction.Vertical && word.StartY + word.Text.Length > m_grid.GetLength(1)))
            return false;

        foreach (var pos in word.Positions)
        {
            int x = pos.x;
            int y = pos.y;

            if (x < 0 || x >= m_grid.GetLength(0) || y < 0 || y >= m_grid.GetLength(1))
            {
                Debug.LogError($"Position ({x}, {y}) is out of m_grid bounds.");
                Debug.LogError($"Words is:{word.Text}");
                return false;
            }
        }

        foreach (var pos in word.Positions)
        {
            int x = pos.x;
            int y = pos.y;
            if (m_grid[x, y] != '\0' && m_grid[x, y] != word.Text[pos.x - word.StartX + pos.y - word.StartY])
                return false;
        }

        bool intersects = false;
        foreach (var pos in word.Positions)
        {
            int x = pos.x;
            int y = pos.y;
            if (m_grid[x, y] != '\0')
            {
                intersects = true;
                break;
            }
        }

        if (!intersects)
            return false;

        PlaceWord(word);
        return true;
    }

    private void PlaceWord(Word word)
    {
        foreach (var pos in word.Positions)
        {
            int x = pos.x;
            int y = pos.y;

            if (m_grid[x, y] != '\0' && m_grid[x, y] != word.Text[pos.x - word.StartX + pos.y - word.StartY])
            {
                char existingLetter = m_grid[x, y];
                char newLetter = word.Text[pos.x - word.StartX + pos.y - word.StartY];

                char chosenLetter = existingLetter;

                m_grid[x, y] = chosenLetter;
            }
            else
            {
                m_grid[x, y] = word.Text[pos.x - word.StartX + pos.y - word.StartY];
            }
        }
        Debug.Log($"PLACED WORD{word.Text}");
    }

    private Direction GetRandomDirection()
    {
        return m_random.Next(2) == 0 ? Direction.Horizontal : Direction.Vertical;
    }
}
public enum Direction
{
    Horizontal,
    Vertical
}