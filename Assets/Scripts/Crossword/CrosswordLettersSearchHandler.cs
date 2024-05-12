using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrosswordLettersSearchHandler
{
    public List<string> FindLetters(List<Word> words)
    {
        HashSet<string> result = new();

        foreach (var word in words)
        {
            foreach (char letter in word.Text)
            {
                result.Add(letter.ToString());
            }
        }

        return result.ToList();
    }
}
