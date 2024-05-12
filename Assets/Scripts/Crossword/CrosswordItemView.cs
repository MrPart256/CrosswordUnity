using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CrosswordItemView : MonoBehaviour
{
    public TextMeshProUGUI Text => m_text;
    [SerializeField] private TextMeshProUGUI m_text;

    private bool m_active;

    public void ActivateText(string text, float delay)
    {
        if (m_active)
            return;

        m_active = true;

        m_text.gameObject.SetActive(true);

        m_text.transform.localScale = Vector3.zero;

        m_text.text = text.ToUpper();

        m_text.transform
            .DOScale(Vector3.one, .25f)
            .SetEase(Ease.OutElastic)
            .SetDelay(delay * .25f)
            .OnComplete(() =>
            {
                m_text.transform.localScale = Vector3.one;
            });
    }
}
