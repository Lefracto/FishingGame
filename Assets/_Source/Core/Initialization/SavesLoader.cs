using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SavesLoader : MonoBehaviour
{
  private readonly List<ISavable> _savableData = new();

  [Inject]
  public void Initialize(ISavable[] savableData)
    => _savableData.AddRange(savableData);

  public void SaveGame()
    => _savableData.ForEach(data => data.SaveData());

  public void LoadGame()
    => _savableData.ForEach(data => data.LoadData());
}