using System;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class SavesHelper
{
  private static readonly JsonSerializerSettings settings = new()
  {
    Formatting = Formatting.Indented,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
  };

  public static void SerializeAndSave<T>(T data, string filePath)
  {
    try
    {
      File.WriteAllText(Application.persistentDataPath + "\\" + filePath, JsonConvert.SerializeObject(data, settings));
    }
    catch (Exception e)
    {
      Debug.LogError("There is error in saving data: " + e.Message);
      throw;
    }
  }

  public static T LoadAndDeserialize<T>(string filePath)
  {
    string statePath = Application.persistentDataPath + "\\" + filePath;
    try
    {
      if (File.Exists(statePath))
      {
        string jsonData = File.ReadAllText(statePath);
        return JsonConvert.DeserializeObject<T>(jsonData);
      }

      Debug.LogError("File not found: " + filePath);
    }
    catch (Exception exception)
    {
      Debug.LogError("There is error in loading data: " + exception.Message);
    }

    return default;
  }
}