using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using System.IO;
using System;

public class EditorUserData : IUserData, IInitializable, IDisposable
{
    private UserData m_userData = new();

    public void Dispose()
    {
        SaveProgress();
    }

    public UserData GetUserData()
    {
        return m_userData;
    }

    public void Initialize()
    {
        if (File.Exists(Application.dataPath + "/Save.json"))
        {
            var text = File.ReadAllText(Application.dataPath + "/Save.json");

            m_userData = JsonUtility.FromJson<UserData>(text);
        }
        IUserData.OnInitialize?.Invoke();
    }

    public void SaveProgress()
    {
        File.WriteAllText(Application.dataPath + "/Save.json", JsonUtility.ToJson(m_userData, true));
    }
}
