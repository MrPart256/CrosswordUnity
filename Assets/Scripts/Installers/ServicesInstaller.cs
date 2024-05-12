using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindUserData();
        BindLoadingService();
    }

    private void BindUserData()
    {
        Container
            .BindInterfacesAndSelfTo<EditorUserData>()
            .AsSingle();
    }


    private void BindLoadingService()
    {
        Container
           .Bind<SceneLoadingService>()
           .AsSingle();
    }
}
