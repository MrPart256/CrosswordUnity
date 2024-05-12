using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class WordHintView : BaseWindowView
{
    [SerializeField] private TextMeshProUGUI m_hint;

    private void OnEnable()
    {
        CrosswordGameManager.OnWordChange += SetWordHint;
    }

    public void SetWordHint(Word word)
    {
        m_hint.text = word.Description;
    }
}
