using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultView : BaseWindowView
{
    [SerializeField] private TextMeshProUGUI m_levelText;

    public void SetLevelIndex(int level)
    {
        m_levelText.text = $"УРОВЕНЬ {level} ПРОЙДЕН!";
    }
}
