using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CrosswordAudioHandler : IInitializable
{
    private CrosswordAudioHandler(AudioCommandHandler audioHandler)
    {
        m_audioHandler = audioHandler;
    }

    private readonly AudioCommandHandler m_audioHandler;

    public void Initialize()
    {
        CrosswordGameManager.OnSuccess += PlaySuccessAudio;
        CrosswordGameManager.OnWrong += PlayWrondAudio;
    }

    private void PlaySuccessAudio()
    {

        UIAudioCommand success = new("Success");
        m_audioHandler.HandleCommand(success);
    }

    private void PlayWrondAudio()
    {
        UIAudioCommand wrong = new("Error");
        m_audioHandler.HandleCommand(wrong);
    }
}
