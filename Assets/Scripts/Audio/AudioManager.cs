using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
public class AudioManager : IFixedTickable
{
    public AudioManager(List<AudioData> audio, AudioSource uiSource)
    {
        m_audios = audio;
        m_uiSource = uiSource;
    }

    private readonly List<AudioData> m_audios;
    private readonly AudioSource m_uiSource;

    private List<AudioSource> m_sources = new();

    public void FixedTick()
    {
        HandleSources();
    }

    private void HandleSources()
    {
        foreach (var source in m_sources.ToList())
        {
            if (source == null)
            {
                m_sources.Remove(source);
                break;
            }
            if (!source.isPlaying)
            {
                Object.Destroy(source.gameObject);
                m_sources.Remove(source);
                break;
            }
        }
    }

    public void PlayUISound(string sound)
    {
        if (!m_audios.Any(x => x.Name == sound))
        {
            Debug.LogWarning($"No audio with name:{sound}");
        }

        var obj = Object.Instantiate(m_uiSource);

        obj.clip = m_audios.Find(x => x.Name == sound).Clip;

        obj.Play();

        m_sources.Add(obj);
    }
}
[System.Serializable]
public class AudioData
{
    public string Name;
    public AudioClip Clip;
}