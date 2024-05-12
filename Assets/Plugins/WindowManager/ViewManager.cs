using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewManager
{
    private List<IView> m_views = new List<IView>();

    public void RegisterView<T>(T view) where T : IView
    {
        m_views.Add(view);
    }
    public T ShowView<T>(bool hideOthers = true) where T : IView
    {
        if (hideOthers)
        {
            foreach (var v in m_views)
            {
                if (v.GetType() is not T)
                {
                    v.Hide();
                }
            }
        }
        var view = m_views.Find(x => x.GetType() == typeof(T));
        if (view == null)
            view = m_views.Find(x => x.GetType().IsSubclassOf(typeof(T)));
        view.Show();
        return (T)view;

    }
    public T ShowView<T>(T view, bool hideOthers = true) where T : IView
    {
        if (hideOthers)
        {
            foreach (IView v in m_views)
            {
                v.Hide();
            }
        }

        view.Show();
        return (T)view;
    }
    public bool HasView<T>() where T : IView
    {
        return m_views.Any(x => x.GetType() == typeof(T));
    }
    public T GetView<T>() where T : IView
    {
        return (T)m_views.Find(x => x.GetType() == typeof(T));
    }
    public void HideView<T>() where T : IView
    {
        m_views.Find(x => x.GetType() == typeof(T)).Hide();
    }
    public void RemoveView<T>() where T : IView
    {
        m_views.Remove(m_views.Find(x => x.GetType() == typeof(T)));
    }
    public void RemoveView<T>(T view) where T : IView
    {
        m_views.Remove(view);
    }
}
