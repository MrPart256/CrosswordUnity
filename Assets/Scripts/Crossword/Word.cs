using System.Collections.Generic;

public class Word
{
    public Word(string text, string description, int startX, int startY, Direction dir)
    {
        Text = text;
        Description = description;
        StartX = startX;
        StartY = startY;
        Dir = dir;
        Positions = new List<(int x, int y)>();
        for (int i = 0; i < Text.Length; i++)
        {
            int x = startX + (dir == Direction.Horizontal ? i : 0);
            int y = startY + (dir == Direction.Vertical ? i : 0);
            Positions.Add((x, y));
        }
    }

    public string Text { get; }
    public string Description { get; }
    public int StartX { get; }
    public int StartY { get; }
    public Direction Dir { get; }
    public List<(int x, int y)> Positions { get; }
}