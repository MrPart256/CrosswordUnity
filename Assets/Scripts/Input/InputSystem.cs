using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputSystem : IDisposable
{
    public static Action<string> OnInputChanged;
    public static Action<string> OnInputApply;

    private string m_input = string.Empty;

    public void AddToInput(string character)
    {
        m_input += character;
        OnInputChanged?.Invoke(m_input);
    }

    public void RemoveLastFromInput()
    {
        if (m_input.Length == 0)
            return;

        m_input = m_input.Remove(m_input.Length - 1);
        OnInputChanged?.Invoke(m_input);
    }

    public void ApplyInput()
    {
        if (m_input.Length == 0)
            return;

        OnInputApply?.Invoke(m_input);

        m_input = string.Empty;
    }

    public void Dispose()
    {
        OnInputChanged = null;
        OnInputApply = null;
    }
}
