using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    [SerializeField] private List<CharacterKeybordButton> m_characterButtons;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public void ActivateButtonsWithSpecificCharacters(List<string> characters)
    {
        foreach (var btn in m_characterButtons)
        {
            btn.Button.interactable = false;
        }

        foreach (var character in characters)
        {
            m_characterButtons.Find(x => x.Character.ToLower().Equals(character.ToLower())).Button.interactable = true;
        }
    }
}
