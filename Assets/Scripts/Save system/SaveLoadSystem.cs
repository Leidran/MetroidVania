using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem : MonoBehaviour
{
    public string SavePath => $"{Application.persistentDataPath}/metroidVaniaSave.txt";

    [ContextMenu("Save")]
    void Save()
    {
        var state = LoadFile();
        SaveState(state);
        SaveFile(state);
    }

    [ContextMenu("Load")]
    void Load()
    {
        var state = LoadFile();
        LoadState(state);
    }

    void SaveFile(object state)
    {
        using (var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("No save file found");
            return new Dictionary<string, object>();
        }

        using (FileStream stream = File.Open(SavePath, FileMode.Open))
        {
            var formater = new BinaryFormatter();
            return (Dictionary<string, object>)formater.Deserialize(stream);
        }
    }

    void SaveState(Dictionary<string, object> state)
    {
        foreach (var savable in FindObjectsOfType<SavableEntity>())
        {
            state[savable.Id] = savable.SaveState();
        }
    }

    void LoadState(Dictionary<string, object> state)
    {
        foreach (var savable in FindObjectsOfType<SavableEntity>())
        {
            if (state.TryGetValue(savable.Id, out object savedState))
            {
                savable.LoadState(savedState);
            }
        }
    }
}
