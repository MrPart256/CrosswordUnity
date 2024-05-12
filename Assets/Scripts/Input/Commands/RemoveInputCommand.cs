using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInputCommand : InputCommand
{
    public override void Execute(InputSystem input)
    {
        input.RemoveLastFromInput();
    }
}
