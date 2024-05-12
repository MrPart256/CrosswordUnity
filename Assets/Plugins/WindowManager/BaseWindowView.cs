using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseWindowView : MonoBehaviour, IView
{
    [Inject]
    private void Construct(ViewManager viewManager)
    {
        viewManager.RegisterView(this);
        m_viewManager = viewManager;
    }

    protected ViewManager m_viewManager;

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
}
