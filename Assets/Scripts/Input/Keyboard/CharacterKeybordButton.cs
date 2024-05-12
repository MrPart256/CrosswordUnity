using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CharacterKeybordButton : KeyboardButton
{
    public string Character => m_character;

    [SerializeField] private string m_character;
    [SerializeField] private TextMeshProUGUI m_characterText;

    private void Start()
    {
        m_characterText.text = m_character.ToUpper();
    }

    private void OnValidate()
    {
        m_characterText.text = m_character;
    }

    public override void Execute()
    {
        m_commandHandler.ExecuteCommand(new CharacterInputCommand(m_character));
    }
}
