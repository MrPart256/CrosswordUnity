using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CrosswordBootstrap : IInitializable
{
    public CrosswordBootstrap(CrosswordGenerator generator, CrosswordSpawnHandler spawnHandler,
    CrosswordGameManager gameManager, KeyboardManagerHandler keyboardHandler)
    {
        m_generator = generator;
        m_spawnHandler = spawnHandler;
        m_gameManager = gameManager;
        m_keyboardHandler = keyboardHandler;
    }

    private readonly CrosswordGenerator m_generator;
    private readonly CrosswordSpawnHandler m_spawnHandler;
    private readonly CrosswordGameManager m_gameManager;
    private readonly KeyboardManagerHandler m_keyboardHandler;

    public async void Initialize()
    {
        var generated = await m_generator.Generate(10, 15);

        var itmes = m_spawnHandler.GenerateGrid(generated.Item2, 10);

        m_keyboardHandler.Initialize(generated.Item1);

        m_gameManager.Setup(generated.Item1, itmes);
    }
}
