using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveKeyboardButton : KeyboardButton
{
    public override void Execute()
    {
        m_commandHandler.ExecuteCommand(new RemoveInputCommand());
    }
}
