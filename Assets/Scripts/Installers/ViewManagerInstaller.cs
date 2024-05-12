using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<ViewManager>()
            .AsSingle();
    }
}
