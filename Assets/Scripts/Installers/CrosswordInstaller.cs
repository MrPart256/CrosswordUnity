using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[CreateAssetMenu(fileName = "Crossword Data", menuName = "Data/Crossword Data")]
public class CrosswordInstaller : ScriptableObjectInstaller
{
    [SerializeField] private TextAsset m_wordsData;
    public override void InstallBindings()
    {
        Container
            .Bind<CrosswordSpawnHandler>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container
            .Bind<CrosswordGenerator>()
            .AsSingle()
            .WithArguments(JsonUtility.FromJson<WordsData>(m_wordsData.text));

        Container
            .Bind<KeyboardManager>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<KeyboardManagerHandler>()
            .AsSingle();

        Container
            .Bind<CrosswordLettersSearchHandler>()
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<CrosswordGameManager>()
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<CrosswordBootstrap>()
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<CrosswordAudioHandler>()
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<ResultViewHandler>()
            .AsSingle();
    }
}
