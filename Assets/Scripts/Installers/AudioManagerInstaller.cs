using Zenject;
using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Audio Data", menuName = "Data/Audio Data")]
public class AudioManagerInstaller : ScriptableObjectInstaller
{
    [SerializeField] private List<AudioData> m_audios;
    [SerializeField] private AudioSource m_uiSOurce;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<AudioManager>()
            .AsSingle()
            .WithArguments(m_audios, m_uiSOurce);

        Container
            .Bind<AudioCommandHandler>()
            .AsSingle();
    }
}