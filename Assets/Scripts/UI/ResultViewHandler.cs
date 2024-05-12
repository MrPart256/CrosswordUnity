using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResultViewHandler : IInitializable
{
    public ResultViewHandler(ViewManager viewManager)
    {
        m_viewManager = viewManager;
    }

    private readonly ViewManager m_viewManager;

    public void Initialize()
    {
        CrosswordGameManager.OnLevelComplete += ShowResultView;
    }

    private void ShowResultView(int lvl)
    {
        m_viewManager.ShowView<ResultView>().SetLevelIndex(lvl);
    }
}
