using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
[RequireComponent(typeof(Button))]
public abstract class KeyboardButton : MonoBehaviour, IPointerClickHandler
{
    [Inject]
    private void Construct(InputCommandHandler commandHandler)
    {
        m_commandHandler = commandHandler;
    }

    public Button Button => m_button;

    [SerializeField] private Button m_button;

    protected InputCommandHandler m_commandHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!m_button.interactable)
            return;
        Execute();
    }

    public abstract void Execute();
}
