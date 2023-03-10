using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableEntity : MonoBehaviour
{
    [SerializeField] private string id;
    public string Id => id;

    [ContextMenu("Generate ID")]
    private void GenerateId()
    {
        id = Guid.NewGuid().ToString();
    }

    public object SaveState()
    {
        var state = new Dictionary<string, object>();
        foreach (var saveable in GetComponents<ISavable>())
        {
            state[saveable.GetType().ToString()] = saveable.SaveState();
        }
        return state;
    }

    public void LoadState(object state)
    {
        var stateDictionary = (Dictionary<string, object>)state;

        foreach (var saveable in GetComponents<ISavable>())
        {
            string typeName = saveable.GetType().ToString();
            if (stateDictionary.TryGetValue(typeName, out object savedState))
            {
                saveable.LoadState(savedState);
            }
        }
    }
}
