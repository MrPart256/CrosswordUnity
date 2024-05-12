using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCommandHandler
{
    public InputCommandHandler(InputSystem inputSystem)
    {
        m_inputSystem = inputSystem;
    }

    private readonly InputSystem m_inputSystem;

    public void ExecuteCommand(InputCommand command)
    {
        command.Execute(m_inputSystem);
    }
}
