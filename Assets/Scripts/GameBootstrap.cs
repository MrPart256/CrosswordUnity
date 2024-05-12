using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameBootstrap : MonoBehaviour
{
    [Inject]
    private void Construct(SceneLoadingService loadingService)
    {
        m_loadingService = loadingService;
    }

    [SerializeField] private AssetReference m_scene;

    private SceneLoadingService m_loadingService;

    private void OnEnable()
    {
        IUserData.OnInitialize += LoadScene;
    }

    private void OnDisable()
    {
        IUserData.OnInitialize -= LoadScene;
    }

    private void LoadScene()
    {
        m_loadingService.LoadScene(m_scene, null);
    }
}
