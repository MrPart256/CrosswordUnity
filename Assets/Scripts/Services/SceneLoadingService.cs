using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneLoadingService
{
    private bool m_loading = false;

    public async void LoadScene(AssetReference scene, Action callback)
    {
        if (m_loading)
            return;
        m_loading = true;

        var handler = scene.LoadSceneAsync();

        await handler.Task;

        m_loading = false;

        callback?.Invoke();
    }
}
