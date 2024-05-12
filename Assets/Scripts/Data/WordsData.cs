using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordsData
{
   public List<WordData> Words = new();
}
[System.Serializable]
public class WordData
{
   public string Word;
   public string Description;
}