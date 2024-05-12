using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using Zenject;

public class SceneLoadingButton : MonoBehaviour, IPointerClickHandler
{
    [Inject]
    private void Construct(SceneLoadingService loader)
    {
        m_loader = loader;
    }

    [SerializeField] private AssetReference m_scene;

    private SceneLoadingService m_loader;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_loader.LoadScene(m_scene, null);
    }
}
