using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelButtonView : MonoBehaviour
{
    [Inject]
    private void Construct(IUserData userData)
    {
        m_userData = userData;
    }

    private IUserData m_userData;

    [SerializeField] private TextMeshProUGUI m_levelValue;

    private void Start()
    {
        m_levelValue.text = string.Format(m_levelValue.text, m_userData.GetUserData().CompletedLevels + 1);
    }
}
