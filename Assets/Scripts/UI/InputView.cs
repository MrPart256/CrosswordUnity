using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class InputView : BaseWindowView
{
    [SerializeField] private TextMeshProUGUI m_inputValue;

    private void OnEnable()
    {
        InputSystem.OnInputChanged += UpdateInput;

        CrosswordGameManager.OnWrong += HighlightWrong;
        CrosswordGameManager.OnSuccess += HighlightSuccess;
    }

    private void UpdateInput(string input) => m_inputValue.text = input;

    private void HighlightSuccess()
    {
        m_inputValue.DOColor(Color.green, .75f)
        .OnComplete(() =>
        {
            m_inputValue.DOColor(Color.clear, .75f)
            .OnComplete(() =>
            {
                m_inputValue.text = string.Empty;
                m_inputValue.color = Color.black;
            });
        });
    }

    private void HighlightWrong()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(
            m_inputValue.DOColor(Color.red, .75f)
        );
        sequence.Join(
            m_inputValue.rectTransform.DOShakeAnchorPos(.75f, Vector2.right * 100, 10, 0)
        );

        sequence.OnComplete(() =>
        {
            m_inputValue.DOColor(Color.clear, .75f).OnComplete(() =>
            {
                m_inputValue.text = string.Empty;
                m_inputValue.color = Color.black;
            });
        });

        sequence.Play();
    }
}
