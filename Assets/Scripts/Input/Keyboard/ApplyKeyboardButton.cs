using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyKeyboardButton : KeyboardButton
{
    public override void Execute()
    {
        m_commandHandler.ExecuteCommand(new ApplyInputCommand());
    }
}
