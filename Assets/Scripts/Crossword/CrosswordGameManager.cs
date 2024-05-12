using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CrosswordGameManager : IInitializable, IDisposable
{
    public CrosswordGameManager(IUserData userData)
    {
        m_userData = userData;
    }

    public static Action OnWrong;
    public static Action OnSuccess;
    public static Action<Word> OnWordChange;
    public static Action<int> OnLevelComplete;


    private List<Word> m_words;
    private CrosswordItemView[,] m_cells;

    private readonly IUserData m_userData;

    public void Setup(List<Word> words, CrosswordItemView[,] cells)
    {
        m_words = words;

        m_cells = cells;

        OnWordChange?.Invoke(m_words[0]);
    }

    public void Initialize()
    {
        InputSystem.OnInputApply += CheckForCompletition;
    }

    public void Dispose()
    {
        OnWrong = null;
        OnSuccess = null;
        OnWordChange = null;
        OnLevelComplete = null;
    }

    private void CheckForCompletition(string word)
    {
        if (m_words.Find(x => x.Text.ToLower() == word.ToLower()) == null)
        {
            OnWrong?.Invoke();
            return;
        }

        var complete = m_words.Find(x => x.Text.ToLower() == word.ToLower());

        CompleteWord(complete);

    }

    public void CompleteWord(Word word)
    {
        for (int i = 0; i < word.Positions.Count; i++)
        {
            var position = word.Positions[i];

            m_cells[position.x, position.y].ActivateText(word.Text[i].ToString(), i);
        }

        m_words.Remove(word);

        if (m_words.Count > 0)
        {
            OnSuccess?.Invoke();
            OnWordChange?.Invoke(m_words[0]);
        }

        if (m_words.Count == 0)
        {
            m_userData.GetUserData().CompletedLevels++;

            OnLevelComplete?.Invoke(m_userData.GetUserData().CompletedLevels);
        }
    }
}
