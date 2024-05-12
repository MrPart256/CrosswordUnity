using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyInputCommand : InputCommand
{
    public override void Execute(InputSystem input)
    {
        input.ApplyInput();
    }
}
