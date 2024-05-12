using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<InputSystem>()
            .AsSingle();
        Container
            .Bind<InputCommandHandler>()
            .AsSingle();
    }
}
