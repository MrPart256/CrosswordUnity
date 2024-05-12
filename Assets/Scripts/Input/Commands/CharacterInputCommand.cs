using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputCommand : InputCommand
{
    public CharacterInputCommand(string character)
    {
        m_character = character;
    }

    private readonly string m_character;

    public override void Execute(InputSystem input)
    {
       input.AddToInput(m_character);
    }
}
