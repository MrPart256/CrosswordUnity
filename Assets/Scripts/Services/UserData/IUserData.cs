using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserData
{
    public static Action OnInitialize;
    public UserData GetUserData();
    public void SaveProgress();
}
