using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyboardManagerHandler
{
    public KeyboardManagerHandler(KeyboardManager keyboardManager, CrosswordLettersSearchHandler searchHandler)
    {
        m_manager = keyboardManager;
        m_searchHandler = searchHandler;
    }

    private List<Word> m_words;

    private readonly KeyboardManager m_manager;
    private readonly CrosswordLettersSearchHandler m_searchHandler;

    public void Initialize(List<Word> words)
    {
        m_words = words;

        m_manager.ActivateButtonsWithSpecificCharacters(m_searchHandler.FindLetters(m_words));

        CrosswordGameManager.OnSuccess += Update;
    }

    private void Update()
    {
        m_manager.ActivateButtonsWithSpecificCharacters(m_searchHandler.FindLetters(m_words));
    }
}
