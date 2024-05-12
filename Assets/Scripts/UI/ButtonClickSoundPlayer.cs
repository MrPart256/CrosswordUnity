using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ButtonClickSoundPlayer : MonoBehaviour, IPointerClickHandler
{
    [Inject]
    private void Consturct(AudioCommandHandler audioHandler)
    {
        m_audioHandler = audioHandler;
    }

    private AudioCommandHandler m_audioHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        UIAudioCommand comamnd = new("ButtonClick");

        m_audioHandler.HandleCommand(comamnd);
    }
}
